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
        [Required]
        public string SneakerName { get; set; }

        [MaxLength(2000)]
        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        [Required]
        public int MaterialId { get; set; }
        public Material Material { get; set; }
        
        public List<Img> Img { get; set; }
    }
}
