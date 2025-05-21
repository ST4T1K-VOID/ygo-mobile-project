using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ygo_mobile
{
    internal class MonsterCard : Card
    {

        public int? Level { get; set; }
        public int? Atk { get; set; }
        public int? Def { get; set; }
        public string? Attribute { get; set; }

        // Link properties

        public int? LinkValue { get; set; }
        public List<string>? LinkMarkers { get; set; }

        public MonsterCard(int iD, string name, string description, string type, string tribe, Dictionary<string, string> cardimages,
            int? level, int? attack, int? defense, string? attribute, int? linkValue = null, List<string>? linkMakers = null)
            : base(iD, name, description, type, tribe, cardimages)
        {
            Level = level;
            Atk = attack;
            Def = defense;
            Attribute = attribute;
            LinkValue = linkValue;
            LinkMarkers = new List<string>();
        }
    }
}
