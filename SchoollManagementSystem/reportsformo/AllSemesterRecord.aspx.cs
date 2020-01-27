using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using SMS.Data;
using SMS.Entities;
using System.Web.UI.WebControls;

namespace SchoollManagementSystem.reportsform
{
    public partial class AllSemesterRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int classs = Convert.ToInt32(Request.QueryString["cboclass"]);

                int cbosession = Convert.ToInt32(Request.QueryString["cbosession"]);
                
                StudentFeesStatusv(classs, cbosession);
            }
        }
        private void StudentFeesStatusv(int cboclass, int cbosession)
        {
            SMSContext SMSContext = new SMSContext();
            

            //ViewBag.name = "cboclass=" + cboclass + "&" + "cbosession=" + cbosession + "&" + "cbocategory=" + cbocategory + "&" + "cboterm=" + cboterm + "&" + "cbosection=" + cbosection;
            var list = SMSContext.allSemesterfeesRecord.ToList().Where(x => x.session ==cbosession  && x.classes==cboclass);

            ReportDataSource rd = new ReportDataSource("DataSet1", list);
            ReportViewer1.LocalReport.DataSources.Add(rd);
            ReportViewer1.LocalReport.Refresh();

        }
    }
}