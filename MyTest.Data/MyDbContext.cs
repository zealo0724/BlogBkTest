using Microsoft.EntityFrameworkCore;
using MyTest.Model;

namespace MyTest.Data
{
    public class MyDbContext : DbContext
    {
        private readonly string _connectionString;
        public MyDbContext(string coonnectionString)
        {
            _connectionString = coonnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(dbContextOptionsBuilder);
        }

        public DbSet<Blog> Blog { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<User> User { get; set; }
    }
}