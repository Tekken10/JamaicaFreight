using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JamaicaFreight.Reports
{
	public partial class HBLsReport : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		
			TextBox1.Text = "1";
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			////List<ReportParameter> list = new List<ReportParameter>();
			////ReportParameter param = new ReportParameter("?", TextBox1.Text);
			////list.Add(param);
			////ReportViewer1.LocalReport.SetParameters(list);


			ReportViewer1.Visible = true;
			//ReportViewer1.LocalReport.ReportPath = @"Reports\BillOfLading.rdlc";

			//JF_DataSet.hbols_packagesDataTable pepe = new JF_DataSet.hbols_packagesDataTable();
			
			//ReportDataSource source = new ReportDataSource("DataSet1", pepe[0]);
			//ReportViewer1.LocalReport.DataSources.Clear();
			//ReportViewer1.LocalReport.DataSources.Add(source);
			//ReportViewer1.LocalReport.Refresh();



		}
	}
}