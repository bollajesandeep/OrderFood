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
    public class ShoppingCartController : Controller
    {
        private readonly IFoodRepository _foodRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IFoodRepository foodRepository, ShoppingCart shoppingCart)
        {
            _foodRepository = foodRepository;
            _shoppingCart = shoppingCart;
        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCVM = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(sCVM);
        }
        public RedirectToActionResult AddToShoppingCart(int foodId)
        {
            var selectedFood = _foodRepository.Foods.FirstOrDefault(p => p.FoodId == foodId);
            if(selectedFood!= null)
            {
                _shoppingCart.AddToCart(selectedFood, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int FoodId)
        {
            var selectedFood = _foodRepository.Foods.FirstOrDefault(p => p.FoodId == FoodId);
            if(selectedFood!=null)
            {
                _shoppingCart.RemoveFromCart(selectedFood);
            }
            return RedirectToAction("Index");
        }
    }
}

