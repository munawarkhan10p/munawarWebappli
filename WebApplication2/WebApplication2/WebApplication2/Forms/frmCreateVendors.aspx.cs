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
    public partial class frmCreateVendors : System.Web.UI.Page
    {
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserName"] = "Admin";
           
            if(!IsPostBack)
            {
                try
                {
                    VendorNumber();
                    txtAccountCode.Text = blayer.VendorNumber;
                    int Sourceid = int.Parse(Request.QueryString["ID"].ToString());
                    DisplayCustomerByID(Sourceid);
                   
                }
                catch
                {
                    btnSubmit.Visible = true;
                    lblSourceID.Visible = false;
                }


            }
        }
        void DisplayCustomerByID(int SourceID)
        {

            //we are getting our BookEditionId from query string and passing that to our propwety
            blayer.VendorId = SourceID;
            DataTable dt = blayer.VendorbyId();
            lblSourceID.Text = dt.Rows[0]["VendorId"].ToString();
            txtAccountCode.Text = dt.Rows[0]["VendorCode"].ToString();

            TxtAccountName.Text = dt.Rows[0]["VendorName"].ToString();

            txtMobileNumber.Text = dt.Rows[0]["MobileNumber"].ToString();

            txtFaxNumber.Text = dt.Rows[0]["Fax"].ToString();
            txtCnic.Text = dt.Rows[0]["Cnic"].ToString();

            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtContactPersonName.Text = dt.Rows[0]["ContactPerson"].ToString();

            txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
            txtCity.Text = dt.Rows[0]["City"].ToString();

            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            cbIsActive.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());

            btnSubmit.Visible = false;
            btnUpdate.Visible = true;


        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            blayer.VendorId = int.Parse(lblSourceID.Text);
            blayer.AccountCode = int.Parse(txtAccountCode.Text);
            blayer.AccountName = TxtAccountName.Text;
            blayer.AccountType = 2; //int.Parse(ddlAccountType.SelectedValue);
            blayer.ChildOf = 30;//int.Parse(ddlChildOf.SelectedValue);
            blayer.parentid = 30;//int.Parse(ddlChildOf.SelectedValue);
            blayer.IsPrent = cbIsActive.Checked;
            blayer.Address = txtAddress.Text;
            blayer.MobileNumber = txtMobileNumber.Text;
            blayer.Fax = txtFaxNumber.Text;
            blayer.Email = txtEmail.Text;
            blayer.Cnic = txtCnic.Text;
            blayer.ContactPerson = txtContactPersonName.Text;
            blayer.Designation = txtDesignation.Text;
            blayer.City = txtCity.Text;
            blayer.CreatedBy = Session["UserName"].ToString();
            blayer.IsActive = Convert.ToBoolean(cbIsActive);
            //calling function
            blayer.InsertVendorDetails();

            
            //blayer.InsertVendorName(); use for previous technique
            // blayer.VendorName = TxtAccountName.Text; same as above

            lblStatus.Text = "Record Inserted Sucesfully";
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            blayer.VendorId = int.Parse(lblSourceID.Text);
            blayer.VendorCode = int.Parse(txtAccountCode.Text);
            blayer.VendorName = TxtAccountName.Text;
            blayer.Address = txtAddress.Text;
            blayer.MobileNumber = txtMobileNumber.Text;
            blayer.Fax = txtFaxNumber.Text;
            blayer.Email = txtEmail.Text;
            blayer.Cnic = txtCnic.Text;
            blayer.ContactPerson = txtContactPersonName.Text;
            blayer.Designation = txtDesignation.Text;
            blayer.City = txtCity.Text;
            blayer.ModifiedBy = Session["UserName"].ToString();
            blayer.IsActive = Convert.ToBoolean(cbIsActive.Checked);
            blayer.UpdateVendorDetails();

            lblStatus.Text = "Record updated Sucesfully";
        }

        protected void bntBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmVendorCenter.aspx");
        }
        public void VendorNumber()
        {
            string cs = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_VendorNumber");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                // cmd.Parameters.AddWithValue("@Date", date);
                cmd.Connection.Open();
                object result = cmd.ExecuteScalar();

                cmd.Connection.Close();
                blayer.VendorNumber =result.ToString();
                //  txtAccountCode.Text = StudentNumber;

            }
        }
    }
}