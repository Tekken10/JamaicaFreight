<%@ Page Title="" Language="C#" MasterPageFile="~/JF.Master" AutoEventWireup="true" CodeBehind="Carriers.aspx.cs" Inherits="JamaicaFreight.Carriers" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
<!--
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
function runEval(args, context)
{
	eval(args);
}
//-->
</script>
	<style type="text/css">
		.carrierwin { 
			background-color:#fff;
			Width:400px;
			height:200px;
			border:2px solid #000
		}
		.pph1 { color:#fff; background-color:#000;padding:5px }
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="margin:5px 0 5px 0">
<table style="width:100%">
<tr>
	<td class="sec">Carriers:</td>
	<td class="ar"><asp:ImageButton ID="btnNew" ImageUrl="~/Images/icons/Addfolder.png" CausesValidation="false" ToolTip="Add New Carrier" Height="23px" Width="24px" runat="server" /></td>
</tr>
</table>
	<div class="stdgrid">
		<asp:GridView ID="carrierGrid" AutoGenerateColumns="False" DataKeyNames="Id" runat="server">	
		<Columns>
			<asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="false" />
			<asp:ButtonField Text="DoubleClick" CommandName="DoubleClick" Visible="false" />
			<asp:BoundField DataField="Code" HeaderText="Carrier Code" ItemStyle-Width="20%" HeaderStyle-CssClass="hblk" />
			<asp:BoundField DataField="Name" HeaderText="Carrier Name" ItemStyle-Width="40%" HeaderStyle-CssClass="hblk" />
			<asp:BoundField DataField="Remarks" HeaderText="Carrier Remarks" ItemStyle-Width="40%" HeaderStyle-CssClass="hblk" />
		</Columns>
		</asp:GridView>
	</div>
</div>
<ajax:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" />

<asp:Panel ID="carrierWin" ClientIDMode="Static" CssClass="carrierwin" style="display:none" runat="server">
    <div id="popupHeader" class="pph1">Add/Edit/Delete Carrier</div>
	<div style="padding:10px">
	<table border="0">
	<tr>
		<td class="ar b nw">Carrier Code:</td>
		<td><asp:TextBox ID="txtCarrierCode" Width="50px" MaxLength="10" ClientIDMode="Static" runat="server" />
			<asp:CompareValidator ID="cv1" ControlToValidate="txtCarrierCode" ErrorMessage="Please enter a Carrier Code" Operator="NotEqual" ValueToCompare="" Display="None" runat="server" />
			<ajax:ValidatorCalloutExtender ID="vcx1" TargetControlID="cv1" runat="server" />
		</td>
	</tr>
	<tr>
		<td class="ar b nw">Carrier Name:</td>
		<td><asp:TextBox ID="txtCarrierName" Width="200px" MaxLength="200" ClientIDMode="Static" runat="server" />
			<asp:CompareValidator ID="cv2" ControlToValidate="txtCarrierCode" ErrorMessage="Please enter a Carrier Name" Operator="NotEqual" ValueToCompare="" Display="None" runat="server" />
			<ajax:ValidatorCalloutExtender ID="vcx2" TargetControlID="cv2" runat="server" />
		</td>
	</tr>
	<tr>
		<td class="ar b nw">Carrier Remarks:</td>
		<td><asp:TextBox ID="txtCarrierRemarks" Width="200px" TextMode="MultiLine" MaxLength="300" ClientIDMode="Static" runat="server" />

		</td>
		</tr>
	<tr>
		<td>&nbsp;&nbsp;</td>
		<td><asp:Button ID="btnSaveCarrier" Text="Save" runat="server" /> &nbsp;
			<asp:Button ID="btnDeleteCarrier" Text="Delete" runat="server" OnClientClick="javascript:if(!confirm('Are you certain you want to delete this record?')){return false;}" /> &nbsp;
			<asp:Button ID="btnCancel" Text="Cancel" CausesValidation="false" runat="server" />
		</td>
	</tr>
	</table>
	</div>
</asp:Panel>
<ajax:ModalPopupExtender ID="carrierWinExt" TargetControlID="btnNew" PopupControlID="carrierWin" popupdraghandlecontrolid="popupHeader" drag="true" runat="server" />
</asp:Content>