using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Models;

namespace UsersApi.Controllers
{
    // Set the URL to /api/user
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserContext _context;

        /**
         If the database is not already created, create it.
             */
        public UserController(UserContext context)
        {
            _context = context;
            if (_context.UserItems.Count() == 0)
            {
                _context.UserItems.Add(new UserItem { Fname = "Toto", Lname = "Titi", Address = "12 rue des mimosas" }); //insert a test value into the database
                _context.SaveChanges();
            }
        }

        /**
         * Method called when a GET request is called on URL /api/user
         * Return a list of all users as a JSON Object.
         */
        [HttpGet]
        public IEnumerable<UserItem> GetAll()
        {
            return _context.UserItems.ToList();
        }

        /**
         * Method called when a GET request is called on URL /api/user/{id}
         * Return user corresponding to the given ID as a JSON Object.
         * ID is a long.
         */
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(long id)
        {
            var item = _context.UserItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /**
        * Method called when a POST request is called on URL /api/user/
        * Create a new User into the database.
        * Consumes Json Object representing au User.
        */
        [HttpPost]
        public IActionResult Create([FromBody] UserItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.UserItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetUser", new { id = item.Id }, item);
        }
    }
}
