using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Preferences
    {
        public Dictionary<Style, double> StylePreferences { get; private set; }
        public int PagesNumberPreference { get; private set; }
        public HashSet<Writer> WritersPreferences { get; private set; }

        public Preferences(Dictionary<Style, double> style=null, int pagesNumber=200, HashSet<Writer> writers=null)
        {
            if (style != null)
                StylePreferences = style;
            else
                StylePreferences = new Dictionary<Style, double>() {
                { Style.Novel, 8 },
                { Style.Tale, 8 },
                { Style.Lyrics, 8 }
            };
            PagesNumberPreference = pagesNumber;
            if (writers != null)
                WritersPreferences = writers;
            else
                WritersPreferences = new HashSet<Writer>();
        }
    }
}
