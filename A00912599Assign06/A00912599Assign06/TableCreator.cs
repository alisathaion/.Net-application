using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLibrary.Data;

namespace A00912599Assign06
{
    public partial class TableCreator : Form
    {
        public TableCreator()
        {
            InitializeComponent();
        }

        private void TableCreator_Load(object sender, EventArgs e)
        {
            labelResult.Text = string.Empty;
            textBoxStudentNumber.MaxLength = 6;
        }

        private void textBoxStudentNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void buttonCreateTable_Click(object sender, EventArgs e)
        {
            string inputStudentNumber = textBoxStudentNumber.Text.ToString();
            if (textBoxStudentNumber.Text != string.Empty && textBoxStudentNumber.TextLength == 6)
            {
                string TableName = "Client" + inputStudentNumber;
                bool result = CustomerRepository.CreateTable(TableName);
                if (result)
                {
                    labelResult.Text = "The table '" + TableName + "' has been created successfully";
                }
                else
                {
                    labelResult.Text = "There is already an object named '" + TableName + "' in the database";   
                }
            }
            else
            {
                labelResult.Text = "Please enter last 6 digits student number";
            }

            //set cusor focus on textbox
            textBoxStudentNumber.Text = inputStudentNumber;
            textBoxStudentNumber.Select();
        }
    }
}
