using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    class Member
    {
        private string firstname;
        private string lastname;
        private double age;

        public Member()
        {
        }
        public Member(string firstname, string lastname, int age)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.age = age;
        }

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
        public double Age
        {
            get { return age; }
            set { age = value; }
        }
        
        //AgeInDecades is calculated on demand and exposed as a public so it is a readonly property
        public double AgeInDecades//no require a corresponding field cuz value can be calculated from other local values
        {
            get { return age / 10; }
        }

        public override string ToString()
        {
            return string.Format("{0, -15} {1, -15} {2, 6} {3, 14 :n2}", this.firstname,this.lastname,this.age,this.AgeInDecades);
        }
    }
}
