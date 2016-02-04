using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication2.Businesslayer
{

    public class Employe
    
    {
        public int TransactionId { get; set; }
        public string AccountName { get; set; }
        public int AccountCode { get; set; }
        public string Description { get; set; }
        public int Credit { get; set; }
        public int Debit { get; set; }
        public string VoucherNumber { get; set; }
    }

    public class EmployeDataAccess
    {
        public static IList<Employe> GetAllEmployes(string VoucherNumber)
        {
            IList<Employe> listEmployees = new List<Employe>();
            string Cs = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using(SqlConnection con = new SqlConnection(Cs))
            {
                SqlCommand cmd = new SqlCommand("usp_JvUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VoucherNo", VoucherNumber);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read()) 
                {
                    Employe employe = new Employe();
                    employe.TransactionId= Convert.ToInt32(rdr["TransactionId"]);
                    employe.AccountName = rdr["AccountName"].ToString();
                    employe.AccountCode = Convert.ToInt32(rdr["AccountCode"]);
                    employe.Description = rdr["Description"].ToString();
                    employe.Credit = Convert.ToInt32(rdr["Credit"]);
                    employe.Debit = Convert.ToInt32(rdr["Debit"]);
                    employe.VoucherNumber = rdr["VoucherNumber"].ToString();
                    listEmployees.Add(employe);
                    
                }
            }
            return listEmployees;
        }

        public static void UpdateEmployees(int TransactionId, string AccountName, int AccountCode, string Description, int Credit, int Debit, string VoucherNumber)
        {
             string Cs = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
             using (SqlConnection con = new SqlConnection(Cs))
             {


                 SqlCommand cmd = new SqlCommand("usp_JvUpdateTransaction", con);
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.Parameters.AddWithValue("@TransactionId", TransactionId);
                // cmd.Parameters.AddWithValue("@VoucherNumber", VoucherNumber);
                 cmd.Parameters.AddWithValue("@AccountName", AccountName);
                 cmd.Parameters.AddWithValue("@AccountCode", AccountCode);
                 cmd.Parameters.AddWithValue("@Description", Description);
                 cmd.Parameters.AddWithValue("@Credit", Credit);
                 cmd.Parameters.AddWithValue("@Debit", Debit);
                 con.Open();
                 cmd.ExecuteNonQuery();



             }
        }
        public static void DeleteEmploye(string VoucherNumber)
        {
            string Cs = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(Cs))
            {
                SqlCommand cmd = new SqlCommand("usp_JvDelete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VoucherNumber", VoucherNumber);
                con.Open();
                cmd.ExecuteNonQuery();
               
            }
        }
    }
}

