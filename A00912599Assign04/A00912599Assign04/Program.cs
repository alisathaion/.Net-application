using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A00912599Assign04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //Show province collection
                ProvinceCollection provinces = CustomerRepository.GetProvince();
                ConsolePrinter.PrintProvince(provinces);

                //convert input from the user 
                int provinceNo = Convert.ToInt16(Console.ReadLine());
                string province = provinces[provinceNo-1].ToString();
                Console.WriteLine("Customer listing for " + province + "\n");

                //Show customer data filter by province
                CustomerCollection customers = CustomerRepository.GetCustomerByProvince(province);
                ConsolePrinter.PrintCustomerCollection(customers);
                Console.ReadLine();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Data Access Error\n\n{ex.Message}\n\n{ex.StackTrace}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Processing Error\n\n{ex.Message}\n\n{ex.StackTrace}");
            }

        }
    }
}
