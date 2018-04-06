using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sneaker.Models
{
    public class Size
    {
        public int SizeId { get; set; }
        public float Number { get; set; }
        
        public List<ProductSize> SneakerSizes { get; set;}
        
        
    }
}
