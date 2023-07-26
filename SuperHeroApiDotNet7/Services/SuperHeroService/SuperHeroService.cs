using Microsoft.EntityFrameworkCore;

namespace SuperHeroApiDotNet7.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private static List<SuperHero> superHeroes = new List<SuperHero>()
        {
            new SuperHero()
            {
                Id = 1,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
            },
            new SuperHero()
            {
                Id = 2,
                Name = "Iron Man",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "Malibu"
            }
        };

        private readonly ApplicationDbContext _context;
        public SuperHeroService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>?> DeleteHero(int id)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);
            if (superHero is null)
                return null;

            _context.SuperHeroes.Remove(superHero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);
            if (superHero is null)
                return null;

            return superHero;        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero request)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);
            if (superHero is null)
                return null;

            superHero.Name = request.Name;
            superHero.FirstName = request.FirstName;
            superHero.LastName = request.LastName;
            superHero.Place = request.Place;
            
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
