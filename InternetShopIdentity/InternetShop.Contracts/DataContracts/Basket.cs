using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Contracts.DataContracts
{
    public class Basket
    {
        [Key]
        [ScaffoldColumn(false)]
        public int IDBasket { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Count is required")]
        public int Count { get; set; }
        //связи
        public ICollection<Product> Products { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
