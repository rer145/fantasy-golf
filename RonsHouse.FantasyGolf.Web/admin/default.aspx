<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.AdminDefaultPage" MasterPageFile="~/admin/admin.master" %>
<asp:Content ContentPlaceHolderID="content_placeholder" runat="server">
	<%--<h2>Current Standings</h2>
	<asp:GridView ID="standings_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
		<Columns>
			<asp:BoundField HeaderText="First Name" DataField="FirstName" />
			<asp:BoundField HeaderText="Last Name" DataField="LastName" />
			<asp:BoundField HeaderText="Winnings" DataField="Winnings" DataFormatString="{0:C2}" />
		</Columns>
	</asp:GridView>--%>

	<h2>Current Leagues</h2>
	<asp:GridView ID="leagues_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
		<Columns>
			<asp:BoundField HeaderText="Name" DataField="Name" />
			<asp:BoundField HeaderText="Tour" DataField="TourName" />
			<asp:BoundField HeaderText="Season" DataField="Season" />
			<asp:TemplateField>
				<ItemTemplate>
					<a href='/admin/league.aspx?id=<%# Eval("Id") %>'>View Standings</a> / 
					<a href='/admin/picks.aspx?leagueid=<%# Eval("Id") %>'>Make Picks</a>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	</asp:GridView>
</asp:Content>
