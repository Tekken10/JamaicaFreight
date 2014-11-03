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

namespace JamaicaFreight.Admin
{
	public partial class States : System.Web.UI.Page
	{
		JFData data = new JFData();
		List<Region> states;
		StringBuilder sb = new StringBuilder();
		
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
				FillStateGrid();
		}

		void FillStateGrid()
		{
			states = data.GetAllStates();

			stateGrid.DataSource = states;
			stateGrid.DataBind();
		}
	}
}