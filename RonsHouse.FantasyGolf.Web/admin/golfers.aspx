<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="golfers.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.AdminGolfersPage" MasterPageFile="~/admin/admin.master" %>
<%@ Register TagPrefix="common" Assembly="RonsHouse.FantasyGolf.Web" Namespace="RonsHouse.FantasyGolf.Web.Controls" %>

<asp:Content ContentPlaceHolderID="content_placeholder" runat="server">

	<asp:Panel ID="message_label_panel" runat="server" Visible="false">
		<div class="alert alert-dismissable alert-info">
			<button type="button" class="close" data-dismiss="alert">x</button>
			<asp:Label ID="message_label" runat="server" />
		</div>
	</asp:Panel>

	<fieldset>
		<legend>Add a Golfer</legend>
	
		<div class="form-group">
			<asp:Label ID="firstname_label" runat="server" AssociatedControlID="firstname_textbox" CssClass="col-lg-2 control-label">First Name</asp:Label>
			<div class="col-lg-10">
				<asp:TextBox ID="firstname_textbox" runat="server" Width="300" CssClass="form-control" placeholder="First Name" />
			</div>
		</div>
		<div class="form-group">
			<asp:Label ID="lastname_label" runat="server" AssociatedControlID="lastname_textbox" CssClass="col-lg-2 control-label">Last Name</asp:Label>
			<div class="col-lg-10">
				<asp:TextBox ID="lastname_textbox" runat="server" Width="300" CssClass="form-control" placeholder="Last Name" />
			</div>
		</div>
		<div class="form-group">
			<asp:Label ID="tour_label" runat="server" AssociatedControlID="tour_list" CssClass="col-lg-2 control-label">Tour</asp:Label>
			<div class="col-lg-10">
				<asp:DropDownList ID="tour_list" runat="server" DataTextField="Name" DataValueField="Id" CssClass="form-control" />
			</div>
		</div>
		<div class="form-group">
			<div class="col-lg-10 col-lg-offset-2">
				<asp:Button id="submit_button" runat="server" Text="Save Golfer" OnClick="OnSaveGolfer" CssClass="btn btn-default" />
			</div>
		</div>
	</fieldset>

	<fieldset>
		<legend>Available Golfers</legend>
	
		<common:BootstrapGridView ID="golfer_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
			<Columns>
				<asp:BoundField HeaderText="Name" DataField="Name" />
				<asp:BoundField HeaderText="Last Name" DataField="LastName" />
				<asp:BoundField HeaderText="First Name" DataField="FirstName" />
			</Columns>
		</common:BootstrapGridView>
	</fieldset>
</asp:Content>
