using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/**
 * This class is a model representing an User object in the database.
 */
namespace UsersApi.Models
{
    public class UserItem
    {
        public long Id { get; set; } // auto incremented id used as a primary key
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }

    }
}
