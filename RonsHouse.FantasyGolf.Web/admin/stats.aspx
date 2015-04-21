<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stats.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.AdminStatsPage" MasterPageFile="~/admin/admin.master" %>

<asp:Content ContentPlaceHolderID="content_placeholder" runat="server">
	<fieldset>
		<legend>View Stats</legend>

		<div class="form-group">
			<asp:Label ID="tournament_list_label" runat="server" AssociatedControlID="tournament_list" CssClass="col-lg-2 control-label">Tournament</asp:Label>
			<div class="col-lg-10">
				<asp:DropDownList ID="tournament_list" runat="server" DataTextField="Name" DataValueField="Id" AutoPostBack="true" OnSelectedIndexChanged="OnSelectTournament" CssClass="form-control" />
			</div>
		</div>
		<div class="form-group">
			<asp:Label ID="user_list_label" runat="server" AssociatedControlID="user_list" CssClass="col-lg-2 control-label">User</asp:Label>
			<div class="col-lg-10">
				<asp:DropDownList ID="user_list" runat="server" DataTextField="Name" DataValueField="Id" AutoPostBack="true" OnSelectedIndexChanged="OnSelectUser" CssClass="form-control" />
			</div>
		</div>
	</fieldset>	
	
	<fieldset>
		<legend>Results</legend>
	
		<div class="row">
			<div class="col-lg-3">
				<h4>Quarter 1 Standings</h4>
				<asp:GridView ID="quarter1_standings_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
					<Columns>
						<asp:BoundField HeaderText="First Name" DataField="FirstName" />
						<asp:BoundField HeaderText="Last Name" DataField="LastName" />
						<asp:BoundField HeaderText="Winnings" DataField="Winnings" DataFormatString="{0:C2}" />
					</Columns>
				</asp:GridView>
			</div>
			<div class="col-lg-3">
				<h4>Quarter 2 Standings</h4>
				<asp:GridView ID="quarter2_standings_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
					<Columns>
						<asp:BoundField HeaderText="First Name" DataField="FirstName" />
						<asp:BoundField HeaderText="Last Name" DataField="LastName" />
						<asp:BoundField HeaderText="Winnings" DataField="Winnings" DataFormatString="{0:C2}" />
					</Columns>
				</asp:GridView>
			</div>
			<div class="col-lg-3">
				<h4>Quarter 3 Standings</h4>
				<asp:GridView ID="quarter3_standings_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
					<Columns>
						<asp:BoundField HeaderText="First Name" DataField="FirstName" />
						<asp:BoundField HeaderText="Last Name" DataField="LastName" />
						<asp:BoundField HeaderText="Winnings" DataField="Winnings" DataFormatString="{0:C2}" />
					</Columns>
				</asp:GridView>
			</div>
			<div class="col-lg-3">
				<h4>Quarter 4 Standings</h4>
				<asp:GridView ID="quarter4_standings_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
					<Columns>
						<asp:BoundField HeaderText="First Name" DataField="FirstName" />
						<asp:BoundField HeaderText="Last Name" DataField="LastName" />
						<asp:BoundField HeaderText="Winnings" DataField="Winnings" DataFormatString="{0:C2}" />
					</Columns>
				</asp:GridView>
			</div>
		</div>

		<div class="row">
			<div class="col-lg-3">
				<h4>Current Overall Standings</h4>
				<asp:GridView ID="standings_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
					<Columns>
						<asp:BoundField HeaderText="First Name" DataField="FirstName" />
						<asp:BoundField HeaderText="Last Name" DataField="LastName" />
						<asp:BoundField HeaderText="Winnings" DataField="Winnings" DataFormatString="{0:C2}" />
					</Columns>
				</asp:GridView>
			</div>
			<div class="col-lg-4">
				<h4>Tournament Results</h4>
				<asp:GridView ID="results_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
					<Columns>
						<asp:BoundField HeaderText="First Name" DataField="FirstName" />
						<asp:BoundField HeaderText="Last Name" DataField="LastName" />
						<asp:BoundField HeaderText="Place" DataField="PlaceDisplay" />
						<asp:BoundField HeaderText="Winnings" DataField="Winnings" DataFormatString="{0:C2}" />
					</Columns>
				</asp:GridView>
			</div>
			<div class="col-lg-5">
				<h4>User Picks</h4>
				<asp:GridView ID="userpicks_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
					<Columns>
						<asp:BoundField HeaderText="Tournament" DataField="Name" />
						<asp:BoundField HeaderText="Golfer" DataField="Pick" />
						<asp:BoundField HeaderText="Place" DataField="PlaceDisplay" />
						<asp:BoundField HeaderText="Winnings" DataField="Winnings" DataFormatString="{0:C2}" />
					</Columns>
				</asp:GridView>
			</div>
		</div>
	</fieldset>
</asp:Content>