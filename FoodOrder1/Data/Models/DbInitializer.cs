
using FoodOrder1.Data;
using FoodOrder1.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrder1.Data.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context =
                applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Foods.Any())
            {
                context.AddRange
                (
                    new Food
                    {
                        Name = "Biryani",
                        Price = 120,
                        ShortDescription = "A Rich and Flavorful Layered Indian Dish",
                        LongDescription = "Long-grained rice (like basmati) flavored with exotic spices, such as saffron, is layered with lamb, chicken, fish, or vegetables, and a thick gravy.",
                        Category = Categories["Non-Veg"],
                        ImageUrl = "Biryani.jpg",
                        InStock = true,
                        IsPreferredFood = true,
                        ImageThumbnailUrl = "Biryani.jpg"
                    },
                    new Food
                    {
                        Name = "Gobi",
                        Price = 100,
                        ShortDescription = "Popular Indo Chinese appetizer",
                        LongDescription = "Gobi Manchurian is a popular Indo Chinese appetizer made with cauliflower, corn flour, soya sauce, vinegar, chilli sauce, ginger & garlic. To make gobi manchurian, cauliflower is first coated in batter & then deep fried until crisp",
                        Category = Categories["Veg"],
                        ImageUrl = "Gobi.jpg",
                        InStock = true,
                        IsPreferredFood = false,
                        ImageThumbnailUrl = "Gobi.jpg"
                    },
                    new Food
                    {
                        Name = "Brown Betty",
                        Price = 90,
                        ShortDescription = "Brown Betty is a traditional American dessert",
                        LongDescription = "A Brown Betty is a traditional American dessert made from fruit and sweetened crumbs. Similar to a cobbler or apple crisp, the fruit is baked, and, in this case, the sweetened crumbs are placed in layers between the fruit.",
                        Category = Categories["Veg"],
                        ImageUrl = "BrownBetty.jpg",
                        InStock = true,
                        IsPreferredFood = false,
                        ImageThumbnailUrl = "BrownBetty.jpg"
                    }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Veg", Description="All veg foods" },
                        new Category { CategoryName = "Non-Veg", Description="All non-veg foods" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}