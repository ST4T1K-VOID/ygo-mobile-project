using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ygo_mobile
{
    public class CardDisplayType: DataTemplateSelector
    {
        public DataTemplate GeneralTemplate { get; set; }
        public DataTemplate MonsterTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((Card)item).Type.Contains("Monster") ? MonsterTemplate : GeneralTemplate;
        }
    }
}
