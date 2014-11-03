using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using JF.Data;
using JF.Model;

namespace JamaicaFreight
{
    public partial class Login : System.Web.UI.Page
    {
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				string msgCode;
				Dictionary<string, string> msgs = new Dictionary<string, string>();
				msgs.Add("a", "You have successfully logged out.");
				msgs.Add("b", "You have been logged out due to unactivity.");

				if (Request.QueryString["msg"] != null)
				{ 
					msgCode = Request.QueryString["msg"];
					
					headerPanel.Controls.Clear();
					headerPanel.Controls.Add(new LiteralControl(msgs[msgCode]));
				}
			}
		}

		protected override void OnInit(EventArgs e)
		{
			btnLogin.Click += btnLogin_Click;
			
			base.OnInit(e);
		}

		void btnLogin_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			string username = txtUsername.Text.Trim();
			string password = txtPassword.Text.Trim();

			try
			{
				JFData data = new JFData();
				User user = data.GetUser(username);

				if (user == null)
				{
					msg.Text = "<span class=\"erricon\"></span> Your User ID or Password is incorrect. Please try again.";
					return;
				}

				if (data.AuthenticateUser(username, password))
				{
					Session["CurrentUser"] = user;

					string role = (user.TypeId == 1) ? "Administrator" : "user";

					AuthenticationTicket(username, password, role);
				}
				else
				{
					msg.Text = "<span class=\"erricon\"></span> Your User ID or Password is incorrect. Please try again.";
					return;
				}
			}
			catch (Exception ex)
			{
				msg.Text = ex.Message;
			}

			Response.Redirect("~/default.aspx");
		}

		void AuthenticationTicket(string username, string password, string role)
		{
			FormsAuthentication.Initialize();

			FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(30), false, role, FormsAuthentication.FormsCookiePath);
			HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

			Response.Cookies.Add(cookie);
		}

    }

}