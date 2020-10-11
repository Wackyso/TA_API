using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TA_API.Models;

namespace TA_API
{
    public class MessageController : ApiController
    {
        ThAppContext db = new ThAppContext();
        // GET api/<controller>
        public IEnumerable<User> Get(/*request_obj obj*/)
        {
            bool answ= false;
            /*User user = db.Users.Find(obj.login);
            if (user.password == obj.password)
                return db.Dialogs.Find(obj.login);
            else*/
                return db.users;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}