using FoodOrder1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder1.ViewModel
{
    public class RestaurentListViewModel
    {
        public IEnumerable<Restaurent> Restaurents { get; set; }
        public string CurrentCategory { get; set; }
    }
}
