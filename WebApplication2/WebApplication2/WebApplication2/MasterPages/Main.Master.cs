using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Main : System.Web.UI.MasterPage
    {
        int userid;
        string uname;
        string upass;
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userid"] != null)
            {
                userid = (int)Session["userid"];
                DataTable dt = blayer.demoimg(userid);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0] == DBNull.Value || dt.Rows[0][0] == string.Empty)
                    {
                        UserImg.ImageUrl = "~/assets/img/defaultUser.jpg";
                        lblLoginas.Text = dt.Rows[0][2].ToString();
                        lblLastAccess.Text = dt.Rows[0][1].ToString();
                        Session["authn"] = dt.Rows[0][2].ToString();
                    }
                    else
                    {
                        UserImg.ImageUrl = "~/assets/StaffUserImage/" + dt.Rows[0][0];
                        lblLoginas.Text = dt.Rows[0][2].ToString();
                        lblLastAccess.Text = dt.Rows[0][1].ToString();
                        Session["authn"] = dt.Rows[0][2].ToString();
                    }
                }
            }
            if (Session["uname"] != null && Session["upass"] != null)
            {
                uname = (string)Session["uname"];
                upass = (string)Session["upass"];
            }
        }
        protected void Image1_Load(object sender, EventArgs e)
        {
        }
        protected void EditProfile_Click(object sender, ImageClickEventArgs e)
        {
            Session["userid"] = userid;
            txtLoginName.Text = uname;
            txtLoginName.Enabled = false;
            lblModalTitle.Text = "Login Authentication Required...!";
            lblModalTitle.ForeColor = Color.Black;
            upModal.Update();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtLoginPassword.Text == upass)
            {
                Session["uname"] = uname;
                Session["uname"] = upass;
                Response.Redirect("~/Forms/UpdateUserInfo.aspx");
            }
            else
            {
                lblModalTitle.Text = "Invalid Password..!";
                lblModalTitle.ForeColor = Color.Red;
                upModal.Update();
            }
        }
    }
}