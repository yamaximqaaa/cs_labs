using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_7_5_lab
{
    class Program
    {
        static void Main(string[] args)
        {
             var init = new CreateDatabaseIfNotExists<ProductDBContext>();

             using (var context = new ProductDBContext())
             {
                 init.InitializeDatabase(context);

                 // Use transaction for operations, where you need to change data in several tables

                 // 9) Add data to database
                 // use method Add() of every element of context for instances with data
                 // for example, context.Products.Add(pr);
                 // where 'pr' - instance of class product

                  context.SaveChanges();

                 // Advanced:
                 // 10) export data to XML and JSON

                 // 11) implort data from XML and JSON

                 
             }
        }
    }
}
