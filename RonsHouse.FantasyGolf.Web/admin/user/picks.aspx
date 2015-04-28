<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="picks.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.User.PicksPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="content_placeholder" runat="server">

	<fieldset>
		<legend>Add/Edit Picks</legend>

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
			<div class="col-lg-5">
				<asp:GridView ID="userpicks_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover" OnRowDataBound="OnDataBoundUserPicks">
					<Columns>
						<asp:BoundField HeaderText="Tournament" DataField="Name" />
						<asp:TemplateField>
							<ItemTemplate>
								<asp:HiddenField ID="userpick_hidden" runat="server" Value='<%# Eval("TournamentId") %>' />
								<asp:DropDownList ID="golfer_list" runat="server" AutoPostBack="true" OnSelectedIndexChanged="OnSelectGolfer" DataValueField="Id" DataTextField="Name" TournamentId='<%# DataBinder.Eval(Container.DataItem, "TournamentId") %>' />
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</asp:GridView>
			</div>
		</div>
	</fieldset>

</asp:Content>
