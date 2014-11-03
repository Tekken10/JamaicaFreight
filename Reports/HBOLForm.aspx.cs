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
	public partial class HBOLForm : System.Web.UI.Page
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

			if (documents.Count > 0)
			{
				Merge(mstream, documents);

				Response.ClearContent();
				Response.AddHeader("Content-Disposition", "attachment; filename=" + "BillOfLading.pdf");

				BinaryWriter bw = new BinaryWriter(Response.OutputStream);

				bw.Write(mstream.ToArray());
				bw.Close();

				Response.End();
			}

		}

		byte[] GetLabels()
		{
			string path = Server.MapPath("~/Reports/Forms/BillOfLading.pdf");

			PdfReader pdfReader = null;

			MemoryStream ms = new MemoryStream();

			pdfReader = new PdfReader(path);

			PdfStamper pdfStamper = new PdfStamper(pdfReader, ms);
			AcroFields pdfFormFields = pdfStamper.AcroFields;

			JFData data = new JFData();
			HBOL hbol = data.ReportBillOfLading("1");		//transactionnumber

			StringBuilder sb = new StringBuilder();
			sb.Append(hbol.Shipper.Name).Append("\n").Append(hbol.Shipper.Address.Line1).Append("\n");
			sb.Append(hbol.Shipper.Address.City + ", " + hbol.Shipper.Address.State.Code + " " + hbol.Shipper.Address.Zip).Append("\n");
			pdfFormFields.SetField("Shipper", sb.ToString());

			sb = new StringBuilder();
			sb.Append(hbol.Consignee.Name).Append("\n").Append(hbol.Consignee.Address.Line1).Append("\n");
			sb.Append(hbol.Consignee.Address.City + ", " + hbol.Consignee.Address.State.Code + " " + hbol.Consignee.Address.Zip).Append("\n");
			pdfFormFields.SetField("Consignee", sb.ToString());

			sb = new StringBuilder();
			sb.Append(hbol.NotifyParty.Name).Append("\n").Append(hbol.NotifyParty.Address.Line1).Append("\n");
			sb.Append(hbol.NotifyParty.Address.City + ", " + hbol.NotifyParty.Address.State.Code + " " + hbol.NotifyParty.Address.Zip).Append("\n");
			pdfFormFields.SetField("NotifyParty", sb.ToString());

			pdfFormFields.SetField("BookingNumber", hbol.BookingNumber);
			pdfFormFields.SetField("HBLNumber", hbol.HBLNumber);

			sb = new StringBuilder();
			sb.Append("REF: ").Append(hbol.Carrier.Code).Append( "CONS: ").Append(hbol.ConsolidationNumber).Append("\n");
			sb.Append("INTL. FREIGHT CONS 1160 N.W. 21 TERRACE").Append("\n");
			sb.Append("MIAMI, FL 33127");
			pdfFormFields.SetField("ExportReferences", sb.ToString());

			pdfFormFields.SetField("ForwardingAgent", hbol.ForwardingAgentCode);
			pdfFormFields.SetField("PortOrigin", "MIAMI, FL");
			pdfFormFields.SetField("PreCarriageBy", hbol.PreCarrierBy);
			pdfFormFields.SetField("PreCarriagePlace", hbol.PlacePreCarrier);
			pdfFormFields.SetField("ExportingCarrier", hbol.ExportingCarrier.Name);
			pdfFormFields.SetField("PortOfLoading", hbol.PortLoadingExport.Name);
			pdfFormFields.SetField("LoadingPier", hbol.LoadingPierTerminal.Name);
			pdfFormFields.SetField("ForeignPort", hbol.ForeignPort.Name);
			pdfFormFields.SetField("PlaceOfDelivery", hbol.PlaceDeliveyOnCarrier.Name);
			pdfFormFields.SetField("ContainerizedYes", (hbol.Containerized == true ? "1" : "0"));
			pdfFormFields.SetField("ContainerizedNo",  (hbol.Containerized == true ? "1" : "0"));

			pdfFormFields.SetField("MarksNumbers", "AS ADDRESSED");
			pdfFormFields.SetField("TotalPackages", hbol.Packages[0].TotalPackages.ToString());
			pdfFormFields.SetField("Description", hbol.Packages[0].Description);
			pdfFormFields.SetField("Weight", hbol.Packages[0].Weight.ToString() + hbol.Packages[0].WeightUnit);
			pdfFormFields.SetField("Measure", hbol.Packages[0].Dimensions.ToString() + hbol.Packages[0].DimUnit);

			pdfFormFields.SetField("TotalPrepaid", hbol.TotalPrepaidCharges.ToString());
			pdfFormFields.SetField("TotalCollect", hbol.TotalCollectCharges.ToString());
			pdfFormFields.SetField("DateAt", "MIAMI, FL");
			pdfFormFields.SetField("UserName", hbol.CreatedBy.FirstName + " " + hbol.CreatedBy.LastName);
			pdfFormFields.SetField("MonthCreatedOn", hbol.CreatedOn.Month.ToString());
			pdfFormFields.SetField("DayCreatedOn", hbol.CreatedOn.Day.ToString());
			pdfFormFields.SetField("YearCreatedOn", hbol.CreatedOn.Year.ToString());

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