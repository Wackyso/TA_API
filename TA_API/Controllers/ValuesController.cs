using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TA_API.Models;

namespace TA_API.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        ThAppContext db = new ThAppContext();
        public IEnumerable<string> Get()
        {
            return new string[] { db.users.Find("exo").login, "value2" };
        }

        // GET api/values/5
        public string Get(string id)
        {
            string[] words = id.Split(new char[] { '=' });
            string login = words[0];
            //string password = words[1];
            return id;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
