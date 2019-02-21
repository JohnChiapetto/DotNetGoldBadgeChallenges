using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge_3;

namespace Challenge_3_Tests
{
    [TestClass]
    public class OutingRepository_Tests
    {
        OutingRepository outings = new OutingRepository();
        Outing outing0 = new Outing(EventType.AmusementPark,20,new DateTime(1999,12,1),2.09M);
        Outing outing1 = new Outing(EventType.Concert,7,new DateTime(1999,1,7),28.95M);

        [TestInitialize]
        public void Init() {
            outings.outings.Add(outing0);
        }

        [TestMethod]
        public void OutingRepository_AddOuting_Test()
        {
            outings.AddOuting(outing1);

            Assert.AreEqual(outing1,outings.outings[1]);
        }
        [TestMethod]
        public void OutingRepository_RemoveOuting_Test()
        {
            outings.RemoveOuting(outing0);

            Assert.AreEqual(0,outings.outings.Count);
        }
        [TestMethod]
        public void OutingRepository_GetByType_Test()
        {
            Outing[] outingz = outings.GetByType(EventType.AmusementPark);

            Assert.AreEqual(1,outingz.Length);
            Assert.AreEqual(outing0,outingz[0]);
        }
    }
}
