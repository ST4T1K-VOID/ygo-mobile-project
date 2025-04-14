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
        public string Description { get; set; }


        public string Type { get; set; }
        public string Race { get; set; }
        public string Attribute { get; set; }

        public int Level { get; set; }
        public int? Atk { get; set; }
        public int? Def { get; set; }

        public List<string> CardImages { get; set; }

        //--misc info--
        public List<string>? CardSets { get; set; }
        //cardsets the card is in

        //public List<string>? CardPrices { get; set; }
        //NOTE: might not keep this

        
        public Card(string iD, string name, string desc, string type, string race, string attribute, int level, int atk, int def, List<string> cardImages, List<string> cardSets, List<string> cardPrices)
        {
            ID = iD;
            Name = name;
            Description = desc;
            Type = type;
            Race = race;
            Attribute = attribute;
            Level = level;
            Atk = atk;
            Def = def;
            CardImages = cardImages;
            CardSets = cardSets;
        }
    }

}

