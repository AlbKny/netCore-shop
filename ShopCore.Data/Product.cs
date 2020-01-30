using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopCore.Data
{
   public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Przekroczono Limit Znaków")]
        public string Name { get; set; }
        [Required]
        [Range(1, 10000, ErrorMessage = "Wartość {0} musi być z zakresu od {1} do {2}.")]
        public int Ammount { get; set; }
        [Required]
        [Range(10.00, 10000.00, ErrorMessage = "Wartość {0} musi być z zakresu od {1} do {2}.")]
        public double Prize { get; set; }
    }
}
