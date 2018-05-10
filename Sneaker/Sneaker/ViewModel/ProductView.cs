using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Models;
using System.ComponentModel.DataAnnotations;

namespace Sneaker.ViewModel
{
    public class ProductView
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int Amount { get; set; }

        public string UrlImage { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string MaterialName { get; set; }
        public float SizesProduct { get; set; }


        public List<ProductSize> Sizes { get; set; }
        public int SelectedSize { get; set; }
    }
}
