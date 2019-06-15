using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {

            //Object Initializer doesn't need parameter (use empty object)
            Member[] members = new Member[5];
            members[0] = new Member { Firstname = "Tim", Lastname = "Conway", Age = 61 };
            members[1] = new Member { Firstname = "Larry", Lastname = "Sanders", Age = 60 };
            members[2] = new Member { Firstname = "Howard", Lastname = "Stern", Age = 58 };
            members[3] = new Member { Firstname = "Steven", Lastname = "Wright", Age = 56 };
            members[4] = new Member { Firstname = "Lewis", Lastname = "Black", Age = 64 };

            Utility.PrintMember(members);
            Console.ReadLine();


        } 
    }
}
