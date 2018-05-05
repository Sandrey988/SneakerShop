using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Models;

namespace Sneaker.ViewModel
{
    public class ProductSizeViewModel
    {
        public List<Product> Products { get; set; }
        public int SelectProduct { get; set; }

        public List<Size> Sizes { get; set; }
        public int SelectSize { get; set; }
    }
}
