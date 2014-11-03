<%@ Page Title="" Language="C#" MasterPageFile="~/JF.Master" AutoEventWireup="true" CodeBehind="BillingCodes.aspx.cs" Inherits="JamaicaFreight.BillingCodes" %>
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
		.billingcodewin { 
			background-color:#fff;
			Width:400px;
			height:100px;
			border:2px solid #000
		}
		.pph1 { color:#fff; background-color:#000;padding:5px }
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div style="margin:5px 0 5px 0">
<table style="width:100%">
<tr>
	<td class="sec">Billing Codes:</td>
	<td class="ar"><asp:ImageButton ID="btnNew" ImageUrl="~/Images/icons/Addfolder.png" CausesValidation="false" ToolTip="Add New Billing Code" Height="23px" Width="24px" runat="server" /></td>
</tr>
</table>
	<div class="stdgrid">
		<asp:GridView ID="billingCodeGrid" AutoGenerateColumns="False" DataKeyNames="Id" runat="server">	
		<Columns>
			<asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="false" />
			<asp:ButtonField Text="DoubleClick" CommandName="DoubleClick" Visible="false" />
			<asp:BoundField DataField="Description" HeaderText="Billing Code Name" ItemStyle-Width="40%" HeaderStyle-CssClass="hblk" />
		</Columns>
		</asp:GridView>
	</div>
</div>
<ajax:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" />

<asp:Panel ID="billingCodeWin" ClientIDMode="Static" CssClass="billingcodewin" style="display:none" runat="server">
    <div id="popupHeader" class="pph1">Add/Edit/Delete Billing Code</div>
	<div style="padding:10px">
	<table border="0">
	<tr>
		<td class="ar b nw">Description:</td>
		<td><asp:TextBox ID="txtBillingCodedescription" Width="200px" MaxLength="200" ClientIDMode="Static" runat="server" />
			<asp:CompareValidator ID="cv2" ControlToValidate="txtBillingCodedescription" ErrorMessage="Please enter a Billing Code description" Operator="NotEqual" ValueToCompare="" Display="None" runat="server" />
			<ajax:ValidatorCalloutExtender ID="vcx2" TargetControlID="cv2" runat="server" />
		</td>
	</tr>
	<tr>
		<td>&nbsp;&nbsp;</td>
		<td><asp:Button ID="btnSaveBillingCode" Text="Save" runat="server" /> &nbsp;
			<asp:Button ID="btnDeleteBillingCode" Text="Delete" runat="server" OnClientClick="javascript:if(!confirm('Are you certain you want to delete this record?')){return false;}" /> &nbsp;
			<asp:Button ID="btnCancel" Text="Cancel" CausesValidation="false" runat="server" />
		</td>
	</tr>
	</table>
	</div>
</asp:Panel>
<ajax:ModalPopupExtender ID="entityTypeWinExt" TargetControlID="btnNew" PopupControlID="billingCodeWin" popupdraghandlecontrolid="popupHeader" drag="true" runat="server" />
</asp:Content>
