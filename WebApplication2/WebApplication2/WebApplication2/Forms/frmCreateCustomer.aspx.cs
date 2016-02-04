using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplication2
{

    public partial class frmCreateCustomer : System.Web.UI.Page
    {
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {

            Session["UserName"] = "Admin";
            if (!IsPostBack)
            {
                try
                {
                    CustomerNumber();
                    txtAccountCode.Text = blayer.CustomerNumber;
                    //here we get id from query string and passed that id to our method below 
                    // int Sourceid = int.Parse(Request.QueryString["ID"].ToString());
                    int Sourceid = int.Parse(Request.QueryString["ID"].ToString());
                    DisplayCustomerByID(Sourceid);
                }
                catch
                {
                    btnSubmit.Visible = true;
                    lblSourceID.Visible = false;
                }

                
                //// dropdownlist for account types
                //DataTable dt = blayer.LoadAccountType();
                //ddlAccountType.DataSource = dt;
                //ddlAccountType.DataTextField = "AccountName";
                //ddlAccountType.DataValueField = "AccountId";
                //ddlAccountType.DataBind();

                //// dropdownlist for parents accounts
                //DataTable dt1 = blayer.LoadParentAccounts();
                //ddlChildOf.DataSource = dt1;
                //ddlChildOf.DataTextField = "AccountName";
                //ddlChildOf.DataValueField = "AccountId";
                //ddlChildOf.DataBind();

            }

        }
        //inserting values of customers in table
        void DisplayCustomerByID(int SourceID)
        {
           
            //we are getting our BookEditionId from query string and passing that to our propwety
            blayer.CustomerId = SourceID;
            DataTable dt = blayer.CustomerById();
            lblSourceID.Text = dt.Rows[0]["CustomerId"].ToString();
            txtAccountCode.Text = dt.Rows[0]["CustomerCode"].ToString();

            TxtAccountName.Text = dt.Rows[0]["CutomerName"].ToString();

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
            
            blayer.AccountCode = int.Parse(txtAccountCode.Text);
            blayer.AccountName = TxtAccountName.Text;
            blayer.AccountType = 1; //int.Parse(ddlAccountType.SelectedValue);
            blayer.ChildOf = 13;//int.Parse(ddlChildOf.SelectedValue);
            blayer.parentid = 13;//int.Parse(ddlChildOf.SelectedValue);
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
            blayer.IsActive = Convert.ToBoolean(cbIsActive.Checked);
            //calling function
            blayer.InsertCustomerDetails();

            //blayer.InsertCustomerName(); use for previous technique
            //blayer.CustomerName = TxtAccountName.Text; same as above


            lblStatus.Text = "Record Inserted Sucesfully";
        }

        public void CustomerNumber()
        {
            string cs = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_CustomerNumber");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                // cmd.Parameters.AddWithValue("@Date", date);
                cmd.Connection.Open();
                object result = cmd.ExecuteScalar();

                cmd.Connection.Close();
                blayer.CustomerNumber = result.ToString();
                //  txtAccountCode.Text = StudentNumber;

            }
        }

        protected void bntBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCustomerCenter.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            blayer.AccountId = int.Parse(lblSourceID.Text);
            blayer.AccountCode = int.Parse(txtAccountCode.Text);
            blayer.AccountName = TxtAccountName.Text;
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
            blayer.UpdateCustomerDetails();            

            lblStatus.Text = "Record updated Sucesfully";
        }

        
    }
}