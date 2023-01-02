namespace Business.DomainClasses.S00210326.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Business.DomainClasses.S00210326.Models.AccountsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Business.DomainClasses.S00210326.Models.AccountsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            addData(context);
            context.SaveChanges();
        }
       
        private static void addData(Models.AccountsContext context)
        {
            context.Customers.AddOrUpdate(c => c.Id, new Models.Customer[]
            {
               new Models.Customer() { Id = 1, Name = "Customer1", Address = "Address for Customer 1" },
               new Models.Customer(){Id = 2, Name = "Customer2", Address = "Address for C 2" },
                new Models.Customer(){Id = 3, Name = "Customer3", Address = "Address for C 3" },


            });
            context.AccountTypes.AddOrUpdate(a => a.Id, new Models.AccountType[]
            {
                new Models.AccountType(){Id = 1, TypeName = "Current", Conditions =  "Current Account Terms and Conditions Apply"},
                 new Models.AccountType(){Id = 2, TypeName = "Savings", Conditions =  "Current Account Terms and Conditions Apply"},
                  new Models.AccountType(){Id = 3, TypeName = "Deposit", Conditions =  "Current Account Terms and Conditions Apply"},

            });
            context.Accounts.AddOrUpdate(a => a.Id, new Models.Account[]
            {
                new Models.Account(){Id = 1, AccountName = "Current1", InceptionDate =  new DateTime(day:25, month:01, year:2002), CustomerID = 1, CurrentBalance = 300000, AccountTypeID = 1 },
                 new Models.Account(){Id = 2, AccountName = "Current2", InceptionDate =  new DateTime(day:25, month:01, year:2004), CustomerID = 1, CurrentBalance = 200000, AccountTypeID = 1 },
                  new Models.Account(){Id = 3, AccountName = "Depost1", InceptionDate =  new DateTime(day:25, month:01, year:2014), CustomerID = 2, CurrentBalance = 100000, AccountTypeID = 3 },
                   new Models.Account(){Id = 4, AccountName = "Deposit1", InceptionDate =  new DateTime(day:25, month:01, year:2011), CustomerID = 1, CurrentBalance = 500000, AccountTypeID = 3 },
                    new Models.Account(){Id = 5, AccountName = "Savings1", InceptionDate =  new DateTime(day:25, month:01, year:2010), CustomerID = 2, CurrentBalance = 3000, AccountTypeID = 2},
                     new Models.Account(){Id = 6, AccountName = "Current1", InceptionDate =  new DateTime(day:25, month:01, year:2004), CustomerID = 3, CurrentBalance = 10000, AccountTypeID = 1 },
            });
            context.Transactions.AddOrUpdate(t => t.Id, new Models.Transactions[]
            {
                new Models.Transactions() { Id = 1, TransactionType = 0, Ammount = 300, TransactionDate =  new DateTime(day:25, month:01, year:2002) , AccountID = 1},
                new Models.Transactions() { Id = 2, TransactionType = 1, Ammount = 500, TransactionDate =  new DateTime(day:14, month:01, year:2002) , AccountID = 1},
                 new Models.Transactions() { Id = 3, TransactionType = 1, Ammount = 300, TransactionDate =  new DateTime(day:25, month:01, year:2004) , AccountID = 2},
                  new Models.Transactions() { Id = 4, TransactionType = 0, Ammount = 200, TransactionDate =  new DateTime(day:25, month:01, year:2014) , AccountID = 3},
                   new Models.Transactions() { Id = 5, TransactionType = 0, Ammount = 1000, TransactionDate =  new DateTime(day:25, month:01, year:2011) , AccountID =4},
                    new Models.Transactions() { Id = 6, TransactionType = 1, Ammount = 1000, TransactionDate =  new DateTime(day:25, month:01, year:2010) , AccountID = 5},
                     new Models.Transactions() { Id = 7, TransactionType = 1, Ammount = 1000, TransactionDate =  new DateTime(day:25, month:01, year:2004) , AccountID = 6} }
                );
            context.SaveChanges();
        }
        //private static void addData(Models.HealthContext context)
        //{
        //    context.Doctors.AddOrUpdate(p => p.DoctorDSS, new Doctor[]
        //    {
        //        new Doctor{DoctorDSS = 1, Name = "Mr Martin O'Donell", Specialization = "Paediatrics", EmailAddress ="modonell@SUH.ie"},
        //         new Doctor{DoctorDSS = 2, Name = "Dr John Rodman", Specialization = "Geriatrics", EmailAddress ="jrodman@SUH.ie"},
        //          new Doctor{DoctorDSS = 3, Name = "Dr Bernard Tham", Specialization = "Infectious Diseases", EmailAddress ="btham@SUH.ie"},
        //           new Doctor{DoctorDSS = 4, Name = "Dr Elizabeth Anderson", Specialization = "Intensive Care", EmailAddress ="eanderson@SUH.ie"},
        //            new Doctor{DoctorDSS = 5, Name = "Dr Madeleine Kelley", Specialization = "Brain Trauma", EmailAddress ="mkelley@SUH.ie"},
        //             new Doctor{DoctorDSS = 6, Name = "Mr Mikael Sandberg", Specialization = "Geriatrics", EmailAddress ="msandberg@SUH.ie"},


        //    });
        //    DateTime basedate = new DateTime(year: 2019, month: 12, day: 9);
        //    DateTime basedate2 = new DateTime(year: 2021, month: 12, day: 9);
        //    Random r = new Random();
        //    CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-IE");
        //    context.Patients.AddOrUpdate(p => p.PatientID, new Patient[]
        //    {
        //        new Patient{PatientID = 1, DoctorDSS = 2, patientName = "Elizabeth Anderson", insuranceType = "VHI", dateAdded = basedate.AddDays(r.Next(5,15)), dateCheckedOut = basedate2.AddDays(r.Next(5,15))}
        //        ,new Patient{PatientID = 2, DoctorDSS = 1, patientName = "Catherine Autier Miconi", insuranceType = "VHI", dateAdded = basedate.AddDays(r.Next(5,15)), dateCheckedOut = basedate2.AddDays(r.Next(5,15))}
        //        ,new Patient{PatientID = 3, DoctorDSS = 3, patientName = "Thomas Axen", insuranceType = "BUPA", dateAdded = basedate.AddDays(r.Next(5,15)), dateCheckedOut = basedate2.AddDays(r.Next(5,15))}
        //        ,new Patient{PatientID = 4, DoctorDSS = 2, patientName = "Jean Philippe Bagel", insuranceType = "Public", dateAdded = basedate.AddDays(r.Next(5,15)), dateCheckedOut = basedate2.AddDays(r.Next(5,15))}
        //        ,new Patient{PatientID = 5, DoctorDSS = 4, patientName = "Anna Bedecs", insuranceType = "BUPA", dateAdded = basedate.AddDays(r.Next(5,15)), dateCheckedOut = basedate2.AddDays(r.Next(5,15))}
        //        ,new Patient{PatientID = 6, DoctorDSS = 5, patientName = "John Edwards", insuranceType = "VHI", dateAdded = basedate.AddDays(r.Next(5,15)), dateCheckedOut = basedate2.AddDays(r.Next(5,15))}
        //        ,new Patient{PatientID = 7, DoctorDSS = 6, patientName = "Alexander Eggerer", insuranceType = "Public", dateAdded = basedate.AddDays(r.Next(5,15)), dateCheckedOut = basedate2.AddDays(r.Next(5,15))}

        //    });
        //    context.SaveChanges();
        //}
    }
}
