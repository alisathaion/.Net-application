using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Common;

namespace ClassLibrary.Data
{
    public class InvoiveRepository
    {
        private static string connString = @"Server=tcp:comp2614.database.windows.net,1433;
                                             Initial Catalog=mc1810;
                                             User ID=student;
                                             Password=93nu5#S163;
                                             Encrypt=True;
                                             TrustServerCertificate=False;
                                             Connection Timeout=30;";

        public static InvoiceCollection GetInvoice()
        {
            InvoiceCollection invoices;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT DetailId, Quantity, Sku, Description, Price, Taxable
                                 FROM InvoiceDetail
                                 ORDER BY Sku";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;

                    conn.Open();

                    invoices = new InvoiceCollection();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int detailId;
                        int quantity;
                        string sku;
                        string description;
                        decimal price;
                        bool taxable;

                        while (reader.Read())
                        {
                            detailId = (int)reader["DetailId"];
                            quantity = (int)reader["Quantity"];
                            sku = reader["Sku"] as string;

                            if (!reader.IsDBNull(3))
                            {
                                description = reader["Description"] as string;
                            }
                            else
                            {
                                description = null;
                            }

                            price = (decimal)reader["Price"];
                            
                            if (!reader.IsDBNull(5))
                            {
                                taxable = (bool)reader["Taxable"];
                            }
                            else
                            {
                                taxable = false;
                            }

                            invoices.Add(new Invoice
                            {
                                DetailId = detailId
                               ,
                                Quantity = quantity
                               ,
                                Sku = sku
                               ,
                                Description = description
                               ,
                                Price = price
                               ,
                                Taxable = taxable
                            });
                        }
                    }

                    return invoices;
                }
            }
        }

        

        public static TaxCollection GetTaxRate()
        {
            TaxCollection taxes;

            //connect to database
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //query to retrieve data from Province table 
                string query = @"SELECT TaxCode, TaxRate
                                 From TaxTable";
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    conn.Open();

                    taxes = new TaxCollection();
                    //read data
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        string taxCode = null;
                        decimal taxRate = 0.00m;

                        while (reader.Read())
                        {
                            taxCode = reader["TaxCode"] as string;
                            taxRate = (decimal)reader["TaxRate"];

                            taxes.Add(new TaxRateTable { Taxcode = taxCode, TaxRate = taxRate });

                        }
                        return taxes;
                    }
                }
            }
        }
    }
}
