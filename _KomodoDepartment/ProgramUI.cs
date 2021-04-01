using _KomodoDepartment_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _KomodoDepartment
{
    class ProgramUI
    {
        private KomodoDepartmentRepository _claimRepo = new KomodoDepartmentRepository();
        public void Run()
        {
            ClaimList();
            Menu();
        }
        private void Menu()
        {
            bool KeepRunnning = true;
            while (KeepRunnning)
            {
                Console.WriteLine("Choose a menu item: \n" +
                "1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new claim\n" +
                "4.Exit");

                string input = Console.ReadLine();


                switch (input)
                {
                    case "1":
                        //See all claims
                        SeeAllClaim();
                        break;

                    case "2":
                        //Take care of next claim
                        TakeCareOfClaim();
                        break;

                    case "3":
                        //Enter a new claim
                        AddNewClaim();
                        break;

                    case "4":
                        //Exit
                        Console.WriteLine("Thank You ");
                        KeepRunnning = false;
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

        //See all claims(read)
        private void SeeAllClaim()
        {
            Console.Clear();

            Queue<KomodoDepartment> listOfClaim = _claimRepo.GetClaimList();
            Console.WriteLine("ClaimID\t Claim Type\t Description \t\t Amount\t Date Of Accident \t Date Of Claim \t Is Valid");

            foreach (KomodoDepartment claim in listOfClaim)
            {
                Console.WriteLine(claim);
                
            }

        }

        //Take care of next claim(delete if claim agent says yes)
        private void TakeCareOfClaim()
        {
            Console.Clear();
            if (_claimRepo.GetClaimList().Count == 0)
            {
                Console.WriteLine("The list empty, no work available");
                return;
            }
            Console.WriteLine("This the current claim\n" +
                _claimRepo.ViewNextClaim   ()) ;

            Console.WriteLine("");
            Console.WriteLine("Do you want to deal with this claim now(y/n)? ");
            string input = Console.ReadLine().ToLower();

            if (input.Equals("y")) 
            {
                _claimRepo.pullTopClaim();
            }
            


        }

        //Enter a new claim(create)
        private void AddNewClaim()
        {
            Console.Clear();

            KomodoDepartment newClaim = new KomodoDepartment();

            //claim ID
            Console.WriteLine("Please,Enter claim ID");
            newClaim.ClaimID = Convert.ToInt32(Console.ReadLine());

            //claim type
            Console.WriteLine("Please,Enter claim Type");
            newClaim.ClaimType = Console.ReadLine();

            //Description
            Console.WriteLine("Please,Enter claim Description");
            newClaim.Description = Console.ReadLine();

            //claim amount
            Console.WriteLine("Please,Enter claim amount");
            newClaim.ClaimAmount = Convert.ToDouble (Console.ReadLine());

            //date of Incident
            Console.WriteLine("Please,Enter claim date of Incident (mm/dd/yyyy)");
            string dateOfIncidentAsString = Console.ReadLine();
            newClaim.DateOfIncident = DateTime.Parse(dateOfIncidentAsString);

            //Date Of Claim
            Console.WriteLine("Please,Enter claim date of claim (mm/dd/yyyy)");
            string dateOfClaimAsString = Console.ReadLine();
            newClaim.DateOfClaim = DateTime.Parse(dateOfClaimAsString);

            //is valid
            Console.WriteLine("IS the claim valid? (y/n)");
            string validString = Console.ReadLine().ToLower();

            if (validString == "y")
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }

            //to add the new claim to the list 
            _claimRepo.AddClaimToList(newClaim);
        }

        
        
        //Claim List 
        private void ClaimList()
        {
            KomodoDepartment car = new KomodoDepartment(1, "Car", "Car accident on 465", 400.00, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            KomodoDepartment Home = new KomodoDepartment(2, "Home", "House fire in kitchen.", 4000.00, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12), true);
            KomodoDepartment Theft = new KomodoDepartment(3, "Theft", "Stolen pancakes.", 4.00, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

            _claimRepo.AddClaimToList(car);
            _claimRepo.AddClaimToList(Home);
            _claimRepo.AddClaimToList(Theft);



        }
    }
}


