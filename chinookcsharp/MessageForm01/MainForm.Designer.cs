namespace MessageForm01
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
            this.tbox_msg = new System.Windows.Forms.TextBox();
            this.lbox_msg = new System.Windows.Forms.ListBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.lbox_user = new System.Windows.Forms.ListBox();
            this.btn_logout = new System.Windows.Forms.Button();
            this.btn_withdraw = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tbox_msg
            // 
            this.tbox_msg.Location = new System.Drawing.Point(238, 402);
            this.tbox_msg.Name = "tbox_msg";
            this.tbox_msg.Size = new System.Drawing.Size(572, 25);
            this.tbox_msg.TabIndex = 6;
            // 
            // lbox_msg
            // 
            this.lbox_msg.AllowDrop = true;
            this.lbox_msg.FormattingEnabled = true;
            this.lbox_msg.ItemHeight = 15;
            this.lbox_msg.Location = new System.Drawing.Point(238, 63);
            this.lbox_msg.Name = "lbox_msg";
            this.lbox_msg.Size = new System.Drawing.Size(707, 319);
            this.lbox_msg.TabIndex = 7;
            this.lbox_msg.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbox_msg_DragDrop);
            this.lbox_msg.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbox_msg_DragEnter);
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(816, 403);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(129, 24);
            this.btn_send.TabIndex = 8;
            this.btn_send.Text = "메모보내기";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // lbox_user
            // 
            this.lbox_user.FormattingEnabled = true;
            this.lbox_user.ItemHeight = 15;
            this.lbox_user.Location = new System.Drawing.Point(12, 63);
            this.lbox_user.Name = "lbox_user";
            this.lbox_user.Size = new System.Drawing.Size(208, 364);
            this.lbox_user.TabIndex = 9;
            this.lbox_user.SelectedIndexChanged += new System.EventHandler(this.lbox_user_SelectedIndexChanged);
            // 
            // btn_logout
            // 
            this.btn_logout.Location = new System.Drawing.Point(12, 12);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(75, 23);
            this.btn_logout.TabIndex = 10;
            this.btn_logout.Text = "로그아웃";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // btn_withdraw
            // 
            this.btn_withdraw.Location = new System.Drawing.Point(123, 12);
            this.btn_withdraw.Name = "btn_withdraw";
            this.btn_withdraw.Size = new System.Drawing.Size(75, 23);
            this.btn_withdraw.TabIndex = 11;
            this.btn_withdraw.Text = "탈퇴";
            this.btn_withdraw.UseVisualStyleBackColor = true;
            this.btn_withdraw.Click += new System.EventHandler(this.btn_withdraw_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btn_send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 450);
            this.Controls.Add(this.btn_withdraw);
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.lbox_user);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.lbox_msg);
            this.Controls.Add(this.tbox_msg);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbox_msg;
        private System.Windows.Forms.ListBox lbox_msg;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.ListBox lbox_user;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Button btn_withdraw;
        private System.Windows.Forms.Timer timer1;
    }
}

