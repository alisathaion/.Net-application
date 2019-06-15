using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A00912599Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName, userPassword;
            const string PASSWORD = "ma5_t3r";

            
            //foreach (int element in fibarray)
            //{
                Console.Write("Please enter your name: ");
                userName = Console.ReadLine();

                Console.Write("Please enter your password: ");
                userPassword = Console.ReadLine().ToLower().Trim();

                if (userPassword == PASSWORD)
                {
                    Console.Write("Hello! " + userName + ", Welcome" + Environment.NewLine);
                    Console.Read();
                }
                else
                {
                    Console.Write("Your password is not correct! Please try again"+Environment.NewLine);
                    Console.Read();

                }
            //}
        }
    }
}
