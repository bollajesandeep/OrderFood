using FoodOrder1.Data.Interfaces;
using FoodOrder1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder1.Data.Repositories
{
    public class RestaurentRepository : IRestaurentRepository
    {
        private readonly AppDbContext _appDbContext;
        public RestaurentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
       public IEnumerable<Restaurent> Restaurents => _appDbContext.Restaurents;

    }
}
