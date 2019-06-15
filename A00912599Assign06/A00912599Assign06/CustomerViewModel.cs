using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLibrary.Common;

namespace A00912599Assign06
{
    public class CustomerViewModel : INotifyPropertyChanged
    {
        //Declaration
        private string clientCode;
        private string companyName;
        private string address1;
        private string address2;
        private string city;
        private string province;
        private string postalCode;
        private decimal ytdSale;
        private bool creditHold;
        private string notes;
    

        //implement interface member INotifyPropertyChanged.PropertyChanged for CustomerviewModel
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CustomerViewModel(CustomerCollection customers)
        {
            this.Customers = customers;
        }

        public string ClientCode
        {
            get { return clientCode; }
            set
            {
                clientCode = value;
                OnPropertyChanged();
            }
        }
        public string CompanyName
        {
            get { return companyName; }
            set
            {
                companyName = value;
                OnPropertyChanged();
            }
        }
        public string Address1
        {
            get { return address1; }
            set
            {
                address1 = value;
                OnPropertyChanged();
            }
        }
        public string Address2
        {
            get { return address2; }
            set
            {
                address2 = value;
                OnPropertyChanged();
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }
        public string Province
        {
            get { return province; }
            set
            {
                province = value;
                OnPropertyChanged();
            }
        }
        public string PostalCode
        {
            get { return postalCode; }
            set
            {
                postalCode = value;
                OnPropertyChanged();
            }
        }
        public decimal YTDSale
        {
            get { return ytdSale; }
            set
            {
                ytdSale = value;
                OnPropertyChanged();
            }
        }
        public bool CreditHold
        {
            get { return creditHold; }
            set
            {
                creditHold = value;
                OnPropertyChanged();
            }
        }
        public string Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                OnPropertyChanged();
            }
        }


        public CustomerCollection Customers { get; set; }

        public void SetDisplayClient(Customer customer)
        {
            this.ClientCode = customer.ClientCode;
            this.CompanyName = customer.CompanyName;
            this.Address1 = customer.Address1;
            this.Address2 = customer.Address2;
            this.City = customer.City;
            this.Province = customer.Province;
            this.PostalCode = customer.PostalCode;
            this.YTDSale = customer.YTDSale;
            this.CreditHold = customer.CreditHold;
            this.Notes = customer.Notes;
            
        }

        public Customer SaveCustomer(int collectionIndex)
        {
            this.Customers[collectionIndex].ClientCode = this.ClientCode;
            this.Customers[collectionIndex].CompanyName = this.CompanyName;
            this.Customers[collectionIndex].Address1 = this.Address1;
            this.Customers[collectionIndex].Address2 = this.Address2;
            this.Customers[collectionIndex].City = this.City;
            this.Customers[collectionIndex].Province = this.Province;
            this.Customers[collectionIndex].PostalCode = this.PostalCode;
            this.Customers[collectionIndex].YTDSale = this.YTDSale;
            this.Customers[collectionIndex].CreditHold = this.CreditHold;
            this.Customers[collectionIndex].Notes = this.Notes;

            return this.Customers[collectionIndex];
        }

        public Customer GetDisplayCustomer()
        {
            return new Customer { ClientCode = this.ClientCode
                                , CompanyName = this.CompanyName
                                , Address1 = this.Address1
                                , Address2 = this.Address2
                                , City = this.City
                                , Province = this.Province
                                , PostalCode = this.PostalCode
                                , YTDSale = this.YTDSale
                                , CreditHold = this.CreditHold
                                , Notes = this.Notes };
        }
    }
}
