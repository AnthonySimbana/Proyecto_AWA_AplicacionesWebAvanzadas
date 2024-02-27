using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

        public EWarcraftFriends.Character GetCharacterDetails(string region, string realm, string name)
        {
            string apiUrl = $"https://raider.io/api/v1/characters/profile?region={region}&realm={realm}&name={name}";

            try
            {
                using (WebClient client = new WebClient())
                {
                    string response = client.DownloadString(apiUrl);

                    JObject jsonResponse = JObject.Parse(response);

                    EWarcraftFriends.Character characterInfo = new EWarcraftFriends.Character
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

                    return characterInfo;
                }
            }
            catch (WebException ex)
            {
                // Retornar un valor indicativo de error, por ejemplo, -1
                return new EWarcraftFriends.Character
                {
                    Class = ex.Message,
                    Faction = ex.Message,
                    Gender = ex.Message,
                    Name = ex.Message,
                    Realm = ex.Message,
                    Region = ex.Message,
                    Race = ex.Message,
                    ThumbnailUrl = ex.Message,
                };
            }
        }
    }
}