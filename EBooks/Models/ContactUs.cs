using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EBooks.Models
{
    public class ContactUs
    {
        [Key]
        public int ContactUsId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your Full Name")]
        [DisplayName("Full Name")]
        public string CuName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
                   ErrorMessage = "Entered Email Address format is not valid.")]
        public string CuEmail { get; set; }

        [MaxLength(1000, ErrorMessage = "The Message is too long")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the Message")]
        public string Message { get; set; }
    }
}
