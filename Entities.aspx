<%@ Page Title="" Language="C#" MasterPageFile="~/JF.Master" AutoEventWireup="true" CodeBehind="Entities.aspx.cs" Inherits="JamaicaFreight.Entities" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript" src="scripts/ILSGrid.js"></script>
	<script type="text/javascript" src="scripts/tools.js"></script>
<script type="text/javascript">
<!--
var table1;
function confirmDelete(sender, eventArgs)
{
	var continueDelete = confirm("Are you sure you want to delete these row(s)?");

	if (!continueDelete)
		eventArgs.set_cancel(true);
}
function showResults(args, context)
{
	window.status = "updated";
}
function editCustomer(cid)
{
	url = "entity.aspx?cid=" + cid;

	openWindow(url, "Entity", 600, 450, false, true);
}
function openHBOL(shipperId, consigneeId)
{
	url = "hbol.aspx?sid=" + shipperId + "&coid=" + consigneeId;

	openWindow(url, "HBOL", 880, 760, false, true);
}
//-->
</script>
	<style type="text/css">
		.entitywin
		{
			background-color:#fff;
			Width:600px;
			height:450px;
			border:2px solid #000
		}
		.pph1 { color:#fff; background-color:#000;padding:5px }
		.consignee { border:1px solid #000;width:500px }
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Literal ID="msg" runat="server" />

	<div style="margin:5px 0 5px 0">

<table border="0" style="width:100%">
<tr>
	<td class="sec">Shippers:</td>
	<td class="ac"><b>Search</b> <asp:TextBox ID="txtSearch" ClientIDMode="Static" TextMode="Search" Width="300px" runat="server" /> <asp:Button ID="btnSearch" Text="Search" runat="server" /> </td>
	<td class="ar"><asp:ImageButton ID="btnNewShipper" ImageUrl="~/Images/icons/Addfolder.png" CausesValidation="false" ToolTip="Add New Shipper" runat="server" /></td>
	<td class="ar"><asp:ImageButton ID="btnPrint" ImageUrl="~/Images/icons/HRA.png" CausesValidation="false" ToolTip="Print Shippers/Consignees" runat="server" /></td>
</tr>
</table>
	<div class="stdgrid">

		<jf:ShippersView ID="shipperView" PageSize="15" ChildGridID="consigneeView" CssClass="stdgrid" runat="server" />
		<jf:ConsigneeView ID="consigneeView" PageSize="15" CssClass="stdgrid" Visible="false" runat="server" />

	</div>
</div>

<ajax:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" />

<asp:Panel ID="consigneeWin" ClientIDMode="Static" CssClass="consignee" runat="server">
	<div id="consigneeHeader" class="pph1">Select Consignee</div>
	<div id="consigneeBody" style="padding:10px">
	</div>
</asp:Panel>

<asp:Button ID="btnNoGo" Visible="false" runat="server" />
<ajax:modalpopupextender ID="consigneeWinExt" TargetControlID="btnNoGo" PopupControlID="consigneeWin" popupdraghandlecontrolid="consigneeHeader" drag="true" runat="server" />

</asp:Content>
