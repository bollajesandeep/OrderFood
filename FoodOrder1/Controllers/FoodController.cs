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
    public class FoodController : Controller
    {
        private readonly IFoodRepository _foodRepository;
        private readonly ICategoryRepository _categoryRepository;

        public FoodController(IFoodRepository foodRepository, ICategoryRepository categoryRepository)
        {
            _foodRepository = foodRepository;
            _categoryRepository = categoryRepository;
        }
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Food> foods;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                foods = _foodRepository.Foods.OrderBy(p => p.FoodId);
                currentCategory = "All foods";
            }
            else
            {
                if (string.Equals("Veg", _category, StringComparison.OrdinalIgnoreCase))
                    foods = _foodRepository.Foods.Where(p => p.Category.CategoryName.Equals("Veg")).OrderBy(p => p.Name);
                else
                    foods = _foodRepository.Foods.Where(p => p.Category.CategoryName.Equals("Non-Veg")).OrderBy(p => p.Name);

                currentCategory = _category;
            }

            return View(new FoodListViewModel
            {
                Foods = foods,
                CurrentCategory = currentCategory
            });
        }
        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Food> foods;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                foods = _foodRepository.Foods.OrderBy(p => p.FoodId);
            }
            else
            {
                foods = _foodRepository.Foods.Where(p => p.Name.Contains(_searchString)|| p.ShortDescription.Contains(_searchString));
            }

            return View("~/Views/Food/List.cshtml", new FoodListViewModel { Foods = foods, CurrentCategory = "All foods" });
        }
        //Details explained
        public ViewResult Details(int foodId)
        {
            var food = _foodRepository.Foods.FirstOrDefault(d => d.FoodId == foodId);
            if (food == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(food);
        }

    }
}