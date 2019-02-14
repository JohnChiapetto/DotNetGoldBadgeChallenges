using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1 {
    class IngredientEditor : ConsoleScreen {
        MenuItem item;
        List<string> ingredients = new List<string>();
        int index;
        bool running = false;

        public IngredientEditor(MenuItem item)
        {
            this.item = item;
            foreach (string ingr in item.Ingredients) ingredients.Add(ingr);
        }

        public void Draw()
        {
            Console.Clear();
            for (int i = 0; i < ingredients.Count; i++)
            {
                string str = "";
                str += i == index ? "[ " : "  ";
                str += ingredients[i];
                str += i == index ? " ]" : "  ";
                Console.WriteLine(str);
            }
        }

        public void OnKeyPress(ConsoleKeyInfo keyInfo)
        {
            ConsoleKey key = keyInfo.Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:    // Index--
                    index--;
                    if (index < 0) index = ingredients.Count - 1;
                    break;
                case ConsoleKey.DownArrow:  // Index++
                    index++;
                    if (index == ingredients.Count) index = 0;
                    break;
                case ConsoleKey.Enter:  // Edit
                    Console.Clear();
                    Console.Write($"What should I replace \"{ingredients[index]}\" with? ");
                    ingredients[index] = Console.ReadLine();
                    if (index == ingredients.Count) index--;
                    break;
                case ConsoleKey.Delete: // Delete
                    ingredients.RemoveAt(index);
                    break;
                case ConsoleKey.S:  // Save
                    item.Ingredients = ingredients.ToArray();
                    running = false;
                    break;
                case ConsoleKey.N:
                    Console.Clear();
                    Console.Write("What is the new ingredient called? ");
                    ingredients.Add(Console.ReadLine());
                    break;
                case ConsoleKey.Escape:
                    running = false;
                    break;
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
