using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nfind
{
    public class FindOptions
    {
        public string StringToFind { get; set; } = string.Empty;
        public bool IsCaseSensitive { get; set; } = true;
        public bool FindDontContains { get; set; } = false;
        public bool CountMode { get; set; } = false ;
        public bool ShowLineNumber { get; set; } = false;
        public bool ShipOfflineFiles { get; set; } = false;
        public string Path { get; set; } = string.Empty ;
        public bool HelpMode { get; set; } = false ;
    }
}
