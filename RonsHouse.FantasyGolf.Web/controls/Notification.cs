using System.Web;
using System.Web.UI;
using System.Security.Permissions;
using System.Text;

namespace RonsHouse.FantasyGolf.Web.Controls
{
	[AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
	public sealed class Notification : LiteralControl
	{
		public string NotificationText { get; set; }
		public NotificationType NotificationType { get; set; }
		public bool IsDismissable { get; set; }

		protected override void Render(HtmlTextWriter output)
		{
			NotificationItem notification = new NotificationItem()
			{
				Type = this.NotificationType,
				Text = this.NotificationText,
				IsDismissable = this.IsDismissable,
				Location = NotificationLocation.Custom
			};

			output.Write(notification.Render());
			base.Render(output);
		}
	}

	public class NotificationItem
	{
		public NotificationType Type { get; set; }
		public NotificationLocation Location { get; set; }
		public bool IsDismissable { get; set; }
		public string Text { get; set; }

		public NotificationItem() { }

		//public Notification(NotificationType type, bool isDismissable, string text)
		//{
		//	this.Type = type;
		//	this.IsDismissable = isDismissable;
		//	this.Text = text;
		//}

		public string Render()
		{
			string alert_dismiss_class = this.IsDismissable ? "alert-dismissable" : "";
			string alert_dismiss_code = "<button type=\"button\" class=\"close\" data-dismiss=\"alert\">&times;</button>";
			string alert_type_class = "alert-";
			switch (this.Type)
			{
				case NotificationType.Warning:
					alert_type_class += "warning";
					break;
				case NotificationType.Success:
					alert_type_class += "success";
					break;
				case NotificationType.Error:
					alert_type_class += "danger";
					break;
				default:
					alert_type_class += "info";
					break;
			}

			StringBuilder output = new StringBuilder();
			output.AppendFormat("<div class=\"alert {0} {1}\">", alert_type_class, alert_dismiss_class);

			if (this.IsDismissable)
				output.Append(alert_dismiss_code);

			output.Append(this.Text);
			output.Append("</div>");

			return output.ToString();
		}
	}

	public enum NotificationType
	{
		Info,
		Success,
		Error,
		Warning
	}

	public enum NotificationLocation
	{
		Top,
		Bottom,
		Custom
	}
}