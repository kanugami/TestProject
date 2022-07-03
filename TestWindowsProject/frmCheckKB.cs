using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsProject
{
    public partial class frmCheckKB : Form
    {
        public frmCheckKB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //A a =new A();
            //a.b = 5;

        }
    }

    public class A
    {
        private int a;
        public int b;

        private A(int c)
        { }
    }

    public class B 
    {
        private A a ;
        
        public B(int c) 
        {
            a.b = 2;
        }
    }
}
