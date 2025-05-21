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
        public string Tribe { get; set; } //known as 'race' by the API
        public Dictionary<string, string>? CardImages { get; set; }

        public Card(int iD, string name, string description, string type, string tribe, Dictionary<string, string> cardimages)
        {
            ID = iD.ToString();
            Name = name;
            Description = description;
            Type = type;
            Tribe = tribe;
            CardImages = cardimages;
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

