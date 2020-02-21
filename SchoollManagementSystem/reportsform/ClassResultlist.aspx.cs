using Microsoft.Reporting.WebForms;
using SMS.Entities;
using System;
using SMS.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SchoollManagementSystem.reportsform
{
    public partial class ClassResultlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int classs = Convert.ToInt32(Request.QueryString["cboclass"]);
                int cbosession = Convert.ToInt32(Request.QueryString["cbosession"]);
              
                int cboterm = Convert.ToInt32(Request.QueryString["cboterm"]);
                int cbosection = Convert.ToInt32(Request.QueryString["cbosection"]);
                int cbosubject = Convert.ToInt32(Request.QueryString["cbosubject"]);

                classmarkslist(classs,cbosession, cboterm, cbosection,cbosubject);
            }
        }
        private void classmarkslist(int ?classs, int ?cbosession,int ? cboterm,int ? cbosection,int? cbosubject)
        {
            SMSContext SMSContext = new SMSContext();
            SqlParameter tids = new SqlParameter("@termid",cboterm);
           SqlParameter subject = new SqlParameter("@subjectid",cbosubject);
            SqlParameter secs = new SqlParameter("@sectionid", cbosection);
            SqlParameter classids = new SqlParameter("@classid",classs);
            SqlParameter session = new SqlParameter("@session",cbosession);
          //ViewBag.name="cboclass="+ cboclass + "&" + "cboclass" + cboclass;
            var list = SMSContext.Database.SqlQuery<Studentclassresult>("classMarkslist @termid,@subjectid,@sectionid,@classid,@session", tids,subject,secs,classids,session).ToList();
            ReportDataSource rd = new ReportDataSource("DataSet1", list);
            ReportViewer1.LocalReport.DataSources.Add(rd);
            ReportViewer1.LocalReport.Refresh();

        }
    }
}