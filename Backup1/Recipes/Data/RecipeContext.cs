using System;
using System.Data.Entity;
using Recipes.Models;

namespace Recipes.Data
{
    public class RecipeContext : DbContext
    {
        public RecipeContext() :base()
        {
        }
        //public MySql.Data.MySqlConnection connection = new 
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Utensil> Utensils { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Recipe>().ToTable("Recipe");
        //    modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
        //    modelBuilder.Entity<Utensil>().ToTable("Utensil");
        //}
    }
}
