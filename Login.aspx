<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JamaicaFreight.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Jamaica Freight - Login</title>
	<link href="site.css" type="text/css" rel="Stylesheet" />
	<style type="text/css">
		body { background-image:url(images/bg_top_login.png); background-repeat:repeat-x }
		.boxh1 { background-color:#026397; color:#fff; text-align:center; font-weight:bold; padding:10px  }
		.boxb { background-color:#F1F1F1; padding:10px }
		.boxh2 { color:#002663; font-weight:bold; font-size:12px }
		._msg { color:#A33F1F; position:relative; padding-left:25px }
		.erricon { background:url("images/elilo-sprite.gif") no-repeat scroll -149px 0 transparent; height:21px; width:24px; position:absolute; left:0px }
		.btn {
			background: url(images/elilo-sprite.gif) no-repeat scroll -41px 0 transparent;
			border: 0 none;
			color: #fff;
			cursor: pointer;
			float: right;
			font-weight: bold;
			height: 28px;
			margin-right: 0px;
			max-width: 98px;
			padding: 4px 0 8px 4px;
			right: 0px;
			text-align: center;
			width: 100%;
		}
	</style>
</head>
<body>

<form id="form1" runat="server">
   
<div style="width:550px;margin-top:160px">

<asp:Panel ID="headerPanel" cssclass="boxh1" runat="server">
	To get started, enter your username and password.
</asp:Panel>

	<div class="boxb">
		
<table border="0" cellpadding="3" style="width:80%">
<tr>
	<td colspan="3" class="boxh2">
		Log In to Your Account
	</td>
</tr>
<tr>
	<td colspan="3" class="_msg">
		<asp:Literal ID="msg" runat="server" />
	</td>
</tr>
<tr>
	<td class="ar b" style="width:25%">Username:</td>
	<td style="width:43%"><asp:TextBox ID="txtUsername" Required="true" autofocus="true" MaxLength="50" Width="170px" runat="server" /></td>
	<td style="width:32%"></td>
</tr>
<tr>
	<td class="ar b">Password:</td>
	<td><asp:TextBox ID="txtPassword" TextMode="Password" Required="true" MaxLength="20" Width="170px" runat="server" /></td>
	<td></td>
</tr>
<tr>
	<td></td>
	<td class="ar"><asp:Button ID="btnLogin" Text="Login" CssClass="btn" Width="100px" runat="server" /></td>
	<td></td>
</tr>
</table>

		</div>

 </div>

</form>
</body>
</html>
