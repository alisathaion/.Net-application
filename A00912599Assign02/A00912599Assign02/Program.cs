using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A00912599Assign02
{
    class Program
    {
        static void Main(string[] args)
        {
            //Display for user input
            string firstname, lastname, address, city, province, postalcode;

            Console.WriteLine("Contact Information");
            Console.WriteLine(new string('-', 30));

            Console.Write("Firstname:\t");
            firstname = Console.ReadLine().ToString();

            Console.Write("Lastname:\t");
            lastname = Console.ReadLine().ToString();

            Console.Write("Address:\t");
            address = Console.ReadLine().ToString();

            Console.Write("City:\t\t");
            city = Console.ReadLine().ToString();

            Console.Write("Province:\t");
            province = Console.ReadLine().ToString();

            Console.Write("Postal Code:\t");
            postalcode = Console.ReadLine().ToString();

            //populate object using 3 different techniques
            //first object, create an empty object and populate via properties
            Contact contactProperty = new Contact();
            contactProperty.Firstname = firstname;
            contactProperty.Lastname = lastname;
            contactProperty.Address = address;
            contactProperty.City = city;
            contactProperty.Province = province;
            contactProperty.Postalcode = postalcode;


            //second object, call a parameterized constructor
            Contact contactParameterized = new Contact(firstname, lastname, address, city, province, postalcode);

            //third object, use the Object Initializer syntax from empty object
            Contact contactInitializer = new Contact
            {
                Firstname = firstname,
                Lastname = lastname,
                Address = address,
                City = city,
                Province = province,
                Postalcode = postalcode
            };

            //Add the Contact objects to an array of reference type
            Contact[] contacts = new Contact[3];
            contacts[0] = contactProperty;
            contacts[1] = contactParameterized;
            contacts[2] = contactInitializer;
            ConsolePrinter.DisplayArray(contacts);
            Console.Read();
            
        }
    }
}
