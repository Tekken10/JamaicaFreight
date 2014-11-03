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
	public partial class EntityTypes : System.Web.UI.Page
	{
		JFData data = new JFData();
		List<EntityType> entityTypes;
		StringBuilder sb = new StringBuilder();

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!Page.IsPostBack)
				{
					FillEntityTypesGrid();
				}
			}
			catch (Exception ex)
			{
				//errorMsg.Show(ex.Message);
			}
		}

		protected override void OnInit(EventArgs e)
		{
			btnSaveEntityType.Click += btnSaveEntityType_Click;
			btnDeleteEntityType.Click += btnDeleteEntityType_Click;
			btnCancel.Click += btnCancel_Click;

			sb = new StringBuilder();
			entityTypeGrid.RowCommand += entityTypeGrid_RowCommand;
			entityTypeGrid.RowDataBound += entityTypeGrid_RowDataBound;

			base.OnInit(e);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void btnCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/entityTypes.aspx");
		}
				
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void btnSaveEntityType_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			Button _btnSaveEntityType = (Button)sender;

			int entityTypeId;
			Int32.TryParse(_btnSaveEntityType.CommandArgument, out entityTypeId);

			EntityType entityType = GetEntityType();

			if (entityTypeId > 0)
			{
				entityType.Id = entityTypeId;
				data.UpdateEntityType(entityType);
			}
			else
				data.SaveEntityType(entityType);

			Response.Redirect("~/entityTypes.aspx");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void btnDeleteEntityType_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			Button _btnDeleteEntityType = (Button)sender;

			int entitytypeId;
			Int32.TryParse(_btnDeleteEntityType.CommandArgument, out entitytypeId);

			EntityType entityType = GetEntityType();
			if (entitytypeId > 0)
			{
				entityType.Id = entitytypeId;
				data.DeleteEntityType(entityType);
			}

			Response.Redirect("~/entityTypes.aspx");
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="writer"></param>
		protected override void Render(HtmlTextWriter writer)
		{
			foreach (GridViewRow r in entityTypeGrid.Rows)
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
		void FillEntityTypeGrid()
		{
			entityTypes = data.GetAllEntityTypes();

			entityTypeGrid.DataSource = entityTypes;
			entityTypeGrid.DataBind();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="entityTypeId"></param>
		void FillEntityType(int entityTypeId)
		{
			EntityType entityType = data.GetEntityType(entityTypeId);

			txtEntityTypeName.Text = entityType.Name;
			btnSaveEntityType.CommandArgument = entityType.Id.ToString();
			btnDeleteEntityType.CommandArgument = entityType.Id.ToString();

			entityTypeWinExt.Show();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		EntityType GetEntityType()
		{
			EntityType entityType = new EntityType();
			entityType.Name = txtEntityTypeName.Text.Trim(); 
			entityType.CreatedBy = entityType.UpdatedBy = JFData.CurrentUser();

			return entityType;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void entityTypeGrid_RowCommand(object sender, GridViewCommandEventArgs e)
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
					int entityTypeId = Convert.ToInt32(entityTypeGrid.DataKeys[selectedIndex].Value);
					FillEntityType(entityTypeId);
					break;
			}
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void entityTypeGrid_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton _singleClickButton = (LinkButton)e.Row.Cells[0].Controls[0];
				LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[1].Controls[0];

				e.Row.Attributes["ondblclick"] = ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
			}
		}

		/// <summary>
		/// 
		/// </summary>
		void FillEntityTypesGrid()
		{
			entityTypes = data.GetAllEntityTypes();

			entityTypeGrid.DataSource = entityTypes;
			entityTypeGrid.DataBind();
		}
	}
}