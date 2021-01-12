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
    public partial class Miniform : Form
    {
        public  static string firstPara;
        int secondP = 0;
        public Miniform()
        {
            InitializeComponent();
        }
        public Miniform(string firstPara1, int secondPara)
        {
            firstPara= firstPara1;
            this.secondP = secondPara;
            InitializeComponent();
        }


        private void Miniform_Load(object sender, EventArgs e)
        {
            
            
            using(ChinookEntities context =  new ChinookEntities())
            { 
                List<Albums> albums = new List<Albums>();
                var query = from x in context.Albums
                            where x.Title.Contains(firstPara)
                            select x;
                foreach (var item in query)
                {
                    Albums album = new Albums();
                    album.AlbumID = item.AlbumId;
                    album.Title = item.Title;
                    album.ArtistID = item.ArtistId;
                    albums.Add(album);
                }
                string message = albums[secondP].AlbumID.ToString()+ albums[secondP].Title.ToString();
                
                textBox1.Text = albums[secondP].AlbumID.ToString();
                textBox2.Text = albums[secondP].Title.ToString();
                textBox3.Text = albums[secondP].ArtistID.ToString();
                //dataGridView1.DataSource = albums[secondP];이거 다시 찾아봐야

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
