using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2.Reports
{
    public partial class frmIncomeStatement : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowReport();
            }
        }
        public DataSet Ledgerreport()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_IncomeStatement", connectionString);
            nadap.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataSet dt = new DataSet();
            nadap.Fill(dt);
            return dt;
        }
        public void ShowReport()
        {
            //LibIssuance isuance = new LibIssuance();
            //isuance.IssuanceID = int.Parse(ddlIssuanceId.SelectedValue);
            //DataTable dt = isuance.issuanceById();

            DataTable dt = IncomeStatement();
            
            //GridView1.DataSource = ds;
            //GridView1.DataBind();
            Session["ReportDataTable"] = dt;
            Session["ReportDS"] = "DataSet1";
            Session["ReportName"] = "Reports/Ledger2.rdlc";
            Response.Redirect("Forms/frmReportsView.aspx");

            //    ReportDataSource rds = new ReportDataSource("DataSet1", dt);
            //    rptViewer1.LocalReport.DataSources.Add(rds);
            //    rptViewer1.LocalReport.ReportPath = "rptAuthor.rdlc";
            //    rptViewer1.LocalReport.Refresh();
        }
        public DataTable IncomeStatement()
        {

            DataSet dt1 = Ledgerreport();
            DataTable ForDropDown = new DataTable();
            ForDropDown.Columns.Add("AccountCode");
          //  ForDropDown.Columns.Add("Description");
            ForDropDown.Columns.Add("Total");
            ForDropDown.Columns.Add("GrandTotal");

            for (int i = 0; i < dt1.Tables[0].Rows.Count; i++)
            {
                var AccountCode = dt1.Tables[0].Rows[i]["AccountCode"].ToString();// +"---" + dt1.Rows[i]["CustomerCode"].ToString();
                var Total = dt1.Tables[0].Rows[i]["Total"].ToString();
                ForDropDown.Rows.Add(AccountCode, Total);

            }

            for (int i = 0; i < dt1.Tables[1].Rows.Count; i++)
            {
                var AccountCode = dt1.Tables[1].Rows[i]["AccountCode"].ToString();// +"---" + dt1.Rows[i]["CustomerCode"].ToString();
                var Total = dt1.Tables[1].Rows[i]["Total"].ToString();
                ForDropDown.Rows.Add(AccountCode, Total);

            }
            for (int i = 0; i < dt1.Tables[2].Rows.Count; i++)
            {
                var AccountCode = dt1.Tables[2].Rows[i]["AccountCode"].ToString();// +"---" + dt1.Rows[i]["CustomerCode"].ToString();
                var Total = dt1.Tables[2].Rows[i]["Total"].ToString();
                ForDropDown.Rows.Add(AccountCode, Total);

            }
            for (int i = 0; i < dt1.Tables[3].Rows.Count; i++)
            {
                var AccountCode = dt1.Tables[3].Rows[i]["AccountCode"].ToString();// +"---" + dt1.Rows[i]["CustomerCode"].ToString();
                var Total = dt1.Tables[3].Rows[i]["Total"].ToString();
                ForDropDown.Rows.Add(AccountCode, Total);

            }
            for (int i = 0; i < dt1.Tables[4].Rows.Count; i++)
            {
                var AccountCode = dt1.Tables[4].Rows[i]["AccountCode"].ToString();// +"---" + dt1.Rows[i]["CustomerCode"].ToString();
                var Total = dt1.Tables[4].Rows[i]["Total"].ToString();
                ForDropDown.Rows.Add(AccountCode, Total);

            }
            for (int i = 0; i < dt1.Tables[5].Rows.Count; i++)
            {
                var AccountCode = dt1.Tables[5].Rows[i]["AccountCode"].ToString();// +"---" + dt1.Rows[i]["CustomerCode"].ToString();
                var Total = dt1.Tables[5].Rows[i]["Total"].ToString();
                ForDropDown.Rows.Add(AccountCode, Total);

            }
            for (int i = 0; i < dt1.Tables.Count; i++)
            {
                //var AccountCode = dt1.Tables[5].Rows[i]["AccountCode"].ToString();// +"---" + dt1.Rows[i]["CustomerCode"].ToString();
                var GrandTotal = dt1.Tables[0].Rows[i]["Total"].ToString();// +dt1.Tables[2].Rows[i]["Total"].ToString();// -dt1.Tables[1].Rows[i]["Total"].ToString();
                ForDropDown.Rows.Add(GrandTotal);

            }
            //for (int i = 0; i < dt1.Rows.Count; i++)
            //{

            //    var AccountName = dt1.Rows[i]["VendorName"].ToString() + "---" + dt1.Rows[i]["VendorCode"].ToString();
            //    var AccountCode = dt1.Rows[i]["VendorCode"].ToString();
            //    ForDropDown.Rows.Add(AccountName, AccountCode);

            //}

            //for (int i = 0; i < dt1.Rows.Count; i++)
            //{

            //    var AccountName = dt1.Rows[i]["ChartOfAccountsName"].ToString() + "---" + dt1.Rows[i]["ChartOfAccountsCode"].ToString();
            //    var AccountCode = dt1.Rows[i]["ChartOfAccountsCode"].ToString();
            //    ForDropDown.Rows.Add(AccountName, AccountCode);

            //}
            return ForDropDown;

        }
    }
}