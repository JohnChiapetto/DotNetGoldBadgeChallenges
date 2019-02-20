using System;
using System.Collections.Generic;
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
            Console.WriteLine("INIT");
            //badge0 = new Badge();
            //badge1 = new Badge();
            badges.badges.Add(badge0.BadgeID,badge0);
            badges.badgeNumbers.Add(badge0.BadgeID);
        }

        [TestMethod]
        public void BadgeRepository_GetBadge_Test()
        {
            Badge badge = badges.GetBadge(badge0.BadgeID);

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
            Badge b = badges.GetBadge((int)0);

            //Console.WriteLine("[GetBadge] COUNT: "+n);
            Console.WriteLine("[GetBadge] BadgeID: " + b.BadgeID);
            Console.WriteLine("[GetBadge] BadgeID Original: " + badge0.BadgeID);

            Assert.AreSame(badge0,b);
        }

        [TestMethod]
        public void BadgeRepository_RemoveBadge_Int_Test() {
            badges.RemoveBadge(0);
            int n = badges.badges.Count;

            Console.WriteLine($"[RemoveBadge(int)] {n}");

            Assert.AreEqual(0,badges.NumberOfBadges);
        }

        [TestMethod]
        public void BadgeRepository_AddBadge_Test() {
            badges.AddBadge(badge1);
            int n = badges.badges.Count;

            Console.WriteLine($"[AddBadge] {n}");

            Assert.AreEqual(2,n);
        }

    }
}
