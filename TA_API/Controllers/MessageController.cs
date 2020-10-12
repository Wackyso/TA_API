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
    public class MessageController : ApiController
    {
        ThAppContext db = new ThAppContext();



        public IEnumerable<Dialog> Get(request_log obj) //аутентификация
        {
            List<Dialog> a = new List<Dialog> { };
            
            User user = db.users.Where(u => u.login == obj.login).FirstOrDefault<User>();
            if (user.password == obj.password)
                return db.dialogs.Where(d => d.login == obj.login).ToList();
            else
                return a;
        }


        // GET api/<controller>/
        public IEnumerable<Message_for_resp> Get(request_dia obj)//выдача сообщений диалога 
        {
            List<Message_for_resp> a = new List<Message_for_resp> { };
            List<Message_for_resp> badlog = new List<Message_for_resp> { };

            User user = db.users.Where(u => u.login == obj.login).FirstOrDefault<User>();

            if (user.password == obj.password)
            {
                List<Message> b = db.messages.Where(m => m.login == obj.login).ToList();

                foreach (Message B in b)
                {
                    Message_for_resp y = new Message_for_resp();
                    y.login = 2;
                    y.send_time = B.send_time;
                    y.text = B.text;
                    if (B.login == obj.login) y.login = 1;
                    a.Add(y);
                }
                return a;
            }
            else
                return badlog;
        }

        // POST api/<controller>
        public void Post([FromBody] request_cra obj)
        {
            User user = db.users.Where(u => u.login == obj.login).FirstOrDefault<User>();
            if (user == null) {
                user.login = obj.login;
                user.password = obj.password;
                db.users.Add(user);
            }
        }

        public void Post([FromBody] request_crd obj)
        {
            User user = db.users.Where(u => u.login == obj.login).FirstOrDefault<User>();
            if (user.password == obj.password)
            {
                Dialog dialog = db.dialogs.Where(d => d.login == obj.login && d.interlocutor == obj.interlocutor).FirstOrDefault<Dialog>();
                if (dialog== null)
                {
                    dialog.login = obj.login;
                    dialog.interlocutor = obj.interlocutor;
                    dialog.dialog_id = db.dialogs.Where(d => d.login == obj.login).ToList().Count;
                    db.dialogs.Add(dialog);
                }
            }
        }

        public void Post([FromBody] request_mes obj)
        {
            User user = db.users.Where(u => u.login == obj.login).FirstOrDefault<User>();
            if (user.password == obj.password)
            {
                Message mes = new Message();
                mes.login = obj.login;
                mes.dialog_id = obj.dialog_id;
                mes.text = obj.text;
                mes.send_time = obj.send_time;
                db.messages.Add(mes);
            }
        }

        // PUT api/<controller>/5
        /*public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}// #iphone_не_нужны