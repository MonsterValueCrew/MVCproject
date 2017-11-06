using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using MonsterValueCrew.Data;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MonsterValueCrew.Data.Migrations
{
   

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            if (!context.Roles.Any())
            {
                var role = context.Roles.Add(new IdentityRole("Admin"));
                context.SaveChanges();
            }
        }
    }
}
