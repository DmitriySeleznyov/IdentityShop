using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Contracts.DataContracts
{
    public class Order
    {
        [Key]
        [ScaffoldColumn(false)]
        public int IDOrder { get; set; }

        [Required(ErrorMessage = "Count is required")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        //связи
        public ICollection<Product> Products { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
