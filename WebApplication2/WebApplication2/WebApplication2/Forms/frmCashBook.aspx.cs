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
    public partial class frmCashBook : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        Businesslayer.BLayer blayer = new Businesslayer.BLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserName"] = "Admin";

            if (!IsPostBack)
            {
                
                SetInitialRow();


                // dropdownlist for account types
                DataTable dt = blayer.CpCashAccount();
                ddlCashAccount.DataSource = dt;
                ddlCashAccount.DataTextField = "ChartOfAccountsName";
                ddlCashAccount.DataValueField = "ChartOfAccountsCode";
                ddlCashAccount.DataBind();

            }
        }
        //binding dropdownlist of gridview
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                DropDownList dropdownCode = (e.Row.FindControl("ddlAccountCode") as DropDownList);
                dropdownCode.DataSource = blayer.loadAccountcandn();
                dropdownCode.DataTextField = "AccountName_Code";
                dropdownCode.DataValueField = "AccountCode";
                dropdownCode.DataBind();

                DropDownList dropdownName = (e.Row.FindControl("ddlAccountName") as DropDownList);
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
            dt.Columns.Add(new DataColumn("Type", typeof(string)));//for TextBox    
            dt.Columns.Add(new DataColumn("Amount", typeof(string)));//for TextBox 
            dt.Columns.Add(new DataColumn("TRANSACTION", typeof(string)));//for TextBox


            dr = dt.NewRow();
            //dr["ID"] = 1;
            dr["RowNumber"] = 1;
            dr["DESCRIPTION"] = string.Empty;
            dr["Type"] = string.Empty;
            dr["Amount"] = string.Empty;
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
                        TextBox boxType = (TextBox)GridView1.Rows[i].Cells[3].FindControl("txtType");

                        TextBox boxAmount = (TextBox)GridView1.Rows[i].Cells[4].FindControl("txtAmount");
                        TextBox boxTransaction = (TextBox)GridView1.Rows[i].Cells[5].FindControl("txtTransaction");

                        dtCurrentTable.Rows[i]["DESCRIPTION"] = boxDescription.Text;
                        dtCurrentTable.Rows[i]["Type"] = boxType.Text;
                        dtCurrentTable.Rows[i]["Amount"] = boxAmount.Text;
                        dtCurrentTable.Rows[i]["TRANSACTION"] = boxTransaction.Text;

                        //extract the DropDownList Selected Items   

                        DropDownList ddlAccountName = (DropDownList)GridView1.Rows[i].Cells[0].FindControl("ddlAccountName");
                        DropDownList ddlAccountCode = (DropDownList)GridView1.Rows[i].Cells[1].FindControl("ddlAccountCode");

                        // Update the DataRow with the DDL Selected Items   

                        dtCurrentTable.Rows[i]["A/C NAME"] = ddlAccountName.SelectedItem.Text;
                        dtCurrentTable.Rows[i]["A/C CODE"] = ddlAccountCode.SelectedItem.Text;
                        if (rbReceipt.Checked)
                        {
                            boxType.Text = "Credit";
                        }
                        if (rbPayment.Checked)
                        {
                            boxType.Text = "Debit";
                        }

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
                        TextBox boxType = (TextBox)GridView1.Rows[i].Cells[3].FindControl("txtType");

                        TextBox boxAmount = (TextBox)GridView1.Rows[i].Cells[4].FindControl("txtAmount");
                        TextBox boxTransaction = (TextBox)GridView1.Rows[i].Cells[5].FindControl("txtTransaction");

                        //TextBox box1 = (TextBox)GridView1.Rows[i].Cells[1].FindControl("TextBox1");
                        //TextBox box2 = (TextBox)GridView1.Rows[i].Cells[2].FindControl("TextBox2");

                        DropDownList ddlAccountName = (DropDownList)GridView1.Rows[rowIndex].Cells[0].FindControl("ddlAccountName");
                        DropDownList ddlAccountCode = (DropDownList)GridView1.Rows[rowIndex].Cells[1].FindControl("ddlAccountCode");

                        //assign credit or debit to new row
                        if (rbReceipt.Checked)
                        {
                            boxType.Text = "Credit";
                        }
                        if (rbPayment.Checked)
                        {
                            boxType.Text = "Debit";
                        }
                        //Fill the DropDownList with Data   
                        //FillDropDownList(ddl1);
                        //FillDropDownList(ddl2);

                        if (i < dt.Rows.Count -1 )    //remove -1 from this place
                        {

                            //Assign the value from DataTable to the TextBox   
                            boxDescription.Text = dt.Rows[i]["DESCRIPTION"].ToString();
                            boxType.Text = dt.Rows[i]["Type"].ToString();
                            boxAmount.Text = dt.Rows[i]["Amount"].ToString();   
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
        public int a;
        public int b;
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

                        TextBox boxType = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtType");
                        TextBox boxAmount = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtAmount");
                        //if (rbReceipt.Checked)
                        //{
                        //    boxType.Text = "Credit";
                        //}
                        //if (rbPayment.Checked)
                        //{
                        //    boxType.Text = "Debit";
                        //}

                        //int cre = int.Parse(boxCredit.Text);
                        //txtTotalCredit.Text = cre.ToString();
                        if (string.IsNullOrWhiteSpace(boxAmount.Text))
                        {
                            // txtTotalCredit.Text = boxCredit.Text;
                            // i = int.Parse(boxCredit.Text);
                            lblMessage2.Text = "No Record Is Entered";
                        }


                        else
                        {
                            a = int.Parse(boxAmount.Text);
                            b = b + a;
                            txtTotal.Text = b.ToString();
                            lblMessage2.Text = "";
                        }

                       
                        //if (a == 0)
                        //{

                        //}
                        //// txtTotalCredit.Text = (boxCredit.Text + txtTotalCredit.Text);
                        ////  txtTotalCredit.Text =((int.Parse(txtTotalCredit.Text)) + (int.Parse(boxCredit.Text))).ToString();

                        //if (string.IsNullOrWhiteSpace(boxAmount.Text))
                        //{
                        //    txtTotalDebit.Text = boxAmount.Text;
                        //}

                        //else
                        //{
                        //    c = int.Parse(boxAmount.Text);
                        //    d = d + c;
                        //    txtTotalDebit.Text = d.ToString();

                        //}






                        rowIndex++;
                    }

                }
            }
            AddNewRowToGrid();
        }

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
                        if (e.Row.RowIndex == dt.Rows.Count )  //remove -1 from this to not show remove label
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
        }

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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    if (gvRow.RowIndex < dt.Rows.Count -1 )    //delete -1 from this line because that causes bot to remove last row
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);
                    }
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable"] = dt;

                //Re bind the GridView for the updated data  
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

            //Set Previous Data on Postbacks  
            SetPreviousData();
        }
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        }
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
        public int CreditA { get; set; }
        public int DebitA { get; set; }
        public string CreatedBy { get; set; }

        public void transition()
        {
            string cs = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("usp_CbMasterTransaction");
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

        public void InsertCashAccount()
        {
            blayer.AccountName = ddlCashAccount.SelectedItem.ToString();
            blayer.AccountCode = int.Parse(ddlCashAccount.SelectedValue);
            blayer.Description = txtDescriptionCashAccount.Text;
            blayer.VoucherNo = voucherNo;
            blayer.Date = date;
            blayer.InsertTransactionsSingleAccount();
            
        }
        public string cbPayment1 { get; set; }
        protected void btnSaveAll_Click(object sender, EventArgs e)
        {
            JvNumber();
            date = System.DateTime.Now.ToShortDateString();
            CreatedBy = Session["UserName"].ToString();
            transition();
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
                        TextBox boxType = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtType");
                        TextBox boxAmount = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtAmount");
                        TextBox boxTransaction = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("txtTransaction");
                        DropDownList ddlAccountName = (DropDownList)GridView1.Rows[rowIndex].Cells[0].FindControl("ddlAccountName");
                        DropDownList ddlAccountCode = (DropDownList)GridView1.Rows[rowIndex].Cells[1].FindControl("ddlAccountCode");



                        blayer.TransactionNumber = int.Parse(JvNo);
                        

                        if (!string.IsNullOrWhiteSpace(boxAmount.Text))
                        {

                            a = int.Parse(boxAmount.Text);
                            b = b + a;
                            txtTotal.Text = b.ToString();
                        }
                        else
                        {
                            txtTotal.Text = b.ToString();
                        }
                        // voucherNo = txtVoucher.Text;
                        //txtTotalCredit.Visible = true;
                        //txtTotalDebit.Visible = true;
                        //txtDifference.Visible = true;
                        boxTransaction.Text = JvNo + i;
                        //transitions =int.Parse(boxTransaction.Text);
                        //txtTotalCredit.Text =boxCredit.Text;
                        //txtTotalDebit.Text = boxDebit.Text;
                        //txtDifference.Text =Convert.ToString((int.Parse(txtTotalCredit.Text)) - (int.Parse(txtTotalDebit.Text)));
                        // txtVoucher.Text = voucherNo;
                        //lblMessage2.Text = i.ToString();
                        if (rbReceipt.Checked)
                        {
                            CreditA = int.Parse(boxAmount.Text);
                            blayer.Debit = b;
                        }
                        else if (rbPayment.Checked)
                        {
                            DebitA = int.Parse(boxAmount.Text);
                            blayer.Credit = b;
                        }
                        //get the values from TextBox and DropDownList  
                        //then add it to the collections with a comma "," as the delimited values  
                        sc.Add(string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", ddlAccountCode.SelectedValue,ddlAccountName.SelectedValue,
                            boxDescription.Text, CreditA, DebitA, boxTransaction.Text, voucherNo,date));

                        rowIndex++;
                    }
                    //Call the method for executing inserts  
                    InsertRecords(sc);
                    txtVoucherNo.Text = voucherNo;
                    InsertCashAccount();
                }
            }
            ///
            btnSaveAll.Visible = false;
            btnPrintReport.Visible = true;
            btnNewCashBook.Visible = true;
        }

        protected void rbReceipt_CheckedChanged(object sender, EventArgs e)
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        TextBox boxType = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtType");
                        TextBox boxAmount = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtAmount");

                        boxType.Text = "Credit";

                    }
                }
            }
        }

        protected void rbPayment_CheckedChanged(object sender, EventArgs e)
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        TextBox boxType = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtType");
                        TextBox boxAmount = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtAmount");

                        boxType.Text = "Debit";

                    }
                }
            }
        }

        protected void txtAmount_TextChanged(object sender, EventArgs e)
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

                        TextBox boxType = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtType");
                        TextBox boxAmount = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtAmount");
                        if (!string.IsNullOrWhiteSpace(boxAmount.Text))
                        {

                            a = int.Parse(boxAmount.Text);
                            b = b + a;
                            txtTotal.Text = b.ToString();
                        }
                        else
                        {
                            txtTotal.Text = b.ToString();
                        }
                        rowIndex++;
                    }
                }
            }
        }

        protected void btnNewCashBook_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCashBook.aspx");
        }

        protected void btnPrintReport_Click(object sender, EventArgs e)
        {

        }

        //protected void cbPayment_CheckedChanged(object sender, EventArgs e)
        //{
        //    int rowIndex = 0;
        //    if (ViewState["CurrentTable"] != null)
        //    {
        //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        //        if (dtCurrentTable.Rows.Count >0)
        //        {
        //            for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
        //            {

        //                TextBox boxType = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtType");
        //                TextBox boxAmount = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtAmount");

        //                boxType.Text = "Debit";

        //            }
        //        }
        //    }
        //}

        //protected void cbReceipt_CheckedChanged(object sender, EventArgs e)
        //{
        //    int rowIndex = 0;
        //    if (ViewState["CurrentTable"] != null)
        //    {
        //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        //        if (dtCurrentTable.Rows.Count >0)
        //        {
        //            for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
        //            {

        //                TextBox boxType = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtType");
        //                TextBox boxAmount = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("txtAmount");

        //                boxType.Text = "Credit";

        //            }
        //        }
        //    }
        //}

                //end o




    /////////////
    }

}