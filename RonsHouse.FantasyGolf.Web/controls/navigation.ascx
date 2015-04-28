<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="navigation.ascx.cs" Inherits="RonsHouse.FantasyGolf.Web.Controls.NavigationUserControl" %>


<nav class="navbar navbar-default navbar-fixed-top">
	<div class="container-fluid">
		<asp:LoginView ID="navigation_login_view" runat="server">
			<AnonymousTemplate>
				<div class="navbar-header">
					<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
						<span class="sr-only">Toggle navigation</span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
						<span class="icon-bar"></span>
					</button>
					<a class="navbar-brand" href="default.aspx">Fantasy Golf</a>
				</div>
				<div id="navbar" class="navbar-collapse collapse">
					<ul class="nav navbar-nav">
						<li><a href="#">About</a></li>
						<li><a href="#">Contact Us</a></li>
						<li><a href="#">Leagues</a></li>
					</ul>
					<ul class="nav navbar-nav navbar-right">
						<li><a href="/admin/default.aspx">Login</a></li>
					</ul>
				</div>
			</AnonymousTemplate>
			<LoggedInTemplate>

			</LoggedInTemplate>
		</asp:LoginView>
	</div>
</nav>
