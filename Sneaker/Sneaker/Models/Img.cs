using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sneaker.Models
{
    public class Img
    {
        public int Id { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        [Required]
        public int SneakerId { get; set; }
        public Sneaker Sneaker { get; set; }
    }
}
