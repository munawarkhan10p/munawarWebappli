using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2.Forms
{
    public partial class frmReports : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void ShowReport()
        {
            //LibIssuance isuance = new LibIssuance();
            //isuance.IssuanceID = int.Parse(ddlIssuanceId.SelectedValue);
            //DataTable dt = isuance.issuanceById();
            blayer.ReportCode =txtAccountCode.Text;
           DataSet ds= blayer.Ledgerreport();
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
           //GridView1.DataSource = ds;
           //GridView1.DataBind();
           Session["ReportDataTable"] = ds.Tables[0];
           Session["ReportDS"] = "DataSet1";
           Session["ReportName"] = "Reports/Ledger1.rdlc";
           Response.Redirect("frmReportsView.aspx");

            //    ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            //    rptViewer1.LocalReport.DataSources.Add(rds);
            //    rptViewer1.LocalReport.ReportPath = "rptAuthor.rdlc";
            //    rptViewer1.LocalReport.Refresh();
        }
        protected void btnDisplayReport_Click(object sender, EventArgs e)
        {
            ShowReport();
        }
    }
}