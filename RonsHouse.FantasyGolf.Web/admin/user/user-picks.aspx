<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.master" AutoEventWireup="true" CodeBehind="user-picks.aspx.cs" Inherits="RonsHouse.FantasyGolf.Web.Admin.User.PicksPage" %>
<%@ Register TagPrefix="common" Assembly="RonsHouse.FantasyGolf.Web" Namespace="RonsHouse.FantasyGolf.Web.Controls" %>

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
				<common:BootstrapGridView ID="userpicks_grid" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover" OnRowDataBound="OnDataBoundUserPicks">
					<Columns>
						<asp:BoundField HeaderText="Tournament" DataField="Name" />
						<asp:TemplateField>
							<ItemTemplate>
								<asp:HiddenField ID="userpick_hidden" runat="server" Value='<%# Eval("TournamentId") %>' />
								<asp:DropDownList ID="golfer_list" CssClass="ajax-userpick" runat="server" AutoPostBack="false" DataValueField="Id" DataTextField="Name" TournamentId='<%# DataBinder.Eval(Container.DataItem, "TournamentId") %>' />
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</common:BootstrapGridView>
			</div>
		</div>

		<%--<asp:Button ID="submit_button" runat="server" Text="Save All Picks" OnClick="OnSubmitUserPicks" CssClass="btn btn-primary" />--%>
	</fieldset>

	<script type="text/javascript">
		$(function () {
			$(".ajax-userpick").change(function () {
				var golfer = $(this).val();
				//alert(golfer);

				var user = $("#user_list").val();
				//alert(user);

				var tournament = $(this).attr("TournamentId");
				//alert(tournament);


				$.ajax({
					type: "GET",
					url: "/api/default.aspx",
					//data: "m=save-user-pick&p_golfer=" + golfer + "&p_user=" + user + "&p_tournament=" + tournament,
					data: {
						m : "save-user-pick",
						p_golfer : golfer,
						p_user : user,
						p_tournament : tournament
					},
					dataType: "json",
					async: false,
					success: function (response) {
						if (!Boolean(response.Success)) {
							alert("There was an error: " + response.Message);
						}
						//alert(response);
						//alert(response.Success);
						//alert(response.Message);
					},
					error: function () {
						alert("Couldn't save the pick due to an error.");
					}
				});
			});
		});
	</script>

</asp:Content>
