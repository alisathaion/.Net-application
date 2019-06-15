using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Common
{
    public class InvoiceCollection : BindingList<Invoice>
    {
        //Calculate subTotal fromsummary of quantity by price
        public decimal subTotal() => Items.Sum(i => i.Quantity*i.Price);
    }
    public class TaxCollection : BindingList<TaxRateTable>
    {
        //
    }
}
