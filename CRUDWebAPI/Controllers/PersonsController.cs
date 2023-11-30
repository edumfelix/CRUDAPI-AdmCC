using CRUDWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonsController : ControllerBase
    {
        private readonly Context _context;
        public PersonsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAllAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        [HttpGet("{personId}")]
        public async Task<ActionResult<Person>> GetPersonByIdAsync(int personId)
        {
            Person? person = await _context.Persons.FindAsync(personId);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> SavePersonAsync(Person person)
        {
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePersonAsync(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{personId}")]
        public async Task<ActionResult> DeletePersonAsync(int personId)
        {
            Person? person = await _context.Persons.FindAsync(personId);
            if (person == null)
                return NotFound();
            _context.Remove(person);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
