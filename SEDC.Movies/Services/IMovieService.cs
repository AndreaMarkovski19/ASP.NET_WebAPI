using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IMovieService
    {
        IEnumerable<MovieModel> GetUserMovies(int userId);
        MovieModel GetMovie(int id, int userId);
        void AddMovie(MovieModel model);
        void DeleteItem(int id, int userId);
    }
}
