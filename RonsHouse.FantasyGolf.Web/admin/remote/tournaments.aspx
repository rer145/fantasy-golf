<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tournaments.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.Remote.TournamentPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
		<p><asp:Button ID="sync_button" runat="server" Text="Sync Remote Tournaments" OnClick="OnSyncTournaments" /></p>

		<asp:GridView ID="tournament_list" runat="server" AutoGenerateColumns="true" />

    </form>
</body>
</html>
