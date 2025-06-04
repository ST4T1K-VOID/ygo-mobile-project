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
        public Dictionary<string, Image>? CardImages { get; set; }
        public ImageSource GeneralImage { get; set; }

        public Card(int iD, string name, string description, string type, string tribe, Dictionary<string, string> cardimages)
        {
            ID = iD.ToString();
            Name = name;
            Description = description;
            Type = type;
            Tribe = tribe;
            CardImages = new Dictionary<string, Image>();
            foreach (KeyValuePair<string, string> image in cardimages)
            {
                CardImages.Add(image.Key, new Image { Source = image.Value});
            }
            GeneralImage = CardImages["image"].Source;
        }
    }
}

