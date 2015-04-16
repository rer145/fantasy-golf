<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="results.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.AdminResultsPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
		<p>Tournament: <asp:DropDownList ID="tournament_list" runat="server" DataTextField="Name" DataValueField="Id" AutoPostBack="true" OnSelectedIndexChanged="OnSelectTournament" /></p>
		<p>Golfer: <asp:DropDownList ID="golfer_list" runat="server" DataTextField="Name" DataValueField="Id" /></p>
		<p>Place: <asp:TextBox ID="place_textbox" runat="server" Width="50" /></p>
		<p>Winnings: $<asp:TextBox ID="winnings_textbox" runat="server" Width="100" /></p>
		<p>Cut: <asp:CheckBox ID="cut_checkbox" runat="server" /></p>
		<p>Withdrew: <asp:CheckBox ID="wd_checkbox" runat="server" /></p>
		<p>Disqualified: <asp:CheckBox ID="dq_checkbox" runat="server" /></p>
		<p>Tied: <asp:CheckBox ID="tied_checkbox" runat="server" /></p>
		<p>Playoff: <asp:CheckBox ID="playoff_checkbox" runat="server" /></p>

		<p><asp:Button id="submit_button" runat="server" Text="Save Results" OnClick="OnSaveResults" /></p>

		<p><asp:Label ID="message_label" runat="server" /></p>

		<p>&nbsp;</p>
		<p>&nbsp;</p>

		<table border="0" width="100%" cellpadding="8" cellspacing="0">
		<tr>
			<td width="50%" valign="top">
				<h2>Tournament Results</h2>
				<asp:GridView ID="results_grid" runat="server" AutoGenerateColumns="false" CellPadding="4">
					<Columns>
						<asp:BoundField HeaderText="First Name" DataField="FirstName" />
						<asp:BoundField HeaderText="Last Name" DataField="LastName" />
						<asp:BoundField HeaderText="Place" DataField="Place" />
						<asp:BoundField HeaderText="Winnings" DataField="Winnings" DataFormatString="{0:C2}" />
					</Columns>
				</asp:GridView>
			</td>
			<td width="50%" valign="top">
				<h2>Current Standings</h2>
				<asp:GridView ID="standings_grid" runat="server" AutoGenerateColumns="false" CellPadding="4">
					<Columns>
						<asp:BoundField HeaderText="First Name" DataField="FirstName" />
						<asp:BoundField HeaderText="Last Name" DataField="LastName" />
						<asp:BoundField HeaderText="Winnings" DataField="Winnings" DataFormatString="{0:C2}" />
					</Columns>
				</asp:GridView>
			</td>
		</tr>
		</table>

    </form>
</body>
</html>
