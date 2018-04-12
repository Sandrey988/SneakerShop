using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Models;

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
        

        public IList<Size> Sizes { get; set; }
        public float SelectedSize { get; set; }

       

    }
}
