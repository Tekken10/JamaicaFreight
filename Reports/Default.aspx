<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JamaicaFreight.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<div class="sec">
		Reports
	</div>
	<div>
		<div><asp:HyperLink ID="hl1" NavigateUrl="~/Reports/CustomersReport.aspx" runat="server">Customer List</asp:HyperLink></div>
		<div><asp:HyperLink ID="hl2" NavigateUrl="~/Reports/HBOLForm.aspx" runat="server">HBL</asp:HyperLink></div>
		<%--<div><asp:HyperLink ID="hl2" NavigateUrl="~/Reports/HBLsReport.aspx" runat="server">HBL</asp:HyperLink></div>--%>
		<div><asp:HyperLink ID="hl3" NavigateUrl="~/Reports/MasterHBLsReport.aspx" runat="server">Master HBL</asp:HyperLink></div>
		<div><asp:HyperLink ID="hl4" NavigateUrl="~/Reports/Labels.aspx" runat="server">Label</asp:HyperLink></div>
		<div><asp:HyperLink ID="hl5" NavigateUrl="~/Reports/ManifestReport.aspx" runat="server">Manifest</asp:HyperLink></div>
	</div>
</asp:Content>
