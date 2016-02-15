using System.Web;
using System.Web.UI;
using System.Security.Permissions;
using System.Text;

namespace RonsHouse.FantasyGolf.Web.Controls
{
	[AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class ProgressBar : LiteralControl
	{
		public decimal Percentage { get; set; }
		public bool IsAnimated { get; set; }
		public bool IsStriped { get; set; }
		public ProgressBarStatus Status { get; set; }

		protected override void Render(HtmlTextWriter output)
		{
			string status_css = "";
			switch (this.Status)
			{
				case ProgressBarStatus.Info:
					status_css = "progress-bar-info";
					break;
				case ProgressBarStatus.Success:
					status_css = "progress-bar-success";
					break;
				case ProgressBarStatus.Warning:
					status_css = "progress-bar-warning";
					break;
				case ProgressBarStatus.Danger:
					status_css = "progress-bar-danger";
					break;
			}

			StringBuilder html = new StringBuilder();
			html.AppendFormat("<div class=\"progress {0} {1}\">", this.IsStriped ? "progress-striped" : "", this.IsAnimated ? "active" : "");
			//TODO: add ability to add more than one progress (i.e. stacked)
			html.AppendFormat("<div class=\"progress-bar {0}\" style=\"width: {1}%;\"><span class=\"sr-only\">{1}% complete</span></div>", status_css, this.Percentage.ToString());
			html.Append("</div>");

			output.Write(html.ToString());
			base.Render(output);
		}
	}

	public enum ProgressBarStatus
	{
		Default,
		Info,
		Success,
		Warning,
		Danger
	}
}