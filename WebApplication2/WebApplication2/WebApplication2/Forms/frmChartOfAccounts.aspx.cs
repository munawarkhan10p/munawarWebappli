using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.Forms
{
    public partial class frmChartOfAccounts : System.Web.UI.Page
    {
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridview();
            CustomerView();
        }

        protected void btnAddNewChartOfAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCreateChartAccounts.aspx");
        }
        public void LoadGridview()
        {
            GridView1.DataSource = blayer.ChartOfAccountsAllColumn();

            GridView1.DataBind();

        }
        void CustomerView()
        {


            GridView1.DataSource = blayer.ChartOfAccountsAllColumn();
            GridView1.DataBind();

            foreach (GridViewRow row in GridView1.Rows)
            {
                HyperLink hpB = (HyperLink)row.FindControl("hypChartOfAccount");
                Label lblid = (Label)row.FindControl("lblChartofAccountId");
                hpB.NavigateUrl += "?ID=" + lblid.Text;

            }
        }
    }
}