using CrudRest.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudRest.Controllers
{
    [Route("api/super_heroes")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "Bat Man",
                FirstName = "Bruce",
                LastName = "Wayne",
                Place = "Gotham"
            },
            new SuperHero
            {
                Id = 2,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New york city"
            }
        };

        private readonly DataContext _context;

        public SuperHeroController(DataContext dataContext)
        {
            this._context = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero == null)
            {
                return BadRequest("Hero not found");
            }

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(this.heroes);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero request)
        {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
            {
                return BadRequest("Hero not found");
            }

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(hero);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Delete(int id)
        {
            var hero = heroes.Find(h => h.Id == id);

            if (hero == null)
            {
                return BadRequest("Hero not found");
            }

            this.heroes.Remove(hero);

            return Ok(hero);
        }

    }
}
