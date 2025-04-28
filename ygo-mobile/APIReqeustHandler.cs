using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ygo_mobile;
namespace ygo_mobile
{
    class APIReqeustHandler
    {
        public List<string> GetArchetypes()
        {
            return new List<string>();
        }

        public async Task<List<Card>> SendRequest(Dictionary<string, string> variables)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponseMessage = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, FormatReqeust(variables)));

            string responseString = await httpResponseMessage.Content.ReadAsStringAsync();
            ResponseObject Cards = JsonConvert.DeserializeObject<ResponseObject>(responseString);

            List<Card> cards = new List<Card>();
            foreach (Datum card in Cards.data)
            {
                //cards.Add(new Card())
            }



            return new List<Card>();

        }

        private string FormatReqeust(Dictionary<string, string> variables)
        {
            string urlString = "https://db.ygoprodeck.com/api/v7/cardinfo.php?";
            string requestString = string.Empty;

            foreach (KeyValuePair<string, string> parameter in variables)
            {
                requestString = requestString + parameter.Key + "=" + parameter.Value + "&";
            }

            return urlString + requestString;
        }




    }





}
