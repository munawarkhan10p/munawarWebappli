using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Registeration : System.Web.UI.Page
    {
        List<string> authenticatedUser = new List<string>();
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            authenticatedUser.Add("Admin");
            authenticatedUser.Add("Manager");
            if (Session["authn"] != null)
            {
                if (authenticatedUser.Contains(Session["authn"].ToString()))
                {

                }
                else
                {
                    Response.Redirect("~/ErrorPages/Unauthorized.aspx");
                }
            }
            if (!IsPostBack)
            {
                DataTable dt = blayer.loadDesignationofCreateStaffUser();
                ddlRole.DataSource = dt;
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "RoleId";
                DataRow row = dt.NewRow();
                row["RoleName"] = "-----> Select Role <-----";
                dt.Rows.InsertAt(row, 0);
                ddlRole.DataBind();
           
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            blayer.createStaffUser(txtFirstName.Text, txtLastName.Text, txtUserName.Text, txtEmail.Text, txtPhoneNo.Text, txtMobileNo.Text, txtPassword.Text,Convert.ToInt32(ddlRole.SelectedValue), true, false, "admin", DateTime.Now, "admin", DateTime.Now);
       
        }


    }
}