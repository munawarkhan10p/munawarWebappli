using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Net.Mail;

namespace WebApplication2
{
    public partial class Forget_Password : System.Web.UI.Page
    {
        int Currentuserid;
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        string username;
        string userpassword;
        string EmailAddress;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["EmailAdd"] != null)
            {
                EmailAddress = (string)ViewState["EmailAdd"];
            }
            if (ViewState["UserName"] != null)
            {
                username = (string)ViewState["UserName"];
            }
            if (ViewState["UserPass"] != null)
            {
                userpassword = (string)ViewState["UserPass"];
            }
            txtQuestion1.Disabled = true;
            txtQuestion2.Disabled = true;
            txtAnswer1.Disabled = true;
            txtAnswer2.Disabled = true;
            if (byEmail.Checked)
            {
                txtEmail.Enabled = true;
                txtUserName.Enabled = false;
                txtQuestion1.Value = "";
                txtQuestion2.Value = "";
                txtUserName.Text = "";

            }
            if (byUserName.Checked)
            {
                txtEmail.Enabled = false;
                txtUserName.Enabled = true;
                txtQuestion1.Value = "";
                txtQuestion2.Value = "";
                txtEmail.Text = "";

            }
            if (IsPostBack)
            {
                if (ViewState["userid"] != null)
                {
                    Currentuserid = (int)ViewState["userid"];
                }
            }
            else
            {


            }
        }
        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = blayer.getSecurityQuestionsbyUserName(txtUserName.Text);
            txtQuestion1.Value = "";
            txtQuestion2.Value = "";
            if (dt.Rows.Count > 0)
            {
                txtQuestion1.Value = dt.Rows[0]["Question"].ToString();
                txtQuestion2.Value = dt.Rows[1]["Question"].ToString();
                txtAnswer1.Disabled = false;
                txtAnswer2.Disabled = false;
                Currentuserid = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
                ViewState["userid"] = Currentuserid;
                username = dt.Rows[1]["UserName"].ToString();
                userpassword = dt.Rows[1]["Password"].ToString();
                EmailAddress = dt.Rows[1]["EmailId"].ToString();
                ViewState["EmailAdd"] = EmailAddress;
                ViewState["UserName"] = username;
                ViewState["UserPass"] = userpassword;
            }
            else
            {
                if (txtUserName.Text != "")
                {
                  //  ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "UserName Not Found" + "');", true);
                    lblModalTitle.Text = "Invalid UserName..!";
                    lblModalBody.Text = "This Username is Not Registered ..!";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
            }
        }



        protected void txtUserEmail_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = blayer.getSecurityQuestionsbyEmail(txtEmail.Text);
            txtQuestion1.Value = "";
            txtQuestion2.Value = "";
            if (dt.Rows.Count > 0)
            {
                txtQuestion1.Value = dt.Rows[0]["Question"].ToString();
                txtQuestion2.Value = dt.Rows[1]["Question"].ToString();
                txtAnswer1.Disabled = false;
                txtAnswer2.Disabled = false;
                Currentuserid = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
                ViewState["userid"] = Currentuserid;
                username = dt.Rows[1]["UserName"].ToString();
                userpassword = dt.Rows[1]["Password"].ToString();
                EmailAddress = dt.Rows[1]["EmailId"].ToString();
                ViewState["EmailAdd"] = EmailAddress;
                ViewState["UserName"] = username;
                ViewState["UserPass"] = userpassword;
            }
            else
            {
                if (txtEmail.Text != "")
                {
                    lblModalTitle.Text = "Invalid Email..!";
                    lblModalBody.Text = "This Email is Not Registered ..!";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            int answer1;
            int answer2;

            answer1 = blayer.checkanswer1(Currentuserid, txtAnswer1.Value);
            answer2 = blayer.checkanswer2(Currentuserid, txtAnswer2.Value);
            if (answer1 == 1 && answer2 == 1)
            {
                try
                {
                    //Sending Email Code
                    //https://www.google.com/settings/security/lesssecureapps
                    string senderID = "fypsmiu@gmail.com";// use sender’s email id here..
                    const string senderPassword = "smiufyp123"; // sender password here…
                    SmtpClient smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com", // smtp server address here…
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                        Timeout = 30000,
                    };
                    MailMessage message = new MailMessage(senderID, EmailAddress.Trim(), "UserName & Password Recovery ", " Username=" + username + " /br Password=" + userpassword);
                    smtp.Send(message);
                  
                    lblModalTitle.Text ="Email sent successfully.!";
                    lblModalBody.Text = "Please Check your Email Address";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                    
                }
                catch (Exception ex)
                {
                    lblModalTitle.Text = "Email Sending Failed...!";
                    lblModalBody.Text = ex.Message + "Make Sure You are connected with Internet Resource!";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                    upModal.Update();
                }
            }
            else
            {
                txtAnswer1.Value = "";
                txtAnswer2.Value = "";
                txtEmail.Text = "";
                txtUserName.Text = "";
              
                lblModalTitle.Text = "Security Answered Not Matched...!";
                lblModalBody.Text = "Please resubmit your details \nThank you!";
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
                upModal.Update();
            }


        }
    }
}