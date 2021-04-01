using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance_Repository
{
    public class KomodoInsuranceRepository
    {

        private Dictionary<int, List<string>> _listOfBadges = new Dictionary<int, List<string>>();


        //create(adding)
        public void AddBagde(KomodoInsurance badge)
        {
            if (badge != null)
            {
                _listOfBadges.Add(badge.BadgeID, badge.DoorName);
            }

        }

        //update
        //public void UpdateBadge(KomodoInsurance badge)
        //{
        //    _listOfBadges.Add(badge.BadgeID, badge.DoorName);
        //}


        //read
        public Dictionary<int, List<string>> GetBadgeList()
        {
            return _listOfBadges;
        }

        //get door list by badge number
        public List<string> GetDoorList(int BadgeNumber)
        {
            if (! _listOfBadges.ContainsKey(BadgeNumber))
            {
                Console.WriteLine("Sorry,We couldn't find that BadgeID");
                return new List<string>();
            }
            return _listOfBadges[BadgeNumber];
        }

        // remove door access 
        public void RemoveDoor(int badgeID, string doorName)
        {
            if (!_listOfBadges.ContainsKey(badgeID))
            {
                Console.WriteLine("Sorry,We couldn't find that BadgeID");
                return;
            }

            List<string> doors = _listOfBadges[badgeID];
            doors.Remove(doorName);
            _listOfBadges[badgeID] = doors;

        }

        //Add door access
        public void AddDoor(int badgeID, string doorName)
        {
            List<string> doors = _listOfBadges[badgeID];
            doors.Add(doorName);
            _listOfBadges[badgeID] = doors;
        }

    }
}
