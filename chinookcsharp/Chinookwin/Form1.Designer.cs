namespace Chinookwin
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
            this.components = new System.ComponentModel.Container();
            this.lbloperator = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.albumIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artistIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chinookDataSet = new Chinookwin.ChinookDataSet();
            this.albumTableAdapter = new Chinookwin.ChinookDataSetTableAdapters.AlbumTableAdapter();
            this.fillByToolStrip = new System.Windows.Forms.ToolStrip();
            this.fillByToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chinookDataSet)).BeginInit();
            this.fillByToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbloperator
            // 
            this.lbloperator.AutoSize = true;
            this.lbloperator.Location = new System.Drawing.Point(146, 33);
            this.lbloperator.Name = "lbloperator";
            this.lbloperator.Size = new System.Drawing.Size(15, 15);
            this.lbloperator.TabIndex = 0;
            this.lbloperator.Text = "+";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(302, 33);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "=";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(26, 30);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(100, 25);
            this.txtLeft.TabIndex = 2;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(398, 34);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(100, 25);
            this.txtResult.TabIndex = 2;
            // 
            // txtRight
            // 
            this.txtRight.Location = new System.Drawing.Point(181, 33);
            this.txtRight.Name = "txtRight";
            this.txtRight.Size = new System.Drawing.Size(100, 25);
            this.txtRight.TabIndex = 2;
            // 
            // dgv
            // 
            this.dgv.AutoGenerateColumns = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.albumIdDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.artistIdDataGridViewTextBoxColumn});
            this.dgv.DataSource = this.albumBindingSource;
            this.dgv.Location = new System.Drawing.Point(26, 98);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 27;
            this.dgv.Size = new System.Drawing.Size(424, 211);
            this.dgv.TabIndex = 3;
            // 
            // albumIdDataGridViewTextBoxColumn
            // 
            this.albumIdDataGridViewTextBoxColumn.DataPropertyName = "AlbumId";
            this.albumIdDataGridViewTextBoxColumn.HeaderText = "AlbumId";
            this.albumIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.albumIdDataGridViewTextBoxColumn.Name = "albumIdDataGridViewTextBoxColumn";
            this.albumIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.albumIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.Width = 125;
            // 
            // artistIdDataGridViewTextBoxColumn
            // 
            this.artistIdDataGridViewTextBoxColumn.DataPropertyName = "ArtistId";
            this.artistIdDataGridViewTextBoxColumn.HeaderText = "ArtistId";
            this.artistIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.artistIdDataGridViewTextBoxColumn.Name = "artistIdDataGridViewTextBoxColumn";
            this.artistIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // albumBindingSource
            // 
            this.albumBindingSource.DataMember = "Album";
            this.albumBindingSource.DataSource = this.chinookDataSet;
            // 
            // chinookDataSet
            // 
            this.chinookDataSet.DataSetName = "ChinookDataSet";
            this.chinookDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // albumTableAdapter
            // 
            this.albumTableAdapter.ClearBeforeFill = true;
            // 
            // fillByToolStrip
            // 
            this.fillByToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.fillByToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillByToolStripButton});
            this.fillByToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fillByToolStrip.Name = "fillByToolStrip";
            this.fillByToolStrip.Size = new System.Drawing.Size(800, 27);
            this.fillByToolStrip.TabIndex = 4;
            this.fillByToolStrip.Text = "fillByToolStrip";
            // 
            // fillByToolStripButton
            // 
            this.fillByToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fillByToolStripButton.Name = "fillByToolStripButton";
            this.fillByToolStripButton.Size = new System.Drawing.Size(48, 24);
            this.fillByToolStripButton.Text = "FillBy";
            this.fillByToolStripButton.Click += new System.EventHandler(this.fillByToolStripButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fillByToolStrip);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.txtRight);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtLeft);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.lbloperator);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chinookDataSet)).EndInit();
            this.fillByToolStrip.ResumeLayout(false);
            this.fillByToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbloperator;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtRight;
        private System.Windows.Forms.DataGridView dgv;
        private ChinookDataSet chinookDataSet;
        private System.Windows.Forms.BindingSource albumBindingSource;
        private ChinookDataSetTableAdapters.AlbumTableAdapter albumTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn albumIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn artistIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip fillByToolStrip;
        private System.Windows.Forms.ToolStripButton fillByToolStripButton;
    }
}

