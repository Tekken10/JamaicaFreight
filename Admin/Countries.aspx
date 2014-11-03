<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="JamaicaFreight.Admin.Countries" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	
<asp:Literal ID="msg" runat="server" />

	<div style="margin:5px 0 5px 0">
<table style="width:100%">
<tr>
	<td class="sec">Countries:</td>
	<td class="ar"><asp:ImageButton ID="btnNew" ImageUrl="~/Images/icons/Addfolder.png" CausesValidation="false" ToolTip="Add New Country" Height="23px" Width="24px" runat="server" /></td>
</tr>
</table>

<div class="stdgrid">
<asp:GridView ID="countryGrid" AutoGenerateColumns="False" DataKeyNames="Code" runat="server">	
	<Columns>
		<asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="false" />
		<asp:ButtonField Text="DoubleClick" CommandName="DoubleClick" Visible="false" />
		<asp:BoundField DataField="Code" HeaderText="Country Code" ItemStyle-Width="20%" HeaderStyle-CssClass="hblk" />
		<asp:BoundField DataField="Name" HeaderText="Country Name" ItemStyle-Width="40%" HeaderStyle-CssClass="hblk" />
		<asp:TemplateField HeaderText="Enabled" ItemStyle-Width="10%">
			<ItemTemplate>
					<asp:CheckBox ID="cbEnabled" Enabled="false" runat="server" />
			</ItemTemplate>
		</asp:TemplateField>
	</Columns>
</asp:GridView>
			</div>


		</div>

</asp:Content>
