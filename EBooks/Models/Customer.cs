using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EBooks.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your full name")]
        public string CustomerName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
                   ErrorMessage = "Entered Email Address format is not valid.")]
        public string CustomerEmail { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your phone")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string CustomerPhone { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your password")]
        public string CustomerPassword { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your address")]
        public string CustomerAddress { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
