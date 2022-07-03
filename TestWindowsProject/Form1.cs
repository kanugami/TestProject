using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsProject
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            txtSource.Text += ConfigurationManager.AppSettings["test"].ToString();
            //return;
            //string strJson = txtSource.Text;

            //List<JIRAFeilds> myDeserializedClass = JsonConvert.DeserializeObject<List<JIRAFeilds>>(strJson);
            //string sR = string.Join("\n", myDeserializedClass.Select(s => s.name + "," + s.custom + "," + s.key + "," + s.id + "," + s.searchable).ToArray());
            //txtResult.Text = sR;

        }


        private void button1_Click(object sender, EventArgs e)
        { 
           // params object[] obj = null;

            //FormType[] ChildClasses = Assembly.GetAssembly(typeof(Form)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Form))));
            //Type[] ChildClasses = Assembly.GetAssembly(typeof(Form)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract));

            foreach (Type Type in
                Assembly.GetExecutingAssembly().GetTypes()
                .Where(TheType => TheType.IsClass && !TheType.IsAbstract && TheType.IsSubclassOf(typeof(Form))))
            { 
                int a = 0;
                //AddView(Type.Name.Replace("View", ""), (BaseView)Activator.CreateInstance(Type));
            }


            //ReflectiveEnumerator.GetEnumerableOfType<Type>(obj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //s.get
        }
    }

}
    //public static class ReflectiveEnumerator
    //{
    //    static ReflectiveEnumerator() { }

    //    public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class, IComparable<T>
    //    {
    //        List<T> objects = new List<T>();
    //        foreach (Type type in
    //            Assembly.GetAssembly(typeof(T)).GetTypes()
    //            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
    //        {
    //            objects.Add((T)Activator.CreateInstance(type, constructorArgs));
    //        }
    //        objects.Sort();
    //        return objects;
    //    }
    //}

//    public class Schema
//    {
//        public string type { get; set; }
//        public string system { get; set; }
//        public string custom { get; set; }
//        public int? customId { get; set; }
//        public string items { get; set; }
//    }

//    public class JIRAFeilds
//    {
//        public string id { get; set; }
//        public string key { get; set; }
//        public string name { get; set; }
//        public bool custom { get; set; }
//        public bool orderable { get; set; }
//        public bool navigable { get; set; }
//        public bool searchable { get; set; }
//        public List<string> clauseNames { get; set; }
//        public Schema schema { get; set; }
//        public string untranslatedName { get; set; }
//    }

//}
