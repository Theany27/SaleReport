namespace SaleReport
{
    partial class Form1
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
            this.tblgetdata = new System.Windows.Forms.DataGridView();
            this.startdate = new System.Windows.Forms.DateTimePicker();
            this.enddate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnreport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfilter = new System.Windows.Forms.TextBox();
            this.btnfilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tblgetdata)).BeginInit();
            this.SuspendLayout();
            // 
            // tblgetdata
            // 
            this.tblgetdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblgetdata.Location = new System.Drawing.Point(76, 190);
            this.tblgetdata.Name = "tblgetdata";
            this.tblgetdata.Size = new System.Drawing.Size(628, 193);
            this.tblgetdata.TabIndex = 0;
            // 
            // startdate
            // 
            this.startdate.Location = new System.Drawing.Point(219, 76);
            this.startdate.Name = "startdate";
            this.startdate.Size = new System.Drawing.Size(200, 20);
            this.startdate.TabIndex = 1;
            this.startdate.ValueChanged += new System.EventHandler(this.startdate_ValueChanged);
            // 
            // enddate
            // 
            this.enddate.Location = new System.Drawing.Point(219, 122);
            this.enddate.Name = "enddate";
            this.enddate.Size = new System.Drawing.Size(200, 20);
            this.enddate.TabIndex = 2;
            this.enddate.ValueChanged += new System.EventHandler(this.enddate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start Date";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "End Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnreport
            // 
            this.btnreport.Location = new System.Drawing.Point(557, 426);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(147, 35);
            this.btnreport.TabIndex = 5;
            this.btnreport.Text = "Generate Report";
            this.btnreport.UseVisualStyleBackColor = true;
            this.btnreport.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(104, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Select Day";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtfilter
            // 
            this.txtfilter.Location = new System.Drawing.Point(452, 75);
            this.txtfilter.Name = "txtfilter";
            this.txtfilter.Size = new System.Drawing.Size(131, 20);
            this.txtfilter.TabIndex = 7;
            this.txtfilter.TextChanged += new System.EventHandler(this.txtfilter_TextChanged);
            // 
            // btnfilter
            // 
            this.btnfilter.Location = new System.Drawing.Point(599, 75);
            this.btnfilter.Name = "btnfilter";
            this.btnfilter.Size = new System.Drawing.Size(75, 23);
            this.btnfilter.TabIndex = 8;
            this.btnfilter.Text = "Fillter";
            this.btnfilter.UseVisualStyleBackColor = true;
            this.btnfilter.Click += new System.EventHandler(this.btnfilter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Controls.Add(this.btnfilter);
            this.Controls.Add(this.txtfilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnreport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enddate);
            this.Controls.Add(this.startdate);
            this.Controls.Add(this.tblgetdata);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblgetdata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tblgetdata;
        private System.Windows.Forms.DateTimePicker startdate;
        private System.Windows.Forms.DateTimePicker enddate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnreport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtfilter;
        private System.Windows.Forms.Button btnfilter;
    }
}

