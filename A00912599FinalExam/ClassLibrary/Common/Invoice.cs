using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Common
{
    public class Invoice
    {
        public int DetailId { get; set; }
        public int Quantity { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Taxable { get; set; }
          
    }

    public class TaxRateTable
    {
        public string Taxcode { get; set; }
        public decimal TaxRate { get; set; }
    }
}
