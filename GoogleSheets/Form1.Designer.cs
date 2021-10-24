
namespace GoogleSheets
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtCellNameSet = new System.Windows.Forms.TextBox();
            this.txtCellValue = new System.Windows.Forms.TextBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.txtCellNameGet = new System.Windows.Forms.TextBox();
            this.txtCellGetValue = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.btnStart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCellNameSet, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCellValue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSet, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCellNameGet, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCellGetValue, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnGet, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtCellNameSet
            // 
            this.txtCellNameSet.Location = new System.Drawing.Point(3, 32);
            this.txtCellNameSet.Name = "txtCellNameSet";
            this.txtCellNameSet.Size = new System.Drawing.Size(100, 20);
            this.txtCellNameSet.TabIndex = 1;
            // 
            // txtCellValue
            // 
            this.txtCellValue.Location = new System.Drawing.Point(109, 32);
            this.txtCellValue.Name = "txtCellValue";
            this.txtCellValue.Size = new System.Drawing.Size(100, 20);
            this.txtCellValue.TabIndex = 1;
            // 
            // btnSet
            // 
            this.btnSet.Enabled = false;
            this.btnSet.Location = new System.Drawing.Point(215, 32);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(100, 23);
            this.btnSet.TabIndex = 0;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // txtCellNameGet
            // 
            this.txtCellNameGet.Location = new System.Drawing.Point(3, 61);
            this.txtCellNameGet.Name = "txtCellNameGet";
            this.txtCellNameGet.Size = new System.Drawing.Size(100, 20);
            this.txtCellNameGet.TabIndex = 1;
            // 
            // txtCellGetValue
            // 
            this.txtCellGetValue.Location = new System.Drawing.Point(215, 61);
            this.txtCellGetValue.Name = "txtCellGetValue";
            this.txtCellGetValue.ReadOnly = true;
            this.txtCellGetValue.Size = new System.Drawing.Size(100, 20);
            this.txtCellGetValue.TabIndex = 1;
            // 
            // btnGet
            // 
            this.btnGet.Enabled = false;
            this.btnGet.Location = new System.Drawing.Point(109, 61);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(100, 23);
            this.btnGet.TabIndex = 0;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtCellNameSet;
        private System.Windows.Forms.TextBox txtCellValue;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.TextBox txtCellNameGet;
        private System.Windows.Forms.TextBox txtCellGetValue;
        private System.Windows.Forms.Button btnGet;
    }
}

