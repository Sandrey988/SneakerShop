using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Models;

namespace Sneaker.ViewModel
{
    public class ProductSneaker
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public IList<Models.Sneaker> Sneakers { get; set; }
        
        public int SelectSneaker { get; set; }
    }
}
