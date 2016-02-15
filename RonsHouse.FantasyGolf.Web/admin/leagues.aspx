<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="leagues.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.AdminLeaguesPage" %>
<%@ Register TagPrefix="common" Assembly="RonsHouse.FantasyGolf.Web" Namespace="RonsHouse.FantasyGolf.Web.Controls" %>

<asp:Content ID="Content2" ContentPlaceHolderID="content_placeholder" runat="server">

	<fieldset>
		<legend>Leagues</legend>

		<p>
			<a href="/admin/edit-league.aspx" class="btn btn-primary">Create New League</a>
		</p>

		<common:BootstrapGridView ID="league_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
			<Columns>
				<asp:BoundField HeaderText="Name" DataField="Name" />
				<asp:BoundField HeaderText="Begins On" DataField="BeginsOn" DataFormatString="{0:d}" />
				<asp:BoundField HeaderText="Ends On" DataField="EndsOn" DataFormatString="{0:d}" />
				<asp:TemplateField>
					<ItemTemplate>
						<a href="/admin/edit-league.aspx?id=<%# Eval("Id") %>" class="btn btn-primary btn-xs">Edit</a>
						<a href="/admin/delete-league.aspx?id=<%# Eval("Id") %>" class="btn btn-danger btn-xs">Delete</a>
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
		</common:BootstrapGridView>
	</fieldset>

</asp:Content>