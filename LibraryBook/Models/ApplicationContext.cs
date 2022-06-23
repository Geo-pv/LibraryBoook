using Microsoft.EntityFrameworkCore;
namespace LibraryBook.Models
{
        public class ApplicationContext : DbContext
        {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<GenBook> GenBooks { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<RateBook> RateBooks { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
                : base(options)
            {
                Database.EnsureCreated();   // создаем базу данных при первом обращении
            }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenBook>().HasKey(table => new { table.GenreId, table.BookId });
            modelBuilder.Entity<RateBook>().HasKey(table => new { table.BookId, table.UserId });
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new() { Id = 1, Name = adminRoleName };
            Role userRole = new() { Id = 2, Name = userRoleName };
            User adminUser = new() { Id = 1, Login = adminEmail, NicName = adminEmail, Password = adminPassword, RoleId = adminRole.Id };

            base.OnModelCreating(modelBuilder);
        }
    }
    
}
