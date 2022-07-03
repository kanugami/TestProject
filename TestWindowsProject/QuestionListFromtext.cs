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
    public enum QueStage
    {
        QueText,
        A,
        B,
        C,
        D,
        CorrectAns,
        Explanation,
        Consider
    }
    public partial class QuestionListFromtext : Form
    {
        string NewLine = "\n";
        bool IsCleanQue = true;
        bool IsExcelFile = true;
        string QuesPattern = @"^\d+";
        string OptionAPattern = @"^[aA]";
        string OptionBPattern = @"^[bB]";
        string OptionCPattern = @"^[cC]";
        string OptionDPattern = @"^[dD]";
        string AnswerPattern = @"^Answer:";
        string ExplainPattern = @"^Explanation:";
        string ConsiderPattern = @"^Consider:";

        public QuestionListFromtext()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtQueList.Text = "";
            List<Question> lstQue = new List<Question>();
            #region File List
            List<Tuple<string, string>> fileList = new List<Tuple<string, string>>();
            Tuple<string, string> t = null;
            t = new Tuple<string, string>(@"C:\Temp\TestProject\TestProject\Question\RDBMS_300_File1.txt", "RDBMS");
            fileList.Add(t);
            t = new Tuple<string, string>(@"C:\Temp\TestProject\TestProject\Question\RDBMS_100_File2.txt", "RDBMS");
            fileList.Add(t);
            t = new Tuple<string, string>(@"C:\Temp\TestProject\TestProject\Question\Data Structures and Algorithms MCQs_File2.txt", "DataStructure");
            fileList.Add(t);
            t = new Tuple<string, string>(@"C:\Temp\TestProject\TestProject\Question\Apptitude_File1.txt", "Aptitude");
            fileList.Add(t);
            t = new Tuple<string, string>(@"C:\Temp\TestProject\TestProject\Question\OOPS_54Que_File2.txt", "OOPS");
            fileList.Add(t);
            t = new Tuple<string, string>(@"C:\Temp\TestProject\TestProject\Question\OOPS_50Que_File2.txt", "OOPS");
            fileList.Add(t);
            t = new Tuple<string, string>(@"C:\Temp\TestProject\TestProject\Question\OOPS_10Que_File1.txt", "OOPS");
            fileList.Add(t);
            t = new Tuple<string, string>(@"C:\Temp\TestProject\TestProject\Question\HTML_File1.txt", "HTML");
            fileList.Add(t);
            t = new Tuple<string, string>(@"C:\Temp\TestProject\TestProject\Question\BasicProgramming_File1.txt", "Basic C");

            fileList.Add(t);

            #endregion

            //tuples.Add(new Tuple(@"C:\Temp\TestProject\TestProject\Question\RDBMS_300_File1.txt","RDBMS">);
            //string strFilePath = @"C:\Temp\TestProject\TestProject\Question\RDBMS_300_File1.txt";
            //string strFilePath = @"C:\Temp\TestProject\TestProject\Question\RDBMS_100_File2.txt";
            //string strFilePath = @"C:\Temp\TestProject\TestProject\Question\Data Structures and Algorithms MCQs_File2.txt";//First 100 Que -Answer need to find
            //string strFilePath = @"C:\Temp\TestProject\TestProject\Question\Apptitude_File1.txt";
            //string strFilePath = @"C:\Temp\TestProject\TestProject\Question\OOPS_54Que_File2.txt";
            //string strFilePath = @"C:\Temp\TestProject\TestProject\Question\OOPS_50Que_File2.txt";
            foreach (Tuple<string, string> tupple in fileList)
            {
                //string strFilePath = @"C:\Temp\TestProject\TestProject\Question\OOPS_10Que_File1.txt";
                string[] strLines = File.ReadAllLines(tupple.Item1);
                //string QuesPattern = @"^\d";

                //string[] strQuestions = strLines.Where(l => Regex.IsMatch(l,regexQuestion)).ToArray();
                //string[] strQuestions = strLines.Where(l => Regex.IsMatch(l, OptionPattern)).ToArray();

                Question q = null;
                QueStage qStage = QueStage.QueText;

                foreach (string line in strLines)
                {
                    if (line.Trim() == string.Empty)
                        continue;
                    if (Regex.IsMatch(line, QuesPattern))
                    {
                        if (q != null)
                        {
                            this.cleanQuestion(q);
                            q.SrNo = lstQue.Count + 1;
                            lstQue.Add(q);
                        }
                        q = new Question();
                        q.Category = tupple.Item2;
                        qStage = QueStage.QueText;
                    }
                    if (Regex.IsMatch(line, OptionAPattern))
                    {
                        qStage = QueStage.A;
                    }
                    if (Regex.IsMatch(line, OptionBPattern))
                    {
                        qStage = QueStage.B;
                    }
                    if (Regex.IsMatch(line, OptionCPattern))
                    {
                        qStage = QueStage.C;
                    }
                    if (Regex.IsMatch(line, OptionDPattern))
                    {
                        qStage = QueStage.D;
                    }
                    if (Regex.IsMatch(line, AnswerPattern))
                    {
                        qStage = QueStage.CorrectAns;
                    }
                    if (Regex.IsMatch(line, ExplainPattern))
                    {
                        qStage = QueStage.Explanation;
                    }
                    if (Regex.IsMatch(line, ConsiderPattern))
                    {
                        qStage = QueStage.Consider;
                    }
                    if (q == null)
                    {
                        continue;
                    }
                    switch (qStage)
                    {
                        case QueStage.QueText:
                            q.QueText += NewLine + line;
                            break;
                        case QueStage.A:
                            q.OptionA += NewLine + line;
                            break;
                        case QueStage.B:
                            q.OptionB += NewLine + line;
                            break;
                        case QueStage.C:
                            q.OptionC += NewLine + line;
                            break;
                        case QueStage.D:
                            q.OptionD += NewLine + line;
                            break;
                        case QueStage.CorrectAns:
                            q.CorrectAns += NewLine + line;
                            break;
                        case QueStage.Explanation:
                            q.Explanation += NewLine + line;
                            break;
                        case QueStage.Consider:
                            q.Consider += NewLine + line;
                            break;
                        default:
                            break;
                    }
                }
                if (q != null)
                {
                    this.cleanQuestion(q);
                    q.SrNo = lstQue.Count + 1;
                    lstQue.Add(q);
                }
            }
            txtQueList.Text = lstQue.Count.ToString();

            dataGridView1.DataSource = lstQue.Where(l => l.Consider != null).ToList<Question>();
            txtQueList.Text = ((List<Question>)dataGridView1.DataSource).Count.ToString();
            ////txtQueList.Lines = strQuestions;
            ///
            IsExcelFile = chkExcel.Checked;
            if (IsExcelFile)
            {
                ExcelHelper.ExcelHelper excelHelper = new ExcelHelper.ExcelHelper();
                ClosedXML.Excel.XLWorkbook xLWorkbook = excelHelper.ListToExcel(lstQue.Where(l => l.Consider != null).ToList<Question>());
                try
                {

                    xLWorkbook.SaveAs(@"C:\Temp\TestProject\TestProject\Question\RDBMS_300_File1.xlsx");
                }
                catch (FileLoadException ex)
                {

                    throw ex;
                }
            }

            if (chkPaperSet.Checked)
            {
                this.createPaperset(lstQue.Where(l => l.Consider != null).ToList<Question>(), 5);
            }
        }

        private void createPaperset(List<Question> lstQue, int NoOfPaperset)
        {
            List<Question> lstPaper = new List<Question>();
            string[] pCategory = {   "Aptitude|5",
                                    "Basic C|6",
                                    "DataStructure|5",
                                    "OOPS|9",
                                    "RDBMS|5"
                                };
            foreach (string sCat in pCategory)
            {
                int Que = Convert.ToInt32(sCat.Split('|')[1]);
                string Cat = sCat.Split('|')[0];
                List<Question> lstCatQ = lstQue.Where(t => t.Category == Cat).OrderBy(x => Guid.NewGuid()).Take(Que).ToList< Question>();
                lstPaper.AddRange(lstCatQ);
            }
            lstPaper = lstPaper.OrderBy(x => Guid.NewGuid()).ToList<Question>();
            int iCnt = 1;
            lstPaper = (from q in lstPaper select new Question {SrNo= (iCnt++), QueText=q.QueText+"\n",OptionA = ("A)  "+ q.OptionA + "\n" + "B)  " + q.OptionB + (q.OptionC!=null?("\nC)  " + q.OptionC):"") + (q.OptionD!=null?("\nD)  " + q.OptionD):"")).Trim('\n'),CorrectAns=q.CorrectAns.ToUpper() }).ToList<Question>();

            dataGridView1.DataSource = lstPaper;
            //return (from examQ in idb.Exam_Question_Int_Tbl
            //        where examQ.Exam_Tbl_ID == exam_id
            //        select examQ).OrderBy(x => Guid.NewGuid()).Take(50);


        }
        private void cleanQuestion(Question q)
        {
            if (IsCleanQue == false)
                return;
            q.CorrectAns = q.CorrectAns.Trim('\n');
            if (q.CorrectAns.Length > 9)
                q.CorrectAns = q.CorrectAns.Substring(0, 9);
            q.CorrectAns = q.CorrectAns.Replace("Answer:", "").Trim().Trim(')').ToLower();

            if (q.Explanation != null)
                q.Explanation = q.Explanation.Trim('\n');
            //q.OrgQueText = q.QueText;
            q.QueText = q.QueText.Trim('\n');
            q.QueText = Regex.Replace(q.QueText, QuesPattern, "").Trim().TrimStart(')').TrimStart('.').Trim();

            if (q.OptionA != null)
                q.OptionA = Regex.Replace(q.OptionA.Trim('\n'), OptionAPattern, "").Trim('\n').Trim().TrimStart(')').TrimStart('.').Trim();

            if (q.OptionB != null)
                q.OptionB = Regex.Replace(q.OptionB.Trim('\n'), OptionBPattern, "").Trim('\n').Trim().TrimStart(')').TrimStart('.').Trim();

            if (q.OptionC != null)
                q.OptionC = Regex.Replace(q.OptionC.Trim('\n'), OptionCPattern, "").Trim('\n').Trim().TrimStart(')').TrimStart('.').Trim();

            if (q.OptionD != null)
                q.OptionD = Regex.Replace(q.OptionD.Trim('\n'), OptionDPattern, "").Trim('\n').Trim().TrimStart(')').TrimStart('.').Trim();

            if (q.Explanation != null)
                q.Explanation = Regex.Replace(q.Explanation.Trim('\n'), ExplainPattern, "").Trim('\n').Trim().TrimStart(')').TrimStart('.').Trim();

            if (q.Consider != null)
                q.Consider = Regex.Replace(q.Consider.Trim('\n'), ConsiderPattern, "").Trim('\n').Trim().TrimStart(')').TrimStart('.').Trim();


        }

    }

    public class Question
    {
        public int SrNo
        { get; set; }
  
        public string QueText
        {
            get;
            set;
        }
        //public string OrgQueText
        //{
        //    get;
        //    set;
        //}
        public string OptionA
        { get; set; }
        public string OptionB
        { get; set; }
        public string OptionC
        { get; set; }
        public string OptionD
        { get; set; }

        public string CorrectAns
        { get; set; }
        public string Category

        { get; set; }
        public string Consider

        { get; set; }
        public string Explanation
        { get; set; }





    }
}
