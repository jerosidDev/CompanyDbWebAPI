namespace CompanyDbWebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CompanyDbWebAPI.ModelsDB.EVOYDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CompanyDbWebAPI.ModelsDB.EVOYDB context)
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

            // one off see of the table Log_Updates newly inserted in the db using code first migration
            //      there is only 31 records maximum in the table corresponding to each day of the month
            //for (int i = 1; i <= 31; i++)
            //{
            //    context.Log_Updates.AddOrUpdate(l => l.id, new ModelsDB.Log_Update() { API_call_failure = 0, BStages_Added = 0, BStages_Updated = 0, Updated_date = new DateTime(0) });
            //}

            //context.SaveChanges();



        }
    }
}
