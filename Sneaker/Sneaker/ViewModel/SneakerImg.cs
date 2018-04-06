using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sneaker.Models;

namespace Sneaker.ViewModel
{
    public class SneakerImg
    {
        public string UrlImage { get; set; }

        public IList<Models.Sneaker> Sneakers { get; set; }

        public int SelectSneaker { get; set; }
    }
}
