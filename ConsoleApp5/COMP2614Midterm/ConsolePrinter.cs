using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Midterm
{
    //this class dedicated output to Console
    class ConsolePrinter
    {
        public static void ShowItem(GroceryItemCollection groceryItems, string header)
        {
            //output header
            Console.WriteLine($"{header}");
            Console.WriteLine($"{"Grocery Item",-30} {"Price",5}   {"Expires",-15}");
            Console.WriteLine(new string('-', 55));
            //output Invoice Items
            foreach (GroceryItem item in groceryItems)
            { 
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 55));

            //Calculate Total by call method Total in GroceryItemCollection class
            Console.WriteLine($"{"Total:",-30} {groceryItems.Total,5}");
        }
    }
}
