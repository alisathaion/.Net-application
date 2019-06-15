using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessLibrary.Business;
using BusinessLibrary.Data;
using BusinessLibrary.Common;

namespace A00912599Assign06
{
    public partial class CustomerEditDialog : Form
    {
        public CustomerViewModel CustomerVM { get; set; }
        public CustomerEditDialog()
        {
            InitializeComponent();
        }

        private void CustomerEditDialog_Load(object sender, EventArgs e)
        { 
            comboBoxProvince.DataSource = CustomerRepository.GetProvince();
            setBindings();
        }

        private void setBindings()
        {
            //Binding data
            textboxClientCode.DataBindings.Add("Text", CustomerVM, "ClientCode", false, DataSourceUpdateMode.OnValidation, "");
            textBoxCompanyName.DataBindings.Add("Text", CustomerVM, "CompanyName", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress1.DataBindings.Add("Text", CustomerVM, "Address1", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress2.DataBindings.Add("Text", CustomerVM, "Address2", false);
            textBoxCity.DataBindings.Add("Text", CustomerVM, "City", false);
            comboBoxProvince.DataBindings.Add("Text", CustomerVM, "Province", false, DataSourceUpdateMode.OnValidation, "");
            textBoxPostalCode.DataBindings.Add("Text", CustomerVM, "PostalCode", false);
            textBoxYTDSale.DataBindings.Add("Text", CustomerVM, "YTDSale", false, DataSourceUpdateMode.OnValidation, "0.00", "#,##0.00;(#,##0.00);0.00");
            textBoxNote.DataBindings.Add("Text", CustomerVM, "Notes", false);
            checkBoxCreditHold.DataBindings.Add("Checked", CustomerVM, "CreditHold");

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textboxClientCode.Text == "" || textBoxCompanyName.Text == "" || textBoxAddress1.Text == "" || Convert.ToDecimal(textBoxYTDSale.Text) < 0.00m )
                {
                    if (textboxClientCode.Text == string.Empty)
                    {
                        errorProvider.SetError(textboxClientCode, "Enter Client Code");
                    }
                    else
                    {
                        errorProvider.SetError(textboxClientCode, string.Empty);
                    }
                    if (textBoxCompanyName.Text == string.Empty)
                    {
                        errorProvider.SetError(textBoxCompanyName, "Enter Company Name");
                    }
                    else
                    {
                        errorProvider.SetError(textBoxCompanyName, string.Empty);
                    }
                    if (textBoxAddress1.Text == String.Empty)
                    {
                        errorProvider.SetError(textBoxAddress1, "Enter Address1");
                    }
                    else
                    {
                        errorProvider.SetError(textBoxAddress1, string.Empty);
                    }
                    if (Convert.ToDecimal(textBoxYTDSale.Text) < 0.00m)
                    {
                        errorProvider.SetError(textBoxYTDSale, "Enter YTD Sales");
                    }
                    else
                    {
                        errorProvider.SetError(textBoxYTDSale, string.Empty);
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    //Update data in database 
                    Customer customer = CustomerVM.GetDisplayCustomer();
                    string errorMessage;
                    int rowsAffected = CustomerValidation.UpdateCustomer(customer);

                    if (rowsAffected <= 0)
                    {
                        if (rowsAffected == 0)
                        {
                            errorMessage = "No DB changes were made";
                        }
                        else
                        {
                            errorMessage = CustomerValidation.ErrorMessage;
                        }

                        MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        

                    }
                }
           

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
