<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report1.aspx.cs" Inherits="JamaicaFreight.Reports.Report1" EnableViewState="true" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer List</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1000px" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
			<LocalReport ReportPath="Reports\CustomersList.rdlc">
				<DataSources>
					<rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Customers" />
				</DataSources>
			</LocalReport>
		</rsweb:ReportViewer>
    	<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="JamaicaFreight.JF_DataSetTableAdapters.customersTableAdapter"></asp:ObjectDataSource>
    </div>
	<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </form>
</body>
</html>
