using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary.Data;
using ClassLibrary.Common;

namespace A00912599FinalExam
{
    public partial class MainForm : Form
    {
        private InvoiceViewModel invoiceVM;
        private TaxViewModel taxesVM;
        int selectedIndex;
        Invoice invoice;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                //Disable all label for result
                labelTitleResult.Visible = false;
                labelGrandTotal.Visible = false;
                labelTotal.Visible = false;
                labelGST.Visible = false;
                labelPST.Visible = false;

                //binding data from database to Listbox
                invoiceVM = new InvoiceViewModel(InvoiveRepository.GetInvoice());
                setDataBindings();

                
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

        private void setDataBindings()
        {
            textBoxQty.DataBindings.Add("Text", invoiceVM, "Quantity", true, DataSourceUpdateMode.OnValidation, "0", "#,##0;(#,##0));0");
            textBoxSku.DataBindings.Add("Text", invoiceVM, "Sku", false, DataSourceUpdateMode.OnValidation, "");
            textBoxDescription.DataBindings.Add("Text", invoiceVM, "Description");
            textBoxPrice.DataBindings.Add("Text", invoiceVM, "Price", true, DataSourceUpdateMode.OnValidation, "0.00", "#,##0.00;(#,##0.00));0.00");
            checkBoxTaxable.DataBindings.Add("Checked", invoiceVM, "Taxable");
       
            listBoxSKUList.DataSource = invoiceVM.Invoices;
            listBoxSKUList.DisplayMember = "Sku";
        }

        private void listBoxSKUList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //show data when Listbox has been changed
            selectedIndex = Math.Max(0, listBoxSKUList.SelectedIndex);
            invoice = invoiceVM.Invoices[selectedIndex];
            invoiceVM.SetDisplayInvoice(invoice);
            //calculate extended from quantity and price
            textBoxExtended.Text = (invoice.Quantity * invoice.Price).ToString();

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //save invoice from textbox changed
            invoice = invoiceVM.SaveInvoice(selectedIndex);

            //Calculate SubTotal
            decimal subTotal = invoiceVM.Invoices.subTotal();
            decimal gstTax = 0.00m;
            decimal gstTotal = 0.00m;
            decimal pstTax = 0.00m;
            labelTotal.Text = subTotal.ToString();

            //Get Tax from database
            taxesVM = new TaxViewModel(InvoiveRepository.GetTaxRate());
            for (int i = 0; i < taxesVM.Taxes.Count; i++)
            {
                if (taxesVM.Taxes[i].Taxcode == "GST")
                {
                    gstTax = taxesVM.Taxes[i].TaxRate;
                    gstTotal = (gstTax * subTotal) / 100;
                    labelGST.Text = gstTotal.ToString("#.##");
                }
                if(taxesVM.Taxes[i].Taxcode == "BCPST")
                {
                    if (checkBoxTaxable.Checked)
                    {
                        pstTax = (taxesVM.Taxes[i].TaxRate * subTotal) / 100;
                        labelPST.Text = pstTax.ToString("#.##");
                    }
                    else
                    {
                        pstTax = (gstTax * subTotal) / 100;
                        labelPST.Text = pstTax.ToString("#.##");
                    }
               
                }
            }
            //Calculate GrandTotal
            labelGrandTotal.Text = (subTotal + gstTax + pstTax).ToString("#.##"); 
            
            //Show all result label
            labelTitleResult.Visible = true;
            labelTotal.Visible = true;
            labelGrandTotal.Visible = true;
            labelPST.Visible = true;
            labelGST.Visible = true;


        }
    }
}
