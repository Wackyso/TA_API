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



        


        // GET api/<controller>/
        public IEnumerable<Message_for_resp> GetMessages(string id)//выдача сообщений диалога 
        {
            string[] words = id.Split(new char[] { '=' });
            string login = words[0];
            string password = words[1];
            int dialog_id = Convert.ToInt32( words[3]);

            List<Message_for_resp> a = new List<Message_for_resp> { };
            List<Message_for_resp> badlog = new List<Message_for_resp> { };

            User user = db.users.Where(u => u.login == login).FirstOrDefault<User>();

            if (user.password == password)
            {
                List<Message> b = db.messages.Where(m => m.login == login && m.dialog_id == dialog_id).ToList();

                foreach (Message B in b)
                {
                    Message_for_resp y = new Message_for_resp();
                    y.login = 2;
                    y.send_time = B.send_time;
                    y.text = B.text;
                    if (B.login == login) y.login = 1;
                    a.Add(y);
                }
                return a;
            }
            else
                return badlog;
        }

        // POST api/<controller>
        

        

        public void PostMessages([FromBody] request_mes obj)
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
                db.SaveChanges();
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