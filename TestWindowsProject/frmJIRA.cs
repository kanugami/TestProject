using Atlassian.Jira;
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
    public partial class frmJIRA : Form
    {


        Jira jira = Jira.CreateRestClient("https://contisx.atlassian.net/", "kanu.gami@contis.com", "732oNlev9rPL33PPWF3R12BA");

        // use LINQ syntax to retrieve issues

        public frmJIRA()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var issue = jira.CreateIssue("SYS");
            issue.Type = "Bug";
            issue.Summary = "testing issue - need to delete";
            issue.SaveChanges();


        }
        private Int64 getInt64()
        {
            return Convert.ToInt64(null);
        }
        private void btnFetch_Click(object sender, EventArgs e)
        {
            Int64 intTemp;
            intTemp = getInt64();
            string s = Convert.ToString(intTemp);
            MessageBox.Show($" intTemp ={ s} ;");
            //MessageBox.Show($" intTemp ={ intTemp} ;");
            //MessageBox.Show($" intTemp ={ intTemp} ;");
            return;
            Issue iss = null;
            MessageBox.Show(nameof(iss));

            return;
            List<ProjectComponent> projectComponents = jira.Components.GetComponentsAsync("SYS").Result.ToList<ProjectComponent>();


            var issues = from i in jira.Issues.Queryable
                         where i.Project == "SYS" && i.Summary == "+216892805" //&&  i.Assignee == "admin" && i.Priority == "Major"
                         orderby i.Created
                         select i;
            List<Issue> lIs = issues.ToList<Issue>();

            foreach (Issue i in lIs)
            {

                MessageBox.Show(i.JiraIdentifier + " , " + i.Key);
            }



        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {

            List<ProjectComponent> projectComponents = jira.Components.GetComponentsAsync("SYS").Result.ToList<ProjectComponent>();

            DateTime dteNow = DateTime.Now;
            List<Issue> issueList = (from i in jira.Issues.Queryable
                                     where i.Project == "SYS" && i.Summary == "+KanuGami"//i.Summary == "Rest API" //&&  i.Assignee == "admin" && i.Priority == "Major"
                                                                                         //&& i.Components. == projectComponents[0]
                                     orderby i.Created descending
                                     select i).ToList<Issue>();

            // Issue issue = null;
            string strIssueKey = "";
            string projectComponent = "Banking";
            Issue issue = issueList.Where(i => i.Status.StatusCategory.Name.ToUpper() != "DONE" && (i.Components.Count > 0 && i.Components.Where(c => c.Name == projectComponent).Count<ProjectComponent>() > 0))
                                        .FirstOrDefault<Issue>();



            Issue Parrentissue = issueList.Where(i => i.Status.StatusCategory.Name.ToUpper() == "DONE" && (i.Components.Count > 0 && i.Components.Where(c => c.Name == projectComponent).Count<ProjectComponent>() > 0))
                                        .FirstOrDefault<Issue>();
            if (Parrentissue != null)
            {
                strIssueKey = Parrentissue.Key.Value.ToString();
            }

            //for (int i = 0; i < issueList.Count; i++)
            //{
            //    Issue issueTemp = issueList[i];
            //    if (issueTemp.Components.Where(c => c.Name == "Banking").Count<ProjectComponent>() > 0)
            //    {
            //        if (issueTemp.Status.StatusCategory.Name.ToUpper() == "DONE")
            //        {
            //            strIssueKey = issueTemp.Key.ToString();
            //        }
            //        else
            //        {
            //            issue = issueTemp;
            //        }
            //    }
            //    if (issue != null & strIssueKey != "")
            //    {
            //        strIssueKey
            //        break;
            //    }
            //}


            if (issue != null)
            {
                MessageBox.Show("Issue not found");

                // return;
            }
            if (issue == null)
            {
                MessageBox.Show("Issue not found");
                // return;
            }
            issue.Summary = issue.Summary + "Test Summary_DELETE";
            issue["Occurrence"] = DateTime.Now.Second.ToString();

            //issue.Components.Add(projectComponents[0]);

            issue["First Occurrence Date"] = DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss.szzz");
            // issue["Last Occurrence Date"] = DateTime.Now.ToString();

            //if (strIssueKey != "")
            //{

            //    await issue.LinkToIssueAsync(strIssueKey, "duplicates");
            //}
            issue.SaveChanges();



            //issue.SaveChanges();
            TimeSpan ts = DateTime.Now.Subtract(dteNow);
            MessageBox.Show("Time : " + ts.TotalMilliseconds);
            //List<Issue> lIs = issues.ToList<Issue>();

            //foreach (Issue i in lIs)
            //{
            //    MessageBox.Show(i.JiraIdentifier + " , " + i.Key);
            //}
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            Class1 cls = null;

            Class1 cls2 = (Class1)cls;
        }
    }
}
