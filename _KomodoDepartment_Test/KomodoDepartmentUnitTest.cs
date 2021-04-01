using _KomodoDepartment_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _KomodoDepartment_Test
{
    [TestClass]
    public class KomodoDepartmentRepositoryTest
    {
            KomodoDepartmentRepository repo;

        [TestInitialize]
        public void TestInit()
        {
            repo = new KomodoDepartmentRepository();

            KomodoDepartment car = new KomodoDepartment(1, "Car", "Car accident on 465", 400.00, new DateTime(2018, 04, 25), new DateTime(2018, 04, 27), true);
            KomodoDepartment Home = new KomodoDepartment(2, "Home", "House fire in kitchen.", 4000.00, new DateTime(2018, 04, 11), new DateTime(2018, 04, 12), true);
            KomodoDepartment Theft = new KomodoDepartment(3, "Theft", "Stolen pancakes.", 4.00, new DateTime(2018, 04, 27), new DateTime(2018, 06, 01), false);

            repo.AddClaimToList(car);
            repo.AddClaimToList(Home);
            repo.AddClaimToList(Theft);
        }

        [TestMethod]
        public void UnitTest_AddClaimToList() //Test Add claim To List Method
        {
            //Act
            repo.AddClaimToList (new KomodoDepartment ());

            //assert
            Assert.AreEqual(4, repo.GetClaimList().Count);

        }

        [TestMethod]
        public void UnitTest_AddNullContentToList() //Test Add Nothing to List Method
        {
            //Act
            repo.AddClaimToList(null);

            //assert
            Assert.AreEqual(3, repo.GetClaimList().Count);
        }
        [TestMethod]
        public void UnitTest_PullTopClaim() //Test Pull Top Claim From List Method
        {
            repo.pullTopClaim();

            Assert.AreEqual(2, repo.GetClaimList ().Count);
        }

        [TestMethod]
        public void UnitTest_ViewNextClaim() //Test View Next Claim Method
        {


            //assert
            KomodoDepartment car = repo.GetClaimList().Peek();

            Assert.AreEqual("Car", car.ClaimType);


        }

       

    }
}
