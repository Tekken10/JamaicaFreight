using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JF.Data;
using JF.Model;

namespace JamaicaFreight.Admin
{
	public partial class Countries : System.Web.UI.Page
	{
		JFData data = new JFData();
		List<JF.Model.Region> countries;

		StringBuilder sb = new StringBuilder();
		
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!Page.IsPostBack)
					FillCountryGrid();
			}
			catch (Exception ex)
			{
				msg.Text = ex.Message;
			}
		}

		void FillCountryGrid()
		{
			countries = data.GetAllCountries();

			countryGrid.DataSource = countries;
			countryGrid.DataBind();
		}

	}
}