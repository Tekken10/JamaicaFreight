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
	public partial class Ports : System.Web.UI.Page, ICallbackEventHandler
	{
		JFData data = new JFData();
		List<Port> ports;
		List<Region> countries;
		StringBuilder sb = new StringBuilder();

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!Page.IsPostBack)
				{
					FillPortsGrid();
					FillCountries();
				}
			}
			catch (Exception ex)
			{
				msg.Text = ex.Message;
			}
		}

		protected override void OnInit(EventArgs e)
		{
			btnSavePort.Click += btnSavePort_Click;
			btnDeletePort.Click += btnDeletePort_Click;		
			btnCancel.Click += btnCancel_Click;

			sb = new StringBuilder();
			sb.Append("ddlChild = document.getElementById(\"").Append(ddlStates.ClientID).Append("\");");
			sb.Append("ddlChild.length = 0;");
			sb.Append("ddlChild.add(new Option('Loading...','-1'));");

			ddlCountries.Attributes["onchange"] += ";" + sb.ToString() + Page.ClientScript.GetCallbackEventReference(this, "this.value", "runEval", "");

			portGrid.RowCommand += portGrid_RowCommand;
			portGrid.RowDataBound += portGrid_RowDataBound;

			base.OnInit(e);
		}

		protected override void Render(HtmlTextWriter writer)
		{
			foreach (GridViewRow r in portGrid.Rows)
			{
				if (r.RowType == DataControlRowType.DataRow)
				{
					Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl00");
					Page.ClientScript.RegisterForEventValidation(r.UniqueID + "$ctl01");
				}
			}

			base.Render(writer);
		}

		void btnCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/ports.aspx");
		}

		void btnSavePort_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			try
			{
				Button _btnSavePort = (Button)sender;

				int portId;
				Int32.TryParse(_btnSavePort.CommandArgument, out portId);

				Port port = GetPort();

				if (portId > 0)
				{
					port.Id = portId;
					data.UpdatePort(port);
				}
				else
					data.SavePort(port);

			}
			catch (Exception ex)
			{
				msg.Text = ex.Message;
			}

			Response.Redirect("~/ports.aspx");
		}

		void btnDeletePort_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			Button _btnDeletePort = (Button)sender;

			int portId;
			Int32.TryParse(_btnDeletePort.CommandArgument, out portId);

			Port port = GetPort();
			if (portId > 0)
			{
				port.Id = portId;
				data.DeletePort(port);
			}
			
			Response.Redirect("~/ports.aspx");
		}

		void FillPortsGrid()
		{
			ports = data.GetAllPorts();

			portGrid.DataSource = ports;
			portGrid.DataBind();
		}

		void FillPort(int portId)
		{
			Port port = data.GetPort(portId);

			txtPortCode.Text = port.Code;
			txtPortName.Text = port.Name;
			ddlCountries.SelectedValue = port.Country.Code;
			FillStates();
			ddlStates.SelectedValue = port.State.Code;
			rbPortType.SelectedValue = port.Type.ToString();
			btnSavePort.CommandArgument = port.Id.ToString();
			btnDeletePort.CommandArgument = port.Id.ToString();
			portWinExt.Show();
		}

		Port GetPort()
		{
			Port port = new Port();
			port.Code = txtPortCode.Text.Trim();
			port.Name = txtPortName.Text.Trim();
			
			port.Country = new Region();
			port.Country.Code = ddlCountries.SelectedValue;
			
			port.State = new Region();
			port.State.Code = Request[ddlStates.UniqueID];
			port.Type = int.Parse(rbPortType.SelectedValue);

			port.CreatedBy = port.UpdatedBy = JFData.CurrentUser();
			
			return port;
		}

		void FillCountries()
		{
			countries = data.GetAllCountries();
			
			ddlCountries.Items.Add(new ListItem("- Select a Country -", "-1"));
			ddlCountries.SelectedIndex = 1;
		
			foreach (var item in countries)
			{
				ddlCountries.Items.Add(new ListItem(item.Name, item.Code));
			}
		}

		void FillStates()
		{
			List<Region> states = data.GetStatesByCountry(ddlCountries.SelectedValue);

			ddlStates.Items.Add(new ListItem("- Select a State -", "-1"));

			foreach (var item in states)
				ddlStates.Items.Add(new ListItem(item.Name, item.Code));
		}

		protected void portGrid_RowCommand(object sender, GridViewCommandEventArgs e)
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
					int portId = Convert.ToInt32(portGrid.DataKeys[selectedIndex].Value);
					FillPort(portId);
					break;
			}
		}

		void portGrid_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
				LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[1].Controls[0];
				e.Row.Attributes["ondblclick"] = ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
			}

		}

		string ICallbackEventHandler.GetCallbackResult()
		{
			return sb.ToString();
		}

		void ICallbackEventHandler.RaiseCallbackEvent(string eventArgument)
		{
			List<Region> states = data.GetStatesByCountry(eventArgument);

			sb.Append("ddlChild = document.getElementById(\"").Append(ddlStates.ClientID).Append("\");\n");
			sb.Append("ddlChild.length = 0;\n");
			sb.Append("ddlChild.add(new Option('-- Select a State --','-1'));\n");

			foreach (Region s in states)
			{
				sb.Append("ddlChild.add(new Option('").Append(s.Name).Append("','").Append(s.Code).Append("'));");
				Page.ClientScript.RegisterForEventValidation(ddlStates.UniqueID, s.Code);
			}
		}
	}
}