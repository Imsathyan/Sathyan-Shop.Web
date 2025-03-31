using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Sathyan_Shop.Web.Data;
using Sathyan_Shop.Web.Models;

namespace Sathyan_Shop.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult create([FromBody] Category category)
        {
            _context.categories.Add(category);
            _context.SaveChanges();
            return Ok();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]

        public ActionResult get()
        {
            var get = _context.categories;
            return Ok(get);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult get(int id)
        {
            var category = _context.categories.FirstOrDefault(x => x.Id == id);
            if (category == null) { 
            return NotFound($"Category not found for the given ID -{id} ");  
            }
            return Ok(category);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpPut]


        public ActionResult Update(Category category) 
        {
            _context.categories.Update(category);
            _context.SaveChanges();
            return NoContent();
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete]

        public ActionResult Delete(int id) { 
            if (id == 0)
            {
                return BadRequest();
            }
           var category = _context.categories.FirstOrDefault(x=>x.Id == id);
            if (category == null) {
                return NotFound();
            }
            _context.categories.Remove(category);
            _context.SaveChanges();
            return NoContent();

        }

    }
}
