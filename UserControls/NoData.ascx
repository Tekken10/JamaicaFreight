<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NoData.ascx.cs" Inherits="UserControls_NoData" %>
<style type="text/css">
.GridEmptyResultsPanel{
    width:100%;
    height:120px;
    border:solid 1px black;
    background-color:White;
    vertical-align:middle;
    text-align:center;
    font-weight:bold;
    color:Gray;    
}

.GridEmptyResultsPanelTable{
    margin:50px auto auto auto;
}
</style>

<asp:Panel ID="Panel1" runat="server" CssClass="GridEmptyResultsPanel">

<table cellpadding="0" cellspacing="0" class="GridEmptyResultsPanelTable">
<tr>
	<td><asp:Label ID="lblText" runat="server" Text="" /></td>
</tr>
</table>

</asp:Panel>