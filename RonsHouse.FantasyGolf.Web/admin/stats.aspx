<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stats.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.AdminStatsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
		<p>Tournament: <asp:DropDownList ID="tournament_list" runat="server" DataTextField="Name" DataValueField="Id" AutoPostBack="true" OnSelectedIndexChanged="OnSelectTournament" /></p>
		<p>User: <asp:DropDownList ID="user_list" runat="server" DataTextField="Name" DataValueField="Id" AutoPostBack="true" OnSelectedIndexChanged="OnSelectUser" /></p>
		
		<p>&nbsp;</p>
		<p>&nbsp;</p>

		
		<h2>Tournament Results</h2>
		<asp:GridView ID="results_grid" runat="server" AutoGenerateColumns="false" CellPadding="4">
			<Columns>
				<asp:BoundField HeaderText="First Name" DataField="FirstName" />
				<asp:BoundField HeaderText="Last Name" DataField="LastName" />
				<asp:BoundField HeaderText="Place" DataField="Place" />
				<asp:BoundField HeaderText="Winnings" DataField="Winnings" DataFormatString="{0:C2}" />
			</Columns>
		</asp:GridView>

		<h2>Current Standings</h2>
		<asp:GridView ID="standings_grid" runat="server" AutoGenerateColumns="false" CellPadding="4">
			<Columns>
				<asp:BoundField HeaderText="First Name" DataField="FirstName" />
				<asp:BoundField HeaderText="Last Name" DataField="LastName" />
				<asp:BoundField HeaderText="Winnings" DataField="Winnings" DataFormatString="{0:C2}" />
			</Columns>
		</asp:GridView>

		<h2>User Picks</h2>
		<asp:GridView ID="userpicks_grid" runat="server" AutoGenerateColumns="false" CellPadding="4">
			<Columns>
				<asp:BoundField HeaderText="Tournament" DataField="Name" />
				<asp:BoundField HeaderText="First Name" DataField="Pick" />
				<asp:BoundField HeaderText="Winnings" DataField="Winnings" DataFormatString="{0:C2}" />
			</Columns>
		</asp:GridView>

    </form>
</body>
</html>
