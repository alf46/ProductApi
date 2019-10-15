using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            _context.Entry(product).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<Product> productPatch)
        {
            ActionResult result = BadRequest();

            if (productPatch != null)
            {
                var productDb = await _context.Products.FindAsync(id);

                productPatch.ApplyTo(productDb, ModelState);

                if (TryValidateModel(productDb))
                {
                    await _context.SaveChangesAsync();
                    result = Ok();
                }
            }

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productDb = await _context.Products.FindAsync(id);

            if (productDb == null)
                return NotFound();

            _context.Entry(productDb).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}