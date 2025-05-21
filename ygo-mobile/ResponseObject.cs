using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ygo_mobile
{
    public class ResponseObject
    {
        public List<Datum> data { get; set; }

        public List<Card> ConvertToCards()
        {
            List<Card> cards = new List<Card>();

            foreach (Datum card in data)
            {
                Dictionary<string, string> imageDictionary = new Dictionary<string, string>
                {
                    { "image_url", card.card_images.First().image_url },
                    { "image_url_small", card.card_images.First().image_url_small },
                    { "image_url_cropped", card.card_images.First().image_url_cropped }
                };

                if (card.type.Contains("Pendulum"))
                {
                    cards.Add(new PendulumMonster(card.id, card.name, card.desc, card.type, card.race, imageDictionary, card.level, card.atk, card.def, card.attribute, card.scale));
                }
                else if (card.type.Contains("Link"))
                {
                    cards.Add(new MonsterCard(card.id, card.name, card.desc, card.type, card.race, imageDictionary, card.level, card.atk, card.def, card.attribute, card.link, card.linkmarker));
                }
                else if (card.type.Contains("Monster"))
                {
                    cards.Add(new MonsterCard(card.id, card.name, card.desc, card.type, card.race, imageDictionary, card.level, card.atk, card.def, card.attribute));
                }
                else
                {
                    cards.Add(new Card(card.id, card.name, card.desc, card.type, card.race, imageDictionary));
                }

            }

            return cards;
        }


    };


    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public string race { get; set; }
        public string? attribute { get; set; }
        public int? link { get; set; }
        public List<string>? linkmarker { get; set; }
        public int? scale { get; set; }
        public int? atk { get; set; }
        public int? def { get; set; }
        public int? level { get; set; }
        public string? archetype { get; set; }
        public string? ygoprodeck_url { get; set; }
        //public Card_Sets[] card_sets { get; set; }
        public Card_Images[]? card_images { get; set; }
        //public Card_Prices[] card_prices { get; set; }
        //}

        //public class Card_Sets
        //{
        //    public string set_name { get; set; }
        //    public string set_code { get; set; }
        //    public string set_rarity { get; set; }
        //    public string set_rarity_code { get; set; }
        //    public string set_price { get; set; }
        //}

        public class Card_Images
        {
            public int id { get; set; }
            public string image_url { get; set; }
            public string image_url_small { get; set; }
            public string image_url_cropped { get; set; }
        }

        //public class Card_Prices
        //{
        //    public string cardmarket_price { get; set; }
        //    public string tcgplayer_price { get; set; }
        //    public string ebay_price { get; set; }
        //    public string amazon_price { get; set; }
        //    public string coolstuffinc_price { get; set; }
        //}
    }
}


