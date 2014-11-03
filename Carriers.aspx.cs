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
	public partial class Carriers : System.Web.UI.Page
	{
		JFData data = new JFData();
		List<Carrier> carriers;
		StringBuilder sb = new StringBuilder();

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!Page.IsPostBack)
				{
					FillCarriersGrid();
				}
			}
			catch (Exception ex)
			{
				//errorMsg.Show(ex.Message);
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit(EventArgs e)
		{
			btnSaveCarrier.Click += btnSaveCarrier_Click;
			btnDeleteCarrier.Click += btnDeleteCarrier_Click;
			btnCancel.Click += btnCancel_Click;

			sb = new StringBuilder();
			carrierGrid.RowCommand += carrierGrid_RowCommand;
			carrierGrid.RowDataBound += carrierGrid_RowDataBound;

			base.OnInit(e);
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void btnCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/carriers.aspx");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void btnSaveCarrier_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			Button _btnSaveCarrier = (Button)sender;

			int carrierId;
			Int32.TryParse(_btnSaveCarrier.CommandArgument, out carrierId);

			Carrier carrier = GetCarrier();

			if (carrierId > 0)
			{
				carrier.Id = carrierId;
				data.UpdateCarrier(carrier);
			}
			else
				data.SaveCarrier(carrier);

			Response.Redirect("~/carriers.aspx");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void btnDeleteCarrier_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			Button _btnDeleteCarrier = (Button)sender;

			int carrierId;
			Int32.TryParse(_btnDeleteCarrier.CommandArgument, out carrierId);

			Carrier carrier = GetCarrier();
			if (carrierId > 0)
			{
				carrier.Id = carrierId;
				data.DeleteCarrier(carrier);
			}

			Response.Redirect("~/carriers.aspx");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="writer"></param>
		protected override void Render(HtmlTextWriter writer)
		{
			foreach (GridViewRow r in carrierGrid.Rows)
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
		void FillCarriersGrid()
		{
			carriers = data.GetAllCarriers();

			carrierGrid.DataSource = carriers;
			carrierGrid.DataBind();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="carrierId"></param>
		void FillCarrier(int carrierId)
		{
			Carrier carrier = data.GetCarrier(carrierId);

			txtCarrierCode.Text = carrier.Code;
			txtCarrierName.Text = carrier.Name;
			txtCarrierRemarks.Text = carrier.Remarks;
			btnSaveCarrier.CommandArgument = carrier.Id.ToString();
			btnDeleteCarrier.CommandArgument = carrier.Id.ToString();

			carrierWinExt.Show();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Carrier GetCarrier()
		{
			Carrier carrier = new Carrier();
			carrier.Code = txtCarrierCode.Text.Trim();
			carrier.Name = txtCarrierName.Text.Trim();
			carrier.Remarks = txtCarrierRemarks.Text.Trim();

			carrier.CreatedBy = carrier.UpdatedBy = JFData.CurrentUser();
			return carrier;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void carrierGrid_RowCommand(object sender, GridViewCommandEventArgs e)
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
					int carrierId = Convert.ToInt32(carrierGrid.DataKeys[selectedIndex].Value);
					FillCarrier(carrierId);
					break;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void carrierGrid_RowDataBound(object sender, GridViewRowEventArgs e)
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