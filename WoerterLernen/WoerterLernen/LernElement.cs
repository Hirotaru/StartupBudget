using System;
using System.Collections.Generic;
using System.Text;

namespace WoerterLernen
{
    class LernElement
    {
        public string ErsteSpracheWort { get; set; }
        public string ZweiteSpracheWort { get; set; }

        public string ErsteSpracheTranskription { get; set; }
        public string ZweiteSpracheTranskription { get; set; }

        public List<DateTime> FehlerDaten { get; set; }

    }
}
