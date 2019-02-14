using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge_2;

namespace Challenge_2_Tests
{
    [TestClass]
    public class ClaimRepository_Tests
    {
        ClaimRepository claims = new ClaimRepository();
        Claim claim = new Claim(ClaimType.Car,"Wreck on I-70",2000,new DateTime(2018,04,27),new DateTime(2018,04,28));

        [TestMethod]
        public void ClaimRepository_NumberOfClaims_Test()
        {
            Assert.AreEqual(0,claims.NumberOfClaims);
            claims.AddClaim(claim);
            Assert.AreEqual(1,claims.NumberOfClaims);
        }

        [TestMethod]
        public void ClaimRepository_AddClaim_Test()
        {
            claims.AddClaim(claim);

            Assert.AreEqual(1,claims.NumberOfClaims);
        }

        [TestMethod]
        public void ClaimRepository_RemoveClaim_Test()
        {
            claims.AddClaim(claim);
            claims.RemoveClaim();

            Assert.AreEqual(0,claims.NumberOfClaims);
        }

        [TestMethod]
        public void ClaimRepository_GetCurrentClaim_Test() {
            claims.AddClaim(claim);

            Assert.AreEqual(claim,claims.CurrentClaim);
        }
    }
}
