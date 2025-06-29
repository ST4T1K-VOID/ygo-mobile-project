﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public async Task<List<string>> GetArchetypes()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage httpResponseMessage = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://db.ygoprodeck.com/api/v7/archetypes.php"));
            string responseString = await httpResponseMessage.Content.ReadAsStringAsync();

            
            JArray array = JArray.Parse(responseString);
            List<string> archetypes = new List<string>();
            foreach (JObject token in array)
            {
                string type = token.GetValue("archetype_name").ToString();
                archetypes.Add(type);
            }
            return archetypes;
        }

        public async Task<List<Card>> SendRequest(Dictionary<string, string> variables)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage? httpResponseMessage = new HttpResponseMessage();
            Console.WriteLine(FormatReqeust(variables));
            string temp = FormatReqeust(variables);
            Console.WriteLine();
            try
            {
                httpResponseMessage = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, FormatReqeust(variables)));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return [];
            }
            

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"{httpResponseMessage.StatusCode}");
            }

            string responseString = await httpResponseMessage.Content.ReadAsStringAsync();

            ResponseObject Cards = JsonConvert.DeserializeObject<ResponseObject>(responseString);

            return Cards.ConvertToCards();
        }
        
        private string FormatReqeust(Dictionary<string, string> variables)
        {
            string urlString = "https://db.ygoprodeck.com/api/v7/cardinfo.php?";
            string requestString = string.Empty;

            int count = 0;
            foreach (KeyValuePair<string, string> parameter in variables)
            {
                if (count == 0)
                {
                    requestString = requestString + parameter.Key + "=" + parameter.Value;
                    count++;
                    continue;
                }
                else
                {
                    requestString = requestString + "&" + parameter.Key + "=" + parameter.Value;
                }
            }
            return urlString + requestString;
        }
    }
}
