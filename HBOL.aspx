<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HBOL.aspx.cs" Inherits="JamaicaFreight.HBOLPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Jamaica Freight - House Bill of Lading</title>
	<style type="text/css">
		html, body { margin:0; padding:0 }
		.pph1 { color:#fff; background-color:#002663;padding:5px }
		legend { font-variant:small-caps;font-size:14px }
		.input1 { border:none; width:100% }
	</style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="popupHeader" class="pph1">
		House Bill of Lading (New)
    </div>

	<asp:Literal ID="msg" runat="server" />
	
	<div style="padding:10px">
<table border="0">
<tr>
	<td>

<asp:Panel ID="consol" runat="server" >

<fieldset>
		<legend>Consolidation</legend>

<table>
<tr>
		<td class="ar b nw">HB/L#:</td>
		<td><asp:TextBox ID="txtHblNo" ClientIDMode="Static" Required="true" Width="150px" MaxLength="200" runat="server" /></td>
		<td class="ar b" style="width:60px">Consolidation#:</td>
		<td><asp:TextBox ID="txtConsolidationNo" ClientIDMode="Static" Width="150px" Enabled="false" runat="server" /></td>
		<td class="tr b" style="width:60px">Carrier:</td>
		<td class="tr"><asp:DropDownList ID="ddlCarriers" ClientIDMode="Static" Width="95%" Enabled="false" runat="server" /></td>
		<td class="ar b">Date:</td>
		<td><asp:TextBox ID="txtDate" TextMode="Date" Width="70px" runat="server" /></td>
</tr>
<tr>
		
		<td class="tr b">Destination</td>
		<td class="tr"><asp:DropDownList ID="ddlPortDest" Width="95%" Enabled="false" runat="server" /></td>
		<td  class="ar b">Booking#:</td>
		<td class="tr"><asp:TextBox ID="txtBookingNo" ClientIDMode="Static" Width="150px" Enabled="false" runat="server" /></td>
		<td class="ar b nw">Transaction#:</td>
		<td><asp:TextBox ID="txtTransNo" ClientIDMode="Static" Required="true" Width="100px" MaxLength="10" Enabled="false" runat="server" /></td>
		<td><%--<b>Weight:</b><br />
			<asp:RadioButtonList ID="rblWeight" runat="server">
				<asp:ListItem Value="-1">Kilos</asp:ListItem>
				<asp:ListItem Value="-1">Lbs</asp:ListItem>
			</asp:RadioButtonList>--%>
		</td>
		<td><%--<b>Volume:</b><br />
			<asp:RadioButtonList ID="rblVolume" runat="server">
				<asp:ListItem Value="-1">M3</asp:ListItem>
				<asp:ListItem Value="-1">Cft</asp:ListItem>
			</asp:RadioButtonList>--%>
			<%--<b>Charges Prepaid:</b> <asp:CheckBox ID="cbChargesPrepaid" runat="server" /><br />
			<b>Containerized:</b> <asp:CheckBox ID="cbContainerized" runat="server" />--%>
		</td>
</tr>
</table>

</fieldset>

</asp:Panel>
		</td>
	</tr>
	<tr>
		<td style="padding-top:20px">
			
			<fieldset>
				<legend class="ac b">House Bill of Lading</legend>

			<table border="0" style="width:100%">
				<tr>
					<td style="width:50%">
						<div style="margin:0 0 10px 0">
							<b>Shipper/Exporter</b>
							<div style="margin:3px auto 3px auto">
								<asp:TextBox ID="txtShipperName" Width="280px" runat="server" />
							</div>
							<asp:TextBox ID="txtShipperAddress" TextMode="MultiLine" Rows="4" Columns="40" runat="server" />
						</div>

						<div style="margin:0 0 10px 0">
							<b>Consignee</b>
							<div style="margin:3px auto 3px auto">
								<asp:TextBox ID="txtConsigneeName" Width="280px" runat="server" /><br />
							</div>
							<asp:TextBox ID="txtConsigneeAddress" TextMode="MultiLine" Rows="4" Columns="40" runat="server" />
						</div>

						<div style="margin:0 0 10px 0">
							<b>Notify Party</b>
							<div style="margin:3px auto 3px auto">
								<asp:TextBox ID="txtNotifyParty" Width="280px" runat="server" /><br />
							</div>
							<asp:TextBox ID="txtNotifyPartyAddress" TextMode="MultiLine" Rows="4" Columns="40" runat="server" />
						</div>
					</td>
					<td class="tl" style="width:50%">

						<b>Export Reference</b><br />
						<asp:TextBox ID="TextBox3" TextMode="MultiLine" Rows="5" Columns="40" runat="server" />

					</td>
				</tr>
			</table>

			</fieldset>

		</td>
	</tr>
	<tr>
		<td>

			<fieldset>
				<legend>Particulars furnished by shipper</legend>

			<table border="1" style="border-collapse:collapse; border:1px solid #000; width:100%">
				<tr>
					<th style="width:20%">Marks</th>
					<th style="width:20%">Packages</th>
					<th style="width:30%">Description of Packages and Goods</th>
					<th style="width:10%">Weight</th>
					<th style="width:10%">KG/LB</th>
					<th style="width:10%">Measure</th>
				</tr>
				<tr>
					<td><asp:TextBox ID="row1_marks" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row1_packages" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row1_description" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row1_weight" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row1_lb" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row1_measure" CssClass="input1" runat="server" /></td>
				</tr>
				<tr>
					<td><asp:TextBox ID="row2_marks" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row2_packages" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row2_description" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row2_weight" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row2_lb" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row2_measure" CssClass="input1" runat="server" /></td>
				</tr>
				<tr>
					<td><asp:TextBox ID="row3_marks" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row3_packages" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row3_description" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row3_weight" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row3_lb" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="row3_measure" CssClass="input1" runat="server" /></td>
				</tr>
				<tr>
					<td colspan="6"><b>Totals:</b>
						<asp:Button ID="btnRemoveLine" Text="Remove Line" runat="server" />
						<asp:Button ID="btnInsertline" Text="Insert Line" runat="server" />
						<asp:Button ID="btnInsertMemo" Text="Insert Memo" runat="server" />
					</td>
				</tr>
			</table>

				</fieldset>
		</td>
	</tr>
	<tr>
		<td>
				<fieldset>
				<legend>Bill of Lading Charges</legend>

					<table border="1" style="border-collapse:collapse; border:1px solid #000; width:100%">
				<tr>
					<th style="width:20%">Code</th>
					<th style="width:20%">Description</th>
					<th style="width:30%">Rate</th>
					<th style="width:10%">Per</th>
					<th style="width:10%">Prepaid</th>
					<th style="width:10%">Collect</th>
				</tr>
				<tr>
					<td><asp:TextBox ID="TextBox1" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox2" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox4" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox5" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox6" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox7" CssClass="input1" runat="server" /></td>
				</tr>
				<tr>
					<td><asp:TextBox ID="TextBox8" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox9" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox10" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox11" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox12" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox13" CssClass="input1" runat="server" /></td>
				</tr>
				<tr>
					<td><asp:TextBox ID="TextBox14" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox15" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox16" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox17" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox18" CssClass="input1" runat="server" /></td>
					<td><asp:TextBox ID="TextBox19" CssClass="input1" runat="server" /></td>
				</tr>
				<tr>
					<td colspan="6">
							handling <asp:TextBox ID="txtHandling" Width="60px" Text="0.00" runat="server" />
							<asp:Button ID="Button1" Text="Remove Line" runat="server" />
							Total charges: <asp:TextBox ID="txtChargesPrepaid" Width="60px" Text="0.00" runat="server" />
							<asp:TextBox ID="txtChargesCollect" Width="60px" Text="0.00" runat="server" /><br />
							Freight: <asp:TextBox ID="txtFreight" Width="60px" Text="0.00" runat="server" />
					</td>
				</tr>
			</table>

				</fieldset>

		</td>
	</tr>
	<tr>
		<td colspan="10">
			<asp:Button ID="btnSavePort" Text="Save" runat="server" /> &nbsp;
			<asp:Button ID="btnDeletePort" Text="Delete" OnClientClick="javascript:if(!confirm('Are you certain you want to delete this record?')){return false;}" runat="server" /> &nbsp;
			<asp:Button ID="btnCancel" Text="Cancel" CausesValidation="false" runat="server" />
		</td>
	</tr>
	</table>
	</div>

		<asp:HiddenField ID="hfShipperId" runat="server" />
		<asp:HiddenField ID="hfConsigneeId" runat="server" />

    </form>

</body>
</html>