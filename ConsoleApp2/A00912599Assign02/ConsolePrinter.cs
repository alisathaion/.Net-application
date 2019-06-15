using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A00912599Assign02
{
    // UI class
    class ConsolePrinter
    {
        //the output code in a utility method in a dedicated class
        public static void DisplayArray(Contact[] contacts)
        {

            //space between input and output area
            Console.WriteLine(Environment.NewLine);

            //Title of Output
            Console.WriteLine("Contacts");
            Console.WriteLine(new string('-', 30));

            //Display array by using foreach 
            foreach (Contact contact in contacts)
            {
                Console.WriteLine("{0}\n", contact);
            }
        }
        
    }
}
