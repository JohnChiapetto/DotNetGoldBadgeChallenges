using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public enum ClaimType {
        Car,
        Home,
        Theft
    }

    public class Claim
    {
        private static long idCounter = 1;

        public long ClaimID;
        public ClaimType ClaimType;
        public string Description;
        public decimal ClaimAmount;
        public DateTime DateOfIncident;
        public DateTime DateOfClaim;

        public bool IsValid
        {
            get
            {
                return DateOfClaim.Day - DateOfIncident.Day < 31
                    && DateOfClaim.Year == DateOfIncident.Year
                    && (
                             DateOfClaim.Month == DateOfIncident.Month
                          || Math.Abs(DateOfClaim.Month - DateOfIncident.Month) == 1
                       );
            }
        }

        public Claim() { this.ClaimID = idCounter++; }
        public Claim(ClaimType type,string desc,decimal amount,DateTime incidentDate,DateTime claimDate) : this() {
            this.ClaimType = type;
            this.Description = desc;
            this.ClaimAmount = amount;
            this.DateOfIncident = incidentDate;
            this.DateOfClaim = claimDate;
        }
    }
}
