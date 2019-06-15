using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A00912599Assign05
{
    public partial class ValidatorForm : Form
    {
        public ValidatorForm()
        {
            InitializeComponent();
           
        }

        private void ValidatorForm_Load(object sender, EventArgs e)
        {
            //clear label for result
            lb_result.Text = string.Empty;
      
        }

        private void button_checkDate_Click(object sender, EventArgs e)
        {
            //collect input from textbox by take out all whitespace
            string year = textBox_Year.Text.ToString().Trim().Replace(" ",string.Empty);
            string month = textBox_Month.Text.ToString().Trim().Replace(" ",string.Empty);
            string day = textBox_Day.Text.ToString().Trim().Replace(" ",string.Empty);

            //call DateValidator method to check if value is valid or not
            bool result = DateValidator.Validate(year, month,day);
            
            //if Value is Valid
            if (result == true)
            {
                lb_result.ForeColor = Color.Green;
                toolTip_on_result.SetToolTip(lb_result, "Entered Date is Valid");
                lb_result.Text = "Valid";
            }
            //if Value is not Valid
            else
            {
                lb_result.ForeColor = Color.Red;
                toolTip_on_result.SetToolTip(lb_result, "Entered Date is NOT Valid");
                lb_result.Text = "InValid";
            }

            //Clear All textbox for the next input
            textBox_Year.Text = year;
            textBox_Month.Text = month;
            textBox_Day.Text = day;
            
            //focus on first textbox for next input
            textBox_Year.Select();

           
        }

       
    }
}
