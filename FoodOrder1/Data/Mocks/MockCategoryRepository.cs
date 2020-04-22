using FoodOrder1.Data.Interfaces;
using FoodOrder1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder1.Data.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                     {
                         new Category { CategoryName = "Vegitarian", Description = "All Vegitarian foods" },
                         new Category { CategoryName = "Non-Vegitarian", Description = "All non-Vegitarian foods" }
                     };
            }
        }
    }
}
