using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sneaker.Models
{
    public class Img
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }

        public int SneakerId { get; set; }
        public Sneaker Sneaker { get; set; }
    }
}
