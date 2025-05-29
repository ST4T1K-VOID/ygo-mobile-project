using Microsoft.Maui.Controls.PlatformConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ygo_mobile
{
    internal class PendulumMonster : MonsterCard
    {
        public int? Scale { get; set; }
        public string PendDesc;

        public PendulumMonster(int iD, string name, string description, string type, string tribe, Dictionary<string, string> cardimages,
        int? level, int? attack, int? defense, string? attribute,
        int? scale)
        : base(iD, name, description, type, tribe, cardimages, level, attack, defense, attribute)
        {
            Scale = scale;
            SplitDescription();
        }

        private void SplitDescription()
        {
            int startIndex = Description.IndexOf("t ]") + 3;
            int endIndex = Description.IndexOf("[ M") - 19;
            PendDesc = Description.Substring(startIndex, endIndex).Trim();

            startIndex = Description.IndexOf("[ Mon") + 18;
            Description = Description.Substring(startIndex).Trim();
        }
    }
}
