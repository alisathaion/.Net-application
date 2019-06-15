using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;//for streamReader

namespace Lab03
{
    class Program
    {
       
        static void Main(string[] args)
        {
            StreamReader streamReader = null;
            string path = "";
            string lineData = "";
            string[] lineDataInArray;
            Console.Write("Please enter file path :");
            path = Console.ReadLine();
            //path = @"C:\Users\Alisa\Desktop\COMP2614\WEEK3\Lab03Files\data.txt";
            Console.WriteLine("\n");
          
            if (File.Exists(path))
            {
                Console.WriteLine("{0, -15} {1, -15} {2, 6}", "First Name", "Last Name", "Age");
                Console.WriteLine(new string('-', 38));
                try
                {
                    double totalAge = 0;
                    int count = 0;
                    streamReader = new StreamReader(path);
                   
                    while (streamReader.Peek() > 0)
                    {
                        lineData = streamReader.ReadLine();
                        lineDataInArray = lineData.Split(',');
                        int total = Convert.ToInt32(lineDataInArray[2]);
                        totalAge += total;
                        AddCount(ref count);//using value type - Pass by Reference
                        string output = $"{lineDataInArray[0], -15} {lineDataInArray[1], -15} {lineDataInArray[2], 6}";
                        Console.WriteLine(output);
                    }
        
                    Console.WriteLine(new string('-', 38));
                    Console.WriteLine($"{"",-15} {"Total:", -15} {totalAge, 6}");
                    Console.WriteLine($"{"",-15} {"Count:",-15} {count,6}");
                    Console.WriteLine($"{"",-15} {"Average:",-15} {totalAge/count,6}");


                }
                catch(Exception ex)
                {
                    Console.WriteLine($"\n{ex.Message}\n");
                }
                finally
                {
                    if (streamReader != null) 
                    {                         
                        streamReader.Close();
                    }
                }
                Console.ReadLine();


            }
            else
            {
                Console.WriteLine("File can not be found, Please check  file directory");
                Console.ReadLine();
            }
         
        }
        private static void AddCount(ref int count)
        {
            count += 1;
        }
    }
}
