using System.Security.Permissions;
using System.Web;
using System.Web.UI.WebControls;

namespace RonsHouse.FantasyGolf.Web.Controls
{
	[AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class BootstrapGridView : GridView
	{
		protected override void OnPreRender(System.EventArgs e)
		{
			base.OnPreRender(e);
			if (this != null && this.HeaderRow != null)
				this.HeaderRow.TableSection = TableRowSection.TableHeader;
		}
	}
}