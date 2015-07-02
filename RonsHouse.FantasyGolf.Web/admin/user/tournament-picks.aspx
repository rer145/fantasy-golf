<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="tournament-picks.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.User.TournamentPicksPage" %>
<%@ Register TagPrefix="common" Assembly="RonsHouse.FantasyGolf.Web" Namespace="RonsHouse.FantasyGolf.Web.Controls" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_placeholder" runat="server">

	<fieldset>
		<legend>Add/Edit Tournament Picks</legend>

		<div class="form-group">
			<asp:Label ID="tournament_list_label" runat="server" AssociatedControlID="tournament_list" CssClass="col-lg-2 control-label">Tournament</asp:Label>
			<div class="col-lg-10">
				<asp:DropDownList ID="tournament_list" runat="server" DataTextField="Name" DataValueField="Id" AutoPostBack="true" OnSelectedIndexChanged="OnSelectTournament" CssClass="form-control" />
			</div>
		</div>
	</fieldset>

	<fieldset>
		<legend>Results</legend>

		<div class="row">
			<div class="col-lg-5">
				<common:BootstrapGridView ID="tournamentpicks_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover" OnRowDataBound="OnDataBoundTournamentPicks">
					<Columns>
						<asp:BoundField HeaderText="User" DataField="Name" />
						<asp:TemplateField>
							<ItemTemplate>
								<asp:HiddenField ID="tournamentpick_hidden" runat="server" Value='<%# Eval("UserID") %>' />
								<asp:DropDownList ID="golfer_list" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnSelectGolfer" DataValueField="Id" DataTextField="Name" UserId='<%# DataBinder.Eval(Container.DataItem, "UserId") %>' />
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</common:BootstrapGridView>
			</div>
		</div>
	</fieldset>

</asp:Content>
