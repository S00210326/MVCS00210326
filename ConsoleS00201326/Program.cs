using Business.DomainClasses.S00210326.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleS00201326
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
        }
        public static void  GetTransactions(Customer customer)
        {

            using (AccountsContext db = new AccountsContext())
            {

                var query1 =
                            from t in db.Transactions
                            where t.AccountID == customer.Id
                            select t;
                foreach (var item in query1)
                {
                    Console.WriteLine("Transaction {0} made by Customer {1}", item.Id, item.AccountID);
                }

            }
            



            }
            
        }

    }

