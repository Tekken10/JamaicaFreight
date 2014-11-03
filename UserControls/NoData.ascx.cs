using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_NoData : System.Web.UI.UserControl
{
    private string _strText;
    public string strText
    {
        get { return _strText; }
        set { _strText = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //lblText.Text = _strText;
    }
}