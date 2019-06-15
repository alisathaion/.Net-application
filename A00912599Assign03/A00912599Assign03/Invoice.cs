using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A00912599Assign03
{
    //invoice header property
    class Invoice
    {
        public string InvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string DiscountDate { get; set; }
        public string InvoiceTerm { get; set; }

        
       
        public override string ToString()
        {
            return string.Format($"\n{"Invoice Number:",-17}{this.InvoiceNumber,-30}" +
                                 $"\n{"Invoice Date:",-17}{this.InvoiceDate,-30}\n{"Discount Date:",-17}" +
                                 $"{this.DiscountDate,-30}\n{"Terms:",-17}{this.InvoiceTerm,-30}");
        }

    }

    //invoice detail line property
    class InvoiceDetail
    {
        public double Qty { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Pst { get; set; }
        public double Ext
        {
            get { return Price*Qty; }
        }
  


        public override string ToString()
        {
            return string.Format("{0,3} {1,-12} {2, -20} {3, 10:N2} {4, 3} {5, 11:N2}"
                                                ,this.Qty
                                                ,this.Sku
                                                ,this.Description
                                                ,this.Price
                                                ,this.Pst
                                                ,this.Ext);
                                                                    
        }
    }

    //invoice subtotal property
    class InvoiceSubtotal
    {
        public double Subtotal { get; set; }
        public double Gst { get; set; }
        public double Pst { get; set; }
        public double Total { get; set; }
        public double Discount { get; set; }
   
        public override string ToString()
        {

           return string.Format($"{"",-17}{"Subtotal:",-30}{this.Subtotal,17:N2}" +
                                $"\n{"",-17}{"GST:",-30}{this.Gst,17:N2}" +
                                $"\n{"",-17}{(this.Pst == 0.00 ? "" : "PST :"),-30}{(this.Pst == 0.00 ? "" : this.Pst.ToString("0.00")),17}" +
                                $"\n{new string('-', 65)}" +
                                $"\n{"",-17}{"Total:",-30}{this.Total,17:N2}" +
                                $"\n\n{"",-17}{"Discount:",-30}{this.Discount,17:N2}\n");

           
        }
    }
}
