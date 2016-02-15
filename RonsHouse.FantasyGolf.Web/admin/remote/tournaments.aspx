<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tournaments.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.Remote.TournamentPage" MasterPageFile="~/admin/admin.master" %>

<asp:Content ContentPlaceHolderID="content_placeholder" runat="server">
	
	<fieldset>
		<legend>Download Tournaments</legend>
	</fieldset>

	<p><asp:Button ID="sync_button" runat="server" Text="Sync Remote Tournaments" OnClick="OnSyncTournaments" /></p>
</asp:Content>