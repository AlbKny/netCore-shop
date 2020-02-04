using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ShopCore.Data;
namespace ShopCore.Models
{
    
    public class ProductModel
    {
        public int Id { get; set; }
        [StringLength(30,ErrorMessage ="Przekroczono limit znaków")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Ilość")]
        public int Ammount { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }
    }
}
