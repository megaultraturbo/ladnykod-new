using Bookshelf.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Data.Sql.DAOConfigurations
{

    public class BookConfiguration : IEntityTypeConfiguration<SQL.DAO.Book>
    {
        public void Configure(EntityTypeBuilder<SQL.DAO.Book> builder)
        {
            builder.Property(c => c.Title).IsRequired();
            builder.Property(c => c.PagesNumber).IsRequired();
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.AuthorId);
            builder.ToTable("Book");
        }
    }
}