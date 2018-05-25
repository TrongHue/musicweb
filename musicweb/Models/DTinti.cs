using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace musicweb.Models
{
    public class DTinti:DropCreateDatabaseIfModelChanges<DTcontext>
    {
        protected override void Seed(DTcontext context)
        {
            context.SaveChanges();
            base.Seed(context);
            
        }
    }
}