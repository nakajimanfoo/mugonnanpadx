namespace mugonnanpadx.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using mugonnanpadx.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<mugonnanpadx.Models.MugonDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(mugonnanpadx.Models.MugonDBContext context)
        {

            context.MugonMessages.AddOrUpdate(i => i.Message,
                new MugonMessage

                {
                    Message = "‚¤‚¤‚¤‚¤‚¤",
                    Yes = 0,
                    //ChangeDate = DateTime.Parse("2016-05-18")

                }
                

                );
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
        }
    }
}
