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
using System.Runtime.CompilerServices;
using BusinessLibrary.Data;
using BusinessLibrary.Common;
using BusinessLibrary.Business;
using System.Text.RegularExpressions;

namespace A00912599Assign06
{
    public partial class CustomerForm : Form
    {
        private CustomerViewModel customerVM;
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            try
            {
                
                bool configured = false;
                SetUpDataGridView();
                customerVM = new CustomerViewModel(CustomerRepository.GetCustomer());
                comboBoxProvince.DataSource = CustomerRepository.GetProvince();
                setBindings(configured);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Data Access Error\n\n{ex.Message}\n\n{ex.StackTrace}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Processing Error\n\n{ex.Message}\n\n{ex.StackTrace}");
            }
        }

        private void setBindings(bool configured)
        {
            //Binding data
            maskedTextBoxClientCode.DataBindings.Add("Text", customerVM, "ClientCode", false, DataSourceUpdateMode.OnValidation, "");
            textBoxCompanyName.DataBindings.Add("Text", customerVM, "CompanyName", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress1.DataBindings.Add("Text", customerVM, "Address1", false, DataSourceUpdateMode.OnValidation, "");
            textBoxAddress2.DataBindings.Add("Text", customerVM, "Address2", false);
            textBoxCity.DataBindings.Add("Text", customerVM, "City", false);
            comboBoxProvince.DataBindings.Add("Text", customerVM, "Province", false, DataSourceUpdateMode.OnValidation, "");
            maskedTextBoxPostalCode.DataBindings.Add("Text", customerVM, "PostalCode", false);
            textBoxYTDSale.DataBindings.Add("Text", customerVM, "YTDSale", false, DataSourceUpdateMode.OnValidation, "0.00", "#,##0.00;(#,##0.00);0.00");
            textBoxNote.DataBindings.Add("Text", customerVM, "Notes", false);
            checkBoxCreditHold.DataBindings.Add("Checked", customerVM, "CreditHold");

            //binding customer data to dataGridView
            dataGridViewCustomer.AutoGenerateColumns = !configured;
            dataGridViewCustomer.DataSource = customerVM.Customers;
          
        }

        private void SetUpDataGridView()
        {
            // configure for readonly 
            dataGridViewCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCustomer.MultiSelect = false;
            dataGridViewCustomer.AllowUserToAddRows = false;
            dataGridViewCustomer.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewCustomer.AllowUserToOrderColumns = false;
            dataGridViewCustomer.AllowUserToResizeColumns = true;
            dataGridViewCustomer.AllowUserToResizeRows = false;
            dataGridViewCustomer.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            //add and configure column
            DataGridViewTextBoxColumn clientCode = new DataGridViewTextBoxColumn();
            clientCode.Name = "ClientCode";
            clientCode.DataPropertyName = "ClientCode";
            clientCode.HeaderText = "Client Code";
            clientCode.Width = 80;
            clientCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clientCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            clientCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomer.Columns.Add(clientCode);

            DataGridViewTextBoxColumn companyName = new DataGridViewTextBoxColumn();
            companyName.Name = "CompanyName";
            companyName.DataPropertyName = "CompanyName";
            companyName.HeaderText = "Company Name";
            companyName.Width = 160;
            companyName.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            companyName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            companyName.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomer.Columns.Add(companyName);

            DataGridViewTextBoxColumn Address1 = new DataGridViewTextBoxColumn();
            Address1.Name = "Address1";
            Address1.DataPropertyName = "Address1";
            Address1.HeaderText = "Address1";
            Address1.Width = 152;
            Address1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Address1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Address1.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomer.Columns.Add(Address1);

            DataGridViewTextBoxColumn Address2 = new DataGridViewTextBoxColumn();
            Address2.Name = "Address2";
            Address2.DataPropertyName = "Address2";
            Address2.HeaderText = "Address2";
            Address2.Width = 70;
            Address2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Address2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Address2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomer.Columns.Add(Address2);

            DataGridViewTextBoxColumn City = new DataGridViewTextBoxColumn();
            City.Name = "City";
            City.DataPropertyName = "City";
            City.HeaderText = "City";
            City.Width = 68;
            City.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            City.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            City.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomer.Columns.Add(City);

            DataGridViewTextBoxColumn Province = new DataGridViewTextBoxColumn();
            Province.Name = "Province";
            Province.DataPropertyName = "Province";
            Province.HeaderText = "Province";
            Province.Width = 63;
            Province.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Province.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Province.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomer.Columns.Add(Province);

            DataGridViewTextBoxColumn PostalCode = new DataGridViewTextBoxColumn();
            PostalCode.Name = "PostalCode";
            PostalCode.DataPropertyName = "PostalCode";
            PostalCode.HeaderText = "Postal";
            PostalCode.Width = 63;
            PostalCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            PostalCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            PostalCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomer.Columns.Add(PostalCode);

            DataGridViewTextBoxColumn YTDSale = new DataGridViewTextBoxColumn();
            YTDSale.Name = "YTDSale";
            YTDSale.DataPropertyName = "YTDSale";
            YTDSale.HeaderText = "YTD Sale";
            YTDSale.Width = 70;
            YTDSale.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            YTDSale.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            YTDSale.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomer.Columns.Add(YTDSale);

            DataGridViewCheckBoxColumn CreditHold = new DataGridViewCheckBoxColumn();
            CreditHold.Name = "CreditHold";
            CreditHold.DataPropertyName = "CreditHold";
            CreditHold.HeaderText = "Credit Hold";
            CreditHold.Width = 80;
            CreditHold.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CreditHold.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CreditHold.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomer.Columns.Add(CreditHold);

            DataGridViewTextBoxColumn Notes = new DataGridViewTextBoxColumn();
            Notes.Name = "Notes";
            Notes.DataPropertyName = "Notes";
            Notes.HeaderText = "Notes";
            Notes.Width = 178;
            Notes.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Notes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Notes.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewCustomer.Columns.Add(Notes);
        }

        private void dataGridViewCustomer_SelectionChanged(object sender, EventArgs e)
        {
            int index = dataGridViewCustomer.CurrentRow.Index;
            Customer customer = customerVM.Customers[index];
            customerVM.SetDisplayClient(customer);

            //Visible All Output Detail Data
            labelOutput.Text = string.Empty;
            groupBoxDetail.Visible = false;
            labelTitle.Visible = false;
            maskedTextBoxClientCode.Enabled = false;

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                int rowsAffected;
                Customer customer;
                string errorMessage;
                int index = dataGridViewCustomer.CurrentRow.Index; 

                //ADD DATABASE
                if (maskedTextBoxClientCode.Enabled == true)
                {
                    customer = customerVM.GetDisplayCustomer();
                    rowsAffected = CustomerValidation.AddCustomer(customer);
                    
                }
                //UPDATE DATABASE
                else
                {
                    index = dataGridViewCustomer.CurrentRow.Index;
                    customer = customerVM.SaveCustomer(index);
                    rowsAffected = CustomerValidation.UpdateCustomer(customer);
                }
                //Insert or Update are completed
                if (rowsAffected > 0)
                {
                    errorProvider.Clear();
                    customerVM.Customers.ResetItem(index);
                    customerVM.Customers = CustomerRepository.GetCustomer();
                    dataGridViewCustomer.DataSource = customerVM.Customers;

                    //Set up data for labelOutput
                    string outputData = string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}\r\n{6}\r\n{7}\r\n{8}\r\n{9}"
                                             , customer.ClientCode
                                             , customer.CompanyName
                                             , customer.Address1
                                             , customer.Address2
                                             , customer.City
                                             , customer.Province
                                             , customer.PostalCode
                                             , customer.YTDSale
                                             , customer.CreditHold
                                             , customer.Notes);

                    //Enable All Output Detail Data
                    groupBoxDetail.Visible = true;
                    labelTitle.Visible = true;
                    labelOutput.Text = outputData;

                    //Display calculated properties TotalYTDSales and CreditHoldCount
                    labelTotalYTD.Text = customerVM.Customers.TotalYTDSales().ToString();
                    labelCreditHoldCount.Text = customerVM.Customers.CreditHoldCount().ToString();
                }
                //Insert or Update are not complete
                else
                {
                    if (rowsAffected == 0)
                    {
                        errorMessage = "No DB changes were made";
                    }
                    else
                    {
                        errorMessage = CustomerValidation.ErrorMessage;
                    }
                    //MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (CustomerValidation.ErrorMessage != "")
                    {
                        if (maskedTextBoxClientCode.Text == string.Empty || maskedTextBoxClientCode.Text == null)
                        {
                            errorProvider.SetError(maskedTextBoxClientCode, "Enter Client Code");
                        }
                        else
                        {
                            string regExClientCode = @"^[A-Z][A-Z][A-Z][A-Z][A-Z]$";
                            if (!Regex.IsMatch(maskedTextBoxClientCode.Text, regExClientCode))
                            {
                                errorProvider.SetError(maskedTextBoxClientCode, "Invalid Client Code Format");
                            }
                            else
                            {
                                errorProvider.SetError(maskedTextBoxClientCode, string.Empty);
                            }
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
                            errorProvider.SetError(textBoxYTDSale, "YTD Sales can not be negative");
                        }
                        else
                        {
                            errorProvider.SetError(textBoxYTDSale, string.Empty);
                        }
                        if (maskedTextBoxPostalCode.Text != string.Empty && maskedTextBoxPostalCode.Text != null)
                        {
                            string regExPostalCode = @"^[A-Z]\d[A-Z] \d[A-Z]\d$";
                            if (!Regex.IsMatch(maskedTextBoxPostalCode.Text, regExPostalCode))
                            {
                                errorProvider.SetError(maskedTextBoxPostalCode, "Invalid Postal Code Format");
                            }
                            else
                            {
                                errorProvider.SetError(maskedTextBoxPostalCode, string.Empty);
                            }
                        }
                     
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

        private void dataGridViewCustomer_DoubleClick(object sender, EventArgs e)
        {
            int index = dataGridViewCustomer.CurrentRow.Index;
            customerVM.SetDisplayClient(customerVM.Customers[index]);

            CustomerEditDialog dlg = new CustomerEditDialog();
            dlg.CustomerVM = customerVM;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (maskedTextBoxClientCode.Text != "" && textBoxCompanyName.Text != "" && textBoxAddress1.Text != "" && Convert.ToDecimal(textBoxYTDSale.Text) >= 0.00m)
                {
                    Customer customer = customerVM.SaveCustomer(index);
                    customerVM.Customers.ResetItem(index);

                    string outputData = string.Format("{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n{5}\r\n{6}\r\n{7}\r\n{8}\r\n{9}"
                                             , customer.ClientCode
                                             , customer.CompanyName
                                             , customer.Address1
                                             , customer.Address2
                                             , customer.City
                                             , customer.Province
                                             , customer.PostalCode
                                             , customer.YTDSale
                                             , customer.CreditHold
                                             , customer.Notes);
                    //Enable All Output Detail Data
                    groupBoxDetail.Visible = true;
                    labelTitle.Visible = true;
                    labelOutput.Text = outputData;

                    //Display calculated properties TotalYTDSales and CreditHoldCount
                    labelTotalYTD.Text = customerVM.Customers.TotalYTDSales().ToString();
                    labelCreditHoldCount.Text = customerVM.Customers.CreditHoldCount().ToString();
                }
                else
                {
                    dlg.CustomerVM = customerVM;
                }

            }

            dlg.Dispose();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            customerVM.SetDisplayClient(new Customer());

            //set default for combobox Province
            comboBoxProvince.SelectedIndex = 0;
            customerVM.Province = this.comboBoxProvince.GetItemText(this.comboBoxProvince.SelectedItem);

            //Clear all textbox and errorProvider
            errorProvider.Clear();
            maskedTextBoxClientCode.Select();
            maskedTextBoxClientCode.SelectAll();
            maskedTextBoxClientCode.Enabled = true;
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = new DialogResult();
                if (cbComfirmDelete.Checked == true)
                {
                    dialogResult = MessageBox.Show("Do you want to delete this record?", "Confirm Record Deletion", MessageBoxButtons.YesNo);
                }
               
                if (dialogResult == DialogResult.No)
                {
                    //Close dialogResult
                }
                else
                {
                    Customer customer = customerVM.GetDisplayCustomer();
                    CustomerValidation.DeleteCustomer(customer);
                    customerVM.Customers = CustomerRepository.GetCustomer();
                    dataGridViewCustomer.DataSource = customerVM.Customers;
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
    }
}
