﻿using FoodOrder1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder1.Data.Interfaces
{
   public interface IRestaurentRepository
    {
        IEnumerable<Restaurent> Restaurents { get; }
    }
}
