using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RonsHouse.FantasyGolf.Web
{
	public class BasePage : Page
	{
		public Panel InfoPanel
		{
			get { return (Panel)base.Master.FindControl("message_label_panel"); }
		}
		public string InfoText
		{
			get { return ((Label)base.Master.FindControl("message_label")).Text; }
			set { ((Label)base.Master.FindControl("message_label")).Text = value; }
		}

		public Panel ErrorPanel
		{
			get { return (Panel)base.Master.FindControl("error_message_label_panel"); }
		}
		public string ErrorText
		{
			get { return ((Label)base.Master.FindControl("error_message_label")).Text; }
			set { ((Label)base.Master.FindControl("error_message_label")).Text = value; }
		}
	}
}
