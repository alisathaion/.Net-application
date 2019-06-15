using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLibrary.Common;
using BusinessLibrary.Data;
using System.Text.RegularExpressions;


namespace BusinessLibrary.Business
{
    public class CustomerValidation
    {
        private static List<string> errors;

        static CustomerValidation()
        {
            errors = new List<string>();
        }


        public static string ErrorMessage
        {
            get
            {
                string message = "";

                foreach (string line in errors)
                {
                    message += line + "\r\n";
                }

                return message;
            }
        }

        public static CustomerCollection GetCustomers() => CustomerRepository.GetCustomer();

        public static int AddCustomer(Customer customer)
        {
            if (Validate(customer))
            {
                return CustomerRepository.AddCustomer(customer,"Client912599");
            }
            else
            {
                return -1;
            }
        }

        public static int UpdateCustomer(Customer customer)
        {
            if (Validate(customer))
            {
                return CustomerRepository.UpdateCustomer(customer, "Client912599");
            }
            else
            {
                return -1;
            }
        }

        public static int DeleteCustomer(Customer customer)
        {
            if (Validate(customer))
            {
                return CustomerRepository.DeleteCustomer(customer, "Client912599");
            }
            else
            {
                return -1;
            }
        }

        private static bool Validate(Customer customer)
        {
            bool success = true;
            errors.Clear();
            if (customer.ClientCode == string.Empty || customer.ClientCode == null)
            {
                errors.Add("Client Code cannot be empty");
                success = false;
            }
            else
            {
                string regExClientCode = @"^[A-Z][A-Z][A-Z][A-Z][A-Z]$";
                if (!Regex.IsMatch(customer.ClientCode, regExClientCode))
                {
                    errors.Add("Client Code is not correct");
                    success = false;
                }
            }
            if (customer.CompanyName == string.Empty || customer.CompanyName == null)
            {
                errors.Add("Company Name cannot be empty");
                success = false;
            }
            if (customer.Address1 == string.Empty || customer.Address1 == null)
            {
                errors.Add("Address1 cannot be empty");
                success = false;
            }
            if (customer.Province == string.Empty || customer.Province == null)
            {
                errors.Add("Province cannot be empty");
                success = false;
            }
            if (customer.YTDSale < 0.00m)
            {
                errors.Add("YTD Sales cannot be negative");
                success = false;
            }
            if (customer.PostalCode != string.Empty && customer.PostalCode != null)
            {
                string regExPostalCode = @"^[A-Z]\d[A-Z] \d[A-Z]\d$";
                if (!Regex.IsMatch(customer.PostalCode, regExPostalCode))
                {
                    errors.Add("Invalid Postal Code");
                    success = false;
                }
            }
            return success;
        }
    }
}
