using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A00912599Assign04
{
    class Province
    {
        public string CustomerPovince { get; }
        public Province(string provinceName)
        {
            this.CustomerPovince = provinceName;
     
        }
        public override string ToString()
        {
            return string.Format($"{this.CustomerPovince}");
        }
    }
    class Customer
    {
        public string CompanyName { get; }
        public string City { get; }
        public string Province { get; }
        public string PostalCode { get; }
        public string CreditHold { get; }

        public Customer(string companyName, string city, string province, string postalCode, string creditHold )
        {
            this.CompanyName = companyName;
            this.City = city;
            this.Province = province;
            this.PostalCode = postalCode;
            this.CreditHold = creditHold;
        }

        public override string ToString()
        {
            return string.Format($"{CompanyName,-40}{City,-20}{Province,-4}{PostalCode,-10}{CreditHold,2}");
        }

    }
}
