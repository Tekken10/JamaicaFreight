using iTextSharp.text.pdf;
using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JF.Data;
using JF.Model;

namespace JamaicaFreight.Reports
{
	public partial class Labels : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			GetReport();
		}

		void GetReport()
		{
			List<PdfReader> documents = new List<PdfReader>();
			MemoryStream mstream = new MemoryStream();

			byte[] labels = GetLabels();

			documents.Add(new PdfReader(labels));

			//if (documents.Count > 0)
			//	Merge(mstream, documents);

			//return mstream.ToArray();


			if (documents.Count > 0)
			{
				Merge(mstream, documents);

				Response.ClearContent();
				Response.AddHeader("Content-Disposition", "attachment; filename=" + "HBLLabel.pdf");

				BinaryWriter bw = new BinaryWriter(Response.OutputStream);

				bw.Write(mstream.ToArray());
				bw.Close();

				Response.End();
			}

		}

		byte[] GetLabels()
		{

			string path = Server.MapPath("~/Reports/Forms/HBLLabel.pdf");

			PdfReader pdfReader = null;

			MemoryStream ms = new MemoryStream();

			pdfReader = new PdfReader(path);

			PdfStamper pdfStamper = new PdfStamper(pdfReader, ms);
			AcroFields pdfFormFields = pdfStamper.AcroFields;

			JFData data =new JFData();
			HBOL hbol = data.ReportLabel("1");		//transactionnumber

			StringBuilder sb = new StringBuilder();
			sb.Append(hbol.Shipper.Name).Append("\n").Append(hbol.Shipper.Address.Line1).Append("\n");
			sb.Append(hbol.Shipper.Address.City + ", " + hbol.Shipper.Address.State.Code + " " + hbol.Shipper.Address.Zip).Append("\n");

			pdfFormFields.SetField("Shipper", sb.ToString());
			pdfFormFields.SetField("HBLNumber", hbol.HBLNumber);
			pdfFormFields.SetField("CreatedOn",String.Format("{0:g}", hbol.CreatedOn));

			pdfFormFields.SetField("Weight", (hbol.Packages[0].WeightUnit.Code == "Lbl" ? hbol.Packages[0].Weight.ToString() : hbol.Packages[0].WeightConverted.ToString()) + "Lbl. / " + 
											 (hbol.Packages[0].WeightUnit.Code == "Lbl" ? hbol.Packages[0].WeightConverted.ToString() : hbol.Packages[0].Weight.ToString()) + "Kgs.");
			pdfFormFields.SetField("Total", 1 + " of " + hbol.Packages[0].TotalPackages.ToString());
						
			pdfStamper.FormFlattening = true;
			pdfStamper.Writer.CloseStream = false;

			pdfStamper.Close();

			return ms.ToArray();
		}

		public void Merge(Stream outputStream, List<PdfReader> documents)
		{
			iTextSharp.text.Document newDocument = null;

			try
			{
				newDocument = new iTextSharp.text.Document(documents[0].GetPageSizeWithRotation(1));

				PdfWriter pdfWriter = PdfWriter.GetInstance(newDocument, outputStream);
				newDocument.Open();

				PdfContentByte pdfContentByte = pdfWriter.DirectContent;

				foreach (PdfReader pdfReader in documents)
				{
					for (int page = 1; page <= pdfReader.NumberOfPages; page++)
					{
						newDocument.NewPage();
						PdfImportedPage importedPage = pdfWriter.GetImportedPage(pdfReader, page);
						pdfContentByte.AddTemplate(importedPage, 0, 0);
					}
				}
			}
			finally
			{
				outputStream.Flush();

				if (newDocument != null)
					newDocument.Close();

				outputStream.Close();
			}
		}

	}
}