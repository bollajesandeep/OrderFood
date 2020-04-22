using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrder1.Data.Models
{
    public class Restaurent
    {
        public int RestaurentId { get; set; }
        public string RestaurentName { get; set; }
        public string ImgUrl { get; set; }
        public string ImgThumbnailUrl { get; set; }
        public string LongDescription { get; set; }
        public int Rating { get; set; }
        public bool IsOpen { get; set; }
        public string Location { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal FoodPrice { get; set; }
        public int CategoryId { get; set; }
        public virtual Food Food { get; set; }
        public virtual Category Category { get; set; }
    }
}
