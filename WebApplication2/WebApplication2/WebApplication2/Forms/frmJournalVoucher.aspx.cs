using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Text;
namespace WebApplication2
{
    public partial class frmJournalVoucher : System.Web.UI.Page
    {
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserName"] = "Admin";
            if (!IsPostBack)
            {
                SetInitialRow();
     ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
     //           DataSet ds1 = blayer.ThreeTablesData();
     //           DataTable ForDropDown = new DataTable();
     //           ForDropDown.Columns.Add("AccountName");
     //           ForDropDown.Columns.Add("AccountCode");


     //           for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
     //           {
     //               var AccountName = ds1.Tables[0].Rows[i]["CutomerName"].ToString(); //+ ds1.Tables[0].Rows[i]["CustomerId"].ToString();
     //               var AccountCode = ds1.Tables[0].Rows[i]["CustomerCode"].ToString();
     //               ForDropDown.Rows.Add(AccountName, AccountCode);

     //           }

     //           for (int i = 0; i < ds1.Tables[1].Rows.Count; i++)
     //           {

     //               var AccountName = ds1.Tables[1].Rows[i]["VendorName"].ToString();
     //               var AccountCode = ds1.Tables[1].Rows[i]["VendorCode"].ToString();
     //               ForDropDown.Rows.Add(AccountName, AccountCode);

     //           }

     //           for (int i = 0; i < ds1.Tables[2].Rows.Count; i++)
     //           {

     //               var AccountName = ds1.Tables[2].Rows[i]["ChartOfAccountsName"].ToString();// +ds1.Tables[2].Rows[i]["ChartOfAccountsId"].ToString();
     //               var AccountCode = ds1.Tables[2].Rows[i]["ChartOfAccountsCode"].ToString();
     //               ForDropDown.Rows.Add(AccountName, AccountCode);

     //           }


     //           //ddlChildOf.DataSource = ForDropDown;
     //           //ddlChildOf.DataTextField = "AccountName";
     //           //ddlChildOf.DataValueField = "AccountCode";
     //           //ddlChildOf.DataBind();

     //           /////////////////////////////////////////////

            }

        }
                //binding dropdownlist of gridview
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                DropDownList dropdownCode = (e.Row.FindControl("ddlAccountCode") as DropDownList);
               // dropdownCode.DataSource = blayer.LoadAccountCodeAndName();
                dropdownCode.DataSource = blayer.loadAccountcandn();
                dropdownCode.DataTextField = "AccountName_Code";        //Name AccountId
                dropdownCode.DataValueField = "AccountCode";
                dropdownCode.DataBind();

