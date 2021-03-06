﻿using Microsoft.Reporting.WebForms;
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
    public partial class StudentResultterm : System.Web.UI.Page
    {
        SMSContext obj = new SMSContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int getid = Convert.ToInt32(Request.QueryString["id"]);
                int termid = Convert.ToInt32(Request.QueryString["termid"]);
                int subjectid = Convert.ToInt32(Request.QueryString["subjectid"]);
                getreport(getid, termid,subjectid);
            }

        }
        private void getreport(int id, int termid,int subjectid)
        {

            SqlParameter ids = new SqlParameter("@studentid", id);
            SqlParameter subjectids = new SqlParameter("@subjectid",subjectid);
            SqlParameter termids = new SqlParameter("@termid", termid);
            var list = obj.Database.SqlQuery<Studentclassresult>("studentresultbyterm @studentid,@termid,@subjectid", ids, termids,subjectids).ToList();
            ReportDataSource rd = new ReportDataSource("DataSet1", list);
            ReportViewer1.LocalReport.DataSources.Add(rd);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}