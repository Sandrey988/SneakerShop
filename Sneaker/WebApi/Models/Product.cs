﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [MaxLength(50)]
        public string ProductName { get; set; }
        
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public int SneakerId { get; set; }

        public Sneaker Sneaker { get; set; }

        public List<ProductSize> SneakerSizes { get; set; }
    }
}
