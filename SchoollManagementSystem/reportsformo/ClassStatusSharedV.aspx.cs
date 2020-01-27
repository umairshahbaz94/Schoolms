using SMS.Entities;
using System;
using SMS.Data;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

namespace SchoollManagementSystem.reportsform
{
    public partial class ClassStatusSharedV : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int classs = Convert.ToInt32(Request.QueryString["cboclass"]);
                int cbosession = Convert.ToInt32(Request.QueryString["cbosession"]);
                int cbocategory = Convert.ToInt32(Request.QueryString["cbocategory"]);
                int cboterm = Convert.ToInt32(Request.QueryString["cboterm"]);
                int cbosection = Convert.ToInt32(Request.QueryString["cbosection"]);
                StudentFeesStatusv(classs, cbosession, cbocategory, cboterm,cbosection);
            }
          
        }
        private void StudentFeesStatusv(int? cboclass, int? cbosession, int? cbocategory, int cboterm,int cbosection)
        {
            SMSContext SMSContext = new SMSContext();
            SqlParameter classids = new SqlParameter("@classid", cboclass);
            SqlParameter catids = new SqlParameter("@catid", cbosession);
            SqlParameter sids = new SqlParameter("@Sid", cbocategory);
            SqlParameter tids = new SqlParameter("@tid", cboterm);
            SqlParameter secs = new SqlParameter("@sec", cboterm);
            //ViewBag.name="cboclass="+ cboclass + "&" + "cboclass" + cboclass;
            var list = SMSContext.Database.SqlQuery<StudentfeesStatusmodel>("studentfeesstatussshared @classid,@catid,@Sid,@tid,@sec", classids, catids, sids, tids, secs).ToList();
            ReportDataSource rd = new ReportDataSource("DataSet1", list);
            ReportViewer1.LocalReport.DataSources.Add(rd);
            ReportViewer1.LocalReport.Refresh();

        }

    }
}