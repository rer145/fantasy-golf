﻿<%@ Page Title="" Language="C#" MasterPageFile="~/public.master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content_placeholder" runat="server">

	<div class="row">
		<div class="col-sm-6 col-md-4 col-md-offset-4">
			<h2 class="text-center">Register</h2>
			<div class="form-group">
				<asp:Label ID="email_label" runat="server" AssociatedControlID="email_textbox" CssClass="control-label">Email</asp:Label>
				<asp:TextBox ID="email_textbox" runat="server" CssClass="form-control" placeholder="Email address" />
			</div>
			<div class="form-group">
				<asp:Label ID="firstname_label" runat="server" AssociatedControlID="firstname_textbox" CssClass="control-label">First Name</asp:Label>
				<asp:TextBox ID="firstname_textbox" runat="server" CssClass="form-control" placeholder="First Name" />
			</div>
			<div class="form-group">
				<asp:Label ID="lastname_label" runat="server" AssociatedControlID="lastname_textbox" CssClass="control-label">Last Name</asp:Label>
				<asp:TextBox ID="lastname_textbox" runat="server" CssClass="form-control" placeholder="Last Name" />
			</div>
			<div class="form-group">
				<asp:Label ID="password_label" runat="server" AssociatedControlID="password_textbox" CssClass="control-label">Password</asp:Label>
				<asp:TextBox ID="password_textbox" runat="server" CssClass="form-control" TextMode="Password" />
			</div>
			<div class="form-group">
				<asp:Label ID="confirm_password_label" runat="server" AssociatedControlID="confirm_password_textbox" CssClass="control-label">Confirm Password</asp:Label>
				<asp:TextBox ID="confirm_password_textbox" runat="server" CssClass="form-control" TextMode="Password" />
			</div>
			<div class="form-group">
				<div class="col-lg-12 col-lg-offset-9">
					<asp:Button ID="submit_button" runat="server" Text="Register" OnClick="OnRegister" CssClass="btn btn-default" />
				</div>
			</div>
		</div>
	</div>

</asp:Content>
