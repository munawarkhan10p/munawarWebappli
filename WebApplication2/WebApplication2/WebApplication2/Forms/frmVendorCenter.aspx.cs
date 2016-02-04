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
    public partial class frmVendorCenter : System.Web.UI.Page
    {
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridview();

            CustomerView();


        }

        protected void btnAddNewVendors_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCreateVendors.aspx");
        }

        public void LoadGridview()
        {
            GridView1.DataSource = blayer.VendorAllColumn();
            GridView1.DataBind();
        }
        void CustomerView()
        {


            GridView1.DataSource = blayer.VendorAllColumn();
            GridView1.DataBind();

            foreach (GridViewRow row in GridView1.Rows)
            {
                HyperLink hpB = (HyperLink)row.FindControl("hypVendor");
                Label lblid = (Label)row.FindControl("lblVendorId");
                hpB.NavigateUrl += "?ID=" + lblid.Text;

            }
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}