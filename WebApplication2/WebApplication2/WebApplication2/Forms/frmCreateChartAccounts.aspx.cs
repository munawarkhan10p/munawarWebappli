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
    public partial class frmChartOA : System.Web.UI.Page
    {
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
       
        protected void Page_Load(object sender, EventArgs e)
        {



            Session["UserName"] = "Admin";
            if (!IsPostBack)
            {

              
                try
                {
                    //CustomerNumber();
                    //txtAccountCode.Text = blayer.CustomerNumber;
                    //here we get id from query string and passed that id to our method below 
                    // int Sourceid = int.Parse(Request.QueryString["ID"].ToString());
                    DataTable dt2 = blayer.DropDownListChildOf();
                    ddlChildOf.DataSource = dt2;
                    ddlChildOf.DataTextField = "ChartOfAccountsName";
                    ddlChildOf.DataValueField = "ChartOfAccountsId";
                    ddlChildOf.DataBind(); 


                    int Sourceid = int.Parse(Request.QueryString["ID"].ToString());
                    DisplayChartOfAccountByID(Sourceid);
                   
                   


                }
                catch
                {
                    btnSubmit.Visible = true;
                    lblSourceID.Visible = false;
                   
                }


                DataTable dt = blayer.LoadAccountType();
                ddlAccountType.DataSource = dt;
                ddlAccountType.DataTextField = "AccountName";
                ddlAccountType.DataValueField = "AccountId";
                ddlAccountType.DataBind();

                // dropdownlist for parents accounts
                DataTable dt1 = blayer.DropDownListFirstItem();
                ddlChildOf.DataSource = dt1;
                ddlChildOf.DataTextField = "ChartOfAccountsName";
                ddlChildOf.DataValueField = "ChartOfAccountsId";
                ddlChildOf.DataBind(); 

                btnBack.Visible = true;
               

                
                // DataSet ds1 = blayer.ThreeTablesData();
                // DataTable ForDropDown = new DataTable();
                //ForDropDown.Columns.Add("AccountName");
                //ForDropDown.Columns.Add("AccountCode");

               
                //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                //{
                //    var AccountName = ds1.Tables[0].Rows[i]["CutomerName"].ToString(); //+ ds1.Tables[0].Rows[i]["CustomerId"].ToString();
                //    var AccountCode = ds1.Tables[0].Rows[i]["CustomerCode"].ToString();
                //    ForDropDown.Rows.Add(AccountName, AccountCode);
               
                //}
                
                //for(int i=0; i<ds1.Tables[1].Rows.Count; i++)
                //{

                //    var AccountName = ds1.Tables[1].Rows[i]["VendorName"].ToString();
                //    var AccountCode = ds1.Tables[1].Rows[i]["VendorCode"].ToString();
                //    ForDropDown.Rows.Add(AccountName, AccountCode);
                   
                //}
               
                //for (int i = 0; i < ds1.Tables[2].Rows.Count; i++)
                //{

                //    var AccountName = ds1.Tables[2].Rows[i]["ChartOfAccountsName"].ToString();// +ds1.Tables[2].Rows[i]["ChartOfAccountsId"].ToString();
                //    var AccountCode = ds1.Tables[2].Rows[i]["ChartOfAccountsCode"].ToString();
                //    ForDropDown.Rows.Add(AccountName, AccountCode);
                    
                //}


                //ddlChildOf.DataSource = ForDropDown;
                //ddlChildOf.DataTextField = "AccountName";
                //ddlChildOf.DataValueField = "AccountCode";
                //ddlChildOf.DataBind();
                // dropdownlist for account types
           



            }
        }
        void DisplayChartOfAccountByID(int SourceID)
        {

            //we are getting our BookEditionId from query string and passing that to our propwety
            blayer.ChartOfAccountId= SourceID;
            DataTable dt = blayer.ChartOfAccountsById();
            lblSourceID.Text = dt.Rows[0]["ChartOfAccountsId"].ToString();
            ddlAccountType.SelectedValue = dt.Rows[0]["AccountType"].ToString();
           // ddlChildOf.SelectedValue = dt.Rows[0]["ChildOf"].ToString();
            blayer.ChildOfDropdown = int.Parse(dt.Rows[0]["ChildOf"].ToString());
            txtAccountCode.Text = dt.Rows[0]["ChartOfAccountsCode"].ToString();

            TxtAccountName.Text = dt.Rows[0]["ChartOfAccountsName"].ToString();

            txtMobileNumber.Text = dt.Rows[0]["MobileNumber"].ToString();

            txtFaxNumber.Text = dt.Rows[0]["Fax"].ToString();
            txtCnic.Text = dt.Rows[0]["Cnic"].ToString();

            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtContactPersonName.Text = dt.Rows[0]["ContactPerson"].ToString();

            txtDesignation.Text = dt.Rows[0]["Designation"].ToString();
            txtCity.Text = dt.Rows[0]["City"].ToString();

            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            cbIsActive.Checked =Convert.ToBoolean ( dt.Rows[0]["IsActive"].ToString());
            cbParent.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
            btnSubmit.Visible = false;
            btnUpdate.Visible = true;


        }
        //inserting values of chart of accounts in table
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            blayer.AccountCode = int.Parse(txtAccountCode.Text);
            blayer.AccountName = TxtAccountName.Text;
            blayer.AccountType = int.Parse(ddlAccountType.SelectedValue);
            blayer.ChildOf = int.Parse(ddlChildOf.SelectedValue);
            blayer.parentid = int.Parse(ddlChildOf.SelectedValue);
            blayer.IsPrent = Convert.ToBoolean(cbParent);
            blayer.IsActive =Convert.ToBoolean(cbIsActive);
            blayer.Address = txtAddress.Text;
            blayer.MobileNumber = txtMobileNumber.Text;
            blayer.Fax = txtFaxNumber.Text;
            blayer.Email = txtEmail.Text;
            blayer.Cnic = txtCnic.Text;
            blayer.ContactPerson = txtContactPersonName.Text;
            blayer.Designation = txtDesignation.Text;
            blayer.City = txtCity.Text;
            blayer.CreatedBy = Session["UserName"].ToString();

            //calling function

            blayer.InsertChartOfAccounts();

            //blayer.InsertChartOfAccountName(); use for previous technique
            //blayer.ChartOfAccountName = TxtAccountName.Text; same as above

            lblStatus.Text = "Record Inserted Sucesfully";
        }



        protected void ddlChildOf_SelectedIndexChanged(object sender, EventArgs e)
        {



            AccountId = int.Parse(ddlChildOf.SelectedValue);
            AccountCode();

        }

        //use for callling Account Code Of SAme item
        public int AccountId { get; set; }
        public void AccountCode()
        {
            string cs = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectAccountCode");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@AccountId", AccountId);
                cmd.Connection.Open();
                object result = cmd.ExecuteScalar();

                cmd.Connection.Close();
                txtAccountCode.Text = result.ToString();
                //  txtAccountCode.Text = StudentNumber;

            }
        }

        protected void btnMoreControl_Click(object sender, EventArgs e)
        {
            if (Panel1.Visible == true)
            {
                Panel1.Visible = false;
            }
            else
            {
                Panel1.Visible = true;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmChartOfAccounts.aspx");

        }

        protected void ddlAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            blayer.AccountType1 = int.Parse(ddlAccountType.SelectedValue);

            DataTable dt1 = blayer.DropDownListItems();
            ddlChildOf.DataSource = dt1;
            ddlChildOf.DataTextField = "ChartOfAccountsName";
            ddlChildOf.DataValueField = "ChartOfAccountsId";
            ddlChildOf.DataBind();
            txtAccountCode.Text = "";
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
            blayer.IsPrent = Convert.ToBoolean(cbParent.Checked);
            blayer.UpdateChartOfAccounts();
            
            lblStatus.Text = "Record updated Sucesfully";

        }



    }

}