using _KomodoCafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _KomodoCafe_UnitTestProject
{
    [TestClass]
    public class MenuContentRepositoryTest
    {
        MenuContentRepository repo;

        [TestInitialize]
        public void TestInit()
        {
            //Arrange
            repo = new MenuContentRepository();

            MenuContent Pizza = new MenuContent(1, "Pizza", "open-faced baked pie of Italian origin", "dough , cheese , Tomato Sauce".Split(',').ToList<String>(), 10.99);
            MenuContent Burger = new MenuContent(2, "Burger", "The Classic Burger", "cheese , onion ,beef".Split(',').ToList<string>(), 5.99);
            MenuContent quesadilla = new MenuContent(3, "quesadilla", "Mexican dish", "chicken , cheese , tortilla , salsa".Split(',').ToList<String>(), 7.99);

            repo.AddContentToList(Pizza);
            repo.AddContentToList(Burger);
            repo.AddContentToList(quesadilla);

        }

        [TestMethod]
        public void UnitTest_AddContentToList() //Test Add Content To List Method
        {
            //Act
            repo.AddContentToList(new MenuContent());

            //assert
            Assert.AreEqual(4, repo.GetContentList().Count);
        }

        [TestMethod]
        public void UnitTest_AddNullContentToList() //Test Add Nothing to List Method
        {
            //Act
            repo.AddContentToList(null);

            //assert
            Assert.AreEqual(3, repo.GetContentList().Count);
        }


        [TestMethod]
        public void UnitTest_DeleteContentFromList() //Test Delete Content From List Method
        {
           

            //assert
            
            repo.DeleteContentFromList("Pizza");

            Assert.AreEqual(2, repo.GetContentList().Count);
        }

        [TestMethod]
        public void UnitTest_DeleteNotFoundContentFromList() //Test Delete Not Founded Content From List Method
        {
           

            //assert
            repo.DeleteContentFromList("Wings");

            Assert.AreEqual(3, repo.GetContentList().Count);
        }

        [TestMethod]
        public void UnitTest_GetContentByName() //Test get Content From List  by name Method
        {
          MenuContent pizza=  repo.GetContentByName("pizza");

            Assert.AreEqual("Pizza", pizza.MealName);
        }

        [TestMethod]
        public void UnitTest_GetNotFoundContentByName() //Test Get Not Founded Content From List Method
        {


            //assert
            MenuContent wings = repo.GetContentByName("wings");

            Assert.AreEqual(null, wings);


        }



    }
}
