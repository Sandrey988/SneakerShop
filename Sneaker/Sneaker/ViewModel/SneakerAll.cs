using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Models;

namespace Sneaker.ViewModel
{
    public class SneakerAll
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Descriptions { get; set; }

        public IList<Category> Categories { get; set; }
        public IList<Material> Materials { get; set; }
        public IList<Brand> Brands { get; set; }

        public int SelectedCategory { get; set; }
        public int SelectedMaterial { get; set; }
        public int SelectedBrand { get; set; }
    }
}
