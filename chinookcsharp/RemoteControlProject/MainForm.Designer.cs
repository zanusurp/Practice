namespace RemoteControlProject
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
            this.components = new System.ComponentModel.Container();
            this.tbox_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_setting = new System.Windows.Forms.Button();
            this.timer_send_imag = new System.Windows.Forms.Timer(this.components);
            this.btn_ok = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbox_controller_ip = new System.Windows.Forms.TextBox();
            this.noti = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // tbox_ip
            // 
            this.tbox_ip.Location = new System.Drawing.Point(174, 30);
            this.tbox_ip.Name = "tbox_ip";
            this.tbox_ip.Size = new System.Drawing.Size(379, 25);
            this.tbox_ip.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "원격 호스트 주소:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_setting
            // 
            this.btn_setting.Location = new System.Drawing.Point(575, 28);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(134, 25);
            this.btn_setting.TabIndex = 2;
            this.btn_setting.Text = "설정하기";
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // timer_send_imag
            // 
            this.timer_send_imag.Tick += new System.EventHandler(this.timer_send_imag_Tick);
            // 
            // btn_ok
            // 
            this.btn_ok.Enabled = false;
            this.btn_ok.Location = new System.Drawing.Point(575, 83);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(134, 25);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "원격 제어 허용";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "원격 컨트롤러 주소:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbox_controller_ip
            // 
            this.tbox_controller_ip.Location = new System.Drawing.Point(174, 85);
            this.tbox_controller_ip.Name = "tbox_controller_ip";
            this.tbox_controller_ip.ReadOnly = true;
            this.tbox_controller_ip.Size = new System.Drawing.Size(379, 25);
            this.tbox_controller_ip.TabIndex = 3;
            // 
            // noti
            // 
            this.noti.Text = "notifyIcon1";
            this.noti.Visible = true;
            this.noti.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.noti_MouseDoubleClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 248);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbox_controller_ip);
            this.Controls.Add(this.btn_setting);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbox_ip);
            this.Name = "MainForm";
            this.Text = "원격제어기";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbox_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.Timer timer_send_imag;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbox_controller_ip;
        private System.Windows.Forms.NotifyIcon noti;
    }
}

