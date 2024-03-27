using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Grampzz.Server.DbContexts;
using Grampzz.Server.Models;

namespace Grampzz.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Pizzas1Controller : ControllerBase
    {
        private readonly PizzaDbContext _context;

        public Pizzas1Controller(PizzaDbContext context)
        {
            _context = context;
        }

        // GET: api/Pizzas1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> Getpizzas()
        {
            var pizzas = await _context.pizzas.ToListAsync();
            return Ok(pizzas);
        }

        // GET: api/Pizzas1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id)
        {
            var pizza = await _context.pizzas.FindAsync(id);

            if (pizza == null)
            {
                return NotFound();
            }

            return pizza;
        }

        // PUT: api/Pizzas1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizza(int id, Pizza pizza)
        {
            if (id != pizza.Id)
            {
                return BadRequest();
            }

            _context.Entry(pizza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PizzaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pizzas1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza)
        {
            _context.pizzas.Add(pizza);
            await _context.SaveChangesAsync();

            return Ok(pizza);
        }

        // DELETE: api/Pizzas1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id)
        {
            var pizza = await _context.pizzas.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }

            _context.pizzas.Remove(pizza);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PizzaExists(int id)
        {
            return _context.pizzas.Any(e => e.Id == id);
        }
    }
}
