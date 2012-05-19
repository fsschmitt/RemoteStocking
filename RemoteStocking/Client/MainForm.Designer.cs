namespace Client
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PanelLeft = new System.Windows.Forms.Panel();
            this.btnAddStock = new System.Windows.Forms.Button();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblShareType = new System.Windows.Forms.Label();
            this.cbShareType = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblType = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblIDClient = new System.Windows.Forms.Label();
            this.txtIDClient = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbSearch = new System.Windows.Forms.ListBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.PanelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.PanelLeft);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel2.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel2.Controls.Add(this.lbSearch);
            this.splitContainer1.Panel2.Controls.Add(this.lblSearch);
            this.splitContainer1.Panel2.Controls.Add(this.txtSearch);
            this.splitContainer1.Size = new System.Drawing.Size(636, 230);
            this.splitContainer1.SplitterDistance = 297;
            this.splitContainer1.TabIndex = 0;
            // 
            // PanelLeft
            // 
            this.PanelLeft.Controls.Add(this.btnAddStock);
            this.PanelLeft.Controls.Add(this.lblPrice);
            this.PanelLeft.Controls.Add(this.txtPrice);
            this.PanelLeft.Controls.Add(this.lblShareType);
            this.PanelLeft.Controls.Add(this.cbShareType);
            this.PanelLeft.Controls.Add(this.lblQuantity);
            this.PanelLeft.Controls.Add(this.numQuantity);
            this.PanelLeft.Controls.Add(this.lblType);
            this.PanelLeft.Controls.Add(this.cbType);
            this.PanelLeft.Controls.Add(this.lblEmail);
            this.PanelLeft.Controls.Add(this.txtEmail);
            this.PanelLeft.Controls.Add(this.lblIDClient);
            this.PanelLeft.Controls.Add(this.txtIDClient);
            this.PanelLeft.Location = new System.Drawing.Point(3, 12);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Size = new System.Drawing.Size(291, 206);
            this.PanelLeft.TabIndex = 1;
            // 
            // btnAddStock
            // 
            this.btnAddStock.Location = new System.Drawing.Point(147, 130);
            this.btnAddStock.Name = "btnAddStock";
            this.btnAddStock.Size = new System.Drawing.Size(132, 36);
            this.btnAddStock.TabIndex = 12;
            this.btnAddStock.Text = "Add Stock";
            this.btnAddStock.UseVisualStyleBackColor = true;
            this.btnAddStock.Click += new System.EventHandler(this.btnAddStock_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(144, 88);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 11;
            this.lblPrice.Text = "Price:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(147, 104);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(131, 20);
            this.txtPrice.TabIndex = 10;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // lblShareType
            // 
            this.lblShareType.AutoSize = true;
            this.lblShareType.Location = new System.Drawing.Point(9, 88);
            this.lblShareType.Name = "lblShareType";
            this.lblShareType.Size = new System.Drawing.Size(38, 13);
            this.lblShareType.TabIndex = 9;
            this.lblShareType.Text = "Share:";
            // 
            // cbShareType
            // 
            this.cbShareType.FormattingEnabled = true;
            
            this.cbShareType.Location = new System.Drawing.Point(10, 104);
            this.cbShareType.Name = "cbShareType";
            this.cbShareType.Size = new System.Drawing.Size(132, 21);
            this.cbShareType.TabIndex = 8;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(144, 48);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(49, 13);
            this.lblQuantity.TabIndex = 7;
            this.lblQuantity.Text = "Quantity:";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(147, 65);
            this.numQuantity.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(132, 20);
            this.numQuantity.TabIndex = 6;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(9, 48);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 5;
            this.lblType.Text = "Type:";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Buy",
            "Sell"});
            this.cbType.Location = new System.Drawing.Point(9, 64);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(132, 21);
            this.cbType.TabIndex = 4;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(144, 9);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 3;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(147, 25);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(132, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // lblIDClient
            // 
            this.lblIDClient.AutoSize = true;
            this.lblIDClient.Location = new System.Drawing.Point(9, 9);
            this.lblIDClient.Name = "lblIDClient";
            this.lblIDClient.Size = new System.Drawing.Size(50, 13);
            this.lblIDClient.TabIndex = 1;
            this.lblIDClient.Text = "Client ID:";
            // 
            // txtIDClient
            // 
            this.txtIDClient.Location = new System.Drawing.Point(9, 25);
            this.txtIDClient.Name = "txtIDClient";
            this.txtIDClient.Size = new System.Drawing.Size(132, 20);
            this.txtIDClient.TabIndex = 0;
            this.txtIDClient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDClient_KeyPress);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(213, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 33);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "History";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbSearch
            // 
            this.lbSearch.FormattingEnabled = true;
            this.lbSearch.Location = new System.Drawing.Point(6, 77);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(326, 134);
            this.lbSearch.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(50, 13);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Client ID:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(59, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(264, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 230);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.PanelLeft.ResumeLayout(false);
            this.PanelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.TextBox txtIDClient;
        private System.Windows.Forms.Label lblIDClient;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblShareType;
        private System.Windows.Forms.ComboBox cbShareType;
        private System.Windows.Forms.Button btnAddStock;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListBox lbSearch;
        private System.Windows.Forms.Label lblSearch;
    }
}