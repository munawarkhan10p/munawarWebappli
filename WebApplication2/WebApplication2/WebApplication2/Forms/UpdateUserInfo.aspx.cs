using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class UpdateUserInfo : System.Web.UI.Page
    {
        int userid;
        string uname;
        string upass;
        string imagename;
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["userid"] != null)
            {
                userid = (int)Session["userid"];
            }

            if (Session["uname"] != null && Session["upass"] != null)
            {
                uname = (string)Session["uname"];
                upass = (string)Session["upass"];
            }
            if (Session["UserImg"] != null)
            {
                imagename = (string)Session["UserImg"];
            }
            if (!IsPostBack)
            {
                DataTable dt = blayer.showallinfoofuser(userid);
                if (dt.Rows.Count > 0)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/assets/StaffUserImage/"+imagename)))
                    {
                        UserImg.ImageUrl = "~/assets/StaffUserimage/"+ imagename;
                    }
                    else
                    {
                        if (dt.Rows[0]["UserImg"].ToString() == "")
                        {
                            UserImg.ImageUrl = "~/assets/img/defaultUser.jpg";
                        }

                        else
                        {
                            UserImg.ImageUrl = "~/assets/StaffUserImage/" + dt.Rows[0]["UserImg"].ToString();
                        }
                    }
                    txtFirstName.Text = (string)dt.Rows[0]["FirstName"];
                    txtLastName.Text = dt.Rows[0]["LastName"].ToString();
                    txtPhone.Text = (string)dt.Rows[0]["PhoneNumber"];
                    txtEmail.Text = (string)dt.Rows[0]["EmailId"];
                    DataSet questions;

                    questions = blayer.getquestions();
                    DataTable questions1 = (DataTable)questions.Tables[1];
                    if (questions1.Rows.Count > 0)
                    {
                        ddlQuestion1.DataSource = questions1;
                        ddlQuestion1.DataTextField = "Question";
                        ddlQuestion1.DataValueField = "QuestionId";
                        ddlQuestion1.SelectedIndex = ((int)dt.Rows[0]["SecurityQuestionOne"]) - 1;
                        ddlQuestion1.DataBind();
                    }

                    DataTable questions2 = (DataTable)questions.Tables[0];

                    if (questions2.Rows.Count > 0)
                    {
                        ddlQuestion2.DataSource = questions2;
                        ddlQuestion2.DataTextField = "Question";
                        ddlQuestion2.DataValueField = "QuestionId";
                        ddlQuestion2.SelectedIndex = ((int)dt.Rows[0]["SecurityQuestionTwo"]) - 6;
                        ddlQuestion2.DataBind();
                    }

                    txtAnswer1.Text = (string)dt.Rows[0]["SecurityAnswerOne"];
                    txtAnswer2.Text = (string)dt.Rows[0]["SecurityAnswerTwo"];
                }
            }
      
        }
        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            if (imagename == null || imagename == "")
            {
                blayer.usp_updateStaffUser(userid, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPhone.Text, txtPassword.Text, Convert.ToInt32(ddlQuestion1.SelectedValue), txtAnswer1.Text, Convert.ToInt32(ddlQuestion2.SelectedValue), txtAnswer2.Text, uname, DateTime.Now,null);
            }
            else
            {
                blayer.usp_updateStaffUser(userid, txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtPhone.Text, txtPassword.Text, Convert.ToInt32(ddlQuestion1.SelectedValue), txtAnswer1.Text, Convert.ToInt32(ddlQuestion2.SelectedValue), txtAnswer2.Text, uname, DateTime.Now, imagename);
            }

        }
        protected void browseImg_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm1.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UserImg.ImageUrl = "~/assets/StaffUserImage/" + "Crop_" + userid + ".jpg";
        }

        protected void btnUseDefault_Click(object sender, EventArgs e)
        {
            UserImg.ImageUrl = "~/assets/img/defaultUser.jpg";
        }
    }
}