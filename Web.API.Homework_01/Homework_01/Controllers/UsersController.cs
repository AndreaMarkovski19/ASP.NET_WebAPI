using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Homework_01.Controllers
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<User> users = new List<User>()
        {
            new User(){ FirstName = "Andrea", LastName = "Markovski", Age = 35 },
            new User(){ FirstName = "Martin", LastName = "Vitanov", Age = 22 },
            new User(){ FirstName = "Katerina", LastName = "Jangelovska", Age = 25 },
            new User(){ FirstName = "Vlatko", LastName = "Petrovski", Age = 28 },
            new User(){ FirstName = "Emil", LastName = "Popovski", Age = 32 },
        };

        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserByIndex(int id)
        {
            try
            {                
                return (users[id - 1]);
            }

            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"User with id: {id} does not exist!");
            }
            catch (Exception ex)
            {
                return BadRequest("BROKEN REQUEST - " + ex.Message);
            }
        }

        [HttpGet("{UserId}")]
        public ActionResult<string> CheckForAdult(int UserId)
        {            
            try
            {
                if (users[UserId - 1].Age >= 0 && users[UserId - 1].Age < 18)
                {
                    return "The User is NOT an a adult.";
                }
                else
                {
                    return "The User is an a adult.";
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"User with id: {UserId} does NOT exist!");
            }
            catch (Exception ex)
            {
                return BadRequest("BROKEN REQUEST - " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post()
        {
            string body;
            using (StreamReader sr = new StreamReader(Request.Body))
            {
                body = sr.ReadToEnd();
            }
            User user = JsonConvert.DeserializeObject<User>(body);
            users.Add(user);
            return Ok($"User with id {users.Count - 1} has been added!");
        }
    }
}