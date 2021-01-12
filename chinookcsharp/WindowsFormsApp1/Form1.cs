using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static string searchtxt = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'chinookDataSet.Album' table. You can move, or remove it, as needed.
            this.albumTableAdapter.Fill(this.chinookDataSet.Album);

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            List<Albums> albums = new List<Albums>();
            
            using(ChinookEntities context = new ChinookEntities())
            {
                searchtxt = txt_search.Text;
                var query = from x in context.Albums
                            where x.Title.Contains(searchtxt)
                            select x;
                foreach (var item in query)
                {
                    Albums album = new Albums();
                    album.AlbumID = item.AlbumId;
                    album.Title = item.Title;
                    album.ArtistID = item.ArtistId;
                    albums.Add(album);
                }
                if (txt_search.Text == "")
                {
                    this.albumTableAdapter.Fill(this.chinookDataSet.Album);
                }
                dgview.DataSource = albums;
                
            }
            
            
        }

        private void dgview_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            string firstPara= searchtxt;
            int secondPara= e.RowIndex;

            MessageBox.Show((secondPara+1).ToString()+"번째 목록 입니다.");
            
            
         
            Miniform m = new Miniform(firstPara,secondPara);
            m.Show();

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
