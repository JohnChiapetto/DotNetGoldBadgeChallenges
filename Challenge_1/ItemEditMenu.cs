using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1 {
    public class ItemEditMenu : ConsoleScreen
    {
        public static readonly string[] VALUES = {
            "Rename",
            "Change Description",
            "Change Number",
            "Change Price",
            "Change Ingredients"
        };

        int index = 0;
        MenuItem item;
        bool running;

        public ItemEditMenu(MenuItem item)
        {
            this.item = item;
        }

        public void OnKeyPress(ConsoleKeyInfo keyInfo)
        {
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    index--;
                    if (index < 0) index = VALUES.Length - 1;
                    break;
                case ConsoleKey.DownArrow:
                    index++;
                    if (index == VALUES.Length) index = 0;
                    break;
                case ConsoleKey.Escape:
                    running = false;
                    break;
                case ConsoleKey.Enter:
                    DoValue();
                    break;
            }
        }
        public void DoValue()
        {
            switch (index)
            {
                case 0:
                    item.Rename();
                    break;
                case 1:
                    item.EditDescription();
                    break;
                case 2:
                    item.ChangeNumber();
                    break;
                case 3:
                    item.ChangePrice();
                    break;
                case 4:
                    item.ChangeIngredients();
                    break;
            }
        }
        public void Draw()
        {
            Console.Clear();
            for (int i = 0; i < VALUES.Length; i++)
            {
                string str = "";
                str += i == index ? "> " : "  ";
                str += VALUES[i];
                str += i == index ? " <" : "  ";
                Console.WriteLine(str);
            }
        }
        public void Run()
        {
            running = true;

            while (running)
            {
                Draw();
                OnKeyPress(Console.ReadKey());
            }
        }
    }
}
