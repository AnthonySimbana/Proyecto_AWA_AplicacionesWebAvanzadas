using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWarcraftFriends
{
    public class Character
    {
        private string main = false;

        public string Class { get; set; }
        public string Faction { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public string Realm { get; set; }
        public string Region { get; set; }
        public string Race { get; set; }
        public string ThumbnailUrl { get; set; }
        public bool Main { get; set; } = false;
    }

}
