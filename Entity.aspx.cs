using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

using JF.Data;
using JF.Model;

namespace JamaicaFreight
{
	public partial class EntityPage : System.Web.UI.Page
	{
		JFData data = new JFData();
		List<Region> countries;

		int entityId = -1;
		int parentId = -1;
		string action;

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!Page.IsPostBack)
				{
					FillCountries();

					if (parentId > 0)
					{
						li1.Text = "New Cosignee";
						ddlCountries.SelectedValue = "JM";
						ddlStates.Attributes.CssStyle.Add(HtmlTextWriterStyle.Display, "none");
					}
					else
					{
						ddlCountries.SelectedValue = "US";
						ddlStates.SelectedValue = "FL";
					}
					if (action == "saved")
					{
						msg.MessageBoxIcon = JF.Controls.MessageBoxIcon.Info;
						msg.CssClass = "msgOk";
						msg.Show("Record Saved!");
					}

					if (entityId > 0)
						FillEntity();
				}
			}
			catch (Exception ex)
			{
				msg.MessageBoxIcon = JF.Controls.MessageBoxIcon.Warning;
				msg.CssClass = "msgWarning";
				msg.Show(ex.Message);
			}
		}

		protected override void OnInit(EventArgs e)
		{
			btnSaveEntity.Click += btnSaveEntity_Click; ;
			btnDeleteEntity.Click += btnDeleteEntity_Click;
			btnNewConsignee.Click += btnNewConsignee_Click;
			btnNewShipper.Click += btnNewShipper_Click;
			
			if (Request["cid"] != null)
				Int32.TryParse(Request["cid"], out entityId);

			if (Request["pid"] != null)
				Int32.TryParse(Request["pid"], out parentId);

			if (Request["action"] != null)
				action = Request["action"];

			base.OnInit(e);
		}

		void btnNewShipper_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/entity.aspx");
		}

		void btnNewConsignee_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/entity.aspx?pid=" + entityId);
		}

		void btnDeleteEntity_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			Button _btnDeleteEntity = (Button)sender;

			int entityId;
			Int32.TryParse(_btnDeleteEntity.CommandArgument, out entityId);

			if (entityId > 0)
				data.MarkEntityAsDeleted(entityId, JFData.CurrentUser().Id);

			Response.Redirect("~/entity.aspx");
		}

		void btnSaveEntity_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			try
			{
				Entity entity = GetEntity();

				if (entityId > 0)
				{
					entity.Id = entityId;
					data.UpdateEntity(entity);
				}
				else
					entityId = data.SaveEntity(entity);

			}
			catch (Exception ex)
			{
				msg.MessageBoxIcon = JF.Controls.MessageBoxIcon.Warning;
				msg.Show(ex.Message);
			}

			Response.Redirect("~/entity.aspx?cid=" + entityId + "&action=saved");
		}

		void FillEntity()
		{
			Entity entity = data.GetEntity(entityId);

			if (entity == null)
				return;

			txtEntityId.Text = entity.ReferenceId;
			txtEntityName.Text = entity.Name;
			txtEntityAddress1.Text = entity.Address.Line1;
			txtEntityAddress2.Text = entity.Address.Line2;
			ddlCountries.SelectedValue = entity.Address.Country.Code;

			FillStates();

			ddlStates.SelectedValue = entity.Address.State.Code;
			txtEntityCity.Text = entity.Address.City;
			txtEntityZip.Text = entity.Address.Zip;
			txtEntityZip2.Text = entity.Address.Zip2;
			txtEntityPhone.Text = entity.Phone1;
			txtEntityPhone2.Text = entity.Phone2;
			txtEntityFax.Text = entity.Fax;
			txtEntityEmail.Text = entity.Email;
			txtEntityTaxID.Text = entity.TaxID;
			txtEntityNotes.Text = entity.Notes;

			//btnSaveEntity.CommandArgument = entity.Id.ToString();
			btnDeleteEntity.CommandArgument = entity.Id.ToString();

			li1.Text = entity.Name;
			
			// No parent then entity is of type shipper; show consignee button.
			if (parentId < 1)
			{
				btnNewConsignee.Visible = true;
				btnNewConsignee.CommandArgument = entity.Id.ToString();
			}
		}

		Entity GetEntity()
		{
			Entity entity;

			if (entityId > 0)
				entity = data.GetEntity(entityId);
			else
			{
				entity = new Entity();
				entity.Parent = new Entity();
				entity.Parent.Id = parentId;
			}

			const int @shipper = 8;
			const int @consignee = 4;

			int entityType = (parentId > 0 || entity.EntityType.Id == 4) ? @consignee : @shipper;

			string[] nameArray = txtEntityName.Text.Split(' ');
			
			string entityname = (nameArray[0].Length < 3 ? nameArray[0].PadLeft(3, '0') : nameArray[0].Substring(0, 3).ToUpper()) + (nameArray.Length > 1 ?
				(nameArray[1].Length < 3 ? nameArray[1].PadLeft(3, '0') : nameArray[1].Substring(0, 3).ToUpper()) : "000");

			if (entityId < 1)
				entity.ReferenceId = data.GetCustomerReferenceId(entityname).ReferenceId;

			entity.EntityType = new EntityType();
			entity.EntityType.Id = entityType;
			entity.Name = txtEntityName.Text;
			
			entity.Address = new Address();
			entity.Address.Line1 = txtEntityAddress1.Text;
			entity.Address.Line2 = txtEntityAddress2.Text;
			
			entity.Address.Country = new Region();
			entity.Address.Country.Code = ddlCountries.SelectedValue;
			
			entity.Address.State = new Region();
			entity.Address.State.Code = Request[ddlStates.UniqueID];
			
			entity.Address.City = txtEntityCity.Text;
			entity.Address.Zip = txtEntityZip.Text;
			entity.Address.Zip2 = txtEntityZip2.Text;
			entity.Phone1 = txtEntityPhone.Text;
			entity.Phone2 = txtEntityPhone2.Text;
			entity.Fax = txtEntityFax.Text;
			entity.Email = txtEntityEmail.Text;
			entity.TaxID = txtEntityTaxID.Text;
			entity.Notes = txtEntityNotes.Text;
			entity.CreatedBy = entity.UpdatedBy = JFData.CurrentUser();
			
			return entity;
		}

		//void FillEntityTypes()
		//{
		//	entitytypes = data.GetAllEntityTypes();

		//	ddlEntityTypes.Items.Add(new ListItem("- Select a Entity Type -", "-1"));
		//	ddlEntityTypes.SelectedIndex = 1;

		//	foreach (var item in entitytypes)
		//	{
		//		ddlEntityTypes.Items.Add(new ListItem(item.Name, item.Id.ToString()));
		//	}
		//}

		void FillCountries()
		{
			countries = data.GetAllCountries();

			ddlCountries.Items.Add(new ListItem("- Select a Country -", "-1"));

			foreach (var item in countries)
				ddlCountries.Items.Add(new ListItem(item.Name, item.Code));
		}

		void FillStates()
		{
			List<Region> states = data.GetStatesByCountry(ddlCountries.SelectedValue);

			ddlStates.Items.Add(new ListItem("- Select a State -", "-1"));

			foreach (var item in states)
				ddlStates.Items.Add(new ListItem(item.Name, item.Code));
		}
	}
}