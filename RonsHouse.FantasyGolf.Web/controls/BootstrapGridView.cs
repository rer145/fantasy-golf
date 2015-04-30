using System.Web.UI.WebControls;

namespace RonsHouse.FantasyGolf.Web.Controls
{
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