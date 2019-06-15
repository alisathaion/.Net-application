using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLibrary.Common;

namespace BusinessLibrary.Data
{
    public class CustomerRepository
    {
        //Set Database Connection
        private static string connString = @"Server=tcp:comp2614.database.windows.net,1433; 
                                             Initial Catalog=mc1810;
                                             User ID=student;
                                             Password=93nu5#S163;
                                             Encrypt=True;
                                             TrustServerCertificate=False;
                                             Connection Timeout=30;";

        //Read Data from Table
        public static CustomerCollection GetCustomer()
        {
            CustomerCollection customers;

            //connect to database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //query to retrieve data from client table 
                string query = @"SELECT *
                                 From Client912599";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    conn.Open();
                    customers = new CustomerCollection();

                    //read data
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string clientCode = null;
                        string companyName = null;
                        string address1 = null;
                        string address2 = null;
                        string city = null;
                        string province = null;
                        string postalCode = null;
                        decimal ytdSale = 0m;
                        bool creditHold = false;
                        string notes = null;

                        while (reader.Read())
                        {
                            //get clientCode which can't be NULL from database setting 
                            clientCode = reader["ClientCode"] as string;
                            //get CompanyName which can't be NULL from database setting 
                            companyName = reader["CompanyName"] as string;
                            //get Address1 which can't be NULL from database setting 
                            address1 = reader["Address1"] as string;
                            //get Address2
                            if (!reader.IsDBNull(3))
                            {
                                address2 = reader["Address2"] as string;
                            }
                            //get City
                            if (!reader.IsDBNull(4))
                            {
                                city = reader["City"] as string;
                            }
                            //get Province which can't be NULL from database setting 
                            province = reader["Province"] as string;
                            //get PostalCode
                            if (!reader.IsDBNull(6))
                            {
                                postalCode = reader["PostalCode"] as string;
                            }
                            //get YTDSales 
                            if (!reader.IsDBNull(7))
                            {
                                ytdSale = (decimal)reader["YTDSales"];
                            }
                            //get CreditHold
                            if (!reader.IsDBNull(8))
                            {
                                creditHold = (bool)reader["CreditHold"];

                            }
                            //get Notes
                            if (!reader.IsDBNull(9))
                            {
                                notes = reader["Notes"] as string;
                            }

                            //Add data to customer list
                            customers.Add(new Customer(clientCode, companyName, address1, address2, city, province, postalCode, ytdSale, creditHold, notes));

                            //Clear all data
                            clientCode = null;
                            companyName = null;
                            address1 = null;
                            address2 = null;
                            city = null;
                            province = null;
                            postalCode = null;
                            creditHold = false;
                            ytdSale = 0m;
                            notes = null;
                        }

                    }
                    return customers;
                }
            }

        }

        //Create Table into database
        public static bool CreateTable(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    //set query to create table into database
                    string query = @"CREATE TABLE "+ tableName + @"
                                (
                                 ClientCode nchar(5) NOT NULL PRIMARY KEY,
                                 CompanyName nvarchar(40) NOT NULL,
                                 Address1 nvarchar(60) NOT NULL,
                                 Address2 nvarchar(60),
                                 City nvarchar(20),
                                 Province nvarchar(10) NOT NULL,
                                 PostalCode nvarchar(10),
                                 YTDSales decimal(18,2) NOT NULL,
                                 CreditHold bit NOT NULL,
                                 Notes nvarchar(4000),
                                 )";
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Data Access Error\n\n{ex.Message}\n\n{ex.StackTrace}");
                }

            }
            return false;
        }

        //Add records to a data table
        public static int AddCustomer(Customer customer,string tableName)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"INSERT INTO "+ tableName +
                               @"(ClientCode, CompanyName, Address1, Address2, City, Province, PostalCode , YTDSales, CreditHold, Notes)
                               VALUES (@ClientCode, @CompanyName, @Address1, @Address2, @City, @Province, @PostalCode, @YTDSales, @CreditHold, @Notes)";


                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@ClientCode", customer.ClientCode);
                    cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                    cmd.Parameters.AddWithValue("@Address1", customer.Address1);
                    if (customer.Address2 != null && customer.Address2 != "")
                    {
                        cmd.Parameters.AddWithValue("@Address2", customer.Address2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Address2", DBNull.Value);
                    }
                    if (customer.City != null && customer.City != "")
                    {
                        cmd.Parameters.AddWithValue("@City", customer.City);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@City", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@Province", customer.Province);
                    if (customer.PostalCode != null && customer.PostalCode != "")
                    {
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PostalCode", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@YTDSales", customer.YTDSale);
                    cmd.Parameters.AddWithValue("@CreditHold", customer.CreditHold);
                    if (customer.Notes != null && customer.PostalCode != "")
                    {
                        cmd.Parameters.AddWithValue("@Notes", customer.Notes);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                    }

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        //Update records to a data table
        public static int UpdateCustomer(Customer customer, string tableName)
        { 
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"UPDATE " + tableName +
                               @" SET CompanyName = @CompanyName
                                   , Address1 = @Address1
                                   , Address2 = @Address2
                                   , City = @City
                                   , Province = @Province
                                   , PostalCode = @PostalCode
                                   , YTDSales = @YTDSales
                                   , CreditHold = @CreditHold
                                   , Notes = @Notes
                                 WHERE ClientCode = @ClientCode";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                    cmd.Parameters.AddWithValue("@Address1", customer.Address1);

                    if (customer.Address2 != null && customer.Address2 != "")
                    {
                        cmd.Parameters.AddWithValue("@Address2", customer.Address2);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Address2", DBNull.Value);
                    }
                    if (customer.City != null && customer.City != "")
                    {
                        cmd.Parameters.AddWithValue("@City", customer.City);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@City", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@Province", customer.Province);
                    if (customer.PostalCode != null && customer.PostalCode != "")
                    {
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@PostalCode", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@YTDSales", customer.YTDSale);
                    cmd.Parameters.AddWithValue("@CreditHold", customer.CreditHold);
                    if (customer.Notes != null && customer.Notes != "")
                    {
                        cmd.Parameters.AddWithValue("@Notes", customer.Notes);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Notes", DBNull.Value);
                    }
                    cmd.Parameters.AddWithValue("@ClientCode", customer.ClientCode);

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        //Delate records from table
        public static int DeleteCustomer(Customer customer, string tableName)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"DELETE "+ tableName +
                               @" WHERE ClientCode = @ClientCode";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@ClientCode", customer.ClientCode);

                    conn.Open();

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }

        //Get a province abbreviation from province table for comboBoxProvince
        public static List<string> GetProvince()
        {
            List<string> province = new List<string>();

            //connect to database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //query to retrieve data from Province table 
                string query = @"SELECT Abbreviation
                                 From Province";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    conn.Open();

                    //read data
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string abbreviation = null;
                        while (reader.Read())
                        {
                            abbreviation = reader["Abbreviation"] as string;
                            province.Add(abbreviation);
                            abbreviation = null;
                        }
                    }
                    return province;
                }
            }
        }


    }
}
