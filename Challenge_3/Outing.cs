using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    class Outing
    {
        public EventType Type;
        public int People;
        public DateTime Date;
        public decimal TotalCostPerPerson;

        public decimal TotalCost { get { return TotalCostPerPerson * People; } }

        public Outing(EventType t,int p,DateTime d,decimal tcpp) {
            this.Type = t;
            this.People = p;
            this.Date = d;
            this.TotalCostPerPerson = tcpp;
        }
    }
}
