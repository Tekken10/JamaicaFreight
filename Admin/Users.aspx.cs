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
	public partial class Users : System.Web.UI.Page
	{
		JFData data = new JFData();
		List<User> users;
		
		StringBuilder sb = new StringBuilder();

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!Page.IsPostBack)
					FillUserGrid();
			}
			catch (Exception ex)
			{
				msg.Text = ex.Message;
			}
		}

		protected override void OnInit(EventArgs e)
		{
			btnSaveUser.Click += btnSaveUser_Click;
			btnCancel.Click += btnCancel_Click;

			base.OnInit(e);
		}

		void btnCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/admin/users.aspx");
		}

		void btnSaveUser_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			try
			{
				Button _btnSaveUser = (Button)sender;

				int userId;
				Int32.TryParse(_btnSaveUser.CommandArgument, out userId);

				User user = GetUser();

				if (userId > 0)
				{
					user.Id = userId;
					data.UpdateUser(user);
				}
				else
					data.SaveUser(user);
			}
			catch (Exception ex)
			{
				msg.Text = ex.Message;
			}

			Response.Redirect("~/admin/users.aspx");
		}

		void FillUserGrid()
		{
			users = data.GetAllUsers();

			userGrid.DataSource = users;
			userGrid.DataBind();
		}

		void FillUser(int userId)
		{
			User user = data.GetUser(userId);

			txtFirstName.Text = user.FirstName;
			txtLastName.Text = user.LastName;

			btnSaveUser.CommandArgument = user.Id.ToString();

			userWinExt.Show();
		}

		User GetUser()
		{
			User user = new User();
			
			user.FirstName = txtFirstName.Text.Trim();
			user.LastName = txtLastName.Text.Trim();
			user.Username = txtUsername.Text.Trim();
			user.Password = txtPassword.Text.Trim();

			user.CreatedBy = JFData.CurrentUser();

			return user;
		}

	}
}