using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JF.Data;
using JF.Model;

using System.Data;
using MySql.Data.MySqlClient;

namespace JamaicaFreight
{
	public partial class HBOLConsolidation : System.Web.UI.Page
	{
		JFData data = new JFData();
		
		List<HBOL> hbols;
		StringBuilder sb = new StringBuilder();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
				FillHBOLGrid();
		}

		protected override void OnInit(EventArgs e)
		{
			hbolView.Callback += hbolView_Callback;

			btnTest.OnClientClick = Page.ClientScript.GetCallbackEventReference(hbolView, "'1'", "test", "''");

			base.OnInit(e);
		}

		void hbolView_Callback(object sender, JF.Controls.CallbackEventArgs args)
		{
			string title = args.NameValueCollection["rowkey"].Split(',')[1];

			DateTime today = DateTime.Today;

			DateTime startDate;
			DateTime endDate;

			switch (title)
			{
				case "This Week":
					startDate = today.AddDays(-7);
					endDate = today;
					break;
				case "Last Week":
					startDate = today.AddDays(-7);
					endDate = today;
					break;
				case "Last 2 Weeks":
					startDate = today.AddDays(-7);
					endDate = today;
					break;
				default:
					startDate = today.AddDays(-7);
					endDate = today;
					break;
			}

			hbolView.DataSource = data.GetHBOLsByDateRange(startDate, endDate);
			hbolView.RecordCount = 20;
		}

		void FillHBOLGrid()
		{
			//hbols = data.getallh

			//hbolGrid.DataSource = hbols;
			//hbolGrid.DataBind();
		}

		

	}
}