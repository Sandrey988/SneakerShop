using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Context;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("admin/[controller]")]
    public class BrandsController : Controller
    {
        private readonly ModelContext db;

        public BrandsController(ModelContext modelContext )
        {
            db = modelContext;
        }

        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return db.Brands.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Brand brand = db.Brands.FirstOrDefault(x => x.Id == id);
            if (brand == null)
                return NotFound();
            return new ObjectResult(brand);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Brand brand)
        {
            if (brand == null)
            {
                return BadRequest();
            }
            db.Brands.Add(brand);
            db.SaveChanges();
            return Ok(brand);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
