<%@ Page Title="" Language="C#" MasterPageFile="~/JF.Master" AutoEventWireup="true" CodeBehind="Ports.aspx.cs" Inherits="JamaicaFreight.Ports" EnableEventValidation="false"  %>
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
		.pph1 { color:#fff; background-color:#000;padding:5px }
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<asp:Literal ID="msg" runat="server" />

	<div style="margin:5px 0 5px 0">
<table style="width:100%">
<tr>
	<td class="sec">Ports:</td>
	<td class="ar"><asp:ImageButton ID="btnNew" ImageUrl="~/Images/icons/Addfolder.png" CausesValidation="false" ToolTip="Add New Port" Height="23px" Width="24px" runat="server" /></td>
</tr>
</table>
		<div class="stdgrid">
		<asp:GridView ID="portGrid" AutoGenerateColumns="False" DataKeyNames="Id" runat="server">	
			<Columns>
				<asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="false" />
				<asp:ButtonField Text="DoubleClick" CommandName="DoubleClick" Visible="false" />
				<asp:BoundField DataField="Code" HeaderText="Port Code" ItemStyle-Width="20%" HeaderStyle-CssClass="hblk" />
				<asp:BoundField DataField="Name" HeaderText="Port Name" ItemStyle-Width="40%" HeaderStyle-CssClass="hblk" />
				<asp:BoundField DataField="Country.Code" HeaderText="Country Code" ItemStyle-Width="20%" HeaderStyle-CssClass="hblk" />
				<asp:BoundField DataField="State.Code" HeaderText="State Code" ItemStyle-Width="10%" HeaderStyle-CssClass="hblk" />
				<asp:BoundField DataField="TypeName" HeaderText="Port Type" ItemStyle-Width="10%" HeaderStyle-CssClass="hblk" />
			</Columns>
		</asp:GridView>
		</div>
</div>
<ajax:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" />

<asp:Panel ID="portWin" ClientIDMode="Static" CssClass="winlet" style="display:normal" runat="server">
    <div id="popupHeader" class="pph1">Add/Edit/Delete Port</div>
	<div style="padding:10px">
	<table border="0">
	<tr>
		<td class="ar b nw">Port Code:</td>
		<td><asp:TextBox ID="txtPortCode" Width="50px" MaxLength="10" ClientIDMode="Static" runat="server" />
			<asp:CompareValidator ID="cv1" ControlToValidate="txtPortCode" ErrorMessage="Please enter a Port Code" Operator="NotEqual" ValueToCompare="" Display="None" runat="server" />
			<ajax:ValidatorCalloutExtender ID="vcx1" TargetControlID="cv1" runat="server" />
		</td>
	</tr>
	<tr>
		<td class="ar b nw">Port Name:</td>
		<td><asp:TextBox ID="txtPortName" Width="200px" MaxLength="200" ClientIDMode="Static" runat="server" />
			<asp:CompareValidator ID="cv2" ControlToValidate="txtPortCode" ErrorMessage="Please enter a Port Name" Operator="NotEqual" ValueToCompare="" Display="None" runat="server" />
			<ajax:ValidatorCalloutExtender ID="vcx2" TargetControlID="cv2" runat="server" />
		</td>
	</tr>
	<tr>
		<td class="ar b" style="width:60px">Country:</td>
		<td>
			<asp:DropDownList ID="ddlCountries" Width="200px" autocomplete="off" ClientIDMode="Static" runat="server" />
			<asp:CompareValidator ID="cv3" ControlToValidate="ddlCountries" ErrorMessage="Please select a Country." Operator="NotEqual" ValueToCompare="-1" Display="None" runat="server" />
			<ajax:ValidatorCalloutExtender ID="vcx3" TargetControlID="cv3" runat="server" />
		</td>
	</tr>
	<tr>
		<td class="ar b" style="width:60px">State:</td>
			<td>
				<asp:DropDownList ID="ddlStates" Width="200px" ClientIDMode="Static" runat="server" />
			</td>
	</tr>
	<tr>
		<td class="ar b" style="width:60px">Type:</td>
			<td>
				<asp:RadioButtonList ID="rbPortType" ClientIDMode="Static" Font-Bold="True" Font-Size="Smaller" RepeatDirection="Horizontal" runat="server" >
					<asp:ListItem Text="Origin"	Value="1" Selected="True"/>
					<asp:ListItem Text="Destination" Value="2" />
					<asp:ListItem Text="Orig./Dest." Value="3" />
				</asp:RadioButtonList>
			</td>
	</tr>
	<tr>
		<td>&nbsp;&nbsp;</td>
		<td>
			<asp:Button ID="btnSavePort" Text="Save" runat="server" /> &nbsp;
			<asp:Button ID="btnDeletePort" Text="Delete" runat="server" OnClientClick="javascript:if(!confirm('Are you certain you want to delete this record?')){return false;}" /> &nbsp;
			<asp:Button ID="btnCancel" Text="Cancel" CausesValidation="false" runat="server" />
		</td>
	</tr>
	</table>
	</div>
</asp:Panel>
	<ajax:ModalPopupExtender ID="portWinExt" TargetControlID="btnNew" PopupControlID="PortWin" popupdraghandlecontrolid="popupHeader" drag="true" runat="server" />

</asp:Content>
