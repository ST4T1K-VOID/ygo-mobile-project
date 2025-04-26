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
            return string.Empty;
        }
    }
}
