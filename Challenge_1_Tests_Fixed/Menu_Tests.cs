using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge_1;

namespace Challenge_1_Tests_Fixed
{
    [TestClass]
    public class Menu_Tests
    {
        Menu menu = new Menu();
        MenuItem item = new MenuItem(0,"Cheeseburger","",new string[0],0.529m);
        MenuItem otherItem = new MenuItem(1,"Fries","",new string[0],10.3333m);

        [TestInitialize]
        public void Init()
        {
            menu.AddItem(item);
        }

        [TestMethod]
        public void MenuItem_PriceStr_Test()
        {
            string priceStr = item.PriceStr;

            Console.WriteLine(priceStr);
            Assert.AreEqual("$0.53",priceStr);
        }

        [TestMethod]
        public void Menu_NumberOfItems_Test()
        {
            // 1 Item was already added
            Assert.AreEqual(1,menu.NumberOfItems);
        }

        [TestMethod]
        public void Menu_Stringify_Test()
        {
            // Comparison Strings
            string comparison0 = "  [0] Cheeseburger    $0.53  ";
            string comparison1 = "  [1] Fries           $10.33  ";

            // Experimental Strings
            string testStr0 = menu.Stringify(item,-1);
            string testStr1 = menu.Stringify(otherItem,-1);

            // Results...
            Console.WriteLine(comparison0.Replace(" ","\\s")); // Make it more obvious how many spaces are present in the output strings
            Console.WriteLine(comparison1.Replace(" ","\\s"));
            Assert.AreEqual(comparison0,testStr0);
            Assert.AreEqual(comparison1,testStr1);
        }

        [TestMethod]
        public void Menu_AddItem_Test()
        {
            menu.AddItem(otherItem);

            Assert.AreEqual(menu.NumberOfItems,2);
            Assert.AreEqual(otherItem,menu.GetItem(1));
        }

        [TestMethod]
        public void Menu_DeleteItem_Test()
        {
            // Arrange
            int num = menu.NumberOfItems - 1;

            // Act
            menu.DeleteItem(0);

            // Assert
            Assert.AreEqual(num, menu.NumberOfItems);
        }

        [TestMethod]
        public void Menu_GetItem_Test()
        {
            MenuItem i = menu.GetItem(0);

            Assert.AreEqual(item,i);
        }
    }
}
