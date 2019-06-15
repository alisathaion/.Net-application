using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A00912599Assign04
{
    class ConsolePrinter
    {
        //Print provice to Console
        public static void PrintProvince(ProvinceCollection provinces)
        {
            Console.WriteLine("Select province filter:");
            for (int i = 0; i < provinces.Count; i++)
            {
                Console.WriteLine($"\t{i+1}: {provinces[i]}");
            }
            
        }
        //Print Customer detail to Console
        public static void PrintCustomerCollection(CustomerCollection customers)
        {
            Console.WriteLine($"{"CompanyName",-40} {"City",-20 } {"Prov",-4 } {"Postal",-10 } {"Hold"}");
            Console.WriteLine(new string('-', 85));
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"{customer.CompanyName,-40} {customer.City,-20} {customer.Province,-4} {customer.PostalCode,-10} {customer.CreditHold,2}");
                
            }
            Console.ReadLine();
        }
    }
}
