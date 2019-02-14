using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1 {
    public class Menu : ConsoleScreen {

        SortedList<int,MenuItem> items = new SortedList<int,MenuItem>();
        int index = 0;
        bool running = false;

        public int NumberOfItems { get { return items.Count; } }

        public void Draw()
        {
            Console.Clear();
            for (int i = 0; i < NumberOfItems; i++)
            {
                Console.WriteLine(Stringify(items[i],i));
            }
        }

        /// <summary>
        /// Made this so that people could extend this class and change how each menuItem is printed
        /// to the screen
        /// </summary>
        /// <param name="item">The MenuItem whose information should be written</param>
        /// <param name="i">The index of the item. Used to check if Stringifying the current indexed item</param>
        public virtual string Stringify(MenuItem item,int i)
        {
            string str = $"[{item.Number}] {item.Name}";
            while (str.Length < 20) str += ' ';
            str += item.PriceStr;
            string prefix = i == index ? "> " : "  ";
            string suffix = i == index ? " <" : "  ";
            return prefix + str + suffix;
        }

        public MenuItem DeleteItem(int n)
        {
            MenuItem item = items[n];
            items.RemoveAt(n);
            return item;
        }
        public void AddItem(MenuItem item)
        {
            items.Add(item.Number,item);
        }
        public MenuItem GetItem(int n)
        {
            return items[n];
        }

        public void CreateNewItem()
        {
            int num = NumberOfItems;
            string line;

            Console.Clear();
            Console.Write("Create Item Named: ");
            string name = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Describe the Item: (End the last line with \"[END]\" without the quotes)");
            string desc = "";
            while (!(line = Console.ReadLine()).EndsWith("[END]"))
            {
                if (desc != "") desc += "\n";
                desc += line;
            }
            desc += ("\n" + line.Replace("[END]",""));

            Console.Clear();
            Console.Write("How much should the Item cost? ");
            decimal price = Decimal.Parse(Console.ReadLine());

            Console.Clear();
            Console.Write("What ingredients go in the item? (Put \"[END]\" as the last ingredient)");
            List<string> ingredients = new List<string>();
            while ((line = Console.ReadLine()) != "[END]") ingredients.Add(line);
            
            MenuItem item = new MenuItem(num,name,desc,ingredients.ToArray<string>(),price);
            AddItem(item);

        }

        public void DescribeCurrentItem()
        {
            Console.Clear();
            Console.WriteLine("Press any key to continue...\n");

            foreach (string line in items[index].Desc.Split('\n')) Console.WriteLine(line);

            Console.ReadKey();
        }
        public void DescribeCurrentIngredients()
        {
            Console.Clear();
            Console.WriteLine("Press any key to continue...\n");

            foreach (string ingredient in items[index].Ingredients) Console.WriteLine(ingredient);

            Console.ReadKey();
        }

        public ConsoleKey GetKeyPress() { return Console.ReadKey().Key; }
        public void OnKeyPress(ConsoleKeyInfo keyInfo)
        {
            ConsoleKey key = keyInfo.Key;

            if (NumberOfItems == 0 && !(new[] { ConsoleKey.Tab,ConsoleKey.N,ConsoleKey.Escape }).Contains(key)) return;

            switch (key)
            {
                case ConsoleKey.Delete:
                case ConsoleKey.Backspace:
                    DeleteItem(index);
                    break;
                case ConsoleKey.N:
                case ConsoleKey.Tab:
                    CreateNewItem();
                    break;
                case ConsoleKey.Escape:
                    running = false;
                    break;
                case ConsoleKey.UpArrow:
                    index--;
                    if (index < 0) index = NumberOfItems - 1;
                    break;
                case ConsoleKey.DownArrow:
                    index++;
                    if (index == NumberOfItems) index = 0;
                    break;
                case ConsoleKey.D:
                    DescribeCurrentItem();
                    break;
                case ConsoleKey.I:
                    DescribeCurrentIngredients();
                    break;
                case ConsoleKey.E:
                    items[index].Edit();
                    break;
            }
        }

        public void Run() {
            running = true;

            while (running) {
                Draw();
                Console.Write("Press 'Tab' or 'N' to create a new Item, and 'Escape' to exit.");
                if (NumberOfItems != 0) Console.Write(" Press 'I' to view Ingredients, 'D' to view description, or 'E' to edit.");
                Console.WriteLine();
                OnKeyPress(Console.ReadKey());
            }
        }
        
    }
}
