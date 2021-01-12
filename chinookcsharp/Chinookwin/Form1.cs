using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chinookwin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'chinookDataSet.Album' table. You can move, or remove it, as needed.
            using(ChinookEntities context = new ChinookEntities())
            {
                var query = from x in context.Albums
                            select x;
                foreach (var item in query)
                {
                    dgv.add
                }
                
            }

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("hi");
            int left = int.Parse(txtLeft.Text);
            int right = int.Parse(txtRight.Text);
            int sum = left + right;
            txtResult.Text = sum.ToString("N0");
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.albumTableAdapter.FillBy(this.chinookDataSet.Album);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
