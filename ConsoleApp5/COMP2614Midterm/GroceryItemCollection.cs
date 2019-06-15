using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Midterm
{
    //this class inheritance provides an alias for List<GroceryItem>
    class GroceryItemCollection : List<GroceryItem>
    {
        //Calculate price total to process its elements
        public decimal Total
        {
            get
            {
                decimal total = 0.00m;

                foreach (GroceryItem item in this)
                {
                    total += item.Price;
                }

                return total;
            }
        }

    }
}
