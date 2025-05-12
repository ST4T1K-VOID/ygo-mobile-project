using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ygo_mobile
{
    internal class MonsterCard
    {

        public int Level { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public string Attribute { get; set; }

        // Link properties

        public int Link { get; set; }
        public List<string> LinkMarkers { get; set; }
    }
}
