using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 언제나휴일_도서검색csv_카카오api
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            List<Book> books = BookSearcher.Search(tbox_query.Text);
            SetLVBooks(books);
            tbox_query.Text = "";
        }

        private void SetLVBooks(List<Book> books)
        {
            ListViewItem lvi;
            string[] datas;
            foreach (Book book in books)
            {
                datas = new string[3] { book.ISBN, book.Title, book.Author };
                lvi = new ListViewItem(datas);
                lv_book.Items.Add(lvi);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Book> books = BookSearcher.Load();
            SetLVBooks(books);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            BookSearcher.Save();
        }
    }
}
