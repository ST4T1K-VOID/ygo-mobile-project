using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ygo_mobile
{
    internal class APIHandler
    {

        public async Task<List<string>> GetArchetypes()
        {
            return new List<string>();
        }


        public async Task<List<Card>> RequestCards()
        {










            return new List<Card>();
        }

        public string FormatRequest(List<Dictionary<string, string>> searchVariables)
        {
            string requestSection = "https://db.ygoprodeck.com/api/v7/cardinfo.php?";
            string varSection = "";
            
            foreach (Dictionary<string, string> variable in searchVariables)
            {
                Dictionary<string, string> currentParameter = variable;
                foreach (KeyValuePair<string, string> parameter in variable)
                {
                    varSection = varSection + parameter.Key + "=" + parameter.Value;
                }
            }
            return requestSection + varSection;
        }
    }
}
