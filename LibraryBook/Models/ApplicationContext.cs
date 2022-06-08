using Microsoft.EntityFrameworkCore;
namespace LibraryBook.Models
{
        public class ApplicationContext : DbContext
        {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAut> BookAuts { get; set; }
        public DbSet<GenBook> GenBooks { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rate> Rates { get; set; }
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
            modelBuilder.Entity<BookAut>().HasKey(table => new { table.idAuthor, table.idBook });
            modelBuilder.Entity<GenBook>().HasKey(table => new { table.idGenre, table.idBook });
            modelBuilder.Entity<RateBook>().HasKey(table => new { table.idRate, table.idBook, table.idUser });
            modelBuilder.Entity<User>().HasKey(table => new { table.idRole });
            base.OnModelCreating(modelBuilder);
        }
    }
    
}
