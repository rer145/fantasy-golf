﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="picks.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.AdminPicksPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
		<p>Tournament: <asp:DropDownList ID="tournament_list" runat="server" DataTextField="Name" DataValueField="Id" /></p>
		<p>User: <asp:DropDownList ID="user_list" runat="server" DataTextField="Name" DataValueField="Id" /></p>
		<p>Golfer: <asp:DropDownList ID="golfer_list" runat="server" DataTextField="Name" DataValueField="Id" /></p>

		<p><asp:Button id="submit_button" runat="server" Text="Save Pick" OnClick="OnSavePick" /></p>

		<p><asp:Label ID="message_label" runat="server" /></p>


    </form>
</body>
</html>
