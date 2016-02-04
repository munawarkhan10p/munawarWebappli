using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2
{
    public partial class frmCustomerCenter : System.Web.UI.Page
    {
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridview();
           
                CustomerView();
            
        }


        protected void Button1_Click(object sender, EventArgs e)
        {



            Response.Redirect("frmCreateCustomer.aspx");



        }

        public void LoadGridview()
        {
            GridView1.DataSource = blayer.CustomerAllColumns();
            GridView1.DataBind();
        }
        void CustomerView()
        {


            GridView1.DataSource = blayer.CustomerAllColumns();
            GridView1.DataBind();

            foreach (GridViewRow row in GridView1.Rows)
            {
                HyperLink hpB = (HyperLink)row.FindControl("hypCustomer");
                Label lblid = (Label)row.FindControl("lblCustomerId");
                hpB.NavigateUrl += "?ID=" + lblid.Text;

            }
        }
    }
}