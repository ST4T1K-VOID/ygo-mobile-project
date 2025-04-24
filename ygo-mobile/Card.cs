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
        public string Tribe { get; set; }
        public string Attribute { get; set; }

        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }

        public Dictionary<string, string>? CardImages { get; set; } = new Dictionary<string, string>();

        //--misc info--
        public List<string>? CardSets { get; set; }
        //cardsets the card is in

        //public List<string>? CardPrices { get; set; }
        //NOTE: might not keep this


        /// <summary>
        /// instatiates a Card
        /// </summary>
        /// <param name="iD"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        /// <param name="tribe"></param>
        /// <param name="attribute"></param>
        /// <param name="level"></param>
        /// <param name="atk"></param>
        /// <param name="def"></param>
        public Card(string iD, string name, string description, string type, string tribe, string attribute, int level, int atk, int def)
        {
            ID = iD;
            Name = name;
            Description = description;
            Type = type;
            Tribe = tribe;
            Attribute = attribute;
            Level = level;
            Atk = atk;
            Def = def;
        }

        public Image? UrlToImage(string key)
        {
            if (CardImages == null)
            {
                return null;
            }
            else if (CardImages.ContainsKey(key))
            {
                Image image = new Image { Source = CardImages[key] };
                return image;
            }
            else
            {
                return null;
            }
        }
    }
}

