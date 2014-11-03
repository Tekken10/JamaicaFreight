using System;
using System.Text;
using System.Collections.Generic;
using System.Web.UI;

using JF.Data;
using JF.Model;

namespace JamaicaFreight
{
	public partial class Entities : System.Web.UI.Page, ICallbackEventHandler
	{
		JFData data = new JFData();
		List<EntityType> entitytypes;
		List<Region> countries;
		List<Entity> entities;
		StringBuilder sb = new StringBuilder();

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!Page.IsPostBack)
					FillEntitiesGrid();
			}
			catch (Exception ex)
			{
				msg.Text = ex.Message;
			}
		}
		
		protected override void OnInit(EventArgs e)
		{
			shipperView.Callback += shipperView_Callback;
			consigneeView.Callback += consigneeView_Callback;

			shipperView.QueryString.Add("sc", "' + getCtrlValue('txtSearch') + '");

			btnSearch.Attributes["onclick"] += shipperView.GetCallbackEventReference() + ";return false";
			btnNewShipper.OnClientClick = "editCustomer(-1);return false";

			base.OnInit(e);
		}

		void shipperView_Callback(object sender, JF.Controls.CallbackEventArgs args)
		{
			string criteria = args.NameValueCollection.ContainsKey("sc") ? args.NameValueCollection["sc"] : String.Empty;

			if (!String.IsNullOrEmpty(criteria))
			{
				shipperView.DataSource = data.SearchCustomers(criteria, shipperView.CurrentPage, shipperView.PageSize, shipperView.OrderBy);
				shipperView.RecordCount = data.SearchCustomersCount(criteria);

				return;
			}

			FillEntitiesGrid();
		}

		void consigneeView_Callback(object sender, JF.Controls.CallbackEventArgs args)
		{
			string _parentId = args.NameValueCollection["rowkey"].Split(',')[1];

			int parentId;
			Int32.TryParse(_parentId, out parentId);

			consigneeView.DataSource = data.GetCustomersByParentId(parentId);
			consigneeView.RecordCount = data.GetCustomersByParentIdCount(parentId);
		}

		//void entityGrid_RowCommand(object sender, GridViewCommandEventArgs e)
		//{
		//	GridView _gridView = (GridView)sender;

		//	// Get the selected index and the command name
		//	int selectedIndex = int.Parse(e.CommandArgument.ToString());
		//	string _commandName = e.CommandName;

		//	switch (_commandName)
		//	{
		//		case ("SingleClick"):
		//			_gridView.SelectedIndex = selectedIndex;
		//			break;
		//		case ("DoubleClick"):
		//			//int entityId = Convert.ToInt32(entityGrid.DataKeys[selectedIndex].Value);
		//			//FillEntity(entityId);
		//			break;
		//	}
		//}

		//void entityGrid_RowDataBound(object sender, GridViewRowEventArgs e)
		//{
		//	if (e.Row.RowType == DataControlRowType.DataRow)
		//	{
		//		LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
		//		LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[1].Controls[0];

		//		e.Row.Attributes["ondblclick"] = ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
		//	}
		//}

	
		//protected override void Render(HtmlTextWriter writer)
		//{
		//	foreach (GridViewRow r in entityGrid.Rows)
		//	{
		//		if (r.RowType == DataControlRowType.DataRow)
		//		{
		//			Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl00");
		//			Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl01");
		//		}
		//	}

		//	base.Render(writer);
		//}

		void FillEntitiesGrid()
		{
			const int @shipper = 8;
			entities = data.GetCustomersByTypeId(@shipper, shipperView.CurrentPage, shipperView.PageSize, "name");

			int count = data.GetCustomersByTypeIdCount(@shipper);

			shipperView.DataSource = entities;
			shipperView.RecordCount = count;
		}

		string ICallbackEventHandler.GetCallbackResult()
		{
			return sb.ToString();
		}

		void ICallbackEventHandler.RaiseCallbackEvent(string eventArgument)
		{
			sb = new StringBuilder();

			int parentId;
			Int32.TryParse(eventArgument, out parentId);

			List<Entity> consignees = data.GetCustomersByParentId(parentId);

			sb.Append("document.getElementById(\"consigneeBody\").innerHTML = '");
			sb.Append("<table border=\"0\" style=\"width:100%\"><tr>");

			int i = 1;

			foreach (Entity c in consignees)
			{
				sb.Append("<td class=\"tl\">").Append(c.Name).Append("<br />").Append(c.Address.ToString().Replace("\n", "<br />"));
				sb.Append("<div><a href=\"#\" onclick=\"openHBOL(").Append(parentId).Append(",").Append(c.Id).Append(")\">Select</a></div></td>");

				if (i == 3)
				{
					sb.Append("</tr><tr>");
					i = 0;
					continue;
				}

				i++;
			}

			sb.Append("</tr></table>'");
		}
	}
}