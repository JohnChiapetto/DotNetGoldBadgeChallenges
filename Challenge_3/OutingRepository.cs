using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class OutingRepository
    {
        // Public so that the test project can access it easily
        public List<Outing> outings = new List<Outing>();

        public int TotalOutings { get { return outings.Count; } }

        public Outing[] GetByType(EventType e) {
            List<Outing> events = new List<Outing>();
            for (int i = 0; i < TotalOutings; i++) {
                if (outings[i].Type == e) events.Add(outings[i]);
            }
            return events.ToArray();
        }

        public void AddOuting(Outing o) { outings.Add(o); }
        public void RemoveOuting(Outing o) { outings.Remove(o); }
        public Outing RemoveOuting(int n) { Outing o = outings[n]; outings.Remove(o); return o; }
        public Outing GetOuting(int n) { return outings[n]; }

        public string Stringify(EventType t,decimal c) {
            string str = "";
            str += t;
            while (str.Length < 14) str += ' ';
            str += "$" + c.ToString("0.00");
            return str;
        }
        public void ShowOutingCostsByType() {
            Console.Clear();
            Dictionary<EventType,decimal> costs = new Dictionary<EventType, decimal>();
            decimal tc = 0;
            for (EventType e = 0; e <= EventType.Golf; e++) costs.Add(e,0M);
            for (int i = 0; i < outings.Count; i++) {
                costs[outings[i].Type] += outings[i].TotalCost;
                tc += outings[i].TotalCost;
            }
            for (EventType e = 0; e <= EventType.Golf; e++) {
                string s = Stringify(e,costs[e]);
                Console.WriteLine(s);
            }
            Console.WriteLine($"\nTotalCost: ${tc.ToString("0.00")}\n\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
