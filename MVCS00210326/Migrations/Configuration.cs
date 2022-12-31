namespace MVCS00210326.Migrations
{
    using Business.DomainClasses.S00210326.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCS00210326.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<MVCS00210326.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCS00210326.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var manager =
            new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            context.Roles.AddOrUpdate(r => r.Name,
               new IdentityRole { Name = "Branch Manager" }
               );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Data Clerk" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Customer" }
                );
            PasswordHasher ps = new PasswordHasher();

            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    EntityID = "Bank Manager",
                    UserName = "bob.manager@bob.com",
                    Email = "bob.manager@bob.com",


                    SecurityStamp = Guid.NewGuid().ToString(),

                    PasswordHash = ps.HashPassword("TheBoss$1")
                });
            Seed_Applications_Customers(manager, context);

            ApplicationUser admin = manager.FindByEmail("bob.manager@bob.com");
            if (admin != null)
            {
                manager.AddToRoles(admin.Id, new string[] { "Branch Manager" });
            }
        }

        private void Seed_Applications_Customers(UserManager<ApplicationUser> manager, ApplicationDbContext context)
        {

            using (AccountsContext ac = new AccountsContext())
            {
                foreach (Customer customer in ac.Customers)
                {
                    //IdentityResult result = manager.Create(new ApplicationUser
                    //{
                    //    EmailConfirmed = true,
                    //    EntityID = c.Id.ToString(),
                    //    UserName = c.Name,
                    //    Email = c.Id + "@itsligo.ie",







                    //    SecurityStamp = Guid.NewGuid().ToString(),
                    //}, "TheCustomer$1");
                    //if (result.Succeeded)
                    //{
                    //    ApplicationUser Customer = manager.FindByEmail(c.Id + "@itsligo.ie");
                    //    if (Customer != null)
                    //    {
                    //        manager.AddToRoles(Customer.Id, new string[] { "Customer" });
                    //    }
                    //    else
                    //    {
                    //        throw new Exception("tthrowing");


                    //    }
                    //}



                    //    //    }
                    //    //    //Take one member from each list of club members and make him club admin
                    //    //    //foreach (Club c in cx.Clubs)
                    //    //    //{
                    //    //    //    Member adminMember = c.clubMembers.FirstOrDefault(m => m.MemberID == c.adminID);

                    //    //    //    ApplicationUser clubAdmin = manager.FindByEmail(adminMember.StudentID + "@itsligo.ie");
                    //    //    //    if (clubAdmin != null)
                    //    //    //    {
                    //    //    //        manager.AddToRoles(clubAdmin.Id, new string[] { "ClubAdmin" });
                    //    //    //    }

                    //    //    //}





                    //}


                }

            }
            }
    }
}
