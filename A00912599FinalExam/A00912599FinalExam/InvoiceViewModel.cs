using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Common;

namespace A00912599FinalExam
{
    //View Model for Invoice details
    class InvoiceViewModel : INotifyPropertyChanged
    {
        private int detailId;
        private int quantity;
        private string sku;
        private string description;
        private decimal price;
        private bool taxable;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public InvoiceViewModel()
        {
            //
        }

        public InvoiceViewModel(InvoiceCollection invoices)
        {
            this.Invoices = invoices;
        }


        public int DetailId
        {
            get { return detailId; }
            set
            {
                detailId = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged();
            }
        }

        public string Sku
        {
            get { return sku; }
            set
            {
                sku = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }

        public bool Taxable
        {
            get { return taxable; }
            set
            {
                taxable = value;
                OnPropertyChanged();
            }
        }

        public InvoiceCollection Invoices { get; set; }


        public void SetDisplayInvoice(Invoice invoice)
        {
            this.DetailId = invoice.DetailId;
            this.Quantity = invoice.Quantity;
            this.Sku = invoice.Sku;
            this.Description = invoice.Description;
            this.Price = invoice.Price;
            this.Taxable = invoice.Taxable;
        }

        public Invoice GetDisplayInvoice()
        {
            return new Invoice
            {
                DetailId = this.DetailId
                               ,
                Quantity = this.Quantity
                               ,
                Sku = this.Sku
                               ,
                Description = this.Description
                               ,
                Price = this.Price
                               ,
                Taxable = this.Taxable
            };
        }

        public Invoice SaveInvoice(int collectionIndex)
        {
            this.Invoices[collectionIndex].DetailId = this.DetailId;
            this.Invoices[collectionIndex].Quantity = this.Quantity;
            this.Invoices[collectionIndex].Sku = this.Sku;
            this.Invoices[collectionIndex].Description = this.Description;
            this.Invoices[collectionIndex].Price = this.Price;
            this.Invoices[collectionIndex].Taxable = this.Taxable;

            return this.Invoices[collectionIndex];
        }
    }

    //view model for Tax details
    class TaxViewModel : INotifyPropertyChanged
    {
        private string taxCode;
        private decimal taxRates;


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //public TaxViewModel()
        //{
        //    //
        //}

        public TaxViewModel(TaxCollection taxes)
        {
            this.Taxes = taxes;
        }
        public string TaxCode
        {
            get { return taxCode; }
            set
            {
                taxCode = value;
                OnPropertyChanged();
            }
        }

        public decimal TaxRates
        {
            get { return taxRates; }
            set
            {
                taxRates = value;
                OnPropertyChanged();
            }
        }

        public TaxCollection Taxes { get; set; }

    }
}
