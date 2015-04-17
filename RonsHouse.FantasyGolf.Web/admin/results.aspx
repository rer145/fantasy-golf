<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="results.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.AdminResultsPage" MasterPageFile="~/admin/admin.master" %>

<asp:Content ContentPlaceHolderID="content_placeholder" runat="server">

	<asp:Panel ID="message_label_panel" runat="server" Visible="false">
		<div class="alert alert-dismissable alert-info">
			<button type="button" class="close" data-dismiss="alert">x</button>
			<asp:Label ID="message_label" runat="server" />
		</div>
	</asp:Panel>

	<fieldset>
		<legend>Set Tournament Results</legend>

		<div class="form-group">
			<asp:Label ID="tournament_list_label" runat="server" AssociatedControlID="tournament_list" CssClass="col-lg-2 control-label">Tournament</asp:Label>
			<div class="col-lg-10">
				<asp:DropDownList ID="tournament_list" runat="server" DataTextField="Name" DataValueField="Id" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="OnSelectTournament" />
			</div>
		</div>

		<div class="form-group">
			<asp:Label ID="golfer_list_label" runat="server" AssociatedControlID="golfer_list" CssClass="col-lg-2 control-label">Golfer</asp:Label>
			<div class="col-lg-10">
				<asp:DropDownList ID="golfer_list" runat="server" DataTextField="Name" DataValueField="Id" CssClass="form-control" />
			</div>
		</div>

		<div class="form-group">
			<asp:Label ID="place_textbox_label" runat="server" AssociatedControlID="place_textbox" CssClass="col-lg-2 control-label">Place</asp:Label>
			<div class="col-lg-10">
				<asp:TextBox ID="place_textbox" runat="server" Width="50" CssClass="form-control" placeholder="Place" />
			</div>
		</div>

		<div class="form-group">
			<asp:Label ID="winnings_textbox_label" runat="server" AssociatedControlID="winnings_textbox" CssClass="col-lg-2 control-label">Winnings</asp:Label>
			<div class="col-lg-10 input-group">
				<span class="input-group-addon">$</span>
				<asp:TextBox ID="winnings_textbox" runat="server" Width="100" CssClass="form-control" placeholder="Winnings" />
			</div>
		</div>

		<div class="form-group">
			<asp:Label ID="options_label" runat="server" AssociatedControlID="cut_checkbox" CssClass="col-lg-2 control-label">Options</asp:Label>
			<div class="col-lg-10">
				<div class="checkbox">
					<label>
						<asp:CheckBox ID="cut_checkbox" runat="server" /> Cut
					</label>
				</div>
				<div class="checkbox">
					<label>
						<asp:CheckBox ID="wd_checkbox" runat="server" /> Withdrew
					</label>
				</div>
				<div class="checkbox">
					<label>
						<asp:CheckBox ID="dq_checkbox" runat="server" /> Disqualified
					</label>
				</div>
				<div class="checkbox">
					<label>
						<asp:CheckBox ID="tied_checkbox" runat="server" /> Tied
					</label>
				</div>
				<div class="checkbox">
					<label>
						<asp:CheckBox ID="playoff_checkbox" runat="server" /> Playoff
					</label>
				</div>
			</div>
		</div>

		<div class="form-group">
			<div class="col-lg-10 col-lg-offset-2">
				<asp:Button ID="submit_button" runat="server" Text="Save Results" OnClick="OnSaveResults" CssClass="btn btn-default" />
			</div>
		</div>
	</fieldset>

	<fieldset>
		<legend>Tournament Results</legend>
	
		<div class="row">
			<div class="col-lg-6">
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
			<div class="col-lg-6">
				<h4>Current Standings</h4>
				<asp:GridView ID="standings_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover">
					<Columns>
						<asp:BoundField HeaderText="First Name" DataField="FirstName" />
						<asp:BoundField HeaderText="Last Name" DataField="LastName" />
						<asp:BoundField HeaderText="Winnings" DataField="Winnings" DataFormatString="{0:C2}" />
					</Columns>
				</asp:GridView>
			</div>
		</div>
	</fieldset>
</asp:Content>