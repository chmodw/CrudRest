using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(this.heroes);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(this.heroes);
        }
    }
}
