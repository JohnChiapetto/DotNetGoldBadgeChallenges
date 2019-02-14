using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class MenuItem
    {
        public int Number;
        public string Name;
        public string Desc;
        public string[] Ingredients;
        public decimal Price;

        public string PriceStr {  get {  return "$" + Price.ToString("0.00");  }  }
        
        public MenuItem(int n,string s) : this(n,s,"",new string[0],1.020M) { }
        public MenuItem(int n,string s,string d,string[] i,decimal p)
        {
            this.Number = n;
            this.Name = s;
            this.Desc = d;
            this.Ingredients = i;
            this.Price = p;
        }

        public void Rename()
        {
            Console.Clear();
            Console.Write("What would you like to name the Item? ");
            this.Name = Console.ReadLine();
        }
        
        public void EditDescription()
        {
            Console.Clear();
            Console.WriteLine("Describe your item below. End your last line with [END]");
            string desc = "";
            string line;
            while (!(line = Console.ReadLine()).EndsWith("[END]"))
            {
                if (desc != "") desc += "\n";
                desc += line;
            }
            desc += "\n" + line.Replace("[END]","");
            this.Desc = desc;
        }

        public void ChangeNumber()
        {
            Console.Clear();
            Console.Write("What number should the item be? ");
            this.Number = int.Parse(Console.ReadLine());
        }

        public void ChangePrice()
        {
            Console.Clear();
            Console.Write("How much should the item cost? ");
            this.Price = decimal.Parse(Console.ReadLine());
        }

        public void ChangeIngredients()
        {
            IngredientEditor editor = new IngredientEditor(this);
            editor.Run();
        }

        public void Edit()
        {
            ItemEditMenu menu = new ItemEditMenu(this);
            menu.Run();
        }
    }
}
