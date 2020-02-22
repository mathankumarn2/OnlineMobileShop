using System.Collections.Generic;
using OnlineMobileShop.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace OnlineMobileShop.Respository
{
    public class MobileRespository
    {
        public static List<Mobile> mobilelist = new List<Entity.Mobile>();
       
        static MobileRespository()
        {

            mobilelist.Add(new Mobile { MobileID = 1, Brand = "Nokia", Model = "y22", Battery = 3000, Price = 6000 });

            mobilelist.Add(new Mobile { MobileID = 2, Brand = "Vivo", Model = "v5", Battery = 4000, Price = 8000 });

            mobilelist.Add(new Mobile { MobileID = 3, Brand = "Oppo", Model = "f1", Battery = 5000, Price = 11000 });
        }
        public DataTable GetDetails()
        {
            string sqlConnection = MobileRespository.GetDBConnection();
            using (SqlConnection myConnection = new SqlConnection(sqlConnection))
            {
                myConnection.Open();
                string sql = "SP_Display";
                SqlCommand sqlCommand = new SqlCommand(sql, myConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
        }

        public bool Add(Mobile mobile)
        {
            string sqlConnection = MobileRespository.GetDBConnection();
            using (SqlConnection myConnection = new SqlConnection(sqlConnection))
                {
                    myConnection.Open();
                    string sql = "SP_InsertData";
                    SqlCommand sqlCommand = new SqlCommand(sql, myConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Brand", mobile.Brand);
                    sqlCommand.Parameters.AddWithValue("@Model", mobile.Model);
                    sqlCommand.Parameters.AddWithValue("@Battery", mobile.Battery);
                    sqlCommand.Parameters.AddWithValue("@RAM", mobile.RAM);
                    sqlCommand.Parameters.AddWithValue("@ROM", mobile.ROM);
                    sqlCommand.Parameters.AddWithValue("@Price", mobile.Price);
                    int limit = sqlCommand.ExecuteNonQuery();
                    if (limit >= 1)
                    {
                        return true;

                    }
                    return false;
            }
            }
        public static bool Delete(int MobileID)
        {
            string sqlConnection = MobileRespository.GetDBConnection();
            using (SqlConnection myConnection = new SqlConnection(sqlConnection))
            {
                myConnection.Open();
                string sql = "SP_Delete";
                SqlCommand sqlCommand = new SqlCommand(sql, myConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@MobileID", MobileID);
                int limit = sqlCommand.ExecuteNonQuery();
                if (limit >= 1)
                {
                    return true;

                }
                return false;
            }
        }

        public static bool Update(Mobile mobile)
        {
            string sqlConnection = MobileRespository.GetDBConnection();
            using (SqlConnection myConnection = new SqlConnection(sqlConnection))
            {
                myConnection.Open();
                string sql = "SP_UpdateData";
                SqlCommand sqlCommand = new SqlCommand(sql, myConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
               
                sqlCommand.Parameters.AddWithValue("@Brand", mobile.Brand);
                sqlCommand.Parameters.AddWithValue("@Model", mobile.Model);
                sqlCommand.Parameters.AddWithValue("@Battery", mobile.Battery);
                sqlCommand.Parameters.AddWithValue("@RAM", mobile.RAM);
                sqlCommand.Parameters.AddWithValue("@ROM", mobile.ROM);
                sqlCommand.Parameters.AddWithValue("@Price", mobile.Price);

                int limit = sqlCommand.ExecuteNonQuery();
                if (limit >= 1)
                {
                    return true;

                }
                return false;
            }
        }
        public static Mobile GetMobileID(int MobileID)
        {
            return mobilelist.Find(id => id.MobileID == MobileID);
        }
        public static string GetDBConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OnlineMobileShop"].ConnectionString;
            return connectionString;
        }
    }
}