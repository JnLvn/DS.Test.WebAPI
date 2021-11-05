using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using DS.Test.WebAPI.Models;


namespace DS.Test.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        
        // GET: api/user
        [System.Web.Http.HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            using (UsersEntities users = new UsersEntities())
            {
                return users.Users.ToList();
            }
        }

        // GET api/user/5
        [System.Web.Http.HttpGet]
        public User GetUser(int id)
        {
            using (UsersEntities users = new UsersEntities())
            {
                return users.Users.FirstOrDefault(u => u.Id == id);
            }
        }



        // POST api/user?id=1&name=John
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateUser(int id, string name)
        {
            User user = new User();

            try
            {
                using (UsersEntities users = new UsersEntities())
                {
                    user.Id = id;
                    user.Name = name;
                    users.Users.Add(user);

                    users.SaveChanges();

                    return Ok();
                }

            }
            catch
            {
                return BadRequest();
            }
            
        }

        // PUT api/user?id=1&name=John
        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateUser(int id, string name)
        {
            using (UsersEntities users = new UsersEntities())
            {
                var existingUser = users.Users.Where(u => u.Id == id).FirstOrDefault<User>();

                if (existingUser != null)
                {
                    existingUser.Name = name;

                    users.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }
        

        // DELETE api/user/5
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            using (UsersEntities users = new UsersEntities())
            {
                var existingUser = users.Users.Where(u => u.Id == id).FirstOrDefault<User>();

                if (existingUser != null)
                {
                    users.Users.Remove(existingUser);

                    users.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

    }
}