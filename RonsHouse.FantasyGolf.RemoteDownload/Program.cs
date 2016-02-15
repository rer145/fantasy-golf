using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using HtmlAgilityPack;

namespace RonsHouse.FantasyGolf.RemoteDownload
{
	class Program
	{
		static void Main(string[] args)
		{
			//DownloadTournaments();
			//DownloadPlayers();
			DownloadResults("r", "003", "2016");

			Console.ReadLine();
		}

		private static void DownloadResults(string tourCode, string permNumber, string year)
		{
			//lookup name in database
			//parse out fancy chars
			//pull down data
			//parse and save

			string baseUrl = "http://www.pgatour.com/tournaments/{0}/past-results/jcr:content/mainParsys/pastresults.selectedYear.{1}.html";
			string url = "";
			bool resultsExist = false;

			string nameO = "";
			string nameL = "";
			string nameM = "";
			string nameS = "";
			
			Console.WriteLine("*** PLAYERS ***");
			Console.WriteLine(" - Determining URL");
			
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
			{
				conn.Open();

				using (SqlCommand cmd = new SqlCommand("Remote_Tournament_Get", conn))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.Add(new SqlParameter("@TourCode", tourCode));
					cmd.Parameters.Add(new SqlParameter("@PermNumber", permNumber));

					using(IDataReader data = cmd.ExecuteReader())
					{
						while (data.Read())
						{
							nameO = ParseNameAsUrl(data["OfficialName"].ToString());
							nameL = ParseNameAsUrl(data["LongName"].ToString());
							nameM = ParseNameAsUrl(data["MediumName"].ToString());
							nameS = ParseNameAsUrl(data["ShortName"].ToString());
						}
						data.Close();
					}
				}

				conn.Close();
			}

			url = String.Format(baseUrl, nameO, year);
			//Console.WriteLine("Results URL: " + url);
			Console.WriteLine(" - Checking Official Name URL");
			try
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.Method = WebRequestMethods.Http.Head;
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				resultsExist = response.StatusCode == HttpStatusCode.OK;

				if (resultsExist)
					ParsePastResults(tourCode, permNumber, year, url);
			}
			catch { }

			if (!resultsExist)
			{
				url = String.Format(baseUrl, nameL, year);
				//Console.WriteLine("Results URL: " + url);
				Console.WriteLine(" - Checking Long Name URL");
				try
				{
					HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
					request.Method = WebRequestMethods.Http.Head;
					HttpWebResponse response = (HttpWebResponse)request.GetResponse();
					resultsExist = response.StatusCode == HttpStatusCode.OK;

					if (resultsExist)
						ParsePastResults(tourCode, permNumber, year, url);
				}
				catch { }
			}

			if (!resultsExist)
			{
				url = String.Format(baseUrl, nameM, year);
				//Console.WriteLine("Results URL: " + url);
				Console.WriteLine(" - Checking Medium Name URL");
				try
				{
					HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
					request.Method = WebRequestMethods.Http.Head;
					HttpWebResponse response = (HttpWebResponse)request.GetResponse();
					resultsExist = response.StatusCode == HttpStatusCode.OK;

					if (resultsExist)
						ParsePastResults(tourCode, permNumber, year, url);
				}
				catch { }
			}

			if (!resultsExist)
			{
				url = String.Format(baseUrl, nameS, year);
				//Console.WriteLine("Results URL: " + url);
				Console.WriteLine(" - Checking Short Name URL");
				try
				{
					HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
					request.Method = WebRequestMethods.Http.Head;
					HttpWebResponse response = (HttpWebResponse)request.GetResponse();
					resultsExist = response.StatusCode == HttpStatusCode.OK;

					if (resultsExist)
						ParsePastResults(tourCode, permNumber, year, url);
				}
				catch { }
			}

