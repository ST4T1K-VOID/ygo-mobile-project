using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ygo_mobile
{
    public class Card
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string desc { get; set; }


        public string Type { get; set; }
        public string Race { get; set; }
        public string Attribute { get; set; }

        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }

        public List<string> CardImages { get; set; }

        //misc info
        public List<string> CardSets { get; set; }
        //cardsets this card is in
        public List<string> CardPrices { get; set; }
        //NOTE: might not keep this
    }

}

