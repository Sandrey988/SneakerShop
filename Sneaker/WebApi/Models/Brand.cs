using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Brand
    {
        [Required]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string BrandName { get; set; }

        [MaxLength(2000)]
        [Required]
        public string Description { get; set; }

        public List<Sneaker> Sneaker { get; set; }

    }
}
