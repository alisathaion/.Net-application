using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace A00912599Assign03
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            string path;
            StreamReader streamReader = null;
            //get filename via command line argument
            if (args.Length > 0)
            {
                path = args[0];
            }
            else
            {
                Console.WriteLine("Usage: TextFileReading invoicedata.txt");
                return;
            }

  
            if (File.Exists(path))
            {
                // Read entire file line-by-line and display to the screen.
                try
                {
                    string lineData;
                    string[] lineDataInArray;
                    ArrayList invoice = new ArrayList();
                    string[] invoiceList;
                    Stack<double> stackSUB = new Stack<double>();
                    Stack<double> stackPST = new Stack<double>();
                    Stack<double> stackDiscount = new Stack<double>();
                    streamReader = new StreamReader(path);

                    while (streamReader.Peek() > 0)
                    {
                        // Read a line at a time, printing it to the screen.
                        lineData = streamReader.ReadLine();
                        lineDataInArray = lineData.Split('|');
                 
                        for (int count = 0; count < lineDataInArray.Length; count++)
                        {
                            
                            invoiceList = lineDataInArray[count].Split(':');
                            if (invoiceList.Length <= 3)
                            {
                                //convert invoice date to format of month,day year
                                DateTime invoiceDate = DateTime.Parse(invoiceList[1].ToString());
                                string dateString = invoiceDate.ToString("MMM d,yyyy");

                                //convert first index of term to percentage in form of 2.00%
                                string percentage = invoiceList[2].ToString().Substring(0, 1);
                                double percentageDouble = double.Parse(percentage) / 100;
                                string percentageString = percentageDouble.ToString("P");
                                
                                //keep the percentage for calculate discount at the summary part
                                stackDiscount.Push(percentageDouble);

                                //calculate discount date from invoice date by adding last two index of term 
                                int discountDate = Convert.ToInt32(invoiceList[2].ToString().Substring(1, 2));
                                DateTime disDate = invoiceDate.AddDays(discountDate);
                                string strDiscount = disDate.ToString("MMM d,yyyy");

                                //concatenate string to show in terms 
                                string terms = percentageString + " " + discountDate.ToString() + " days ADI";
                              

                                invoice.Add(new Invoice
                                {
                                    InvoiceNumber = invoiceList[0]
                                                        ,
                                    InvoiceDate = dateString
                                                        ,
                                    DiscountDate = strDiscount
                                                        ,
                                    InvoiceTerm = terms
                                });
                                


                            }
                            else
                            {
                                //convert qty and price to double
                                double qtyDouble = Convert.ToDouble(invoiceList[0].ToString());
                                double priceDouble = Convert.ToDouble(invoiceList[3].ToString());
                                double ext = qtyDouble * priceDouble;
                         
                                invoice.Add(new InvoiceDetail
                                {
                                    Qty = qtyDouble
                                                              ,
                                    Sku = invoiceList[1]
                                                              ,
                                    Description = invoiceList[2]
                                                              ,
                                    Price = priceDouble
                                                              ,
                                    Pst = invoiceList[4]      
                                                              
                                   
                                });
                                if (invoiceList[4].ToString() == "Y")
                                {
                                    stackPST.Push(ext);
                                }

                                //to collect Ext value in to stack
                                stackSUB.Push(ext);
                                
                               
                                //check the last item for summary each invoice
                                if (lineDataInArray.Length == count+1)
                                {
                                    //calculate subtotal by sum of Ext
                                    double subtotal = stackSUB.Sum();
                                    //calculate GST 5% of subtotal
                                    double gst = subtotal * 0.05;
                                    //calculate PST
                                    double pst = stackPST.Sum()*0.07;
                                    //calculate total
                                    double total = subtotal + gst + pst;
                                    //calculate discount
                                    double discount = stackDiscount.Pop() * total;

                                  
                                    //Add summary to array list
                                    invoice.Add(new InvoiceSubtotal
                                    {
                                        Subtotal = subtotal
                                      , Gst = gst
                                      , Pst = pst
                                      , Total = total
                                      , Discount = discount

                                    });

                                    // clear stack for next invoice 
                                    stackSUB.Clear();
                                    stackPST.Clear();
                                    stackDiscount.Clear();
                                    

                                }


                                //use stack to collect the Ext to summary for Subtotal
                                //stack.Push(qtyDouble*priceDouble);
                            }

                        }
              

                    }

                    //out put to screen
                    Console.WriteLine("Invoice Listing");
                    Console.WriteLine(new string('-', 65));
                    foreach (var item in invoice)
                    {
                        //output for header
                        if (item.GetType().Name.ToString() == "Invoice")
                        {
                            Console.WriteLine(item);
                            Console.WriteLine(new string('-', 65));
                            Console.WriteLine($"{"Qty",-3} {"SKU",-12} {"Description", -20} {"Price", 10} {"PST", 4} {"Ext", 10}");
                            Console.WriteLine(new string('-', 65));
                        }
                        else
                        {
                            //check if it is a summary part of invoice
                            if (item.GetType().Name.ToString() == "InvoiceSubtotal")
                            {
                                Console.WriteLine(new string('-', 65));
                                Console.WriteLine(item);
                            }
                            //if it is item detail part
                            else
                            {
                                Console.WriteLine(item);
                            }

                            
                        }
                      
                    }
                   
                }

                // this block will execute if an exception is thrown in the try block
                catch (Exception ex)
                {
                    Console.WriteLine($"\n{ex.Message}\n");
                }

                // this block always executes - used for resource cleanup.
                finally
                {
                    if (streamReader != null) 
                    {                         
                        streamReader.Close(); 
                    }                         
                }                             
            }
            else
            {
                Console.WriteLine("\nFile not found.\n");
            }
            Console.ReadLine();
        }

      




    }
}
