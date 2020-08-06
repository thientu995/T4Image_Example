namespace T4Image_WindowsFormApp_v2._0._0
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pic_QR = new System.Windows.Forms.PictureBox();
            this.pic_Barcode = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_QR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Barcode)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pic_QR
            // 
            this.pic_QR.Location = new System.Drawing.Point(12, 38);
            this.pic_QR.Name = "pic_QR";
            this.pic_QR.Size = new System.Drawing.Size(182, 105);
            this.pic_QR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_QR.TabIndex = 2;
            this.pic_QR.TabStop = false;
            // 
            // pic_Barcode
            // 
            this.pic_Barcode.Location = new System.Drawing.Point(12, 149);
            this.pic_Barcode.Name = "pic_Barcode";
            this.pic_Barcode.Size = new System.Drawing.Size(182, 105);
            this.pic_Barcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Barcode.TabIndex = 3;
            this.pic_Barcode.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 264);
            this.Controls.Add(this.pic_Barcode);
            this.Controls.Add(this.pic_QR);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pic_QR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Barcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pic_QR;
        private System.Windows.Forms.PictureBox pic_Barcode;
    }
}

