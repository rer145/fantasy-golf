using System;
using System.Web;
using System.Web.UI;
using System.Security.Permissions;
using System.Text;
using System.Web.UI.WebControls;

namespace RonsHouse.FantasyGolf.Web.Controls
{
	[ParseChildren(true)]
	[AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class Modal : CompositeControl
	{
		public bool HasCloseButton { get; set; }
		public bool HasFade { get; set; }
		public ModalHeader ModalHeader { get; set; }

		protected override void CreateChildControls()
		{
			base.CreateChildControls();
		}


		protected override void Render(HtmlTextWriter output)
		{
			StringBuilder html = new StringBuilder();
			html.AppendFormat("<div class=\"modal{0}\">", this.HasFade ? " fade" : "");
			html.Append("<div class=\"modal-dialog\">");
			html.Append("<div class=\"modal-content\">");

			html.Append("<div class=\"modal-header\">");
			if (this.HasCloseButton)
			{
				html.Append("<button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\"><span aria-hidden=\"true\">&times;</span></button>");
			}

			if (this.ModalHeader != null)
			{
				RenderChildren(output);
			}
			html.Append("</div>");	//modal-header

			html.Append("</div>");	//modal-content
			html.Append("</div>");	//modal-dialog
			html.Append("</div>");	//modal

			output.Write(html.ToString());
			base.Render(output);
		}
	}

	public enum ModalSize
	{
		Default,
		Small,
		Large
	}

	public sealed class ModalHeader : LiteralControl
	{
		protected override void Render(HtmlTextWriter output)
		{
			output.Write(String.Format("<h4 class=\"modal-title\">{0}</h4>", this.Text));
			base.Render(output);
		}
	}
}