using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TA_API.Models
{
    public class DialogContext :DbContext
    {

        public DbSet<Dialog> Dialogs
        {
            get; set;
        }

    }
public class Dialog
{
    public string login { get; set; }
    public int dialog_id { get; set; }

}
}