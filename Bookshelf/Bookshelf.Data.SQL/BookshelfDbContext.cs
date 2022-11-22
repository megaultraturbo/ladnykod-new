using Bookshelf.Data.SQL.DAO;
using Bookshelf.Data.Sql.DAOConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Data.Sql
{
    //Klasa odpowiadająca za konfigurację Entity Framework Core
    //Przy pomocy instancji klasy FoodlyDbContext możliwe jest wykonywanie
    //wszystkich operacji na bazie danych od tworzenia bazy danych po zapytanie do bazy danych itd.
    public class BookshelfDbContext : DbContext
    {
        public BookshelfDbContext(DbContextOptions<BookshelfDbContext> options) : base(options){}

        //Ustawienie klas z folderu DAO jako tabele bazy danych
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<AuthorPreference> AuthorPreference { get; set; }
        public virtual DbSet<SQL.DAO.Book> Book { get; set; }
        public virtual DbSet<BookPreference> BookPreference { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<ReviewPreference> ReviewPreference { get; set; }
        public virtual DbSet<SQL.DAO.User> User { get; set; }

        //Przykład konfiguracji modeli/encji poprzez klasy konfiguracyjne z folderu DAOConfigurations
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthorConfiguration());
            builder.ApplyConfiguration(new AuthorPreferenceConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new BookPreferenceConfiguration());
            builder.ApplyConfiguration(new ReviewConfiguration());
            builder.ApplyConfiguration(new ReviewPreferenceConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}