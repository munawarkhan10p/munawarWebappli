using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2.Businesslayer
{
    public class BLayer
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

        #region loginAuthentication
        public int checkauthentication(string uname, string upass)
        {
            int userId = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_loginauthentication"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@uname", uname);
                    cmd.Parameters.AddWithValue("@upass", upass);
                    cmd.Connection = con;
                    con.Open();
                    userId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }

            }
            return userId;
        }

        public int checkbit(string uname, string upass)
        {
            int chkbit = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_chkbit"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@uname", uname);
                    cmd.Parameters.AddWithValue("@upass", upass);
                    cmd.Connection = con;
                    con.Open();
                    chkbit = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }

            }
            return chkbit;
        }
        
        
        #endregion

        #region forgot Password Recover
        public DataTable getSecurityQuestionsbyUserName(string uname)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Question");
            SqlDataAdapter nadaq1 = new SqlDataAdapter("usp_getquestion1byUserName", connectionString);
            nadaq1.SelectCommand.CommandType = CommandType.StoredProcedure;
            nadaq1.SelectCommand.Parameters.AddWithValue("@uname", uname);
            nadaq1.Fill(dt);
            //also getting username and password through question2 store procedure
            SqlDataAdapter nadapq2 = new SqlDataAdapter("usp_getquestion2byUserName", connectionString);
            nadapq2.SelectCommand.CommandType = CommandType.StoredProcedure;
            nadapq2.SelectCommand.Parameters.AddWithValue("@uname", uname);
            nadapq2.Fill(dt);
            return dt;
        }
        public DataTable getSecurityQuestionsbyEmail(string email)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Question");
            SqlDataAdapter nadaq1 = new SqlDataAdapter("usp_getquestion1byEmail", connectionString);
            nadaq1.SelectCommand.CommandType = CommandType.StoredProcedure;
            nadaq1.SelectCommand.Parameters.AddWithValue("@Email", email);
            nadaq1.Fill(dt);
            //also getting username and password through question2 store procedure
            SqlDataAdapter nadapq2 = new SqlDataAdapter("usp_getquestion2byEmail", connectionString);
            nadapq2.SelectCommand.CommandType = CommandType.StoredProcedure;
            nadapq2.SelectCommand.Parameters.AddWithValue("@Email", email);
            nadapq2.Fill(dt);
            return dt;
        }
        public int checkanswer1(int id, string answer1)
        {
            int chk;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_securityanswer1"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@answer1", answer1);
                    cmd.Connection = con;
                    con.Open();
                    chk = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return chk;
        }
        public int checkanswer2(int id, string answer2)
        {
            int chk;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_securityanswer2"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@answer2", answer2);
                    cmd.Connection = con;
                    con.Open();
                    chk = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return chk;
        }
        public int changepass(int id, string newpass)
        {
            int chk;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_passwordchange"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@npass", newpass);
                    cmd.Connection = con;
                    con.Open();
                    chk = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return chk;
        }
        #endregion

        #region CreateStaffUser
        //int SecurityQuestionOne,string SecurityAnswerOne,int SecurityQuestionTwo,string SecurityAnswerTwo,,DateTime LastLogin
        public DataTable loadDesignationofCreateStaffUser()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_ShowStaffDesignations", connectionString);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }
        public int createStaffUser(string FirstName,string LastName,string UserName,string EmailId,string PhoneNumber,string MobileNumber,string Password,int Designation,bool IsActive,bool IsReset,string CreatedBy,DateTime CreatedDate,string Modifiedby,DateTime ModifiedDate)
        {
            int chkstatus = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_createstaffuser"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Parameters.AddWithValue("@EmailId", EmailId);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("@MobileNumber", MobileNumber);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    //cmd.Parameters.AddWithValue("@SecurityQuestionOne", SecurityQuestionOne);
                    //cmd.Parameters.AddWithValue("@SecurityAnswerOne", SecurityAnswerOne);
                    //cmd.Parameters.AddWithValue("@SecurityQuestionTwo", SecurityQuestionTwo);
                    //cmd.Parameters.AddWithValue("@SecurityAnswerTwo", SecurityAnswerTwo);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    cmd.Parameters.AddWithValue("@IsReset", IsReset);
                    cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                    cmd.Parameters.AddWithValue("@Modifiedby", Modifiedby);
                    cmd.Parameters.AddWithValue("@ModifiedDate", ModifiedDate);
                   //AddWithValue("@LastLogin", LastLogin);
                    
                    cmd.Connection = con;
                    con.Open();
                    chkstatus= Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }

            }
            return chkstatus;

        }

        #endregion


        #region FirstLoginChangePassword

        public DataSet getquestions() {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_getquestions", connectionString);
            DataSet nset = new DataSet();
            nadap.Fill(nset);
            return nset;
        }

        public void FirstAttemptPasswordChange(int id, string password, string SecurityAnswerOne, string SecurityAnswerTwo, int question1, int question2, bool isreset, string img)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_changePasswordFirstAttempt"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@securityquestion1", question1);
                    cmd.Parameters.AddWithValue("@SecurityAnswerOne", SecurityAnswerOne);
                    cmd.Parameters.AddWithValue("@securityquestion2", question2);
                    cmd.Parameters.AddWithValue("@SecurityAnswerTwo", SecurityAnswerTwo);
                    cmd.Parameters.AddWithValue("@isreset", isreset);
                    if (img != null|| img==string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@img", img);
                    }
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }



            }
        }
        

        #endregion

        #region Change Password
        public void ChangePassword(int id, string password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_ChangePassword"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteScalar();
                    con.Close();
                }

            }
            
        
        }
        #endregion

        #region Chart Of Account
        public DataTable LoadAccountType()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_ShowAccountTypes", connectionString);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }

        public DataTable LoadParentAccounts()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_ShowParentAccounts", connectionString);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }

        //inserting into table
        public int AccountId { get; set; }
        public int AccountCode { get; set; }
        public string AccountName { get; set; }
        public int AccountType { get; set; }
        public int ChildOf { get; set; }
        public Boolean IsPrent { get; set; }
        public Boolean IsActive { get; set; }
        public int parentid { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Cnic { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string City { get; set; }
        public int AccountType1 { get; set; }
        public string ChartOfAccountName { get; set; }
        public int ChartOfAccountId { get; set; }
        public int ChildOfDropdown { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

        public void InsertChartOfAccounts()
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_InsertChartOfAccount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChartOfAccountsCode", AccountCode);
            cmd.Parameters.Add("@ChartOfAccountsName", AccountName);
            cmd.Parameters.Add("@AccountType", AccountType);
            cmd.Parameters.Add("@ChildOf", ChildOf);
            cmd.Parameters.Add("@IsParent",IsPrent);
            cmd.Parameters.Add("@IsActive", IsActive);
            cmd.Parameters.Add("@ParentId", parentid);


            cmd.Parameters.Add("@Address", Address);
            cmd.Parameters.Add("@MobileNumber", MobileNumber);
            cmd.Parameters.Add("@Fax", Fax);
            cmd.Parameters.Add("@Email", Email);
            cmd.Parameters.Add("@Cnic", Cnic);
            cmd.Parameters.Add("@ContactPerson", ContactPerson);
            cmd.Parameters.Add("@Designation", Designation);
            cmd.Parameters.Add("@City", City);
            cmd.Parameters.Add("@CreatedBy", CreatedBy);
            
            
            
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateChartOfAccounts()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_UpdateChartOfAccounts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ChartOfAccountsId", AccountId);
            cmd.Parameters.Add("@ChartOfAccountsCode", AccountCode);
            cmd.Parameters.Add("@ChartOfAccountsName", AccountName);
            cmd.Parameters.Add("@IsActive", IsActive);
            cmd.Parameters.Add("@IsParent", IsPrent);



            cmd.Parameters.Add("@Address", Address);
            cmd.Parameters.Add("@MobileNumber", MobileNumber);
            cmd.Parameters.Add("@Fax", Fax);
            cmd.Parameters.Add("@Email", Email);
            cmd.Parameters.Add("@Cnic", Cnic);

            cmd.Parameters.Add("@ContactPerson", ContactPerson);
            cmd.Parameters.Add("@Designation", Designation);
            cmd.Parameters.Add("@City", City);
            cmd.Parameters.Add("@ModifiedBy", ModifiedBy);


            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable ChartOfAccountsById()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_ChartOfAccountsById", connectionString);
            nadap.SelectCommand.CommandType = CommandType.StoredProcedure;
            nadap.SelectCommand.Parameters.AddWithValue("@ChartOfAccountsId", ChartOfAccountId);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }
        public void InsertChartOfAccountName()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_InsertChartOfAccountName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", ChartOfAccountName);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable ChartOfAccountsAllColumn()       //we get all our view record using this function
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_ChartOfAccountAllRecord", connectionString);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }
        public DataTable DropDownListChildOf()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_DropdownlistChildOf", connectionString);
            nadap.SelectCommand.CommandType = CommandType.StoredProcedure;
            nadap.SelectCommand.Parameters.AddWithValue("@ChildOf", ChildOfDropdown);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }
        #endregion

        #region Create Customers

        public void InsertCustomerDetails()
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_InsertCustomerDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerCode", AccountCode);
            cmd.Parameters.Add("@CutomerName", AccountName);
            cmd.Parameters.Add("@AccountType", AccountType);
            cmd.Parameters.Add("@ChildOf", ChildOf);
            cmd.Parameters.Add("@IsActive", IsActive);
            cmd.Parameters.Add("@ParentId", parentid);

            cmd.Parameters.Add("@Address", Address);
            cmd.Parameters.Add("@MobileNumber", MobileNumber);
            cmd.Parameters.Add("@Fax", Fax);
            cmd.Parameters.Add("@Email", Email);
            cmd.Parameters.Add("@Cnic", Cnic);

            cmd.Parameters.Add("@ContactPerson", ContactPerson);
            cmd.Parameters.Add("@Designation", Designation);
            cmd.Parameters.Add("@City", City);
            cmd.Parameters.Add("@CreatedBy", CreatedBy);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateCustomerDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_UpdateCustomer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CustomerId", AccountId);
            cmd.Parameters.Add("@CustomerCode", AccountCode);
            cmd.Parameters.Add("@CutomerName", AccountName);

            cmd.Parameters.Add("@IsActive", IsActive);
          //  cmd.Parameters.Add("@IsParent", IsPrent);

            cmd.Parameters.Add("@Address", Address);
            cmd.Parameters.Add("@MobileNumber", MobileNumber);
            cmd.Parameters.Add("@Fax", Fax);
            cmd.Parameters.Add("@Email", Email);
            cmd.Parameters.Add("@Cnic", Cnic);

            cmd.Parameters.Add("@ContactPerson", ContactPerson);
            cmd.Parameters.Add("@Designation", Designation);
            cmd.Parameters.Add("@City", City);
            cmd.Parameters.Add("@ModifiedBy", ModifiedBy);


            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public void InsertCustomerName()
        {
             SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_InsertCustomerName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", CustomerName);
                cmd.ExecuteNonQuery();
                con.Close();
            }

        public DataTable CustomerAllColumns()       //we get all our view record using this function
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_CustomerAllRecord", connectionString);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }
        public DataTable CustomerById()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_CustomerById", connectionString);
            nadap.SelectCommand.CommandType = CommandType.StoredProcedure;
            nadap.SelectCommand.Parameters.AddWithValue("@CustomerId", CustomerId);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }

        public DataTable DropDownListItems()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_ChartOfAccounts", connectionString);
            nadap.SelectCommand.CommandType = CommandType.StoredProcedure;
            nadap.SelectCommand.Parameters.AddWithValue("@AccountType", AccountType1);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }
 
        public DataTable DropDownListFirstItem()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_ChartOfAccountFiirstItem", connectionString);
            nadap.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }

        //public string StudentNumber { get; set; }
        //public void CustomerNumber()
        //{
        //    string cs = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        //    using (SqlConnection connection = new SqlConnection(cs))
        //    {
        //        SqlCommand cmd = new SqlCommand("usp_StudentNumber");
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Connection = connection;
        //       // cmd.Parameters.AddWithValue("@Date", date);
        //        cmd.Connection.Open();
        //        object result = cmd.ExecuteScalar();
        //        StudentNumber = result.ToString();
        //        cmd.Connection.Close();

        //    }
        //}            //e




       #endregion
        #region Create Vendor

        public string VendorNumber { get; set; }
        public int VendorCode { get; set; }
        public string VendorName { get; set; }
        public int VendorId { get; set; }

        public void UpdateVendorDetails()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_UpdateVendor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VendorId", VendorId);
            cmd.Parameters.Add("@VendorCode", VendorCode);
            cmd.Parameters.Add("@VendorName", VendorName);

             cmd.Parameters.Add("@IsActive", IsActive);
          //  cmd.Parameters.Add("@IsParent", IsPrent);

            cmd.Parameters.Add("@Address", Address);
            cmd.Parameters.Add("@MobileNumber", MobileNumber);
            cmd.Parameters.Add("@Fax", Fax);
            cmd.Parameters.Add("@Email", Email);
            cmd.Parameters.Add("@Cnic", Cnic);

            cmd.Parameters.Add("@ContactPerson", ContactPerson);
            cmd.Parameters.Add("@Designation", Designation);
            cmd.Parameters.Add("@City", City);
            cmd.Parameters.Add("@ModifiedBy", ModifiedBy);


            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable VendorbyId()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_VendorById", connectionString);
            nadap.SelectCommand.CommandType = CommandType.StoredProcedure;
            nadap.SelectCommand.Parameters.AddWithValue("@VendorId", VendorId);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }
        public DataTable VendorAllColumn()     //we get all our view record using this function
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_VendorAllRecord", connectionString);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }
       
        public void InsertVendorName()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_InsertVendorName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Name", VendorName);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void InsertVendorDetails()
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_InsertVendorDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@VendorCode", AccountCode);
            cmd.Parameters.Add("@VendorName", AccountName);
            cmd.Parameters.Add("@AccountType", AccountType);
            cmd.Parameters.Add("@ChildOf", ChildOf);
            cmd.Parameters.Add("@IsActive", IsActive);
            cmd.Parameters.Add("@ParentId", parentid);

            cmd.Parameters.Add("@Address", Address);
            cmd.Parameters.Add("@MobileNumber", MobileNumber);
            cmd.Parameters.Add("@Fax", Fax);
            cmd.Parameters.Add("@Email", Email);
            cmd.Parameters.Add("@Cnic", Cnic);

            cmd.Parameters.Add("@ContactPerson", ContactPerson);
            cmd.Parameters.Add("@Designation", Designation);
            cmd.Parameters.Add("@City", City);
            cmd.Parameters.Add("@CreatedBy", CreatedBy);


            cmd.ExecuteNonQuery();
            con.Close();
        }






        #endregion

        #region Journal Voucher

        public DataTable CpCashAccount()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_CpAccount", connectionString);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }
        //dropdownlist AccountName And Code
        public DataTable LoadAccountNameAndCode()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_JvAccountNameAndCode", connectionString);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }

        //dropdown AccountCode And Name
        public DataTable LoadAccountCodeAndName()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_JvAccountCodeAndName", connectionString);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }
        public DataSet ThreeTablesData()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_ThreeTablesData", connectionString);
            DataSet ds = new DataSet();
            nadap.Fill(ds);
            return ds;
        }



        #endregion 
        #region Bank Book

        public DataTable BpCashAccounts()     //we get all our view record using this function
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_BbAccount", connectionString);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }
        public void BbInsertTransactions()
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_CbTransactionInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AccountCode", AccountCode);
            cmd.Parameters.Add("@Description", Description);
            cmd.Parameters.Add("@Credit", Credit);
            cmd.Parameters.Add("@Debit", Debit);
            cmd.Parameters.Add("@TransactionNumber", TransactionNumber);



            cmd.ExecuteNonQuery();
            con.Close();
        }

     

        #endregion

        #region Cash Book

        public string Description { get; set; }
        public int Credit { get; set; }
        public int Debit { get; set; }
        public int TransactionNumber { get; set; }
        public string VoucherNo { get; set; }
        public string Date { get; set; }
        public void InsertTransactions()
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_CbTransactionInsert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AccountCode", AccountCode);
            cmd.Parameters.Add("@Description", Description);
            cmd.Parameters.Add("@Credit", Credit);
            cmd.Parameters.Add("@Debit", Debit);
            cmd.Parameters.Add("@TransactionNumber", TransactionNumber);

            

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void InsertTransactionsSingleAccount()
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_CbTransactionIsertSingleAccount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@AccountName", AccountName);
            cmd.Parameters.Add("@AccountCode", AccountCode);
            cmd.Parameters.Add("@Description", Description);
            cmd.Parameters.Add("@Credit", Credit);
            cmd.Parameters.Add("@Debit", Debit);
            cmd.Parameters.Add("@TransactionNumber", TransactionNumber);
            cmd.Parameters.Add("@VoucherNumber", VoucherNo);
            cmd.Parameters.Add("@Date", Date);

            cmd.ExecuteNonQuery();
            con.Close();
        }




        #endregion 



        #region MainDashboard

        public DataTable demoimg(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter nadap = new SqlDataAdapter("usp_demoreadimg", connectionString);
            nadap.SelectCommand.CommandType = CommandType.StoredProcedure;
            nadap.SelectCommand.Parameters.AddWithValue("@id", id);
            nadap.Fill(dt);
            return dt;
        }

        #endregion

        public DataTable loadAccountcandn()
        {

            DataSet ds1 = ThreeTablesData();
            DataTable ForDropDown = new DataTable();
            
            ForDropDown.Columns.Add("AccountName_Code");
            ForDropDown.Columns.Add("AccountName");
            ForDropDown.Columns.Add("AccountCode");

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                var AccountName_Code = ds1.Tables[0].Rows[i]["CutomerName"].ToString() + "---" + ds1.Tables[0].Rows[i]["CustomerCode"].ToString();
                var AccountName = ds1.Tables[0].Rows[i]["CutomerName"].ToString();
                var AccountCode = ds1.Tables[0].Rows[i]["CustomerCode"].ToString();
                ForDropDown.Rows.Add(AccountName_Code, AccountCode, AccountName);

            }

            for (int i = 0; i < ds1.Tables[1].Rows.Count; i++)
            {

                var AccountName_Code = ds1.Tables[1].Rows[i]["VendorName"].ToString() + "---" + ds1.Tables[1].Rows[i]["VendorCode"].ToString();
                var AccountName = ds1.Tables[1].Rows[i]["VendorName"].ToString();
                var AccountCode = ds1.Tables[1].Rows[i]["VendorCode"].ToString();
                ForDropDown.Rows.Add(AccountName_Code, AccountCode, AccountName);

            }

            for (int i = 0; i < ds1.Tables[2].Rows.Count; i++)
            {

                var AccountName_Code = ds1.Tables[2].Rows[i]["ChartOfAccountsName"].ToString() + "---" + ds1.Tables[2].Rows[i]["ChartOfAccountsCode"].ToString();
                var AccountName = ds1.Tables[2].Rows[i]["ChartOfAccountsName"].ToString();
                var AccountCode = ds1.Tables[2].Rows[i]["ChartOfAccountsCode"].ToString();
                ForDropDown.Rows.Add(AccountName_Code, AccountCode, AccountName);

            }
            return ForDropDown;

        }



        #region Reports Management
        public string ReportCode { get; set; }
        public string JvRptVoucherNo { get; set; }
        public string Date1 { get; set; }
        public string Date2 { get; set; }
        public DataSet Ledgerreport()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_ReportLedger", connectionString);
            nadap.SelectCommand.CommandType = CommandType.StoredProcedure;
            nadap.SelectCommand.Parameters.AddWithValue("@Date1", Date1);
            nadap.SelectCommand.Parameters.AddWithValue("@Date2", Date2);
            nadap.SelectCommand.Parameters.AddWithValue("@AccountCode", ReportCode);
            DataSet dt = new DataSet();
            nadap.Fill(dt);
            return dt;
        }

        public DataTable JvReportPrint()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_JvReportPrint", connectionString);
            nadap.SelectCommand.CommandType = CommandType.StoredProcedure;
            nadap.SelectCommand.Parameters.AddWithValue("@VoucherNumber", JvRptVoucherNo);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }
        public string JvRModifiedBy { get; set; }
        public string JvVoucherNo { get; set; }
        public void JvModifiedBy()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("usp_JvModifiedNameAndDate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ModifiedBy", JvRModifiedBy);
            cmd.Parameters.Add("@VoucherNumber", JvVoucherNo);
            cmd.ExecuteNonQuery();
            con.Close();
        }

 
        public string AccountCde { get; set; }
        public string AccountNAme { get; set; }
        public DataTable SearchVoucher()
        {
            SqlDataAdapter nadap = new SqlDataAdapter("usp_SearchVouchers", connectionString);
            nadap.SelectCommand.CommandType = CommandType.StoredProcedure;
            nadap.SelectCommand.Parameters.AddWithValue("@AccountName", AccountNAme);
            nadap.SelectCommand.Parameters.AddWithValue("@AccountCode", AccountCde);
            DataTable dt = new DataTable();
            nadap.Fill(dt);
            return dt;
        }
        #endregion



        #region UpdateStaffINfo

        public DataTable showallinfoofuser(int id)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adap = new SqlDataAdapter("usp_getStaffUserInfo ", connectionString);
            adap.SelectCommand.CommandType = CommandType.StoredProcedure;
            adap.SelectCommand.Parameters.AddWithValue("@id", id);
            adap.Fill(dt);
            return dt;
        }

        public void usp_updateStaffUser(int id, string FirstName, string LastName, string EmailId, string PhoneNumber, string Password, int SecurityQuestionOne, string SecurityAnswerOne, int SecurityQuestionTwo, string SecurityAnswerTwo, string Modifiedby, DateTime ModifiedDate, string UserImg)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_updateStaffUser"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UserId", id);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@EmailId", EmailId);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@SecurityQuestionOne", SecurityQuestionOne);
                    cmd.Parameters.AddWithValue("@SecurityAnswerOne", SecurityAnswerOne);
                    cmd.Parameters.AddWithValue("@SecurityQuestionTwo", SecurityQuestionTwo);
                    cmd.Parameters.AddWithValue("@SecurityAnswerTwo", SecurityAnswerTwo);
                    cmd.Parameters.AddWithValue("@Modifiedby", Modifiedby);
                    cmd.Parameters.AddWithValue("@ModifiedDate", ModifiedDate);
                    if (UserImg != null || UserImg == string.Empty)
                    {
                        cmd.Parameters.AddWithValue("@UserImg", UserImg);
                    }
                    cmd.Connection = con;
                    con.Open();
                    Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }
        }

        #endregion








    }


}