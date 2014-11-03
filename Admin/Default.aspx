<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JamaicaFreight.Admin.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="sec">
		Administration
	</div>

	<div>
		<div><asp:HyperLink ID="hl1" NavigateUrl="~/ports.aspx" runat="server">Ports</asp:HyperLink></div>
		<div><asp:HyperLink ID="hl2" NavigateUrl="~/admin/countries.aspx" runat="server">Countries</asp:HyperLink></div>
		<div><asp:HyperLink ID="hl3" NavigateUrl="~/admin/states.aspx" runat="server">States</asp:HyperLink></div>
		<div><asp:HyperLink ID="hl4" NavigateUrl="~/admin/units.aspx" runat="server">Units</asp:HyperLink></div>
		<div><asp:HyperLink ID="hl5" NavigateUrl="~/admin/users.aspx" runat="server">Users</asp:HyperLink></div>
		<div><asp:HyperLink ID="hl6" NavigateUrl="~/billingcodes.aspx" runat="server">Billing Codes</asp:HyperLink></div>
		<div><asp:HyperLink ID="hl7" NavigateUrl="~/carriers.aspx" runat="server">Carriers</asp:HyperLink></div>
		<div><asp:HyperLink ID="hl8" NavigateUrl="~/entitytypes.aspx" runat="server">Customer Types</asp:HyperLink></div>

	</div>

</asp:Content>
