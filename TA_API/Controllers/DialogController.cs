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
    public class DialogController : ApiController
    {
        ThAppContext db = new ThAppContext();


        public IEnumerable<Dialog> GetDialogs(string id) //аутентификация
        {
            string[] words = id.Split(new char[] { '=' });
            string login = words[0];
            string password = words[1];

            List<Dialog> a = new List<Dialog> { };

            User user = db.users.Where(u => u.login == login).FirstOrDefault<User>();
            if (user.password == password)
                return db.dialogs.Where(d => d.login == login).ToList();
            else
                return a;
        }

        public void PostDialog([FromBody] request_crd obj)
        {
            User user = db.users.Where(u => u.login == obj.login).FirstOrDefault<User>();
            if (user.password == obj.password)
            {
                Dialog dialog = db.dialogs.Where(d => d.login == obj.login && d.interlocutor == obj.interlocutor).FirstOrDefault<Dialog>();
                if (dialog == null)
                {
                    dialog = new Dialog();
                    dialog.login = obj.login;
                    dialog.interlocutor = obj.interlocutor;
                    dialog.dialog_id = db.dialogs.Where(d => d.login == obj.login).ToList().Count;
                    db.dialogs.Add(dialog);
                    db.SaveChanges();
                }
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}