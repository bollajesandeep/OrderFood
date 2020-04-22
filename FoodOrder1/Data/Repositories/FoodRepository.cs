using FoodOrder1.Data.Interfaces;
using FoodOrder1.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder1.Data.Repositories
{
    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext _appDbContext;
        public FoodRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Food> Foods => _appDbContext.Foods.Include(c => c.Category);

        public IEnumerable<Food> PreferredFoods => _appDbContext.Foods.Where(p => p.IsPreferredFood).Include(c => c.Category);

        public Food GetFoodById(int FoodId) => _appDbContext.Foods.FirstOrDefault(p => p.FoodId == FoodId);
       
    }
}
