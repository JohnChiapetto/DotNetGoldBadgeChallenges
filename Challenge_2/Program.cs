using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ClaimRepository claims = new ClaimRepository();
            claims.AddClaim(new Claim(ClaimType.Home,"Wreck in my house",0.05m,new DateTime(2006,04,27),new DateTime(2018,04,28)));
            claims.Run();
        }
    }
}
