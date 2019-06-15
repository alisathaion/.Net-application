using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A00912599Assign04
{
    class CustomerRepository
    {
        //set path for database
        private static string connString = @"Server=tcp:comp2614.database.windows.net,1433; 
                                             Initial Catalog=mc1810;
                                             User ID=student;
                                             Password=93nu5#S163;
                                             Encrypt=True;
                                             TrustServerCertificate=False;
                                             Connection Timeout=30;";

        //get all province from customer database
        public static ProvinceCollection GetProvince()
        {
            ProvinceCollection customerProvince;
            //connect to database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //query to retrieve Provice from Customer table 
                string query = @"SELECT Province
                                 From Customer 
                                 GROUP BY province WITH ROLLUP";

                using (SqlCommand cmd = new SqlCommand())
                {
                    
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    conn.Open();
                    customerProvince = new ProvinceCollection();
                    
                    //read data
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string provinceName = null;
                           
                                if (!reader.IsDBNull(0))
                                {
                                    provinceName = reader["Province"] as string;
                                    
                                }
                                else
                                {
                                    provinceName = "ALL";
                                }
                                customerProvince.Add(new Province(provinceName));
                            
                            provinceName = null;
                        }
                    }
                    return customerProvince;
                }
            }
        }

        //get customer data filter by province that input from user
        public static CustomerCollection GetCustomerByProvince(string provinceFilter)
        {
            CustomerCollection customers;
            //connect database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query;
                //query to retrieve ALL data from customer table
                if (provinceFilter == "ALL")
                {
                    query = @"SELECT CompanyName, City, Province, PostalCode, CreditHold
                                 From Customer
                                 ORDER BY CompanyName";
                }
                //query to retrieve data from customer table with province filter
                else
                {
                    query = @"SELECT CompanyName, City, Province, PostalCode, CreditHold
                                 From Customer
                                 WHERE Province = @province
                                 ORDER BY CompanyName";
                }
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    cmd.Parameters.AddWithValue("@province", provinceFilter);
                    conn.Open();
                    customers = new CustomerCollection();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string customerName = null;
                        string city = null;
                        string province = null;
                        string postalCode = null;
                        string creditHold = null;

                        while (reader.Read())
                        {
                            //get CompanyName which can't be NULL from database setting 
                            customerName = reader["CompanyName"] as string;

                            //get City
                            if (!reader.IsDBNull(1))
                            {
                                city = reader["City"] as string;
                            }
                            //get Province
                            if (!reader.IsDBNull(2))
                            {
                                province = reader["Province"] as string;
                            }
                            //get PostalCode
                            if (!reader.IsDBNull(3))
                            {
                                postalCode = reader["PostalCode"] as string;
                            }
                            //get CreditHold
                            if (!reader.IsDBNull(4))
                            {
                                bool boolCredit = (bool)reader["CreditHold"];
                           
                                if (boolCredit == true)
                                {
                                    creditHold = "Y";
                                }
                                else
                                {
                                    creditHold = "N";
                                }
                            }
                            //Incase CreditHold is NULL
                            if (reader.IsDBNull(4))
                            {
                                creditHold = "N";
                            }
                            //Add data to customers list
                            customers.Add(new Customer(customerName, city, province, postalCode, creditHold));


                            customerName = null;
                            city = null;
                            province = null;
                            postalCode = null;
                            creditHold = null;
                        }
                    }

                    return customers;
                }
            }
        
        }
    }
}
