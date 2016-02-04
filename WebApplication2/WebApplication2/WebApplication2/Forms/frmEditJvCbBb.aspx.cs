using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.Forms
{
    public partial class frmJvReport : System.Web.UI.Page
    {
        Businesslayer.Employe das = new Businesslayer.Employe();
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserName"] = "Admin";

        }
      
        protected void Button1_Click(object sender, EventArgs e)
        {


            GridView1.DataSourceID = "ObjectDataSource1";
            blayer.JvRModifiedBy = Session["UserName"].ToString();
            blayer.JvVoucherNo = txtVoucherNo.Text;
            blayer.JvModifiedBy();
        
           
        }

        protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            if (!IsPostBack)
            {
                e.Cancel = true;
            }
        }
    }
}