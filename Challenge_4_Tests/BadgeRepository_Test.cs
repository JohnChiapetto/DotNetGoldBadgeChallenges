using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge_4;

namespace Challenge_4_Tests
{
    [TestClass]
    public class BadgeRepository_Test
    {
        BadgeRepository badges = new BadgeRepository();
        Badge badge0 = new Badge();
        Badge badge1 = new Badge();

        [TestInitialize]
        public void TestInit() {
            badges.AddBadge(new Badge());
        }

        [TestMethod]
        public void BadgeRepository_GetBadge_Test()
        {
            badges.AddBadge(badge0);

            Badge badge = badges.GetBadge(0L);

            Assert.AreSame(badge0,badge);
        }

        [TestMethod]
        public void BadgeRepository_RemoveBadge_Test() {
            badges.RemoveBadge(badge0);

            Assert.AreEqual(0,badges.NumberOfBadges);
        }

        [TestMethod]
        public void BadgeRepository_GetBadge_Int_Test()
        {
            Badge b = badges.GetBadge(0);

            Console.WriteLine("BADGE COUNT: " + badges.NumberOfBadges);
            Console.WriteLine("BADGE ID: " + b.BadgeID);
            Console.WriteLine("XPCTD ID: " + badge0.BadgeID);

            Assert.AreSame(badge0,b);
        }

        [TestMethod]


    }
}
