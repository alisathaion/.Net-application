using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A00912599Assign02
{
    //data class
    class Contact
    {
        ////automatic properties optional
        //public string Firstname { get; set; }
        //public string Lastname { get; set; }
        //public string Address { get; set; }
        //public string City { get; set; }
        //public string Province { get; set; }
        //public string Postalcode { get; set; }

        //field
        private string firstname;
        private string lastname;
        private string address;
        private string city;
        private string province;
        private string postalcode;

        //default constructor usually contain no code
        public Contact()//unneccessay but must write our own in this case because
        {               //we have written a paramaterized ctor
        }               //and want to be able to create an empty object

        //parameterized constructor
        public Contact(string firstname, string lastname, string address, string city, string province, string postalcode)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.city = city;
            this.province = province;
            this.postalcode = postalcode;
        }


        //property method Read/Write
        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string Province
        {
            get { return province; }
            set { province = value; }
        }
        public string Postalcode
        {
            get { return postalcode; }
            set { postalcode = value; }
        }


        //ToString override to format the output to Canadian Postal Standard
        public override string ToString()
        {
            return string.Format("{0} {1} \n{2} \n{3} {4}  {5}"
                                , this.firstname
                                , this.lastname
                                , this.address
                                , this.city
                                ,this.province
                                , this.postalcode);
        }
    }
}
