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
        public string? Pendulum_Description { get; set; }

        public string Type { get; set; }
        public string Tribe { get; set; }
        public string Attribute { get; set; }

        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }

        //other card attributes
        //public int Pend_Scale { get; set; }
        public List<String> LinkMarkers { get; set; }

        public Dictionary<string, string>? CardImages { get; set; } = new Dictionary<string, string>();


        //--misc info--
        //public List<string>? CardSets { get; set; }
        //cardsets that include the card

        //public List<string>? CardPrices { get; set; }
        //NOTE: might not keep this

        

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

