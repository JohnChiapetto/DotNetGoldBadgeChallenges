using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    class OutingsMenu
    {
        bool isRunning = false;
        OutingRepository repo;
        int index = 0;

        public OutingsMenu(OutingRepository repo) {
            this.repo = repo;
        }

        public string Stringify(Outing o) {
            string str = "";
            str += o.Type;
            while (str.Length < 16) str += " ";
            string b = $"${o.TotalCost}";
            str += b;
            return str;
        }

        public void Draw() {
            Console.Clear();
            for (int i = 0; i < repo.TotalOutings; i++) {
                ConsoleColor fg = Console.ForegroundColor;
                ConsoleColor bg = Console.BackgroundColor;
                if (i == index) {
                    Console.ForegroundColor = bg;
                    Console.BackgroundColor = fg;
                }
                Console.WriteLine(Stringify(repo.GetOuting(i)));
                if (i == index)
                {
                    Console.ForegroundColor = fg;
                    Console.BackgroundColor = bg;
                }
            }
            Console.WriteLine("[Del] to delete, [Escape] to exit, [C] Costs By Type, [N] Add Outing, [UpArrow] to scroll up, [DownArrow] to scroll down");
        }
        public void OnKeyPress(ConsoleKeyInfo info) {
            ConsoleKey key = info.Key;
            

            switch (key) {
                case ConsoleKey.UpArrow:
                    index--;
                    if (index < 0) index = repo.TotalOutings - 1;
                    break;
                case ConsoleKey.DownArrow:
                    index++;
                    if (index >= repo.TotalOutings) index = 0;
                    break;
                case ConsoleKey.Delete:
                    repo.RemoveOuting(index);
                    while (index >= repo.TotalOutings && repo.TotalOutings > 0) index--;
                    break;
                case ConsoleKey.C:
                    repo.ShowOutingCostsByType();
                    break;
                case ConsoleKey.N:
                    CreateOuting();
                    break;
                case ConsoleKey.Escape:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine((int) key);
                    Console.ReadKey();
                    break;
            }
        }
        public void Run() {
            isRunning = true;
            
            while (isRunning) {
                Draw();
                OnKeyPress(Console.ReadKey());
            }
        }

        public void CreateOuting() {
            Console.Clear();

            Console.Write("What type of outing? ");
            EventType type = 0;
            switch (Console.ReadLine().ToLower()) {
                case "golf":
                    type = EventType.Golf;
                    break;
                case "concert":
                    type = EventType.Concert;
                    break;
                case "bowling":
                    type = EventType.Bowling;
                    break;
                case "amusement park":
                    type = EventType.AmusementPark;
                    break;
            }

            Console.Write("How much per person? ");
            decimal cost = Decimal.Parse(Console.ReadLine());

            Console.Write("How many people? ");
            int numP = int.Parse(Console.ReadLine());

            Console.Write("When (MM/dd/yyyy)? ");
            DateTime dt = DateTime.Parse(Console.ReadLine());

            Outing outing = new Outing(type,numP,dt,cost);
            repo.AddOuting(outing);
        }
    }
}
