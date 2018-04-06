using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sneaker.Models
{
    public class Sneaker
    {
        public int SneakerId { get; set; }

        [MaxLength(50)]
        public string SneakerName { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }
        
        public List<Img> Img { get; set; }
        public List<Product> Products { get; set; }
    }
}
