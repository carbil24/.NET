using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using StudentsWebApplication.BussinessLayer;

namespace StudentsWebApplication.DataLayer
{
    public class DBUtility
    {
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["StudentsConnection"].ConnectionString;
        }

        public static int InsertAddress(Address address)
        {
            SqlConnection conn;
            SqlCommand cmd;

            using (conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    string sql = "insert into Address values (@street, @city, @province, @postalcode)";
                    //string sql = $"insert into Address values ('{address.Street}', '{address.City}', '{address.Province}', '{address.PostalCode}')";

                    conn.Open();

                    using (cmd = new SqlCommand(sql, conn))
                    {
                        
                        SqlParameter[] param = new SqlParameter[4];
                        param[0] = new SqlParameter("@street", System.Data.SqlDbType.NVarChar, 50);
                        param[1] = new SqlParameter("@city", System.Data.SqlDbType.NVarChar, 50);
                        param[2] = new SqlParameter("@province", System.Data.SqlDbType.Char, 2);
                        param[3] = new SqlParameter("@postalCode", System.Data.SqlDbType.Char, 7);

                        param[0].Value = address.Street;
                        param[1].Value = address.City;
                        param[2].Value = address.Province;
                        param[3].Value = address.PostalCode;

                        foreach (SqlParameter p in param)
                        {
                            cmd.Parameters.Add(p);
                        }
                        

                        cmd.CommandType = System.Data.CommandType.Text;

                        return cmd.ExecuteNonQuery();
                    }
                }
                catch(SqlException ex)
                {
                    return ex.ErrorCode;
                }
            }
        }

        public static int InsertAddressNoParam(Address address)
        {
            SqlConnection conn;
            SqlCommand cmd;

            using (conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    //string sql = "insert into Address values (@street, @city, @province, @postalcode)";
                    string sql = $"insert into Address values ('{address.Street}', '{address.City}', '{address.Province}', '{address.PostalCode}')";

                    conn.Open();

                    using (cmd = new SqlCommand(sql, conn))
                    {
                        /*
                        SqlParameter[] param = new SqlParameter[4];
                        param[0] = new SqlParameter("@street", System.Data.SqlDbType.NVarChar, 50);
                        param[1] = new SqlParameter("@city", System.Data.SqlDbType.NVarChar, 50);
                        param[2] = new SqlParameter("@province", System.Data.SqlDbType.Char, 2);
                        param[3] = new SqlParameter("@postalCode", System.Data.SqlDbType.Char, 7);

                        param[0].Value = address.Street;
                        param[1].Value = address.City;
                        param[2].Value = address.Province;
                        param[3].Value = address.PostalCode;

                        foreach (SqlParameter p in param)
                        {
                            cmd.Parameters.Add(p);
                        }
                        */

                        cmd.CommandType = System.Data.CommandType.Text;

                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    return ex.ErrorCode;
                }
            }
        }


        public static int InsertAddressFromSP(Address address)
        {
            SqlConnection conn;
            SqlCommand cmd;

            using (conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    string sql = "sp_InsertAddress";

                    conn.Open();

                    using (cmd = new SqlCommand(sql, conn))
                    {
                        
                        SqlParameter[] param = new SqlParameter[4];
                        param[0] = new SqlParameter("@street", System.Data.SqlDbType.NVarChar, 50);
                        param[1] = new SqlParameter("@city", System.Data.SqlDbType.NVarChar, 50);
                        param[2] = new SqlParameter("@province", System.Data.SqlDbType.Char, 2);
                        param[3] = new SqlParameter("@postalCode", System.Data.SqlDbType.Char, 7);

                        param[0].Value = address.Street;
                        param[1].Value = address.City;
                        param[2].Value = address.Province;
                        param[3].Value = address.PostalCode;

                        foreach (SqlParameter p in param)
                        {
                            cmd.Parameters.Add(p);
                        }
                        

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    return ex.ErrorCode;
                }
            }
        }

    }
}