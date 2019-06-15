using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BusinessLibrary.Common
{
    public class CustomerCollection : BindingList<Customer>
    {
        //lambda expression and expression-bodied method to calculate YTDSales
        public decimal TotalYTDSales() => Items.Sum(i => i.YTDSale);

        //lambda expression and expression-bodied method to count CreditHold
        public int CreditHoldCount() => Items.Count(i => i.CreditHold);




    }
}
