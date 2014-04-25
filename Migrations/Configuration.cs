using System.Collections.Generic;
using MvcRouting.Models;

namespace MvcRouting.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcRouting.Models.MvcRoutingDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MvcRouting.Models.MvcRoutingDBContext context)
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

            context.Restaurants.AddOrUpdate(
                r => r.Name,
                new Restaurant { Name = "Bhater hotel", City = "Dhaka", Country = "Bangladesh", },
                new Restaurant { Name = "Bhola bhai", City = "Dhaka", Country = "Bangladesh", },
                new Restaurant { Name = "Al Rahmaniya", City = "Dhaka", Country = "Bangladesh", },
                new Restaurant { Name = "CTG hotel1", City = "CTG", Country = "Bangladesh", },
                new Restaurant { Name = "Sylhet hotel1", City = "Sylhet", Country = "Bangladesh", },
                new Restaurant
                {
                    Name = "panta hotel",
                    City = "Rajshahi",
                    Country = "BD",
                    Reviews = new List<RestaurantReview>
                    {
                        new RestaurantReview
                        {
                            Rating = 9,
                            Body = "Great food"
                        }
                    }
                },

                new Restaurant
                {
                    Name = "polao hotel",
                    City = "Khulna",
                    Country = "BD",
                    Reviews = new List<RestaurantReview>
                    {
                        new RestaurantReview
                        {
                            Rating = 10,
                            Body = "Great food"
                        }
                    }
                }
                );

            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(
                    r => r.Name,
                    new Restaurant { Name = i.ToString(), City = "Dhaka", Country = "Bangladesh"}
                    );
            }
        }
    }
}
