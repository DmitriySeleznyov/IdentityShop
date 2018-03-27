using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShop.Contracts.DataContracts
{
    public class User
    {
        [Key]
        [ScaffoldColumn(false)]
        public int IDUser { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(30, ErrorMessage = "Must be between 5 and 30 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(30, ErrorMessage = "Must be between 5 and 30 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Patronymic is required")]
        [StringLength(50, ErrorMessage = "Must be between 5 and 50 characters", MinimumLength = 5)]
        public string Patronymic { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string Address { get; set; }
        //связи
        public Basket Baskets { get; set; }
        public Order Orders { get; set; }

    }
}
