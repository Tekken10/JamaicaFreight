using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JF.Model;
using JF.Data;

namespace JamaicaFreight
{
	public partial class HBOLPage : System.Web.UI.Page
	{
		JFData data = new JFData();
		
		int referenceNo;
		int shipperId;
		int consigneeId;

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				//string referrer = Request.UrlReferrer.AbsolutePath;
				//string uri = Request.UrlReferrer.AbsoluteUri;
				//string localPath = Request.UrlReferrer.LocalPath;

				if (!Page.IsPostBack)
				{
					if (referenceNo > 0)
						FillHBOLFromDb();

					if (shipperId > 0)
						FillShipperInfo();

					if (consigneeId > 0)
						FillConsigneeInfo();
				}
			}
			catch (Exception ex)
			{
				msg.Text = ex.Message;
			}
		}

		protected override void OnInit(EventArgs e)
		{
			if (!Page.IsPostBack)
			{ 
				Int32.TryParse(Request["refno"], out referenceNo);

				Int32.TryParse(Request["sid"], out shipperId);
				Int32.TryParse(Request["coid"], out consigneeId);

				hfShipperId.Value = shipperId.ToString();
				hfConsigneeId.Value = consigneeId.ToString();

				txtDate.Text = DateTime.Now.ToShortDateString();
			}

			base.OnInit(e);
		}

		void btnSaveHBOL_Click(object sender, EventArgs e)
		{
			if (!Page.IsValid)
				return;

			Button _btnSaveEntity = (Button)sender;

			string transNo = _btnSaveEntity.CommandArgument;

			HBOL hbol = GetHBOL();

			if (!String.IsNullOrEmpty(transNo))
			{
				hbol.TransactionNumber = transNo;
				data.UpdateHBOL(hbol);
			}
			else
				data.SaveHBOL(hbol);

			Response.Redirect("~/hbol.aspx");
		}

		void FillShipperInfo()
		{
			Entity shipper = data.GetEntity(shipperId);

			if (shipper != null)
			{
				txtShipperName.Text = shipper.Name;
				txtShipperAddress.Text = shipper.Address.ToString();
			}

		}

		void FillConsigneeInfo()
		{
			Entity consignee = data.GetEntity(shipperId);

			if (consignee != null)
			{
				txtConsigneeName.Text = consignee.Name;
				txtConsigneeAddress.Text = consignee.Address.ToString();
			}
		}

		void FillHBOLFromDb()
		{
			HBOL hbol = data.GetHBOL("");
		}

		void FillHBOLFromSession()
		{
			HBOL hbol = (HBOL)Session["HBOL"];

			txtShipperName.Text = hbol.Shipper.Name;
			txtShipperAddress.Text = hbol.Shipper.Address.ToString();

			txtConsigneeName.Text = hbol.Consignee.Name;
			txtConsigneeAddress.Text = hbol.Consignee.Address.ToString();

			txtNotifyParty.Text = hbol.NotifyParty.Name;
			txtNotifyPartyAddress.Text = hbol.NotifyParty.Address.ToString();
		}

		HBOL GetHBOL()
		{
			HBOL hbol = new HBOL();

			hbol.Shipper = data.GetEntity(shipperId);
			hbol.Consignee = data.GetEntity(consigneeId);
			
			//hbol.NotifyParty = data.GetEntity(-1);

			return hbol;
		}

		void btnCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/hbl.aspx");
		}
	}
}