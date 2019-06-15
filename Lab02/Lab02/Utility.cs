using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    class Utility
    {
        public static void PrintMember(Member[] members)
        {
            Console.WriteLine("{0, -15} {1, -15} {2, 6} {3, 14}", "FirstName", "LastName", "AgeYears", "AgeDecades");
            Console.WriteLine(new string('-', 55));
            foreach (Member member in members)
            {
                Console.WriteLine("{0}", member);
            }
            Console.WriteLine("\n");
        }
    }
}
