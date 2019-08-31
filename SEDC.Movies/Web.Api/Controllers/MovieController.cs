using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieModel>> Get()
        {
            var userId = GetAuthorizedUserId();
            return Ok(_movieService.GetUserMovies(userId));
        }

        [HttpGet("{id}")]
        public ActionResult<MovieModel> Get(int id)
        {
            var userId = GetAuthorizedUserId();
            return Ok(_movieService.GetMovie(id, userId));
        }

        [HttpPost]
        public void Post([FromBody] MovieModel model)
        {
            model.UserId = GetAuthorizedUserId();
            _movieService.AddMovie(model);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var userId = GetAuthorizedUserId();
            _movieService.DeleteItem(id, userId);
        }

        private int GetAuthorizedUserId()
        {
            if (!int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?
                .Value, out var userId))
            {
                throw new Exception("Name identifier claim does not exist!");
            }
            return userId;
        }
    }
}