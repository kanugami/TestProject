using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsProject
{
    public partial class LogViewer : Form
    {
        public LogViewer()
        {
            InitializeComponent();
            if (Properties.Settings.Default.localPath != "")
                txtFolder.Text = Properties.Settings.Default.localPath;

            chkSubFolder.Checked = Properties.Settings.Default.blSubFolder;


        }

        private void btnReadLog_Click(object sender, EventArgs e)
        {
            saveSetting();

            txtResult.Text = ReadgRPClogs();

        }

        private string ReadgRPClogs()
        {
            StringBuilder sb = new StringBuilder();
            string pattern = @"(\d{8},\d{2}:\d{2}:\d{2}.\d{3})";
            sb.AppendLine($"FileName\tReq\tType\t#Records\tStartTime\tEndTime\tMilliseconds");
            foreach (string strFile in Directory.GetFiles(txtFolder.Text, "*detaillog*.log", (chkSubFolder.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)))
            {
                //string strFile1 = @"C:\PerfLogs\20X50_s_10_detaillog_2206202219.log";
                DateTime dteStartTime = DateTime.MinValue;
                DateTime dteEndTime = DateTime.MinValue;
                int i = 0;
                foreach (string strLine in File.ReadLines(strFile))
                {
                    if (strLine.Trim() == "")
                        continue;
                    i++;
                    string s = strLine;
                    Match match = Regex.Match(s, pattern);
                    if (match != null)
                    {
                        if (dteStartTime == DateTime.MinValue)
                            dteStartTime = this.ConvertDateFormat_gRPC(match);
                        dteEndTime = this.ConvertDateFormat_gRPC(match);
                    }
                }
                FileInfo f = new FileInfo(strFile);
                TimeSpan ts = dteEndTime.Subtract(dteStartTime);
                string[] sfPart = f.Name.Split('_');
                sb.AppendLine($"{f.Directory.Name}\\{f.Name}\t{(sfPart.Length> 0?sfPart[0]:"")}\t{(sfPart.Length > 1 ? sfPart[1] : "")}\t{i}\t'{dteStartTime.ToString("HH:mm:ss.fff")}\t'{dteEndTime.ToString("HH:mm:ss.fff")}\t{ts.TotalMilliseconds}");
                //sb.AppendLine(f.Directory.Name + "\\" + f.Name + "\t" + s);
            }
            return sb.ToString();
        }

        private string Readlogs()
        {
            StringBuilder sb = new StringBuilder();
            //string strMatch = "dd/dd/dddd";
            string strMatch = @"^\d+";
            //string pattern = @"^\d{2}\/\d{2}\/\d{4}";
            string pattern = @"^(\d{2}\/\d{2}\/\d{4})|(\d{2}\-\d{2}\-\d{4})|(\d{1}\/\d{2}\/\d{4})";
            //Regex r = new Regex(pattern);
            //var res = r.Replace(text, new MatchEvaluator(ConvertDateFormat));
            foreach (string strFile in Directory.GetFiles(txtFolder.Text, "*.*", (chkSubFolder.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)))
            {
                // string strFile = @"C:\Logs\20220425_tokenApiLog.txt";

                foreach (string strLine in File.ReadLines(strFile))
                {
                    if (Regex.IsMatch(strLine, strMatch))
                    {
                        string s = strLine.Replace("\r", "").Replace("\t", "").Replace(" : ", "\t");
                        s = (s.Length > 250 ? s.Substring(0, 250) : s);
                        s = Regex.Replace(s, pattern, new MatchEvaluator(ConvertDateFormat));
                        FileInfo f = new FileInfo(strFile);
                        sb.AppendLine(f.Directory.Name + "\\" + f.Name + "\t" + s);
                    }
                }

            }
            return sb.ToString();
        }

        private DateTime ConvertDateFormat_gRPC(Match match)
        {
            DateTime mydate = DateTime.MinValue;
            try
            {
                mydate = Convert.ToDateTime(match.Value.Insert(4, "/").Insert(7, "/"));
            }
            catch
            {
                //mydate = DateTime.ParseExact(match.Value, "M/dd/yyyy", null);
            }
            return mydate;
        }

        private string ConvertDateFormat(Match match)
        {
            DateTime mydate = DateTime.MinValue;
            try
            {
                mydate = DateTime.Parse(match.Value);
            }
            catch
            {
                mydate = DateTime.ParseExact(match.Value, "M/dd/yyyy", null);
            }



            return mydate.ToString("yyyy-MM-dd");
            return match.Value;
        }

        async private void btnSearch_Click(object sender, EventArgs e)
        {
            saveSetting();
            //txtResult.Text = string.Format(System.Windows.Forms.Application.StartupPath + "\\ErrorLog_{0}.log", (DateTime.Now.ToString("MMMyy")) + "_" + (DateTime.Now.Day / 7));
            //txtResult.Multiline = true;
            //StringBuilder sb = new StringBuilder();
            //for (int i = 1; i <= 31; i++)
            //{
            //     sb.AppendLine(string.Format("{1}=>{0}\n\r", (DateTime.Now.ToString("MMMyy")) + "_" + ((i-1) / 7),i));
            //}
            //txtResult.Text = sb.ToString();

            //for (int i = 1; i <= 31; i++)
            //{
            //     sb.AppendLine(string.Format("{1}=>{0}\n\r", (DateTime.Now.ToString("MMMyy")) + "_" + ((i-1) / 7),i));
            //}
            //Method1();
            //Method2();
            //for (int i = 1; i <= 4; i++)
            //{
            //    //sb.AppendLine(string.Format("{1}=>{0}\n\r", (DateTime.Now.ToString("MMMyy")) + "_" + ((i - 1) / 7), i));
            //    CheckAsync(i);
            //    txtResult.Text += $"Search Called - {i}";
            //}
            //txtResult.Text += $"Completed Call";
            // return;
            string strKey = txtResult.Text;
            foreach (string strFile in Directory.GetFiles(txtFolder.Text, "*.*", (chkSubFolder.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)))
            {
                // string strFile = @"C:\Logs\20220425_tokenApiLog.txt";

                if (File.ReadAllText(strFile).Contains(strKey))
                {
                    txtResult.Text += "\n" + strFile;
                }

            }

        }
        private void saveSetting()
        {
            Properties.Settings.Default.localPath = txtFolder.Text;
            Properties.Settings.Default.blSubFolder = chkSubFolder.Checked;
            Properties.Settings.Default.Save();
        }
        public async Task Method1()
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 1");
                    // Do something
                    Task.Delay(100).Wait();
                }
            });
        }


        public void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(" Method 2");
                // Do something
                Task.Delay(100).Wait();
            }
        }



        async private Task CheckAsync(int i)
        {

            //System.Threading.Thread.Sleep(1000);
            if (i % 2 == 0)
            {

            }
            txtResult.Text += $"CheckAsync - {i}";
            txtResult.Refresh();

        }
    }

    public abstract class ABC
    {

    }
}
