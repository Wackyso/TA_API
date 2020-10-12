using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql.TypeHandlers.DateTimeHandlers;

namespace TA_API
{
    public class request_log // dialog list +
    {
        public string login;
        public string password;
    }

    public class request_cra // create acc +
    {
        public string login;
        public string password;
    }

    public class request_dia // dialogs entry +
    {
        public string login;
        public string password;
        public int dialog_id;
    }

    public class request_crd // create dialog +
    {
        public string login;
        public string password;
        public string interlocutor;
    }

    public class request_mes // new message +
    {
        public string login;
        public string password;
        public int dialog_id;
        public string text;
        public DateTime send_time { get; set; }
    }
}