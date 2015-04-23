<%@ Page Title="" Language="C#" MasterPageFile="~/public.master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content_placeholder" runat="server">
	
	<div class="row">
		<div class="col-sm-6 col-md-4 col-md-offset-4">
			<h2 class="text-center">Login</h2>
			<div class="form-group">
				<asp:Label ID="email_label" runat="server" AssociatedControlID="email_textbox" CssClass="control-label">Email</asp:Label>
				<asp:TextBox ID="email_textbox" runat="server" CssClass="form-control" placeholder="Email address" />
			</div>
			<div class="form-group">
				<asp:Label ID="password_label" runat="server" AssociatedControlID="password_textbox" CssClass="control-label">Password</asp:Label>
				<asp:TextBox ID="password_textbox" runat="server" CssClass="form-control" TextMode="Password" />
			</div>
			<div class="form-group">
				<div class="col-lg-2">
					<asp:Label ID="rememberme_label" runat="server" AssociatedControlID="rememberme_checkbox" CssClass="checkbox pull-right">
						<asp:CheckBox ID="rememberme_checkbox" runat="server" />
						Remember me?
					</asp:Label>
				</div>
				<div class="col-lg-8 col-lg-offset-9">
					<asp:Button ID="submit_button" runat="server" Text="Login" OnClick="OnLogin" CssClass="btn btn-default" />
				</div>
			</div>
		</div>
	</div>

</asp:Content>
