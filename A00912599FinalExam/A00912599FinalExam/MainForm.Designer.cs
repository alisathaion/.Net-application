namespace A00912599FinalExam
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listBoxSKUList = new System.Windows.Forms.ListBox();
            this.lbSKU = new System.Windows.Forms.Label();
            this.lbQty = new System.Windows.Forms.Label();
            this.labelSku = new System.Windows.Forms.Label();
            this.textBoxQty = new System.Windows.Forms.TextBox();
            this.textBoxSku = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxExtended = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelExtended = new System.Windows.Forms.Label();
            this.checkBoxTaxable = new System.Windows.Forms.CheckBox();
            this.labelTitleResult = new System.Windows.Forms.Label();
            this.labelGrandTotal = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelGST = new System.Windows.Forms.Label();
            this.labelPST = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxSKUList
            // 
            this.listBoxSKUList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxSKUList.FormattingEnabled = true;
            this.listBoxSKUList.Location = new System.Drawing.Point(12, 25);
            this.listBoxSKUList.Name = "listBoxSKUList";
            this.listBoxSKUList.Size = new System.Drawing.Size(120, 184);
            this.listBoxSKUList.TabIndex = 0;
            this.listBoxSKUList.SelectedIndexChanged += new System.EventHandler(this.listBoxSKUList_SelectedIndexChanged);
            // 
            // lbSKU
            // 
            this.lbSKU.AutoSize = true;
            this.lbSKU.Location = new System.Drawing.Point(12, 9);
            this.lbSKU.Name = "lbSKU";
            this.lbSKU.Size = new System.Drawing.Size(48, 13);
            this.lbSKU.TabIndex = 1;
            this.lbSKU.Text = "&SKU List";
            // 
            // lbQty
            // 
            this.lbQty.AutoSize = true;
            this.lbQty.Location = new System.Drawing.Point(157, 28);
            this.lbQty.Name = "lbQty";
            this.lbQty.Size = new System.Drawing.Size(49, 13);
            this.lbQty.TabIndex = 2;
            this.lbQty.Text = "&Quantity:";
            // 
            // labelSku
            // 
            this.labelSku.AutoSize = true;
            this.labelSku.Location = new System.Drawing.Point(157, 55);
            this.labelSku.Name = "labelSku";
            this.labelSku.Size = new System.Drawing.Size(32, 13);
            this.labelSku.TabIndex = 3;
            this.labelSku.Text = "&SKU:";
            // 
            // textBoxQty
            // 
            this.textBoxQty.Location = new System.Drawing.Point(224, 25);
            this.textBoxQty.Name = "textBoxQty";
            this.textBoxQty.Size = new System.Drawing.Size(100, 20);
            this.textBoxQty.TabIndex = 1;
            // 
            // textBoxSku
            // 
            this.textBoxSku.Location = new System.Drawing.Point(224, 52);
            this.textBoxSku.Name = "textBoxSku";
            this.textBoxSku.Size = new System.Drawing.Size(100, 20);
            this.textBoxSku.TabIndex = 2;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(224, 79);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(201, 20);
            this.textBoxDescription.TabIndex = 3;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(224, 106);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrice.TabIndex = 4;
            // 
            // textBoxExtended
            // 
            this.textBoxExtended.Location = new System.Drawing.Point(224, 133);
            this.textBoxExtended.Name = "textBoxExtended";
            this.textBoxExtended.Size = new System.Drawing.Size(100, 20);
            this.textBoxExtended.TabIndex = 5;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(157, 82);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(63, 13);
            this.labelDescription.TabIndex = 9;
            this.labelDescription.Text = "&Description:";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(157, 109);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(34, 13);
            this.labelPrice.TabIndex = 10;
            this.labelPrice.Text = "&Price:";
            // 
            // labelExtended
            // 
            this.labelExtended.AutoSize = true;
            this.labelExtended.Location = new System.Drawing.Point(157, 136);
            this.labelExtended.Name = "labelExtended";
            this.labelExtended.Size = new System.Drawing.Size(55, 13);
            this.labelExtended.TabIndex = 11;
            this.labelExtended.Text = "&Extended:";
            // 
            // checkBoxTaxable
            // 
            this.checkBoxTaxable.AutoSize = true;
            this.checkBoxTaxable.Location = new System.Drawing.Point(224, 159);
            this.checkBoxTaxable.Name = "checkBoxTaxable";
            this.checkBoxTaxable.Size = new System.Drawing.Size(64, 17);
            this.checkBoxTaxable.TabIndex = 6;
            this.checkBoxTaxable.Text = "&Taxable";
            this.checkBoxTaxable.UseVisualStyleBackColor = true;
            // 
            // labelTitleResult
            // 
            this.labelTitleResult.AutoSize = true;
            this.labelTitleResult.Location = new System.Drawing.Point(454, 25);
            this.labelTitleResult.Name = "labelTitleResult";
            this.labelTitleResult.Size = new System.Drawing.Size(66, 91);
            this.labelTitleResult.TabIndex = 13;
            this.labelTitleResult.Text = "Sub Total:\r\n\r\nGST:\r\n\r\nPST:\r\n\r\nGrand Total:";
            // 
            // labelGrandTotal
            // 
            this.labelGrandTotal.AutoSize = true;
            this.labelGrandTotal.Location = new System.Drawing.Point(526, 103);
            this.labelGrandTotal.Name = "labelGrandTotal";
            this.labelGrandTotal.Size = new System.Drawing.Size(60, 13);
            this.labelGrandTotal.TabIndex = 14;
            this.labelGrandTotal.Text = "GrandTotal";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(350, 155);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(526, 25);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(42, 13);
            this.labelTotal.TabIndex = 15;
            this.labelTotal.Text = "TOTAL";
            // 
            // labelGST
            // 
            this.labelGST.AutoSize = true;
            this.labelGST.Location = new System.Drawing.Point(526, 50);
            this.labelGST.Name = "labelGST";
            this.labelGST.Size = new System.Drawing.Size(29, 13);
            this.labelGST.TabIndex = 16;
            this.labelGST.Text = "GST";
            // 
            // labelPST
            // 
            this.labelPST.AutoSize = true;
            this.labelPST.Location = new System.Drawing.Point(526, 76);
            this.labelPST.Name = "labelPST";
            this.labelPST.Size = new System.Drawing.Size(28, 13);
            this.labelPST.TabIndex = 17;
            this.labelPST.Text = "PST";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 216);
            this.Controls.Add(this.labelPST);
            this.Controls.Add(this.labelGST);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelGrandTotal);
            this.Controls.Add(this.labelTitleResult);
            this.Controls.Add(this.checkBoxTaxable);
            this.Controls.Add(this.labelExtended);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBoxExtended);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxSku);
            this.Controls.Add(this.textBoxQty);
            this.Controls.Add(this.labelSku);
            this.Controls.Add(this.lbQty);
            this.Controls.Add(this.lbSKU);
            this.Controls.Add(this.listBoxSKUList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COMP2614 Final Exam";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSKUList;
        private System.Windows.Forms.Label lbSKU;
        private System.Windows.Forms.Label lbQty;
        private System.Windows.Forms.Label labelSku;
        private System.Windows.Forms.TextBox textBoxQty;
        private System.Windows.Forms.TextBox textBoxSku;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxExtended;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelExtended;
        private System.Windows.Forms.CheckBox checkBoxTaxable;
        private System.Windows.Forms.Label labelTitleResult;
        private System.Windows.Forms.Label labelGrandTotal;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelGST;
        private System.Windows.Forms.Label labelPST;
    }
}

