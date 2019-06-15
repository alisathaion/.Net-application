namespace A00912599Assign05
{
    partial class ValidatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidatorForm));
            this.textBox_Year = new System.Windows.Forms.TextBox();
            this.textBox_Month = new System.Windows.Forms.TextBox();
            this.textBox_Day = new System.Windows.Forms.TextBox();
            this.Label_Year = new System.Windows.Forms.Label();
            this.label_Month = new System.Windows.Forms.Label();
            this.label_Day = new System.Windows.Forms.Label();
            this.button_checkDate = new System.Windows.Forms.Button();
            this.lb_result = new System.Windows.Forms.Label();
            this.toolTip_on_result = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // textBox_Year
            // 
            this.textBox_Year.Location = new System.Drawing.Point(12, 40);
            this.textBox_Year.Name = "textBox_Year";
            this.textBox_Year.Size = new System.Drawing.Size(70, 20);
            this.textBox_Year.TabIndex = 0;
            // 
            // textBox_Month
            // 
            this.textBox_Month.Location = new System.Drawing.Point(88, 40);
            this.textBox_Month.Name = "textBox_Month";
            this.textBox_Month.Size = new System.Drawing.Size(70, 20);
            this.textBox_Month.TabIndex = 1;
            // 
            // textBox_Day
            // 
            this.textBox_Day.Location = new System.Drawing.Point(164, 40);
            this.textBox_Day.Name = "textBox_Day";
            this.textBox_Day.Size = new System.Drawing.Size(70, 20);
            this.textBox_Day.TabIndex = 2;
            // 
            // Label_Year
            // 
            this.Label_Year.AutoSize = true;
            this.Label_Year.Location = new System.Drawing.Point(13, 21);
            this.Label_Year.Name = "Label_Year";
            this.Label_Year.Size = new System.Drawing.Size(32, 13);
            this.Label_Year.TabIndex = 3;
            this.Label_Year.Text = "Year:";
            // 
            // label_Month
            // 
            this.label_Month.AutoSize = true;
            this.label_Month.Location = new System.Drawing.Point(88, 20);
            this.label_Month.Name = "label_Month";
            this.label_Month.Size = new System.Drawing.Size(40, 13);
            this.label_Month.TabIndex = 4;
            this.label_Month.Text = "Month:";
            // 
            // label_Day
            // 
            this.label_Day.AutoSize = true;
            this.label_Day.Location = new System.Drawing.Point(164, 19);
            this.label_Day.Name = "label_Day";
            this.label_Day.Size = new System.Drawing.Size(29, 13);
            this.label_Day.TabIndex = 5;
            this.label_Day.Text = "Day:";
            // 
            // button_checkDate
            // 
            this.button_checkDate.Location = new System.Drawing.Point(159, 88);
            this.button_checkDate.Name = "button_checkDate";
            this.button_checkDate.Size = new System.Drawing.Size(75, 23);
            this.button_checkDate.TabIndex = 6;
            this.button_checkDate.Text = "Check Date";
            this.button_checkDate.UseVisualStyleBackColor = true;
            this.button_checkDate.Click += new System.EventHandler(this.button_checkDate_Click);
            // 
            // lb_result
            // 
            this.lb_result.AutoSize = true;
            this.lb_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_result.Location = new System.Drawing.Point(12, 85);
            this.lb_result.Name = "lb_result";
            this.lb_result.Size = new System.Drawing.Size(85, 24);
            this.lb_result.TabIndex = 7;
            this.lb_result.Text = "<result>";
            // 
            // ValidatorForm
            // 
            this.AcceptButton = this.button_checkDate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 123);
            this.Controls.Add(this.lb_result);
            this.Controls.Add(this.button_checkDate);
            this.Controls.Add(this.label_Day);
            this.Controls.Add(this.label_Month);
            this.Controls.Add(this.Label_Year);
            this.Controls.Add(this.textBox_Day);
            this.Controls.Add(this.textBox_Month);
            this.Controls.Add(this.textBox_Year);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ValidatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Date Validator";
            this.Load += new System.EventHandler(this.ValidatorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Year;
        private System.Windows.Forms.TextBox textBox_Month;
        private System.Windows.Forms.TextBox textBox_Day;
        private System.Windows.Forms.Label Label_Year;
        private System.Windows.Forms.Label label_Month;
        private System.Windows.Forms.Label label_Day;
        private System.Windows.Forms.Button button_checkDate;
        private System.Windows.Forms.Label lb_result;
        private System.Windows.Forms.ToolTip toolTip_on_result;
    }
}

