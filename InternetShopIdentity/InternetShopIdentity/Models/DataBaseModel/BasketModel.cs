using InternetShopIdentity.Models.DataBaseModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternetShop.Models
{
    public class BasketModel
    {
        //public int IDBasket { get; set; }
        //public DateTime Date { get; set; }
        //public int Count { get; set; }

        [Key]
        [ScaffoldColumn(false)]
        public int IDBasket { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Count is required")]
        public int Count { get; set; }
        //связи
        public ICollection<ProductModel> Products { get; set; }
        public ICollection<IdentityUser> Users { get; set; }
    }
}