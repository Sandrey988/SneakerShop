﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sneaker.Models
{
    public class ProductSize
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; }

        public string Name { get; set; }
        public float Number { get; set; }

        [Required]
        public int SizeId { get; set; }

        public Size Size { get; set; }
    }
}
