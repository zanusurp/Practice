using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTierCalc.Engine
{
    //public delegate void OnzeroDelegate(double a, double b);
    public class Calculator
    {
        //public OnzeroDelegate onZero;
        public Action<double, double> onZero;
        public double devide(double a, double b)
        {
            
            if (b == 0)
            {
                onZero(a, b);
                MessageBox.Show("b값이 0");
                Console.WriteLine("b값이 영이 돨 수 없읍니다.");
                return 0;
            }
            return a / b;
        }
       
    }
}
