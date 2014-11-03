<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="JamaicaFreight.Admin.Users" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.pph1 { color:#fff; background-color:#000;padding:5px }
	</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Literal ID="msg" runat="server" />

	<div style="margin:5px 0 5px 0">
<table style="width:100%">
<tr>
	<td class="sec">Users:</td>
	<td class="ar"><asp:ImageButton ID="btnNew" ImageUrl="~/Images/icons/Addfolder.png" CausesValidation="false" ToolTip="Add New User" Height="23px" Width="24px" runat="server" /></td>
</tr>
</table>

<div class="stdgrid">
<asp:GridView ID="userGrid" AutoGenerateColumns="False" DataKeyNames="Id" runat="server">	
	<Columns>
		<asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="false" />
		<asp:ButtonField Text="DoubleClick" CommandName="DoubleClick" Visible="false" />
		<asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-Width="20%" HeaderStyle-CssClass="hblk" />
		<asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-Width="30%" HeaderStyle-CssClass="hblk" />
		<asp:BoundField DataField="Username" HeaderText="Username" ItemStyle-Width="20%" HeaderStyle-CssClass="hblk" />
		<asp:BoundField DataField="LastLogin" HeaderText="Last Login" ItemStyle-Width="20%" HeaderStyle-CssClass="hblk" />
		<asp:BoundField DataField="Active" HeaderText="Active" ItemStyle-Width="10%" HeaderStyle-CssClass="hblk" />
	</Columns>
</asp:GridView>
			</div>
</div>
<ajax:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" />

<asp:Panel ID="userWin" ClientIDMode="Static" CssClass="winlet" style="display:none" runat="server">
	
    <div id="popupHeader" class="pph1">Add/Edit User</div>
	<div style="padding:10px">
	<table border="0">
	<tr>
		<td class="ar b nw">First Name:</td>
		<td>
			<asp:TextBox ID="txtFirstName" Required="true" Width="200px" MaxLength="10" ClientIDMode="Static" runat="server" />
		</td>
	</tr>
	<tr>
		<td class="ar b nw">Last Name:</td>
		<td>
			<asp:TextBox ID="txtLastName" Required="true" Width="200px" MaxLength="200" ClientIDMode="Static" runat="server" />
		</td>
	</tr>
	<tr>
		<td class="ar b">Username:</td>
		<td>
			<asp:TextBox ID="txtUsername" Required="true" Width="200px" MaxLength="200" ClientIDMode="Static" runat="server" />
		</td>
	</tr>
	<tr>
		<td class="ar b">Password:</td>
			<td>
				<asp:TextBox ID="txtPassword" TextMode="Password" Required="true" Width="200px" MaxLength="200" ClientIDMode="Static" runat="server" />
			</td>
	</tr>
		<tr>
		<td class="ar b">Re-enter Password:</td>
			<td>
				<asp:TextBox ID="txtPassword2" TextMode="Password" Required="true" Width="200px" MaxLength="200" ClientIDMode="Static" runat="server" />
			</td>
	</tr>
	<tr>
		<td>&nbsp;&nbsp;</td>
		<td><asp:Button ID="btnSaveUser" Text="Save" runat="server" /> &nbsp;
			<asp:Button ID="btnCancel" Text="Cancel" formnovalidate="formnovalidate" CausesValidation="false" runat="server" />
		</td>
	</tr>
	</table>
	</div>
</asp:Panel>
	<ajax:ModalPopupExtender ID="userWinExt" TargetControlID="btnNew" PopupControlID="userWin" popupdraghandlecontrolid="popupHeader" drag="true" runat="server" />

</asp:Content>
