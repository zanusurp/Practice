using NTierCalc.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTierCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(digit1.Value);
            double b = Convert.ToDouble(digit2.Value);

            Calculator cal = new Calculator();
            
            //함수 정의 후 이름 지정
            cal.onZero = NotifiedInvalidOperand; //아래 있음 즉 익명함수 사용 calculator에 이미 방향 적혀 있음

            //익명함수
            cal.onZero = delegate (double x, double y) //a,b는 상위에 이미 사용됨
            {
                MessageBox.Show($"유효하지 ㅇ낳음 a={x} b={y}");
            };
            //람다식
            cal.onZero = (x, y) => MessageBox.Show($"유효하지않은 수 a={a} b={b}");

            digit3.Text = cal.devide(a, b).ToString();
            
        }
        private void NotifiedInvalidOperand(double a, double b)
        {
            MessageBox.Show($"유효하지 않은 매개변수 : a={a}, b={b}");
        }
    }
}
