using Microsoft.Ajax.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;
using TA_API.Models;

namespace TA_API
{
    public class AccountController : ApiController
    {
        ThAppContext db = new ThAppContext();

        public void PostAccount([FromBody] request_cra obj)
        {
            User user = new User();//db.users.Where(u => u.login == obj.login).FirstOrDefault<User>();
            if (/*user == null*/ 1 == 1)
            {
                user.login = obj.login;
                user.password = obj.password;
                db.users.Add(user);
                db.SaveChanges();
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}