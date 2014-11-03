<%@ Page Title="" Language="C#" MasterPageFile="~/JF.Master" AutoEventWireup="true" CodeBehind="EntityTypes.aspx.cs" Inherits="JamaicaFreight.EntityTypes" %>
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
		.entitytypewin { 
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
	<td class="sec">Entity Types:</td>
	<td class="ar"><asp:ImageButton ID="btnNew" ImageUrl="~/Images/icons/Addfolder.png" CausesValidation="false" ToolTip="Add New Entity Type" Height="23px" Width="24px" runat="server" /></td>
</tr>
</table>
	<div class="stdgrid">
		<asp:GridView ID="entityTypeGrid" AutoGenerateColumns="False" DataKeyNames="Id" runat="server">	
		<Columns>
			<asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="false" />
			<asp:ButtonField Text="DoubleClick" CommandName="DoubleClick" Visible="false" />
			<asp:BoundField DataField="Name" HeaderText="Entity Type Name" ItemStyle-Width="40%" HeaderStyle-CssClass="hblk" />
		</Columns>
		</asp:GridView>
	</div>
</div>
<ajax:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" />

<asp:Panel ID="entityTypeWin" ClientIDMode="Static" CssClass="entitytypewin" style="display:none" runat="server">
    <div id="popupHeader" class="pph1">Add/Edit/Delete Entity Type</div>
	<div style="padding:10px">
	<table border="0">
	<tr>
		<td class="ar b nw">Type Name:</td>
		<td><asp:TextBox ID="txtEntityTypeName" Width="200px" MaxLength="200" ClientIDMode="Static" runat="server" />
			<asp:CompareValidator ID="cv2" ControlToValidate="txtEntityTypeName" ErrorMessage="Please enter a Entity Type Name" Operator="NotEqual" ValueToCompare="" Display="None" runat="server" />
			<ajax:ValidatorCalloutExtender ID="vcx2" TargetControlID="cv2" runat="server" />
		</td>
	</tr>
	<tr>
		<td>&nbsp;&nbsp;</td>
		<td><asp:Button ID="btnSaveEntityType" Text="Save" runat="server" /> &nbsp;
			<asp:Button ID="btnDeleteEntityType" Text="Delete" runat="server" OnClientClick="javascript:if(!confirm('Are you certain you want to delete this record?')){return false;}" /> &nbsp;
			<asp:Button ID="btnCancel" Text="Cancel" CausesValidation="false" runat="server" />
		</td>
	</tr>
	</table>
	</div>
</asp:Panel>
<ajax:ModalPopupExtender ID="entityTypeWinExt" TargetControlID="btnNew" PopupControlID="entityTypeWin" popupdraghandlecontrolid="popupHeader" drag="true" runat="server" />
</asp:Content>
