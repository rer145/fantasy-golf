<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="edit-league.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.AdminEditLeaguePage" %>
<%@ Register TagPrefix="common" Assembly="RonsHouse.FantasyGolf.Web" Namespace="RonsHouse.FantasyGolf.Web.Controls" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_placeholder" runat="server">

	<common:Notification ID="notification_control" runat="server" Visible="false" />

	<fieldset>
		<legend>Options</legend>

		<div class="form-group">
			<asp:Label ID="name_label" runat="server" AssociatedControlID="name_textbox" CssClass="col-lg-2 control-label">Name</asp:Label>
			<div class="col-lg-10">
				<asp:TextBox ID="name_textbox" runat="server" Width="300" CssClass="form-control" placeholder="Name" />
			</div>
		</div>
		<div class="form-group">
			<asp:Label ID="tour_label" runat="server" AssociatedControlID="tour_list" CssClass="col-lg-2 control-label">Tour</asp:Label>
			<div class="col-lg-10">
				<asp:DropDownList ID="tour_list" runat="server" DataTextField="Name" DataValueField="Id" CssClass="form-control" />
			</div>
		</div>
		<div class="form-group">
			<asp:Label ID="season_label" runat="server" AssociatedControlID="season_textbox" CssClass="col-lg-2 control-label">Season</asp:Label>
			<div class="col-lg-10">
				<asp:TextBox ID="season_textbox" runat="server" Width="75" CssClass="form-control" placeholder="Season" />
			</div>
		</div>
		<div class="form-group">
			<div class="col-lg-10 col-lg-offset-2">
				<asp:Button id="submit_button" runat="server" Text="Save League" OnClick="OnSaveLeague" CssClass="btn btn-primary" />
			</div>
		</div>
	</fieldset>

	<asp:Panel ID="league_user_panel" runat="server" Visible="false">
		<fieldset>
			<legend>Users</legend>

			<div class="form-group">
				<div class="col-lg-10 col-lg-offset-2">
					<asp:Button id="submit_user_button" runat="server" Text="Update League Users" OnClick="OnSaveLeagueUsers" CssClass="btn btn-primary" />
				</div>
			</div>
		</fieldset>
	</asp:Panel>

	<asp:Panel ID="league_tournament_panel" runat="server" Visible="false">
		<fieldset>
			<legend>Tournaments</legend>

			<div class="form-group">
				<div class="col-lg-10 col-lg-offset-2">
					<asp:Button id="submit_tournament_button" runat="server" Text="Update League Tournaments" OnClick="OnSaveLeagueTournaments" CssClass="btn btn-primary" />
				</div>
			</div>
		</fieldset>
	</asp:Panel>

</asp:Content>
