using DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class MovieRepository : IRepository<MovieDto>
    {
        private readonly MoviesAppDbContext _context;

        public MovieRepository(MoviesAppDbContext context)
        {
            _context = context;
        }

        public void Add(MovieDto entity)
        {
            _context.Movies.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(MovieDto entity)
        {
            _context.Movies.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<MovieDto> GetAll()
        {
            return _context.Movies;
        }

        public void Update(MovieDto entity)
        {
            _context.Movies.Update(entity);
            _context.SaveChanges();
        }
    }
}
