using Microsoft.Reporting.WebForms;
using SMS.Data;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoollManagementSystem.reportsform
{
    public partial class Grade : System.Web.UI.Page
    {
        SMSContext obj = new SMSContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int classs = Convert.ToInt32(Request.QueryString["cid"]);
                int term = Convert.ToInt32(Request.QueryString["tid"]);
                int sectionid = Convert.ToInt32(Request.QueryString["seid"]);
                int sessionid = Convert.ToInt32(Request.QueryString["sessid"]);
                //int subjectid = Convert.ToInt32(Request.QueryString["subid"]);
                int studendid = Convert.ToInt32(Request.QueryString["student"]);
                getreport(classs, term, sectionid,sessionid/*,subjectid*/,studendid);
            }
        }
        private void getreport(int classs, int term, int sectionid,int sessionid/*,/*int  subjectid*/,int  studendid )
        {

            SqlParameter classes = new SqlParameter("@cid", classs);
            SqlParameter terms = new SqlParameter("@tid",term);
            SqlParameter sections = new SqlParameter("@seid", sectionid);
            SqlParameter sessionids = new SqlParameter("@sessid", sessionid);
           
            SqlParameter studentids = new SqlParameter("@student",studendid);

            var list = obj.Database.SqlQuery<Studentgrade>("GradeProc @cid,@tid," +
                "@seid,@sessid,@student", 
                classes, terms, sections,sessionids/*,subjectid*/, studentids).ToList();
            ReportDataSource rd = new ReportDataSource("DataSet1", list);
            ReportViewer1.LocalReport.DataSources.Add(rd);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}