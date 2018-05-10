using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sneaker.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        
        public string UrlImage { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


    }
}
