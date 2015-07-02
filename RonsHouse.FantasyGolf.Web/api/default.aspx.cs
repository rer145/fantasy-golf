using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Newtonsoft.Json;

using RonsHouse.FantasyGolf.EF;
using RonsHouse.FantasyGolf.Services;
using RonsHouse.FantasyGolf.Web.Controls;

namespace RonsHouse.FantasyGolf.Web.Api
{
	public partial class DefaultPage : System.Web.UI.Page
	{
		private string _method = String.Empty;
		
		protected void Page_Load(object sender, EventArgs e)
		{
			ApiResult result = new ApiResult();
			result.Success = false;
			result.Message = "Unknown error occurred";
			
			Dictionary<string, string> _params = new Dictionary<string, string>();
			foreach (var key in Request.QueryString.AllKeys)
			{
				if (key == "m")
					_method = Request.QueryString[key];

				if (key.StartsWith("p_"))
				{
					_params.Add(key.Replace("p_", ""), Request.QueryString[key]);
				}
			}

			//Response.Write("method: " + _method + "<br />");
			//Response.Write("params: <br />");
			//foreach (var x in _params.Keys)
			//{
			//	Response.Write(x + ": " + _params[x] + "<br />");
			//}
			
			switch (_method.ToLower())
			{
				case "save-user-pick":
					result = SaveUserPick(_params);
					break;
				default:
					result.Message = "Method could not be found";
					break;
			}

			Response.Write(JsonConvert.SerializeObject(result));
		}

		private ApiResult SaveUserPick(Dictionary<string, string> p)
		{
			ApiResult result = new ApiResult();
			
			try
			{
				int tournamentId = Convert.ToInt32(p["tournament"]);
				int userId = Convert.ToInt32(p["user"]);
				int golferId = Convert.ToInt32(p["golfer"]);

				if (tournamentId > 0 && userId > 0 && golferId > 0)
				{
					UserPickService.Save(userId, tournamentId, golferId);
					result.Success = true;
				}
				else
				{
					result.Success = false;
					result.Message = "One of the parameters was missing";
				}
			}
			catch (Exception ex)
			{
				result.Success = false;
				result.Message = ex.Message;
			}

			return result;
		}
	}

	public class ApiResult
	{
		public bool Success { get; set; }
		public string Message { get; set; }
	}
}