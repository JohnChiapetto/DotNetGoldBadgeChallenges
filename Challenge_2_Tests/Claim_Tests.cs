using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge_2;

namespace Challenge_2_Tests
{
    [TestClass]
    public class Claim_Tests
    {
        Claim claim0 = new Claim(ClaimType.Car,"Wreck on I-70",2000,new DateTime(2018,04,27),new DateTime(2018,04,28));
        Claim claim1 = new Claim(ClaimType.Home,"Wreck in my house",0.05m,new DateTime(2006,04,27),new DateTime(2018,04,28));

        [TestMethod]
        public void Claim_IsValid_Test()
        {
            Assert.IsTrue(claim0.IsValid);
            Assert.IsFalse(claim1.IsValid);
        }
    }
}
