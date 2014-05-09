namespace WebRole1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebRole1.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebRole1.Models.InterviewLoopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebRole1.Models.InterviewLoopContext";
        }

        protected override void Seed(WebRole1.Models.InterviewLoopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Companies.AddOrUpdate(
                p => p.Name,
                new Company { Name="company1" },
                new Company { Name="company2" }
                );
        }
    }
}
