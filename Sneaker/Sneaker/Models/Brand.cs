using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sneaker.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string BrandName { get; set; }

        [MaxLength (2000)]
        public string Description { get; set; }

        public List<Sneaker> Sneaker { get; set; }
    }
}
