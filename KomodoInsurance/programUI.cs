using KomodoInsurance_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _KomodoInsurance
{

    class programUI
    {
        private KomodoInsuranceRepository _badgeRepo = new KomodoInsuranceRepository();
        public void Run()
        {
            BagdeList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine($"Hello Security Admin, What would you like to do?\n" +
                    $"1.Add a badge\n" +
                    $"2.Edit a badge\n" +
                    $"3.List all Badges\n" +
                    $"4.Exit");

                string input = Console.ReadLine();

                switch (input)
                {

                    case "1":
                        //Add a badge
                        AddBagde();
                        break;

                    case "2":
                        //Edit a bagde
                        EditBagde();

                        break;

                    case "3":
                        //List all Badges
                        ListAllBadges();

                        break;

                    case "4":
                        //exit
                        Console.WriteLine("Thank You ");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please, Enter a valid number..");
                        break;




                }
                Console.WriteLine("");
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }

        }


        //Add a badge
        private void AddBagde()
        {
            Console.Clear();

            KomodoInsurance NewBadge = new KomodoInsurance();


            Console.WriteLine("What is the number on the badge;");
            NewBadge.BadgeID = Convert.ToInt32(Console.ReadLine());


            String userInput = "n";

            //init a new list of door names
            NewBadge.DoorName = new List<string>();

            do
            {
                Console.WriteLine("List a door that it needs access to:");
                NewBadge.DoorName.Add(Console.ReadLine());

                Console.WriteLine("Any other doors(y/n)?");
                userInput = Console.ReadLine().ToLower();
            }
            while (userInput.Equals("y"));

            _badgeRepo.AddBagde(NewBadge);


        }

        //update a bagde
        private void EditBagde()
        {
            Console.Clear();

            

            Console.WriteLine("What is the badge number to update?");
            int badgeNum = Convert.ToInt32(Console.ReadLine());

            List<string> doors = _badgeRepo.GetDoorList(badgeNum);

            Console.WriteLine("");
            if (doors.Count > 0)
            {
                Console.WriteLine(badgeNum + " has access to doors " + String.Join(" & ", doors));
            }
            else
            {
                Console.WriteLine(badgeNum + " has NO access to doors ");
            }
           
            //Add or Remove Door access
            Console.WriteLine("");
            Console.WriteLine("What would you like to do?\n" +
                "1.Remove a door\n" +
                "2.Add a door");
            string input = Console.ReadLine();

            // remove door access
            if (input == "1")
            {
                if (doors.Count> 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Which door would you like to remove?");
                    string doorInput = Console.ReadLine().ToUpper();

                    _badgeRepo.RemoveDoor(badgeNum, doorInput);

                    Console.WriteLine("");
                    Console.WriteLine("Door removed");

                    Console.WriteLine("");

                    if (doors.Count > 0)
                    {
                        Console.WriteLine(badgeNum + " has access to doors " + String.Join(" & ", doors));

                    }
                    else
                    {
                        Console.WriteLine(badgeNum + " has no door access");
                    }
                }
                else
                {
                    Console.WriteLine(badgeNum + " has no door access");
                }
            }

            //Add door access
            else if (input == "2")
            {
                Console.WriteLine("");
                Console.WriteLine("What door would you like to Add?");
                string doorInput = Console.ReadLine().ToUpper();

                _badgeRepo.AddDoor(badgeNum, doorInput);

                Console.WriteLine("");
                Console.WriteLine("Door Added");

                Console.WriteLine("");
                Console.WriteLine(badgeNum + " has access to doors " + String.Join(" & ", doors));
            }


        }

        //List all Badges
        private void ListAllBadges()
        {
            Console.Clear();

            Dictionary<int, List<string>> listOfBadges = _badgeRepo.GetBadgeList();
            Console.WriteLine("Badge #\t\tDoor Access");
            foreach (KeyValuePair<int, List<string>> entry in listOfBadges)
            {
                Console.WriteLine(entry.Key + "\t\t" + string.Join(",", entry.Value));

            }


        }


        //Badge list 
        private void BagdeList()
        {
            KomodoInsurance Developer = new KomodoInsurance(12345, "A7".Split(',').ToList<String>(), "Developer");
            KomodoInsurance claimAgent = new KomodoInsurance(22345, "A1, A4, B1, B2".Split(',').ToList<String>(), "claimAgent");
            KomodoInsurance employee = new KomodoInsurance(32345, "A4, A5".Split(',').ToList<String>(), "employee");

            _badgeRepo.AddBagde(Developer);
            _badgeRepo.AddBagde(claimAgent);
            _badgeRepo.AddBagde(employee);




        }

    }


}
