using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Mapping;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class TwitterDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TweetModel> Tweets { get; set; }
        public DbSet<TweetUserModel> TweetUsers { get; set; }

        
        public TwitterDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new TweetUserMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
