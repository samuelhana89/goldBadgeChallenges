using _KomodoCafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _KomodoCafe_ConsoleApp
{
    class programUI
    {
        private MenuContentRepository _contectRepo = new MenuContentRepository();

        public void Run()
        {
            MenuList();
            Menu();
        }
        public void Menu()
        {
            bool KeepRunning = true;
            while (KeepRunning)
            {

                Console.WriteLine(" Select a menu option: \n" +
                    "1. Add a new Meal\n" +
                    "2. View all meals\n" +
                    "3. View meal by name\n" +
                    "4. Delete meal\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Add a new Meal
                        AddNewMeal();
                        break;

                    case "2":
                        //View all meals
                        ViewAllMeals();
                        break;

                    case "3":
                        //View meal by name
                        ViewMealByName();
                        break;

                    case "4":
                        //Delete meal
                        DeleteMeal();
                        break;

                    case "5":
                        //Exit
                        Console.WriteLine("Thank You ");
                        KeepRunning = false;
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
        //Add a new Meal
        private void AddNewMeal()
        {
            Console.Clear();

            MenuContent NewContent = new MenuContent();

            //MealNumber
            Console.WriteLine("Enter the meal number ");
            NewContent.MealNumber = Convert.ToInt32 (Console.ReadLine());

            //MealName
            Console.WriteLine("Enter the meal name ");
            NewContent.MealName = Console.ReadLine();

            //Description
            Console.WriteLine("Enter the meal description ");
            NewContent.Description = Console.ReadLine();

            //Ingredients
            Console.WriteLine("Enter the meal Ingredients(with comma seperated )");
            NewContent.Ingredients = Console.ReadLine().Split(',').ToList<String>();
           

            //Price
            Console.WriteLine("Enter the meal price ");
            string PriceAsString = Console.ReadLine();
            NewContent.Price = double.Parse(PriceAsString);

            _contectRepo.AddContentToList(NewContent);


        }

        
        
        //View all meals
        private void ViewAllMeals()
        {
            Console.Clear();

            List<MenuContent> listOfContent = _contectRepo.GetContentList();
            
            foreach(MenuContent content in listOfContent)
            {
                Console.WriteLine( $"Meal number : {content.MealNumber}\n" + $"Meal Name : {content.MealName}" );
            }
        }



        //View meal by name
        private void ViewMealByName()
        {
            Console.Clear();

            Console.WriteLine("Enter the Meal name ");
            string mealName = Console.ReadLine();

            MenuContent content = _contectRepo.GetContentByName(mealName);
            if (content != null)
            {
                Console.WriteLine("");
                Console.WriteLine($"Meal number: {content.MealNumber}\n" + $"Meal Name: {content.MealName}\n" +
                    $"Description: {content.Description}\n" +
                    $"Ingredients: {string.Join(",",content.Ingredients)}\n" +
                    $"Price: ${content.Price}");
            }
            else
            {
                Console.WriteLine("No Item by that name");
            }
        }


        //Delete meal
        private void DeleteMeal()
        {
            ViewAllMeals();

            Console.WriteLine("\nEnter meal name you want to delete :");

            string remove = Console.ReadLine();

            //call the delete method
            bool wasRemoved =_contectRepo.DeleteContentFromList(remove);

            if (wasRemoved)
            {
                Console.WriteLine("The Meal was removed from the menu");
            }
            else
            {
                Console.WriteLine("The Meal couldn't be removed from the menu");
            }

        }

       
        //menu list 
        private void MenuList()
        {
            MenuContent Pizza = new MenuContent( 1, "Pizza", "open-faced baked pie of Italian origin", "dough , cheese , Tomato Sauce".Split(',').ToList<String>(), 10.99);
            MenuContent Burger = new MenuContent( 2, "Burger", "The Classic Burger","cheese , onion ,beef".Split(',').ToList<String>(), 5.99);
            MenuContent quesadilla = new MenuContent( 3, "quesadilla", "Mexican dish", "chicken , cheese , tortilla , salsa".Split(',').ToList<String>(), 7.99);

            _contectRepo.AddContentToList(Pizza);
            _contectRepo.AddContentToList(Burger);
            _contectRepo.AddContentToList(quesadilla);

        }
    }
}
