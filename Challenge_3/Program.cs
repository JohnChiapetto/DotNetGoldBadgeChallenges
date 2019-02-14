using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    class Program
    {
        static void Main(string[] args)
        {
            OutingRepository outings = new OutingRepository();
            outings.AddOuting(new Outing(EventType.AmusementPark,30,new DateTime(2010,10,10),30M));

            OutingsMenu menu = new OutingsMenu(outings);

            menu.Run();
        }
    }
}
