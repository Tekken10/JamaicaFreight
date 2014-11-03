using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_Legend : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

	protected override void OnInit(EventArgs e)
	{
		JF.Model.User u = JF.Data.JFData.CurrentUser();

		if (u == null)
			Response.Redirect("~/login.aspx");

		string agencyName = "";

		this.Visible = (agencyName == "la care");

		base.OnInit(e);
	}
}