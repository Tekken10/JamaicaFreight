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
	public partial class Units : System.Web.UI.Page
	{
		JFData data = new JFData();
		List<JF.Model.Unit> units;

		StringBuilder sb = new StringBuilder();

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!Page.IsPostBack)
					FillUnitGrid();
			}
			catch (Exception ex)
			{
				msg.Text = ex.Message;
			}
		}

		protected override void OnInit(EventArgs e)
		{
			btnSaveUnit.Click += btnSaveUnit_Click;
			btnCancel.Click += btnCancel_Click;

			base.OnInit(e);
		}

		void btnCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/admin/units.aspx");
		}

		void btnSaveUnit_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			try
			{
				Button _btnSaveUser = (Button)sender;

				string unitCode = _btnSaveUser.CommandArgument;

				JF.Model.Unit unit = GetUnit();

				if (!String.IsNullOrEmpty(unitCode))
				{
					unit.Code = unitCode;
					data.UpdateUnit(unit);
				}
				else
					data.SaveUnit(unit);
			}
			catch (Exception ex)
			{
				msg.Text = ex.Message;
			}

			Response.Redirect("~/admin/users.aspx");
		}

		void FillUnitGrid()
		{
			units = data.GetAllUnits();

			unitGrid.DataSource = units;
			unitGrid.DataBind();
		}

		void FillUnit(string unitCode)
		{
			JF.Model.Unit unit = data.GetUnit(unitCode);

			txtCode.Text = unit.Code;
			txtDescription.Text = unit.Description;

			btnSaveUnit.CommandArgument = unit.Code.ToString();

			userWinExt.Show();
		}

		JF.Model.Unit GetUnit()
		{
			JF.Model.Unit unit = new JF.Model.Unit();

			unit.Code = txtCode.Text.Trim();
			unit.Description = txtDescription.Text.Trim();
			
			//unit.CreatedBy = JFData.CurrentUser();

			return unit;
		}
	}
}