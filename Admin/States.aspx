<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="States.aspx.cs" Inherits="JamaicaFreight.Admin.States" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<asp:Literal ID="msg" runat="server" />

	<div style="margin:5px 0 5px 0">
<table style="width:100%">
<tr>
	<td class="sec">States:</td>
	<td class="ar"><asp:ImageButton ID="btnNew" ImageUrl="~/Images/icons/Addfolder.png" CausesValidation="false" ToolTip="Add New Port" Height="23px" Width="24px" runat="server" /></td>
</tr>
</table>
		<div class="stdgrid">
		<asp:GridView ID="stateGrid" AutoGenerateColumns="False" DataKeyNames="Code" runat="server">	
			<Columns>
				<asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="false" />
				<asp:ButtonField Text="DoubleClick" CommandName="DoubleClick" Visible="false" />
				<asp:BoundField DataField="Code" HeaderText="Code" ItemStyle-Width="10%" HeaderStyle-CssClass="hblk" />
				<asp:BoundField DataField="Name" HeaderText="State" ItemStyle-Width="40%" HeaderStyle-CssClass="hblk" />
				<asp:BoundField DataField="Parent.Code" HeaderText="Country" ItemStyle-Width="30%" HeaderStyle-CssClass="hblk" />
				<asp:TemplateField HeaderText="Enabled" ItemStyle-Width="10%">
					<ItemTemplate>
						<asp:CheckBox ID="cbEnabled" Enabled="false" runat="server" />
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
		</asp:GridView>
		</div>
</div>

<ajax:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" />

</asp:Content>