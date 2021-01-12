namespace NTierCalc
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
            this.digit1 = new System.Windows.Forms.NumericUpDown();
            this.digit2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.digit3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.digit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digit2)).BeginInit();
            this.SuspendLayout();
            // 
            // digit1
            // 
            this.digit1.Location = new System.Drawing.Point(68, 39);
            this.digit1.Name = "digit1";
            this.digit1.Size = new System.Drawing.Size(120, 25);
            this.digit1.TabIndex = 0;
            // 
            // digit2
            // 
            this.digit2.Location = new System.Drawing.Point(256, 39);
            this.digit2.Name = "digit2";
            this.digit2.Size = new System.Drawing.Size(120, 25);
            this.digit2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(394, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "=";
            // 
            // digit3
            // 
            this.digit3.Location = new System.Drawing.Point(466, 41);
            this.digit3.Name = "digit3";
            this.digit3.Size = new System.Drawing.Size(100, 25);
            this.digit3.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "&button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.digit3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.digit2);
            this.Controls.Add(this.digit1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.digit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown digit1;
        private System.Windows.Forms.NumericUpDown digit2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox digit3;
        private System.Windows.Forms.Button button1;
    }
}

