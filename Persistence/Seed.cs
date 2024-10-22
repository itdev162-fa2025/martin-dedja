using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context)
        {
            if (!context.Posts.Any())
            {
                var Posts = new List<Post>
                {
                    new Post {
                        Title = "Post 1",
                        Body = "This is the body of post 1",
                        Date = DateTime.Now.AddDays(-10)
                    },
                    new Post {
                        Title = "Post 2",
                        Body = "This is the body of post 2",
                        Date = DateTime.Now.AddDays(-7)
                    },
                    new Post {
                        Title = "Post 3",
                        Body = "This is the body of post 3",
                        Date = DateTime.Now.AddDays(-4)
                    }
                };

                context.Posts.AddRange(Posts);
                context.SaveChanges();
            }
        }
    }
}