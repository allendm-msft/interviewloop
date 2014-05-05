using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebRole1.Models
{
    public class InterviewerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public InterviewerContext() : base("name=InterviewerContext")
        {
        }

        public System.Data.Entity.DbSet<WebRole1.Models.Interviewer> Interviewers { get; set; }

        public System.Data.Entity.DbSet<WebRole1.Models.Company> Companies { get; set; }
    
    }
}
