using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Size
    {
        [Required]
        public int SizeId { get; set; }
        [Required]
        public float Number { get; set; }
        
        public List<ProductSize> SneakerSizes { get; set;}
        
        
    }
}
