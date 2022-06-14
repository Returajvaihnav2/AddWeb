using Microsoft.EntityFrameworkCore;

namespace Api.School.Entity
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {

        }

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            if (!optionsbuilder.IsConfigured)
            {
              
                optionsbuilder.UseSqlServer("Data Source=TRX-LTP03;Database=db_School;");
            }
        }
        //entities

    }
}
