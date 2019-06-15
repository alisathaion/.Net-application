using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A00912599Assign1
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare variable 
            int[] evenNumber = new int[] { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
            int sumSquare = 0;
            int sumCube = 0;

            //summary the even number 0 to 20 and formatting number with comma
            string sumNumber = evenNumber.Sum().ToString("#,##0");

            //display the title of column
            Console.WriteLine("{0, 5}  {1, 10}  {2,10}", "Number", "Square", "Cube");
            Console.WriteLine(new string('-', 30));

     
            foreach (int number in evenNumber)
            {
               //calculate square and cube in each row
                int square = number * number;
                int cube = number * number * number;

                //display the value with ample space and formatting number with comma
                Console.WriteLine("{0, 5}  {1, 10}  {2,10}"
                                    , number
                                    , square.ToString("#,##0")
                                    , cube.ToString("#,##0"));

                //Summary the square column
                sumSquare += square;
                //Summary the cube column
                sumCube += cube;
          
            }

            //display the total for each column with ample space and number format
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("{0, 5}  {1, 10}  {2,10}"
                                , sumNumber
                                , sumSquare.ToString("#,##0")
                                , sumCube.ToString("#,##0"));
            Console.ReadLine();

        }
    }
}
