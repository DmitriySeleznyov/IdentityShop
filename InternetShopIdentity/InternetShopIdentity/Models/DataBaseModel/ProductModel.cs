using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternetShop.Models
{
    public class ProductModel
    {
        //public int IDProduct { get; set; }
        //public string Name { get; set; }
        //public int Count { get; set; }
        //public double Price { get; set; }
        [Key]
        [ScaffoldColumn(false)]
        public int IDProduct { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(150, ErrorMessage = "Must be between 10 and 150 characters", MinimumLength = 10)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Count is required")]
        [Range(0, 999)]
        public int Count { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        public double Price { get; set; }

        //связи
        public BasketModel Baskets { get; set; }
        public OrderModel Orders { get; set; }

    }
}