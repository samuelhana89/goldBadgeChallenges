using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository
{
    public class KomodoInsurance
    {
        public int BadgeID { get; set; }
        public List<string> DoorName { get; set; }
        public string BadgeName { get; set; }

        public  KomodoInsurance() { }

        public KomodoInsurance(int badgeID,List<string> doorname, string badgename)
        {
            BadgeID = badgeID;
            DoorName = doorname;
            BadgeName = badgename;
        }

        
    }
}
