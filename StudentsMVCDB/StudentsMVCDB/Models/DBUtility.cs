using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentsMVCDB.Models
{
    public class DBUtility
    {
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["StudentsConnection"].ConnectionString;
        }

        #region Insert Address

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

        public static int InsertAddressFromSPNoParameter(Address address)
        {
            SqlConnection conn;
            SqlCommand cmd;


            using (conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    string sql = $"exec sp_insertAddress '{address.Street}', '{address.City}', '{address.Province}', '{address.PostalCode}'";


                    conn.Open();


                    using (cmd = new SqlCommand(sql, conn))
                    {
                        //    SqlParameter[] param = new SqlParameter[4];
                        //    param[0] = new SqlParameter("@street", System.Data.SqlDbType.NVarChar, 50);
                        //    param[1] = new SqlParameter("@city", System.Data.SqlDbType.NVarChar, 50);
                        //    param[2] = new SqlParameter("@province", System.Data.SqlDbType.Char, 2);
                        //    param[3] = new SqlParameter("@postalCode", System.Data.SqlDbType.Char, 7);


                        //    param[0].Value = address.Street;
                        //    param[1].Value = address.City;
                        //    param[2].Value = address.Province;
                        //    param[3].Value = address.PostalCode;


                        //    foreach (SqlParameter p in param)
                        //    {
                        //        cmd.Parameters.Add(p);
                        //    }


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

        #endregion

        #region Select Address

        public static Address SelectAddressById(int id)
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader dataReader;
            DataTable dataTable;

            using (conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    string sql = $"select top 1 * from [Address] where Id = {id}";

                    conn.Open();

                    using (cmd = new SqlCommand(sql, conn))
                    {
                        using (dataReader = cmd.ExecuteReader())
                        {
                            //Create a data table to hold the retrieved data.
                            dataTable = new DataTable();

                            //Load the data from SqlDataReades into the data table
                            dataTable.Load(dataReader);

                            return new Address
                            {
                                Id = (int)dataTable.Rows[0]["Id"],
                                City = (string)dataTable.Rows[0]["City"],
                                PostalCode = (string)dataTable.Rows[0]["PostalCode"],
                                Province = (string)dataTable.Rows[0]["Province"],
                                Street = (string)dataTable.Rows[0]["Street"]
                            };
                        }
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        public static DataTable SelectAllAddresses()
        {
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader dataReader;
            DataTable dataTable = null;

            using (conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    string sql = "select * from [Address]";

                    conn.Open();

                    using (cmd = new SqlCommand(sql, conn))
                    {
                        using (dataReader = cmd.ExecuteReader())
                        {
                            //Create a data table to hold the retrieved data.
                            dataTable = new DataTable();

                            //Load the data from SqlDataReades into the data table
                            dataTable.Load(dataReader);

                            return dataTable;
                        }
                    }
                }
                catch
                {
                    return dataTable;
                }
            }
        }

        public static IList<Address> SelectAllAddressesAsList(DataTable dt)
        {
            IList<Address> addressList = new List<Address>();
            foreach (DataRow dr in dt.Rows)
            {
                addressList.Add(new Address
                {
                    Id = (int)dr["Id"],
                    City = (string)dr["City"],
                    PostalCode = (string)dr["PostalCode"],
                    Province = (string)dr["Province"],
                    Street = (string)dr["Street"]
                });
            }

            return addressList;

        }

        #endregion

        #region Update Address

        public static int UpdateAddress(Address address)
        {
            SqlConnection conn;
            SqlCommand cmd;

            using (conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    //string sql = "insert into Address values (@street, @city, @province, @postalcode)";
                    string sql = $"update [Address] set Street = '{address.Street}', City = '{address.City}', Province = '{address.Province}', PostalCode = '{address.PostalCode}' where Id = {address.Id}";

                    conn.Open();

                    using (cmd = new SqlCommand(sql, conn))
                    {
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

        #endregion

        #region Delete Address

        public static int DeleteAddress(int id)
        {
            SqlConnection conn;
            SqlCommand cmd;

            using (conn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    string sql = $"delete from [Address] where Id = {id}";

                    conn.Open();

                    using (cmd = new SqlCommand(sql, conn))
                    {
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

        #endregion

    }
}