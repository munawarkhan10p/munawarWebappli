using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Login : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string uname = txtLoginName.Text;
            string upass = txtLoginPassword.Text;
            Businesslayer.BLayer blayer = new Businesslayer.BLayer();
            int chkbit = blayer.checkbit(uname, upass);
            int userid = blayer.checkauthentication(uname, upass);
            if (chkbit == 101)
            {
                if (userid == -1)
                {
                    lblModalTitle.Text = "LoginFailed...!";
                    lblModalBody.Text = "Invalid Username Or Pasword....!";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
                else
                {
                    Session["userid"] = userid;

                }
                Session["userid"] = userid;
                Session["uname"] = uname;
                Session["upass"] = upass;
                Response.Redirect("~/Forms/ChangePassword.aspx");
            
            }
            else
            {
                if (userid == -1)
                {
                    lblModalTitle.Text = "LoginFailed...!";
                    lblModalBody.Text = "Invalid Username Or Pasword....!";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
                else
                {
                    Session["userid"] = userid;
                    Session["uname"] = uname;
                    Session["upass"] = upass;
                    Response.Redirect("~/Forms/frmMainDashboard.aspx");

                }

               
            }
                 
       
        }
    }
}