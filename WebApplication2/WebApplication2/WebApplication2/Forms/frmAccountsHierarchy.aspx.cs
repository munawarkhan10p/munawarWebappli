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
    public partial class frmAccountsHierarchy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTreeViewItems();
            }

        }
        private void GetTreeViewItems()
        {
            string cs = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter adapter = new SqlDataAdapter("usp_AllColumsOfCreateCustomers", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
         
            
            //ds.Relations.Add("ChildRows", ds.Tables[0].Columns["AccountId"], ds.Tables[0].Columns["ParentId"]);
            ds.Relations.Add("ChildRows", ds.Tables[0].Columns["ChartOfAccountsId"], ds.Tables[0].Columns["ParentId"]);            
            foreach (DataRow Level1DataRow in ds.Tables[0].Rows)
            {
                if (string.IsNullOrEmpty(Level1DataRow["ParentId"].ToString()))
                {
                    TreeNode parentTreeNode = new TreeNode();
                    parentTreeNode.Text = Level1DataRow["Name"].ToString();
                   // parentTreeNode.NavigateUrl = Level1DataRow["NavigateUrl"].ToString();
                    getChildRows(Level1DataRow, parentTreeNode);
                    TreeView1.Nodes.Add(parentTreeNode);
                }
                //else if ((Level1DataRow["ParentId"].ToString()==13.ToString()))
                //{
                //    TreeNode parentTreeNode = new TreeNode();
                //    parentTreeNode.Text = Level1DataRow["AccountName"].ToString();
                //    parentTreeNode.NavigateUrl = Level1DataRow["NavigateUrl"].ToString();
                //    getChildRows(Level1DataRow, parentTreeNode);
                //    TreeView1.Nodes.Add(parentTreeNode);
                //}
            }


        }
        private void getChildRows(DataRow datarow, TreeNode treenode)
        {
            DataRow[] ChildRows = datarow.GetChildRows("ChildRows");
            foreach (DataRow Childrow in ChildRows)
            {
                TreeNode childTreeNode = new TreeNode();
                childTreeNode.Text = Childrow["Name"].ToString();
             //   childTreeNode.NavigateUrl = Childrow["NavigateUrl"].ToString();
                treenode.ChildNodes.Add(childTreeNode);
                if (Childrow.GetChildRows("ChildRows").Length > 0)
                {
                    getChildRows(Childrow, childTreeNode);
                }

            }

        }
    }
}