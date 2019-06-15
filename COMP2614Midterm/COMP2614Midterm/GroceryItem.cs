using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP2614Midterm
{
    //this class implement Icomparable<GroceryItem> to support sorting in a List<GroceryItem>
    class GroceryItem : IComparable<GroceryItem>
    {

        private string description;
        private DateTime expirationDate;
        private decimal price;

        public GroceryItem(string description, decimal price, DateTime expirationDate)
        {
            this.description = description;
            this.price = price;
            this.expirationDate = expirationDate;
        }
        //read only property method
        public string Description
        {
            get { return description; }
        }
   
        //read and write property method
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        //read only property method
        public DateTime ExpirationDate
        {
            get { return expirationDate; }
        }

        //Format string output
        public override string ToString()
        {
            return string.Format($"{this.Description,-30} {this.Price,5}" +
                                 $"   {(this.ExpirationDate.Year == 9999 ? "<never>" : this.ExpirationDate.ToString("ddd MMM d, yyyy")),-15}");
        }

        // implementing IComparable<>  
        public int CompareTo(GroceryItem other)
        {                                   
            if (other == null)
            {
                return 1; 
            }
            //descending order
            return other.Price.CompareTo(this.Price);
        }

    }
}
