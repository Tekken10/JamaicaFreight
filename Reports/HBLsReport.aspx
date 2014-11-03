<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HBLsReport.aspx.cs" Inherits="JamaicaFreight.Reports.HBLsReport" EnableViewState="true" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<br />
		<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
		<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
		
    	<br />
		<rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
			<LocalReport ReportPath="Reports\Report1.rdlc">
			</LocalReport>
		</rsweb:ReportViewer>
		
    	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>
		
    </div>
		<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </form>
</body>
</html>
