using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMS.Data;
using SMS.Entities;
using Microsoft.Reporting.WebForms;

namespace SchoollManagementSystem.reportsform
{
    public partial class ClassStatuslocalV : System.Web.UI.Page
    {
        


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int classs = Convert.ToInt32( Request.QueryString["cboclass"]);
               
                int cbocategory = Convert.ToInt32(Request.QueryString["cbocategory"]);
                int cbosession = Convert.ToInt32(Request.QueryString["cbosession"]);
                int cboterm = Convert.ToInt32(Request.QueryString["cboterm"]);
                int cbosection = Convert.ToInt32(Request.QueryString["cbosection"]);
                StudentFeesStatusv(classs,cbosession,cbocategory,cboterm, cbosection);
            }

        }
        private void StudentFeesStatusv(int? cboclass, int? cbosession, int? cbocategory, int cboterm,int cbosection)
        {
            SMSContext SMSContext = new SMSContext();
            SqlParameter classids = new SqlParameter("@classid", cboclass);
            SqlParameter catids = new SqlParameter("@catid", cbocategory);
            SqlParameter sids = new SqlParameter("@Sid", cbosession);
            SqlParameter tids = new SqlParameter("@tid", cboterm);
            SqlParameter secs = new SqlParameter("@sec", cbosection);

            //ViewBag.name = "cboclass=" + cboclass + "&" + "cbosession=" + cbosession + "&" + "cbocategory=" + cbocategory + "&" + "cboterm=" + cboterm + "&" + "cbosection=" + cbosection;
            var list = SMSContext.Database.SqlQuery<StudentfeesStatusmodel>("studentfeesstatuss @classid,@catid,@Sid,@tid,@sec", classids, catids, sids, tids, secs).ToList();

            ReportDataSource rd = new ReportDataSource("DataSet1", list);
            ReportViewer1.LocalReport.DataSources.Add(rd);
            ReportViewer1.LocalReport.Refresh();

        }
    }
}