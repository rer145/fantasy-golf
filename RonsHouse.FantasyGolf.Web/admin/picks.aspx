<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="picks.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.AdminPicksPage" MasterPageFile="~/admin/admin.master" %>
<%@ Register TagPrefix="common" Assembly="RonsHouse.FantasyGolf.Web" Namespace="RonsHouse.FantasyGolf.Web.Controls" %>

<asp:Content ContentPlaceHolderID="content_placeholder" runat="server">

	<asp:Panel ID="message_label_panel" runat="server" Visible="false">
		<div class="alert alert-dismissable alert-info">
			<button type="button" class="close" data-dismiss="alert">x</button>
			<asp:Label ID="message_label" runat="server" />
		</div>
	</asp:Panel>

	<fieldset>
		<legend>Set User Picks</legend>
	
		<div class="form-group">
			<asp:Label ID="tournament_list_label" runat="server" AssociatedControlID="tournament_list" CssClass="col-lg-2 control-label">Tournament</asp:Label>
			<div class="col-lg-10">
				<asp:DropDownList ID="tournament_list" runat="server" DataTextField="Name" DataValueField="Id" AutoPostBack="true" OnSelectedIndexChanged="OnSelectTournament" CssClass="form-control" />
			</div>
		</div>
		<div class="form-group">
			<asp:Label ID="user_list_label" runat="server" AssociatedControlID="user_list" CssClass="col-lg-2 control-label">User</asp:Label>
			<div class="col-lg-10">
				<asp:DropDownList ID="user_list" runat="server" DataTextField="Name" DataValueField="Id" CssClass="form-control" />
			</div>
		</div>
		<div class="form-group">
			<asp:Label ID="golfer_list_label" runat="server" AssociatedControlID="golfer_list" CssClass="col-lg-2 control-label">Golfer</asp:Label>
			<div class="col-lg-10">
				<asp:DropDownList ID="golfer_list" runat="server" DataTextField="Name" DataValueField="Id" CssClass="form-control" />
			</div>
		</div>
		<div class="form-group">
			<div class="col-lg-10 col-lg-offset-2">
				<asp:Button id="submit_button" runat="server" Text="Save Pick" OnClick="OnSavePick" CssClass="btn btn-default" />
			</div>
		</div>
	</fieldset>

	<fieldset>
		<legend>Tournament Picks</legend>
	
		<%--<asp:GridView ID="picks_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
			<Columns>
				<asp:BoundField HeaderText="User" DataField="UserName" />
				<asp:BoundField HeaderText="Golfer" DataField="GolferName" />
			</Columns>
		</asp:GridView>--%>
		<common:BootstrapGridView ID="picks_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
			<Columns>
				<asp:BoundField HeaderText="User" DataField="UserName" />
				<asp:BoundField HeaderText="Golfer" DataField="GolferName" />
			</Columns>
		</common:BootstrapGridView>
	</fieldset>
</asp:Content>
