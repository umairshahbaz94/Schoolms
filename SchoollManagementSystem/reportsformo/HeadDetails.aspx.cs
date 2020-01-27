using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using SMS.Data;
using System.Web.UI.WebControls;
using SMS.Entities;
using Microsoft.Reporting.WebForms;

namespace SchoollManagementSystem.reportsform
{
    public partial class HeadDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!IsPostBack)
                {
                    int cboclass = Convert.ToInt32(Request.QueryString["cboclass"]);
                    int cbosession = Convert.ToInt32(Request.QueryString["cbosession"]);
                    int cbovoucher = Convert.ToInt32(Request.QueryString["cbovoucher"]);
                    int cbocategory = Convert.ToInt32(Request.QueryString["cbocategory"]);
                    int cboterm = Convert.ToInt32(Request.QueryString["cboterm"]);
                    int cbosection = Convert.ToInt32(Request.QueryString["cbosection"]);
                    int cboprogram = Convert.ToInt32(Request.QueryString["cboprogram"]);
                    int cbohead = Convert.ToInt32(Request.QueryString["cbohead"]);
                    DateTime start =Convert.ToDateTime(Request.QueryString["start"]);
                    DateTime End = Convert.ToDateTime(Request.QueryString["End"]);
                    getreport(cboclass,cbosession,cbovoucher,cbocategory,cboterm,cbosection,cboprogram,cbohead,start,End);
                }

            }
        }
        private void getreport(int? cboclass, int? cbosession,int ? cbovoucher, int? cbocategory, int? cboterm, int? cbosection,
            int? cboprogram, int? cbohead, DateTime start, DateTime End)
        {

            SMSContext SMSContext = new SMSContext();
            SqlParameter starts = new SqlParameter("@start", start);
            SqlParameter ends = new SqlParameter("@end", End);
            SqlParameter classids = new SqlParameter("@classid", cboclass);
            SqlParameter type = new SqlParameter("@type", cbovoucher);
            SqlParameter sids = new SqlParameter("@seid", cbosession);
            SqlParameter tids = new SqlParameter("@smid", cboterm);
            SqlParameter secs = new SqlParameter("@secid", cbosection);
            SqlParameter pid = new SqlParameter("@pid ", cboprogram);
            SqlParameter hid = new SqlParameter("@hid", cbohead);
            SqlParameter cid = new SqlParameter("@cid", cbocategory);


            var list = SMSContext.Database.SqlQuery<vocuherheadvm>("getresultbyhead @classid,@seid,@type,@smid,@secid,@pid,@hid,@cid,@start, @end", classids, sids, type, tids, secs, pid, hid, cid,starts, ends).ToList();

            

            ReportDataSource rd = new ReportDataSource("DataSet1", list);
            ReportViewer1.LocalReport.DataSources.Add(rd);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}