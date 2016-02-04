using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;



namespace WebApplication2.Reports
{
    public partial class frmcrystalReportView : System.Web.UI.Page
    {

        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnReport_Click(object sender, EventArgs e)
        {

            // for cashBook Jv And Bank Book Voucher start
            //blayer.JvRptVoucherNo = txtVoucherNo.Text;
            //DataTable dt = blayer.JvReportPrint();
            //ReportDocument myrpt = new ReportDocument();
            //myrpt.Load(Server.MapPath("Reports/CrystalReport.rpt"));
            //myrpt.SetDataSource(dt);
            //CrystalReportViewer1.ReportSource = myrpt;
            // for cashBook Jv And Bank Book Voucher end

            ShowReport();





            


            //Session["ReportDataTable"] = dt;
            //Session["ReportName"] = "~/CrystalReport.rpt";
            ////Session["rptmode"] = 1;
            //Response.Redirect("Forms/frmaaa.aspx");
        }

         //Session["ReportDataTable"] = dt;
         //   Session["ReportDS"] = "DataSet1";
         //   Session["ReportName"] = "Reports/JournalVoucher.rdlc";
         //   Response.Redirect("frmReportsView.aspx");
        public void ShowReport()
        {
            
            blayer.ReportCode = txtVoucherNo.Text.ToString();  // here voucher no is used as account code or account name that we are looking for our ledger report
            DataSet ds = blayer.Ledgerreport();
            ds.Tables[0].Columns.Add("Balance");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];

                decimal credit = 0, debit = 0, previousBalance = 0;
                decimal.TryParse(row["Credit"].ToString(), out credit);
                decimal.TryParse(row["Debit"].ToString(), out debit);

                if (i > 0)
                    decimal.TryParse(ds.Tables[0].Rows[i - 1]["Balance"].ToString(), out previousBalance);

                row["Balance"] = i == 0 ? credit + debit : previousBalance - credit + debit;
            }
            ReportDocument myrpt = new ReportDocument();
            myrpt.Load(Server.MapPath("Reports/CrystalReport.rpt"));
            myrpt.SetDataSource(ds.Tables[0]);

            CrystalReportViewer1.ReportSource = myrpt;
        }

       
    }
}