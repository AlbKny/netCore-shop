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
        public string Name { get; set; }
        public int Ammount { get; set; }
        [DataType(DataType.Currency)]
        //[Range(00.00, 10000.00)]
        public decimal Price { get; set; }
    }
}
