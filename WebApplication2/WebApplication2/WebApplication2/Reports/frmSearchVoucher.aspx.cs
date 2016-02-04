using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace WebApplication2.Reports
{
    public partial class frmReports : System.Web.UI.Page
    {
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {


    
            if (!Page.IsPostBack)
            {
               
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            

                ddl();
            
            
        }
        public void ddl()
        {
            
                blayer.AccountCde = txtAccountCode.Text;
                blayer.AccountNAme = txtAccountName.Text;
                DataTable dt = blayer.SearchVoucher();
                DropDownList1.DataSource = dt;
                DropDownList1.DataTextField = "AccountName";
                DropDownList1.DataValueField = "AccountCode";
                DropDownList1.DataBind();
                //GridView1.DataSource = dt;
                //GridView1.DataBind();

            
        }
        public void ShowReport()
        {
            
                    // here voucher no is used as account code or account name that we are looking for our ledger report
          //  blayer.ReportCode = Code;
            blayer.ReportCode = DropDownList1.SelectedValue;
            blayer.Date1 = txtDate1.Text;
            blayer.Date2 = txtDate2.Text;
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
            myrpt.Load(Server.MapPath("CrystalReport.rpt"));
            myrpt.SetDataSource(ds.Tables[0]);

            CrystalReportViewer.ReportSource = myrpt;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Panel1.Visible == false)
            {
                Panel1.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
            }
           
        }

        protected void txtDate2_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //ShowReport();
        }
        public string Code { get; set; }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {







            //GridViewRow row = GridView1.SelectedRow;

            ////Find your textbox within the row
            //Label yourTextbox = row.FindControl("lblAccountCode") as Label;

            ////Check if your textbox was found
            //if (yourTextbox != null)
            //{
            //    //Get your value here
            //    var yourValue = yourTextbox;
            //}
            ////string name = GridView1.SelectedRow.Cells[1].Text;
            ////Code = name;
            ////ShowReport();
            
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
           
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "MyCommand")
            //{
            //    int row = int.Parse(e.CommandArgument.ToString());
            //    var cellText = GridView1.Rows[row].Cells[1].Text.Trim();
               
            //}
        }

        protected void btnPrint_Click1(object sender, EventArgs e)
        {
            ShowReport();
        }
    }
}