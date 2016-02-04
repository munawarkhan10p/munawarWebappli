using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        int userid; //user id got throug session variable or etc in this page through loginpage
        
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        DataSet questions; 
        protected void Page_Load(object sender, EventArgs e)
        {
            userid =(int) Session["userid"];
            if (Session["UserImg"] != null)
            {
                UserImg.ImageUrl ="~/assets/StaffUserImage/"+ (string) Session["UserImg"];
            }

           if (IsPostBack)
            {

            }
            else
            {
                userid = (int)Session["userid"];
                questions = blayer.getquestions();
                DataTable questions1 = (DataTable)questions.Tables[1];
                ddlQuestion1.DataSource = questions1;
                ddlQuestion1.DataTextField = "Question";
                ddlQuestion1.DataValueField = "QuestionId";
                DataRow row = questions1.NewRow();
                row["QuestionId"] = -1;
                row["Question"] = "-----> Select Question <-----";
                questions1.Rows.InsertAt(row, 0);
                ddlQuestion1.DataBind();

                DataTable questions2 = (DataTable)questions.Tables[0];
                ddlQuestion2.DataSource = questions2;
                ddlQuestion2.DataTextField = "Question";
                ddlQuestion2.DataValueField = "QuestionId";
                DataRow onflyrow = questions2.NewRow();
                onflyrow["QuestionId"] = -1;
                onflyrow["Question"] = "-----> Select Question <-----";
                questions2.Rows.InsertAt(onflyrow, 0);
                ddlQuestion2.DataBind();

                if (Session["imgpath"] != null)
                {
                    UserImg.ImageUrl =(string) Session["imgpath"];
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            userid =(int) Session["userid"];
            var chkq1= Convert.ToInt32(ddlQuestion1.SelectedValue);
            var chkq2= Convert.ToInt32(ddlQuestion2.SelectedValue);
            if ( chkq1== -1 || chkq2 == -1)
            {
                //Select questions
            }
            else
            {
             string imagename =(string) Session["UserImg"];
             blayer.FirstAttemptPasswordChange(userid, txtnewpass.Text, txtAnswer1.Text, txtAnswer2.Text, Convert.ToInt32(ddlQuestion1.SelectedValue), Convert.ToInt32(ddlQuestion2.SelectedValue), true, imagename);
             Response.Redirect("~/Forms/Login.aspx");
            }
        }

        protected void BtnImgUpload_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Forms/frmSelect&CropImage.aspx");
        }

        protected void browseImg_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm1.aspx");
        }

        protected void btnUseDefault_Click(object sender, EventArgs e)
        {
            UserImg.ImageUrl = "~/assets/img/defaultUser.jpg";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            UserImg.ImageUrl="~/assets/StaffUserImage/"+"Crop_"+userid+".jpg";
        }


        //protected void mp1_Unload(object sender, EventArgs e)
        //{
        //    if (IsPostBack)
        //    {
        //        Response.Redirect("~/Forms/ChangePassword.aspx");
            
        //    }
        //}

        //protected void mp1_Disposed(object sender, EventArgs e)
        //{
        //    if (IsPostBack)
        //    {
        //        Response.Redirect("~/Forms/ChangePassword.aspx");

        //    }
        //}



      
        
    }
}