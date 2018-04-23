using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteDotNet.Data.Models;

namespace TesteDotNet.Data
{
    public static class DbInitializer
    {
        public static void Initialize(Data.Context.DataContext context)
        {
            context.Database.EnsureCreated();

           
            if (context.Categories.Any())
            {
                return;   
            }

            var Categories = new Category[]
            {
                new Category{CategoryName="Categoria 1"},
                new Category{CategoryName="Categoria 2"},
                new Category{CategoryName="Categoria 3"}
            };

            foreach (Category c in Categories)
            {
                context.Categories.Add(c);
            }

            context.SaveChanges();

        }
    }
}
