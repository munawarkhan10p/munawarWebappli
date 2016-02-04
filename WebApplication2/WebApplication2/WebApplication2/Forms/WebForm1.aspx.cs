using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] != null)
            {
                userid = (int)Session["userid"];
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // Upload Original Image Here
            string uploadFileName = "";
            string uploadFilePath = "";
            if (FU1.HasFile)
            {
                string ext = Path.GetExtension(FU1.FileName).ToLower();
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".png")
                {
                    uploadFileName = userid + ".jpg";
                    uploadFilePath = Path.Combine(Server.MapPath("~/assets/StaffUserImage"), uploadFileName);
                    try
                    {
                        FU1.SaveAs(uploadFilePath);
                        FU1.Dispose();
                        imgUpload.ImageUrl = "~/assets/StaffUserImage/" + uploadFileName;
                        panCrop.Visible = true;

                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = "Error! Please try again.";
                    }
                }
                else
                {
                    lblMsg.Text = "Selected file type not allowed!";
                }
            }
            else
            {
                lblMsg.Text = "Please select file first!";
            }
        }

        protected void btnCrop_Click(object sender, EventArgs e)
        {
            // Crop Image Here & Save
            string fileName = Path.GetFileName(imgUpload.ImageUrl);
            string filePath = Path.Combine(Server.MapPath("~/assets/StaffUserImage"), fileName);
            string cropFileName = "";
            string cropFilePath = "";
            string deleteFilepath = "";
            using (System.Drawing.Image orgImg = System.Drawing.Image.FromFile(filePath))
            {
                Rectangle CropArea = new Rectangle(
                    Convert.ToInt32(X.Value),
                    Convert.ToInt32(Y.Value),
                    Convert.ToInt32(W.Value),
                    Convert.ToInt32(H.Value));
            
                Bitmap bitMap = new Bitmap(CropArea.Width, CropArea.Height);
                using (Graphics g = Graphics.FromImage(bitMap))
                {
                    g.DrawImage(orgImg, new Rectangle(0, 0, bitMap.Width, bitMap.Height), CropArea, GraphicsUnit.Pixel);
                }
                cropFileName = "Crop_" + userid + ".jpg";
                cropFilePath = Path.Combine(Server.MapPath("~/assets/StaffUserImage"), cropFileName);
                deleteFilepath = Path.Combine(Server.MapPath("~/assets/StaffUserImage"), userid + ".jpg");
                bitMap.Save(cropFilePath);
                Session["UserImg"] = cropFileName;
                bitMap.Dispose();
            }
            if (System.IO.File.Exists(deleteFilepath))
            {
                System.IO.File.Delete(deleteFilepath);
            }
            Response.Redirect("~/assets/StaffUserImage/" + cropFileName);
        }

        protected void Page_UnLoad(object sender, EventArgs e)
        {
          
        }
    }
}