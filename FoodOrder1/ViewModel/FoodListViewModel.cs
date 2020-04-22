using FoodOrder1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder1.ViewModel
{
    public class FoodListViewModel
    {
        public IEnumerable<Food> Foods { get; set; }
        public string CurrentCategory { get; set; }
    }
}
