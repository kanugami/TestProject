using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           // pnlLinks.Padding = new Padding(20, 20, 0, 0);
            foreach (Type Type in
               Assembly.GetExecutingAssembly().GetTypes()
               .Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(Form))))
            {
                if (Type.Name == this.Name)
                    continue;
                
                //AddView(Type.Name.Replace("View", ""), (BaseView)Activator.CreateInstance(Type));
                LinkLabel l = new LinkLabel();
                l.AutoSize = false;
                l.Name = "link"+Type.Name;
                l.Text = Type.Name;
                l.Height = 30;
                l.TextAlign = ContentAlignment.MiddleLeft;
                l.Width = 1000;
                l.Tag = Type.FullName;
                l.Click += Link_Click;
                l.Padding = new Padding(20, 0, 0, 0);
                pnlLinks.Controls.Add(l);
            }
        }

        private void Link_Click(object sender, EventArgs e)
        {
            Type t = Type.GetType((sender as LinkLabel).Tag.ToString());
            Form f= (Form)Activator.CreateInstance(t);
            f.Show();
        }
    }
}
