using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Midterm
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare GroceryItemCollection 
            GroceryItemCollection groceryItems = new GroceryItemCollection();

            //Add an object
            groceryItems.Add(new GroceryItem("4L Milk", 3.87m, DateTime.Parse("2018,02,13")));
            groceryItems.Add(new GroceryItem("500g Cottage Cheese", 4.28m, DateTime.Parse("2018,03,5")));
            groceryItems.Add(new GroceryItem("1 Tin Mushroom Soup", 0.99m, DateTime.MaxValue));
            groceryItems.Add(new GroceryItem("15kg Dog Food", 29.99m, DateTime.Parse("2019,12,19")));

            //Ouput Natural Order to screen
            ConsolePrinter.ShowItem(groceryItems,"Natural Order:");

            //Sort Order by Price
            groceryItems.Sort();
            Console.WriteLine(Environment.NewLine);

            //Output Sorted Order to screen
            ConsolePrinter.ShowItem(groceryItems,"Sorted Order: [Price Descending]");

            Console.ReadLine();

        }
    }
}
