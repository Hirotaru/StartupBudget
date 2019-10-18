using System;
using System.Collections.Generic;
using System.Text;

namespace WoerterLernen
{
    public class LernElement
    {
        public string ErsteSpracheWort { get; set; }
        public string ZweiteSpracheWort { get; set; }

        public string ErsteSpracheTranskription { get; set; }
        public string ZweiteSpracheTranskription { get; set; }

        public List<DateTime> FehlerDaten { get; set; } = new List<DateTime>();

        public LernElement(string w1, string w2, string t1, string t2 = "")
        {
            ErsteSpracheWort = w1;
            ZweiteSpracheWort = w2;
            ErsteSpracheTranskription = t1;
            ZweiteSpracheTranskription = t2;
        }
    }
}
