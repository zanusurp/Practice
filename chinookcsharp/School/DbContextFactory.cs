using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class DbContextFactory
    {
        public static SchoolContext Create()
        {
            SchoolContext context = new SchoolContext();
            context.Database.Log = log => Console.WriteLine(log);
            return context;                
        }
        
        

    }
}
