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

    public partial class FinePrint : System.Web.UI.Page
    {
        SMSContext obj = new SMSContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    int getid = Convert.ToInt32(Request.QueryString["id"]);
                    getreport(getid);
                }

            }
            

        }
        private void getreport(int id)
        {

            SqlParameter ids = new SqlParameter("@id", id);
            var list = obj.Database.SqlQuery<finelist>("printstudentfine @id", ids).ToList();
            ReportDataSource rd = new ReportDataSource("DataSet1", list);
            ReportViewer1.LocalReport.DataSources.Add(rd);
            ReportViewer1.LocalReport.Refresh();
        }
    }

}