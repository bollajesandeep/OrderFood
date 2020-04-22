using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrder1.Data.Interfaces;
using FoodOrder1.Data.Models;
using FoodOrder1.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrder1.Controllers
{
    public class RestaurentController : Controller
    {
        private readonly IRestaurentRepository _restaurentRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RestaurentController(IRestaurentRepository restaurentRepository, ICategoryRepository categoryRepository)
        {
            _restaurentRepository = restaurentRepository;
            _categoryRepository = categoryRepository;
        }
     
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Restaurent> restaurents;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                restaurents = _restaurentRepository.Restaurents.OrderBy(p => p.RestaurentId);
                currentCategory = "All restaurents";
            }
            else
            {
                if (string.Equals("Veg", _category, StringComparison.OrdinalIgnoreCase))
                   restaurents = _restaurentRepository.Restaurents.Where(p => p.Category.CategoryName.Equals("Veg")).OrderBy(p => p.RestaurentName);
                else
                  restaurents = _restaurentRepository.Restaurents.Where(p => p.Category.CategoryName.Equals("Non-Veg")).OrderBy(p => p.RestaurentName);
                
                currentCategory = _category;
            }
            return View(new RestaurentListViewModel
            {
               Restaurents = restaurents,
                CurrentCategory = currentCategory
            });
        }

    }
}