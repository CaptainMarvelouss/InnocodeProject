using FPT.BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FPT.BusinessLogic
{
    public class InnocodeDbContext : DbContext
    {
        public InnocodeDbContext(DbContextOptions<InnocodeDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //IConfigurationRoot configuration = builder.Build();
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("InnocodeDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .Property(user => user.UserName)
            .IsRequired()
            .HasMaxLength(20);
            modelBuilder.Entity<User>()
                .HasIndex(user => user.UserName)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(user => user.Email)
                .IsUnique();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<React> Reacts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReply> CommentsReply { get; set; }
    }
}