			if (!resultsExist)
			{
				Console.WriteLine(" - Cannot determine URL");
			}
		}

		private static void ParsePastResults(string tourCode, string permNumber, string year, string url)
		{
			string html = "";

			Console.WriteLine(" - Downloading");
			using (WebClient client = new WebClient())
			{
				html = client.DownloadString(url);
			}

			if (!String.IsNullOrEmpty(html))
			{
				//html = "<root>" + html + "</root>";
				html = html.Replace("<option ", "<my_option ").Replace("</option>", "</my_option");
				
				Console.WriteLine(" - Parsing HTML");
				HtmlDocument doc = new HtmlDocument();
				doc.OptionFixNestedTags = true;
				doc.OptionCheckSyntax = false;
				doc.OptionAutoCloseOnEnd = false;
				doc.LoadHtml(html);

				if (doc.ParseErrors != null && doc.ParseErrors.Count() > 0)
				{
					Console.WriteLine("   - Parse Errors:");
					foreach (var error in doc.ParseErrors)
					{
						Console.WriteLine("     - " + error.Reason);
					}
				}
				else
				{
					if (doc.DocumentNode != null)
					{
						HtmlNodeCollection rows = doc.DocumentNode.SelectNodes("//table//tr");
						Console.WriteLine("   - Total Rows: " + rows.Count.ToString());
						for (int i = 3; i < rows.Count; i++)
						{
							HtmlNodeCollection cells = rows[i].SelectNodes("td");
							string name = cells[0].InnerText.Trim();
							string position = cells[1].InnerText.Trim();
							decimal winnings = Convert.ToDecimal(cells[cells.Count - 2].InnerText.Trim().Replace("$", ""));
							decimal points = Convert.ToDecimal(cells[cells.Count - 1].InnerText.Trim());
							
							Console.WriteLine(String.Format("Name: {0} / Position: {1} / Winnings: {2} / Points: {3}", name, position, winnings.ToString(), points.ToString()));
						}
					}
				}
			}

			Console.WriteLine("Done");
		}

		private static string ParseNameAsUrl(string name)
		{
			StringBuilder output = new StringBuilder();
			char[] temp = name.ToCharArray();
			
			foreach (char c in temp)
			{
				if (!char.IsLetterOrDigit(c))
				{
					output.Append("-");
				}
				else
				{
					output.Append(char.ToLower(c));
				}
			}

			return output.ToString();
		}

		private static void DownloadPlayers()
		{
			string json = "";

			Console.WriteLine("*** PLAYERS ***");
			Console.WriteLine(" - Downloading");
			using (WebClient client = new WebClient())
			{
				json = client.DownloadString("http://www.pgatour.com/content/pgatour/players/jcr:content/mainParsys/players_directory.players.json");
			}

			Console.WriteLine(" - Parsing");
			if (!String.IsNullOrEmpty(json))
			{
				var serializer = new JavaScriptSerializer();
				serializer.MaxJsonLength = 10000000;
				serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
				dynamic players = serializer.Deserialize(json, typeof(object));

				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
				{
					conn.Open();

					foreach (var player in players.players)
					{
						using (SqlCommand cmd = new SqlCommand("Remote_Golfer_Save", conn))
						{
							cmd.CommandType = CommandType.StoredProcedure;
							cmd.Parameters.Add(new SqlParameter("@Id", player.id));
							cmd.Parameters.Add(new SqlParameter("@Name", player.name));
							cmd.Parameters.Add(new SqlParameter("@CountryCode", player.country));
							cmd.Parameters.Add(new SqlParameter("@CountryName", player.countryName));

							Console.WriteLine("      - Saving: " + player.name);
							cmd.ExecuteNonQuery();
						}
					}

					conn.Close();
				}
			}

			Console.WriteLine(" - Done");
		}

		private static void DownloadTournaments()
		{
			string json = "";

			Console.WriteLine("*** TOURNAMENTS ***");
			Console.WriteLine(" - Downloading");
			using (WebClient client = new WebClient())
			{
				json = client.DownloadString("http://www.pgatour.com/data/r/current/schedule.json");
			}

			Console.WriteLine(" - Parsing");
			if (!String.IsNullOrEmpty(json))
			{
				var serializer = new JavaScriptSerializer();
				serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
				dynamic schedule = serializer.Deserialize(json, typeof(object));

				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
				{
					conn.Open();

					Console.WriteLine(" - Tours");
					foreach (var tour in schedule.tours)
					{						
						Console.WriteLine("    - " + tour.desc + " ( " + tour.trns.Count.ToString() + " tournaments)");
						foreach (var tournament in tour.trns)
						{
							//HACK: only pull PGA events since data format is different for other tours (i.e. no FedExCup)
							if (tour.tourCodeLc == "r")
							{
								using (SqlCommand cmd = new SqlCommand("Remote_Tournament_Save", conn))
								{
									cmd.CommandType = CommandType.StoredProcedure;
									cmd.Parameters.Add(new SqlParameter("@TourCode", tour.tourCodeLc));
									cmd.Parameters.Add(new SqlParameter("@Season", tournament.year));
									cmd.Parameters.Add(new SqlParameter("@PermNumber", tournament.permNum));
									cmd.Parameters.Add(new SqlParameter("@TournamentNumber", tournament.trnNum));
									cmd.Parameters.Add(new SqlParameter("@TournamentType", tournament.trnType));
									cmd.Parameters.Add(new SqlParameter("@OfficialName", tournament.trnName.official));
									cmd.Parameters.Add(new SqlParameter("@LongName", tournament.trnName.@long));
									cmd.Parameters.Add(new SqlParameter("@MediumName", tournament.trnName.medium));
									cmd.Parameters.Add(new SqlParameter("@ShortName", tournament.trnName.@short));
									cmd.Parameters.Add(new SqlParameter("@IsOfficial", tournament.official.ToLower() == "yes" ? true : false));
									cmd.Parameters.Add(new SqlParameter("@IsFedExCup", tournament.FedExCup.ToLower() == "yes" ? true : false));
									cmd.Parameters.Add(new SqlParameter("@IsPrimaryEvent", tournament.primaryEvent.ToUpper() == "Y" ? true : false));
									cmd.Parameters.Add(new SqlParameter("@FedExCupPurse", Convert.ToDecimal(String.IsNullOrEmpty(tournament.FedExCupPurse) ? "0" : tournament.FedExCupPurse)));
									cmd.Parameters.Add(new SqlParameter("@FedExCupWinnerPoints", Convert.ToDecimal(String.IsNullOrEmpty(tournament.FedExCupWinnerPoints) ? "0" : tournament.FedExCupWinnerPoints)));
									cmd.Parameters.Add(new SqlParameter("@TotalPurse", Convert.ToDecimal(String.IsNullOrEmpty(tournament.Purse) ? "0" : tournament.Purse)));
									cmd.Parameters.Add(new SqlParameter("@TotalWinnerShare", Convert.ToDecimal(String.IsNullOrEmpty(tournament.winnersShare) ? "0" : tournament.winnersShare)));
									cmd.Parameters.Add(new SqlParameter("@BeginsOn", Convert.ToDateTime(String.IsNullOrEmpty(tournament.date.start) ? DateTime.MinValue : tournament.date.start)));
									cmd.Parameters.Add(new SqlParameter("@EndsOn", Convert.ToDateTime(String.IsNullOrEmpty(tournament.date.end) ? DateTime.MinValue : tournament.date.end)));

									Console.WriteLine("      - Saving: " + tournament.trnName.@short);
									cmd.ExecuteNonQuery();
								}
							}
						}
					}

					conn.Close();
				}
			}

			Console.WriteLine(" - Done");
		}
	}
}
