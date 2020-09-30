namespace ApiServerTestForm
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
            this.btnStartUpload = new System.Windows.Forms.Button();
            this.txtUrlApi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStartUpload
            // 
            this.btnStartUpload.Location = new System.Drawing.Point(12, 60);
            this.btnStartUpload.Name = "btnStartUpload";
            this.btnStartUpload.Size = new System.Drawing.Size(75, 23);
            this.btnStartUpload.TabIndex = 0;
            this.btnStartUpload.Text = "Upload File";
            this.btnStartUpload.UseVisualStyleBackColor = true;
            this.btnStartUpload.Click += new System.EventHandler(this.btnStartUpload_Click);
            // 
            // txtUrlApi
            // 
            this.txtUrlApi.Location = new System.Drawing.Point(22, 13);
            this.txtUrlApi.Name = "txtUrlApi";
            this.txtUrlApi.Size = new System.Drawing.Size(273, 20);
            this.txtUrlApi.TabIndex = 1;
            this.txtUrlApi.Text = "https://localhost:44318/UploadFile";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtUrlApi);
            this.Controls.Add(this.btnStartUpload);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartUpload;
        private System.Windows.Forms.TextBox txtUrlApi;
    }
}

