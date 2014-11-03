<%@ Page Title="" Language="C#" MasterPageFile="~/JF.Master" AutoEventWireup="true" CodeBehind="HBOLConsolidation.aspx.cs" Inherits="JamaicaFreight.HBOLConsolidation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript" src="scripts/ILSGrid.js"></script>
	<script type="text/javascript" src="scripts/tools.js"></script>
	<style type="text/css">
		.pph1 { color:#fff; background-color:#000;padding:5px }
		.win1 { width:1200px; }
	</style>
		<script>
			function openHbolWin()
			{
				openWindow("HBOL.aspx", "HBOL", 900, 900, true)
			}
		</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<asp:Literal ID="msg" runat="server" />

	<div style="margin:5px 0 5px 0">
<table border="0" style="width:100%">
<tr>
	<td class="sec">House Bill of Lading:</td>
	<td class="ac"><b>Search</b> <asp:TextBox ID="txtSearch" ClientIDMode="Static" TextMode="Search" Width="300px" runat="server" /> <asp:Button ID="btnSearch" Text="Search" runat="server" /> </td>
	<td class="ar"><asp:ImageButton ID="btnNew" ImageUrl="~/Images/icons/Addfolder.png" OnClientClick="openHbolWin();return false" CausesValidation="false" ToolTip="Add New HBOL" Height="23px" Width="24px" runat="server" /></td>
</tr>
</table>

	<asp:Button ID="btnTest" Text="Test" Visible="false" runat="server" />

	<div class="stdgrid">
			<jf:RangeView ID="rangeView" PageSize="25" ChildGridID="hbolView" CssClass="stdgrid" runat="server" />
			<jf:HBOLView ID="hbolView" CssClass="stdgrid" Visible="false" runat="server" />
	</div>
</div>

<ajax:toolkitscriptmanager ID="ToolkitScriptManager1" runat="server" />

</asp:Content>