                DropDownList dropdownName = (e.Row.FindControl("ddlAccountName") as DropDownList);
                //dropdownName.DataSource = blayer.LoadAccountNameAndCode();
                dropdownName.DataSource = blayer.loadAccountcandn();
                dropdownName.DataTextField = "AccountName_Code";
                dropdownName.DataValueField = "AccountName";
                dropdownName.DataBind();
            }
        }
                    //   end 

                    //creating initial rows
        private void SetInitialRow()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("A/C CODE", typeof(string)));//for dropdowmlist acontcode
            dt.Columns.Add(new DataColumn("A/C NAME", typeof(string)));//for dropdownlist AccountName   
            dt.Columns.Add(new DataColumn("DESCRIPTION", typeof(string)));//for TextBox     
            dt.Columns.Add(new DataColumn("CREDIT", typeof(string)));//for TextBox    
            dt.Columns.Add(new DataColumn("DEBIT", typeof(string)));//for TextBox 
            dt.Columns.Add(new DataColumn("TRANSACTION", typeof(string)));//for TextBox


            dr = dt.NewRow();
            //dr["ID"] = 1;
            dr["RowNumber"] = 1;
            dr["DESCRIPTION"] = string.Empty;
            dr["CREDIT"] = string.Empty;
            dr["DEBIT"] = string.Empty;
            dr["TRANSACTION"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTable"] = dt;

            //Bind the Gridview   
            GridView1.DataSource = dt;
            GridView1.DataBind();

            ////After binding the gridview, we can then extract and fill the DropDownList with Data   
            DropDownList ddlAccountName = (DropDownList)GridView1.Rows[0].Cells[0].FindControl("ddlAccountName");
            DropDownList ddlAccountCode = (DropDownList)GridView1.Rows[0].Cells[1].FindControl("ddlAccountCode");
            //FillDropDownList(ddl1);
            //FillDropDownList(ddl2);
        }

                        // end
        private void AddNewRowToGrid()
        {

            if (ViewState["CurrentTable"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    // drCurrentRow["ID"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   

                    ViewState["CurrentTable"] = dtCurrentTable;


                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the TextBox values   

                        TextBox boxDescription = (TextBox)GridView1.Rows[i].Cells[2].FindControl("txtDescription");
                        TextBox boxCredit = (TextBox)GridView1.Rows[i].Cells[3].FindControl("txtCredit");

                        TextBox boxDebit = (TextBox)GridView1.Rows[i].Cells[4].FindControl("txtDebit");
                        TextBox boxTransaction = (TextBox)GridView1.Rows[i].Cells[5].FindControl("txtTransaction");

                        dtCurrentTable.Rows[i]["DESCRIPTION"] = boxDescription.Text;
                        dtCurrentTable.Rows[i]["CREDIT"] = boxCredit.Text;
                        dtCurrentTable.Rows[i]["DEBIT"] = boxDebit.Text;
                        dtCurrentTable.Rows[i]["TRANSACTION"] = boxTransaction.Text;

                        //extract the DropDownList Selected Items   

                        DropDownList ddlAccountName = (DropDownList)GridView1.Rows[i].Cells[0].FindControl("ddlAccountName");
                        DropDownList ddlAccountCode = (DropDownList)GridView1.Rows[i].Cells[1].FindControl("ddlAccountCode");

                        // Update the DataRow with the DDL Selected Items   

                        dtCurrentTable.Rows[i]["A/C NAME"] = ddlAccountName.SelectedItem.Text;
                        dtCurrentTable.Rows[i]["A/C CODE"] = ddlAccountCode.SelectedItem.Text;
                        
                    }

                    //Rebind the Grid with the current data to reflect changes   
                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks   
            SetPreviousData();
        }
        //end
        private void SetPreviousData()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox boxDescription = (TextBox)GridView1.Rows[i].Cells[2].FindControl("txtDescription");
                        TextBox boxCredit = (TextBox)GridView1.Rows[i].Cells[3].FindControl("txtCredit");

                        TextBox boxDebit = (TextBox)GridView1.Rows[i].Cells[4].FindControl("txtDebit");
                        TextBox boxTransaction = (TextBox)GridView1.Rows[i].Cells[5].FindControl("txtTransaction");

                        //TextBox box1 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("TextBox1");
                        //TextBox box2 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("TextBox2");

                        DropDownList ddlAccountName = (DropDownList)GridView1.Rows[rowIndex].Cells[0].FindControl("ddlAccountName");
                        DropDownList ddlAccountCode = (DropDownList)GridView1.Rows[rowIndex].Cells[1].FindControl("ddlAccountCode");

                        //Fill the DropDownList with Data   
                        //FillDropDownList(ddl1);
                        //FillDropDownList(ddl2);

                        if (i < dt.Rows.Count - 1)
                        {

                            //Assign the value from DataTable to the TextBox   
                            boxDescription.Text = dt.Rows[i]["DESCRIPTION"].ToString();
                            boxCredit.Text = dt.Rows[i]["CREDIT"].ToString();
                            boxDebit.Text = dt.Rows[i]["DEBIT"].ToString();
                            boxTransaction.Text = dt.Rows[i]["TRANSACTION"].ToString();

                            //Set the Previous Selected Items on Each DropDownList  on Postbacks   
                            ddlAccountName.ClearSelection();
                            ddlAccountName.Items.FindByText(dt.Rows[i]["A/C NAME"].ToString()).Selected = true;

                            ddlAccountCode.ClearSelection();
                            ddlAccountCode.Items.FindByText(dt.Rows[i]["A/C CODE"].ToString()).Selected = true;

                        }
                        
                        rowIndex++;
                    }
                }
            }
        }
                    //button add new rows
        public int a;
        public int b;
        public int c;
        public int d;
        public int ee;
        public int ff;
        public int gg;
        public int h;
        public int i { get; set; }
        protected void btnAddNewRow_Click(object sender, EventArgs e)
        {
           
             int rowIndex = 0;
            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        
                        TextBox boxCredit = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                        TextBox boxDebit = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtDebit");

                       
                            //int cre = int.Parse(boxCredit.Text);
                            //txtTotalCredit.Text = cre.ToString();
                        if (string.IsNullOrWhiteSpace(boxCredit.Text) )
                        {
                           // txtTotalCredit.Text = boxCredit.Text;
                           // i = int.Parse(boxCredit.Text);
                            lblMessage2.Text = "No Record Is Entered";
                        }
                       
                       
                        else
                        {
                            a = int.Parse(boxCredit.Text);
                            b = b + a;
                            txtTotalCredit.Text = b.ToString();
                            lblMessage2.Text = "";
                        }
                        

                         if ( a == 0)
                        {
                            
                        }
                       // txtTotalCredit.Text = (boxCredit.Text + txtTotalCredit.Text);
                      //  txtTotalCredit.Text =((int.Parse(txtTotalCredit.Text)) + (int.Parse(boxCredit.Text))).ToString();

                        if (string.IsNullOrWhiteSpace(boxDebit.Text) )
                        {
                            txtTotalDebit.Text = boxDebit.Text;
                        }
                       
                        else
                        {
                            c = int.Parse(boxDebit.Text);
                            d = d + c;
                            txtTotalDebit.Text = d.ToString();
                            
                        }      
                            

                          



                            rowIndex++;
                    }

                }
            }
       
            AddNewRowToGrid();
           
        
        }              //end
                // link button 
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                LinkButton lb = (LinkButton)e.Row.FindControl("lbRemove");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count)  //remove -1 from this to not show remove label
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }           // end

        private void ResetRowID(DataTable dt)
        {
            int rowNumber1 = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber1;
                    rowNumber1++;

                }
            }
        }

        protected void lbRemove_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)    //delete -1 from this line because that causes bot to remove last row
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);

                        ////////////////////////////////////////////////////////////////////////////////
                        //int rowIndex = 0;
                        //if (ViewState["CurrentTable"] != null)
                        //{
                        //    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                        //    if (dtCurrentTable.Rows.Count > 0)
                        //    {
                        //        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        //        {

                        //            TextBox boxCredit = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                        //            TextBox boxDebit = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtDebit");

                        //            a = int.Parse(txtTotalCredit.Text);
                        //            h = i;
                        //            txtTotalCredit.Text = (a - b).ToString();
                        //        }
                        //    }
                        //}
                        //rowIndex++;
                    }
                }
                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable"] = dt;

                //Re bind the GridView for the updated data  
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            //int rowIndex = 0;
            //StringCollection sc = new StringCollection();
            //if (ViewState["CurrentTable"] != null)
            //{
            //    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            //    if (dtCurrentTable.Rows.Count > 0)
            //    {
            //        for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
            //        {

            //            TextBox boxCredit = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
            //            TextBox boxDebit = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtDebit");


            //            //int cre = int.Parse(boxCredit.Text);
            //            //txtTotalCredit.Text = cre.ToString();
            //            a = int.Parse(boxCredit.Text);
            //            b = b - a;
            //            txtTotalCredit.Text = b.ToString();


            //            //txtTotalCredit.Text = cre.ToString();


                        
            //            rowIndex++;
            //        }

            //    }
            //}

            //Set Previous Data on Postbacks  
            SetPreviousData();
        }




        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        }


                    //inserting record in database
        private void InsertRecords(StringCollection sc)
        {
            StringBuilder sb = new StringBuilder(string.Empty);
            string[] splitItems = null;
            const string sqlStatement = "INSERT INTO tblDetailTransaction (AccountName,AccountCode,Description,Credit,Debit,TransactionNumber,VoucherNumber,Date) VALUES";
            foreach (string item in sc)
            {
                if (item.Contains(","))
                {
                    splitItems = item.Split(",".ToCharArray());
                    sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'); ", sqlStatement,
                        splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], splitItems[5], splitItems[6], splitItems[7]);
                }
            }

            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(sb.ToString(), connection))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
            lblMessage2.Text = "Records successfully saved!";
        }               // record insertion end

        public string voucherNo { get; set; }
        public string voucher { get; set; }
        public int transitions { get; set; }
        public string date { get; set; }
        public string CreatedBy { get; set; }

        public void transition()
        {
            string cs = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_JvMasterTransaction");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@CreatedDate", date);
                cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                cmd.Connection.Open();
                object result = cmd.ExecuteScalar();
                voucherNo = result.ToString();
                txtVoucherNo.Text = voucherNo;
                cmd.Connection.Close();

            }
        }            //end of function

        public void transitionbefore()
        {
            string cs = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_jvGetVoucherNoBefore");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@VDate", date);
                cmd.Connection.Open();
                object result = cmd.ExecuteScalar();
                voucherNo = result.ToString();
                txtVoucherNo.Text = voucherNo;
                cmd.Connection.Close();

            }
        }
        public string JvNo { get; set; }
        public void JvNumber()
        {
            string cs = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_JvNumber");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                // cmd.Parameters.AddWithValue("@Date", date);
                cmd.Connection.Open();
                object result = cmd.ExecuteScalar();

                cmd.Connection.Close();
                JvNo = result.ToString();
                //  txtAccountCode.Text = StudentNumber;

            }
        }
        public void insert()
        {
            
        }
        protected void ClearTextBoxes(Control p1)
        {
            foreach (Control ctrl in p1.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox t = ctrl as TextBox;

                    if (t != null)
                    {
                        t.Text = String.Empty;
                    }
                }
                else
                {
                    if (ctrl.Controls.Count > 0)
                    {
                        ClearTextBoxes(ctrl);
                    }
                }
            }
        }
        protected void btnSaveAll_Click(object sender, EventArgs e)
        {
            JvNumber();
            date = System.DateTime.Now.ToShortDateString();      //DateTimePicker.Text;    //Convert.ToDateTime(System.DateTime.Now.ToShortDateString());       //DateTime.Parse(DateTimePicker.Text);
            CreatedBy = Session["UserName"].ToString();
            transitionbefore();

            int rowIndex = 0;
            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values     ddlAccountName ddlAccountCode
                        TextBox boxDescription = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("txtDescription");
                        TextBox boxCredit = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtCredit");
                        TextBox boxDebit = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtDebit");
                        TextBox boxTransaction = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtTransaction");
                        DropDownList ddlAccountName = (DropDownList)GridView1.Rows[rowIndex].Cells[0].FindControl("ddlAccountName");
                        DropDownList ddlAccountCode = (DropDownList)GridView1.Rows[rowIndex].Cells[1].FindControl("ddlAccountCode");
                        // voucherNo = txtVoucher.Text;
                        txtTotalCredit.Visible = true;
                        txtTotalDebit.Visible = true;
                        txtDifference.Visible = true;
                        boxTransaction.Text = JvNo+i;

                        if (!string.IsNullOrWhiteSpace(boxCredit.Text))
                        {

                            a = int.Parse(boxCredit.Text);
                            b = b + a;
                            txtTotalCredit.Text = b.ToString();
                        }
                        else
                        {
                            txtTotalCredit.Text = b.ToString();
                        }
                        // txtTotalCredit.Text = (boxCredit.Text + txtTotalCredit.Text);
                        //  txtTotalCredit.Text =((int.Parse(txtTotalCredit.Text)) + (int.Parse(boxCredit.Text))).ToString();

                        if (!string.IsNullOrWhiteSpace(boxDebit.Text))
                        {
                            c = int.Parse(boxDebit.Text);
                            d = d + c;
                            txtTotalDebit.Text = d.ToString();
                        }
                        else
                        {
                            txtTotalDebit.Text = d.ToString();

                        }

                        txtDifference.Text = (b - d).ToString();
                        ee = int.Parse(txtDifference.Text);
                        ff=int.Parse(txtTotalCredit.Text);




                        //txtTotalDebit.Text = boxDebit.Text;
                        //transitions =int.Parse(boxTransaction.Text);
                        //txtTotalCredit.Text =boxCredit.Text;
                        //txtTotalDebit.Text = boxDebit.Text;
                        //txtDifference.Text =Convert.ToString((int.Parse(txtTotalCredit.Text)) - (int.Parse(txtTotalDebit.Text)));
                        // txtVoucher.Text = voucherNo;
                        //lblMessage2.Text = i.ToString();
                        //get the values from TextBox and DropDownList  
                        //then add it to the collections with a comma "," asthe delimited values  
                        sc.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", ddlAccountCode.SelectedValue, ddlAccountName.SelectedValue,
                            boxDescription.Text, boxCredit.Text, boxDebit.Text, boxTransaction.Text,voucherNo,date));

                        rowIndex++;
                    }
                    //Call the method for executing inserts  

                   

                    //method call for condition checking
                    if (ee != 0 )
                    {
                        lblMessage2.Text = "Difference in accounts";
                        
                    }
                  else  if (d == 0 || b == 0)
                    {
                        lblMessage2.Text = "No Record Is Entered";
                    }
                    else if (ee == 0)
                    {
                        txtVoucherNo.Text = voucherNo;
                        transition();
                        InsertRecords(sc);
                        btnSaveAll.Visible = false;
                        btnPrintreport.Visible = true;
                        btnNewvoucher.Visible = true;
                        //ClearTextBoxes(Page);




                    }

                }
            }



        }

        protected void btnPrintreport_Click(object sender, EventArgs e)
        {
            blayer.JvRptVoucherNo = txtVoucherNo.Text;
            DataTable dt = blayer.JvReportPrint();
            Session["ReportDataTable"] = dt;
            Session["ReportDS"] = "DataSet1";
            Session["ReportName"] = "Reports/JournalVoucher.rdlc";
            Response.Redirect("frmReportsView.aspx");

        }

        protected void btnNewvoucher_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmJournalVoucher.aspx");
        }

        protected void ddlAccountCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
        }   ///////////////    //end


        /////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////
    } 
    ///////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////