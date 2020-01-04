using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using realstate.ListOfAdds;

namespace realstate.Model
{
    class dbContext : DbContext
    {
        public dbContext() : base("MyConnection3")
        {

        }

        public DbSet<item> items { get; set; }
        public DbSet<archive> Archives { get; set; }
        public DbSet<CatesAndAreas> catDatas { get; set; }
        
    }
}
