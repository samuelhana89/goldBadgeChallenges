using KomodoInsurance_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _KomodoInsurance_UnitTest
{
    [TestClass]

    public class KomodoInsuranceRepositoryTest
    {

        KomodoInsuranceRepository repo;

        [TestInitialize]
        public void TestInit()
        {
            repo = new KomodoInsuranceRepository();

            KomodoInsurance Developer = new KomodoInsurance(12345, "A7".Split(',').ToList<String>(), "Developer");
            KomodoInsurance claimAgent = new KomodoInsurance(22345, "A1, A4, B1, B2".Split(',').ToList<String>(), "claimAgent");
            KomodoInsurance employee = new KomodoInsurance(32345, "A4, A5".Split(',').ToList<String>(), "employee");

            repo.AddBagde(Developer);
            repo.AddBagde(claimAgent);
            repo.AddBagde(employee);

        }
        [TestMethod]
        public void UnitTest_AddBagde() //Test Add bagde Method
        {
            //Act
            repo.AddBagde(new KomodoInsurance());

            //assert
            Assert.AreEqual(4, repo.GetBadgeList().Count);
        }
        [TestMethod]
        public void UnitTest_AddNoBadge() //Test Add no Badge
        {
            //Act
            repo.AddBagde(null);

            //assert
            Assert.AreEqual(3, repo.GetBadgeList().Count);
        }
        [TestMethod]
        public void UnitTest_AddDoor()  // test Add door method if we have the badge Id in our list 
        {
            repo.AddDoor(12345, "A8");

            //repo.GetDoorList(12345);

            Assert.AreEqual(2, repo.GetDoorList(12345).Count);

        }
        [TestMethod]
        public void UnitTest_RemoveDoor() // test remove door method if we have the badge Id in our list 
        {
            repo.RemoveDoor(22345, "A1");

            Assert.AreEqual(3, repo.GetDoorList(22345).Count);

        }
        [TestMethod]
        public void UnitTest_RemoveDoorNotInBadgeID() // test remove door method if we don't have the badge Id in our list 
        {
            try
            {
                repo.RemoveDoor(56789, "A1");
            }
            catch(Exception e)
            {
                Assert.Fail("Expect no exception, but we got exception", e.Message);
            }

            


        }
    }
}