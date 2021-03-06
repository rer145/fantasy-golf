﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tournaments.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.AdminTournamentsPage" MasterPageFile="~/admin/admin.master" %>
<%@ Register TagPrefix="common" Assembly="RonsHouse.FantasyGolf.Web" Namespace="RonsHouse.FantasyGolf.Web.Controls" %>

<asp:Content ContentPlaceHolderID="content_placeholder" runat="server">

	<asp:Panel ID="message_label_panel" runat="server" Visible="false">
		<div class="alert alert-dismissable alert-info">
			<button type="button" class="close" data-dismiss="alert">x</button>
			<asp:Label ID="message_label" runat="server" />
		</div>
	</asp:Panel>

	<fieldset>
		<legend>Tournaments</legend>

		<common:BootstrapGridView ID="tournament_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
			<Columns>
				<asp:BoundField HeaderText="Name" DataField="Name" />
				<asp:BoundField HeaderText="Begins On" DataField="BeginsOn" DataFormatString="{0:d}" />
				<asp:BoundField HeaderText="Ends On" DataField="EndsOn" DataFormatString="{0:d}" />
				<asp:TemplateField>
					<ItemTemplate>
						<asp:LinkButton ID="remote_results_button" runat="server" CommandName="RemoteResults" CommandArgument='<%# Eval("ID") %>' OnCommand="OnClickTournamentOption" Text="Download Results" CssClass="btn btn-warning btn-xs" />
						<asp:LinkButton ID="picks_button" runat="server" CommandName="Picks" CommandArgument='<%# Eval("ID") %>' OnCommand="OnClickTournamentOption" Text="View Picks" CssClass="btn btn-info btn-xs" />
						<asp:LinkButton ID="edit_button" runat="server" CommandName="Edit" CommandArgument='<%# Eval("ID") %>' OnCommand="OnClickTournamentOption" Text="Edit" CssClass="btn btn-primary btn-xs" />
						<asp:LinkButton ID="delete_button" runat="server" CommandName="Delete" CommandArgument='<%# Eval("ID") %>' OnCommand="OnClickTournamentOption" Text="Delete" CssClass="btn btn-danger btn-xs" />
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
		</common:BootstrapGridView>
	</fieldset>
	
</asp:Content>
