using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
namespace MicroServiceWCFCharacter
{
    /// <summary>
    /// Summary description for MicroServiceCharacter
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MicroServiceCharacter : System.Web.Services.WebService
    {

        [WebMethod]
        public EWarcraftFriends.CharacterInfo GetCharacterDetails(string region, string realm, string name)
        {
            try
            {
                string apiUrl = $"https://raider.io/api/v1/characters/profile?region={region}&realm={realm}&name={name}";
                string response = MakeWebRequest(apiUrl);
                return ParseCharacterDetails(response);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return new EWarcraftFriends.CharacterInfo();
            }
        }

        private string MakeWebRequest(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                return client.GetStringAsync(apiUrl).Result;
            }
        }

        private EWarcraftFriends.CharacterInfo ParseCharacterDetails(string response)
        {
            JObject jsonResponse = JObject.Parse(response);

            return new EWarcraftFriends.CharacterInfo
            {
                Class = jsonResponse.SelectToken("class")?.Value<string>() ?? "",
                Faction = jsonResponse.SelectToken("faction")?.Value<string>() ?? "",
                Gender = jsonResponse.SelectToken("gender")?.Value<string>() ?? "",
                Name = jsonResponse.SelectToken("name")?.Value<string>() ?? "",
                Realm = jsonResponse.SelectToken("realm")?.Value<string>() ?? "",
                Region = jsonResponse.SelectToken("region")?.Value<string>() ?? "",
                Race = jsonResponse.SelectToken("race")?.Value<string>() ?? "",
                ThumbnailUrl = jsonResponse.SelectToken("thumbnail_url")?.Value<string>() ?? ""
            };
        }

        private void LogError(Exception ex)
        {
        }
    }
}