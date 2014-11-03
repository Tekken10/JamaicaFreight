<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entity.aspx.cs" Inherits="JamaicaFreight.EntityPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Jamaica Freight</title>
	<link href="site.css" type="text/css" rel="Stylesheet" />
	<style type="text/css">
		html, body { margin:0; padding:0 }
		.pph1 { color:#fff; background-color:#002663;padding:5px }
		.msgOk { color:green; border-top:1px dashed green;border-bottom:1px dashed green;text-align:left }
		.msgWarning { color:red; border-top:1px dashed red;border-bottom:1px dashed red;text-align:left }
	</style>
</head>
<body>

<form id="form1" runat="server">
   
<asp:Panel ID="entityWin" ClientIDMode="Static" CssClass="entitywin" runat="server">
    <div id="popupHeader" class="pph1">
		<div>
			<asp:Literal ID="li1" Text="New Shipper" runat="server" />
		</div>
    </div>

	<jf:MessageBox ID="msg" runat="server" />

	<div style="padding:10px">
	<table border="0">
	<tr>
		<td class="ar b nw">Id:</td>
		<td><asp:TextBox ID="txtEntityId" Width="100px" MaxLength="10" ClientIDMode="Static" Enabled="false" runat="server" />
			<asp:CompareValidator ID="cv1" ControlToValidate="txtEntityId" ErrorMessage="Please enter a Entity Id" Operator="NotEqual" ValueToCompare="" Display="None" runat="server" />
			<ajax:ValidatorCalloutExtender ID="vcx1" TargetControlID="cv1" runat="server" />
		</td>
	</tr>
	<tr>
		<td class="ar b nw">Name:</td>
		<td><asp:TextBox ID="txtEntityName" ClientIDMode="Static" Required="true" Width="440px" MaxLength="400" runat="server" /></td>
	</tr>
	<tr>
		<td class="ar b nw">Address:</td>
		<td><asp:TextBox ID="txtEntityAddress1" Required="true" Width="232px" MaxLength="100" ClientIDMode="Static" runat="server" />
			<asp:TextBox ID="txtEntityAddress2" Width="200px" MaxLength="100" ClientIDMode="Static" runat="server" />
		</td>
	</tr>
	<tr>
		<td class="ar b nw">Country/State:</td>
		<td>
			<asp:DropDownList ID="ddlCountries" Width="210px" ClientIDMode="Static" runat="server" />
			<asp:CompareValidator ID="cv4" ControlToValidate="ddlCountries" ErrorMessage="Please select a Country." Operator="NotEqual" ValueToCompare="-1" Display="None" runat="server" />
			<ajax:ValidatorCalloutExtender ID="vcx4" TargetControlID="cv4" runat="server" />
			<jf:StatesDropDown ID="ddlStates" ClientIDMode="Static" ParentControlID="ddlCountries" Width="210px" runat="server" />
		</td>
	</tr>
	<tr>
		<td class="ar b nw">City:</td>
		<td><asp:TextBox ID="txtEntityCity" Required="true" Width="300px" MaxLength="100" ClientIDMode="Static" runat="server" /></td>
	</tr>
	<tr>
		<td class="ar b nw">Zip Code:</td>
		<td><asp:TextBox ID="txtEntityZip" Required="true" Width="60px" MaxLength="5" ClientIDMode="Static" runat="server" />
			<asp:TextBox ID="txtEntityZip2" Width="40px" MaxLength="4" ClientIDMode="Static" runat="server" />
		</td>
	</tr>
	<tr>
		<td class="ar b nw">Phone 1:</td>
		<td><asp:TextBox ID="txtEntityPhone" Required="true" Width="200px" MaxLength="10" ClientIDMode="Static" runat="server" /></td>
	</tr>
	<tr>
		<td class="ar b nw">Phone 2:</td>
		<td><asp:TextBox ID="txtEntityPhone2" ClientIDMode="Static" Width="200px" MaxLength="10" runat="server" /></td>
	</tr>	
	<tr>
		<td class="ar b nw">Fax:</td>
		<td><asp:TextBox ID="txtEntityFax" ClientIDMode="Static" Width="200px" MaxLength="10" runat="server" /></td>
	</tr>
	<tr>
		<td class="ar b nw">E-mail:</td>
		<td><asp:TextBox ID="txtEntityEmail" ClientIDMode="Static" type="email" Width="200px" MaxLength="60" runat="server" /></td>
	</tr>
	<tr>
		<td class="ar b nw">Tax ID:</td>
		<td><asp:TextBox ID="txtEntityTaxID" ClientIDMode="Static" Width="200px" MaxLength="20" runat="server" /></td>
	</tr>
	<tr>
		<td class="tr b nw">Notes:</td>
		<td><asp:TextBox ID="txtEntityNotes" Width="440px" TextMode="MultiLine" Rows="3" MaxLength="2000" ClientIDMode="Static" runat="server" /></td>
	</tr>
	<tr>
		<td>&nbsp;&nbsp;</td>
		<td>
			<table border="0" style="width:100%">
				<tr>
					<td style="width:15%"><asp:Button ID="btnSaveEntity" Text="Save" runat="server" /></td>
					<td style="width:40%"><asp:Button ID="btnNewConsignee" Text="Add Consignee" formnovalidate="formnovalidate" Visible="false" CausesValidation="false" runat="server" /></td>
					<td style="width:20%"><asp:Button ID="btnDeleteEntity" Text="Delete" OnClientClick="javascript:if(!confirm('Are you certain you want to delete this record?')){return false;}" runat="server" /></td>
					<td style="width:25%"><asp:Button ID="btnNewShipper" Text="New Shipper" runat="server" /></td>
				</tr>
			</table>
			
		</td>
	</tr>
	</table>
	</div>
</asp:Panel>

<ajax:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" />

    </form>
</body>
</html>
