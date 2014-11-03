using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JamaicaFreight
{
    public partial class JFMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

		protected override void OnInit(EventArgs e)
		{
			btnLogout.Click += btnLogout_Click;

			RenderNavStrip();

			base.OnInit(e);
		}

		void btnLogout_Click(object sender, EventArgs e)
		{
			FormsAuthentication.SignOut();
			
			Response.Redirect("~/login.aspx?msg=a");
		}

		void RenderNavStrip()
		{
			StringBuilder sb = new StringBuilder();
			
			string page, path;

			path = Request.ApplicationPath;
			path = (path == "/") ? String.Empty : path;

			sb.Append("<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\" style=\"width:100%\">");
			sb.Append("<tr>");

			int i = 1;
			foreach (SiteMapNode n in SiteMap.RootNode.ChildNodes)
			{
				string cssClass = (n != SiteMap.CurrentNode) ? "off" : "on";
				//string width = (i < SiteMap.RootNode.ChildNodes.Count) ? "107" : "128";

				page = path + n.Url;

				sb.Append("<td>");
				sb.Append("<div class=\"").Append(cssClass).Append("\">");
				sb.Append("<div class=\"outer\">");
				sb.Append("<div class=\"inner\">");
				sb.Append("<a href=\"").Append(n.Url).Append("\">").Append(n.Title).Append("</a>");
				sb.Append("</div></div></div>");
				sb.Append("</td>");

				i++;
			}

			sb.Append("</tr></table>");

			navStrip.Text = sb.ToString();
		}
    }
}