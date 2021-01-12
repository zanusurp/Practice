namespace WindowsFormsApp1
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
            this.dgview = new System.Windows.Forms.DataGridView();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.albumIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.artistIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.albumBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chinookDataSet = new WindowsFormsApp1.ChinookDataSet();
            this.albumTableAdapter = new WindowsFormsApp1.ChinookDataSetTableAdapters.AlbumTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chinookDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dgview
            // 
            this.dgview.AutoGenerateColumns = false;
            this.dgview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.albumIdDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.artistIdDataGridViewTextBoxColumn});
            this.dgview.DataSource = this.albumBindingSource;
            this.dgview.Location = new System.Drawing.Point(13, 13);
            this.dgview.Name = "dgview";
            this.dgview.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgview.RowTemplate.Height = 27;
            this.dgview.Size = new System.Drawing.Size(775, 347);
            this.dgview.TabIndex = 0;
            this.dgview.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgview_CellMouseDoubleClick);
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(13, 385);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(637, 25);
            this.txt_search.TabIndex = 1;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(671, 386);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 2;
            this.btn_search.Text = "search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // albumIdDataGridViewTextBoxColumn
            // 
            this.albumIdDataGridViewTextBoxColumn.DataPropertyName = "AlbumId";
            this.albumIdDataGridViewTextBoxColumn.HeaderText = "AlbumId";
            this.albumIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.albumIdDataGridViewTextBoxColumn.Name = "albumIdDataGridViewTextBoxColumn";
            this.albumIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // artistIdDataGridViewTextBoxColumn
            // 
            this.artistIdDataGridViewTextBoxColumn.DataPropertyName = "ArtistId";
            this.artistIdDataGridViewTextBoxColumn.HeaderText = "ArtistId";
            this.artistIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.artistIdDataGridViewTextBoxColumn.Name = "artistIdDataGridViewTextBoxColumn";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 450);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.dgview);
            this.Name = "Form1";
            this.Text = "앨범검색";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chinookDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgview;
        private ChinookDataSet chinookDataSet;
        private System.Windows.Forms.BindingSource albumBindingSource;
        private ChinookDataSetTableAdapters.AlbumTableAdapter albumTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn albumIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn artistIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_search;
    }
}

