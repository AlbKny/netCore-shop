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
        public string Name { get; set; }
        public int Ammount { get; set; }
        public decimal Price { get; set; }
    }
}
