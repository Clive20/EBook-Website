using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EBooks.Models
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public int CategoryId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the category")]
        [DisplayName("Book Genre")]
        public string CategoryName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
