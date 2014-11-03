using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using JF.Data;
using JF.Model;

using System.Data;
using MySql.Data.MySqlClient;

namespace JamaicaFreight
{
	public partial class BillingCodes : System.Web.UI.Page
	{
		JFData data = new JFData();
		List<BillingCode> billingCodes;
		StringBuilder sb = new StringBuilder();

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!Page.IsPostBack)
				{
					FillBillingCodesGrid();
				}
			}
			catch (Exception ex)
			{
				//errorMsg.Show(ex.Message);
			}
		}

		protected override void OnInit(EventArgs e)
		{
			
			btnSaveBillingCode.Click += btnSaveBillingCode_Click;
			btnDeleteBillingCode.Click += btnDeleteBillingCode_Click;
			btnCancel.Click += btnCancel_Click;

			sb = new StringBuilder();
			billingCodeGrid.RowCommand += billingCodeGrid_RowCommand;
			billingCodeGrid.RowDataBound += billingCodeGrid_RowDataBound;

			base.OnInit(e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void btnCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/billingCodes.aspx");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void btnDeleteBillingCode_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			Button _btnDeleteBillingCode = (Button)sender;

			int billingCodeId;
			Int32.TryParse(_btnDeleteBillingCode.CommandArgument, out billingCodeId);

			BillingCode billingCode = GetBillingCode();
			if (billingCodeId > 0)
			{
				billingCode.Id = billingCodeId;
				data.DeleteBillingCode(billingCode);
			}

			Response.Redirect("~/billingCodes.aspx");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="writer"></param>
		protected override void Render(HtmlTextWriter writer)
		{
			foreach (GridViewRow r in billingCodeGrid.Rows)
			{
				if (r.RowType == DataControlRowType.DataRow)
				{
					Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl00");
					Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl01");
				}
			}

			base.Render(writer);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void btnSaveBillingCode_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			Button _btnSaveBillingCode = (Button)sender;

			int billingCodeId;
			Int32.TryParse(_btnSaveBillingCode.CommandArgument, out billingCodeId);

			BillingCode billingCode = GetBillingCode();

			if (billingCodeId > 0)
			{
				billingCode.Id = billingCodeId;
				data.UpdateBillingCode(billingCode);
			}
			else
				data.SaveBillingCode(billingCode);

			Response.Redirect("~/billingCodes.aspx");
		}

		/// <summary>
		/// 
		/// </summary>
		void FillBillingCodesGrid()
		{
			billingCodes = data.GetAllBillingCodes();

			billingCodeGrid.DataSource = billingCodes;
			billingCodeGrid.DataBind();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="billingCodeId"></param>
		void FillBillingCode(int billingCodeId)
		{
			BillingCode billingCode = data.GetBillingCode(billingCodeId);

			txtBillingCodedescription.Text = billingCode.Description;
			btnSaveBillingCode.CommandArgument = billingCode.Id.ToString();
			btnDeleteBillingCode.CommandArgument = billingCode.Id.ToString();

			entityTypeWinExt.Show();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		BillingCode GetBillingCode()
		{
			BillingCode billingCode = new BillingCode();
			billingCode.Description = txtBillingCodedescription.Text.Trim();
			billingCode.CreatedBy = billingCode.UpdatedBy = JFData.CurrentUser();

			return billingCode;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void billingCodeGrid_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			GridView _gridView = (GridView)sender;

			// Get the selected index and the command name
			int selectedIndex = int.Parse(e.CommandArgument.ToString());
			string _commandName = e.CommandName;

			switch (_commandName)
			{
				case ("SingleClick"):
					_gridView.SelectedIndex = selectedIndex;
					break;
				case ("DoubleClick"):
					int billingCodeId = Convert.ToInt32(billingCodeGrid.DataKeys[selectedIndex].Value);
					FillBillingCode(billingCodeId);
					break;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void billingCodeGrid_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
				LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[1].Controls[0];

				e.Row.Attributes["ondblclick"] = ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
			}
		}
	}
}