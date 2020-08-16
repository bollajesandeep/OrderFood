using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodOrder1.Data.Models;
using FoodOrder1.Data.Interfaces;
using FoodOrder1.ViewModel;

namespace FoodOrder1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFoodRepository _foodRepository;

        public HomeController(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }
        //Home page
        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PrefferedFoods = _foodRepository.PreferredFoods
            };
            return View(homeViewModel);
        }
        
       
    }
}
