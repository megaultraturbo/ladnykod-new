using Bookshelf.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Data.Sql.DAOConfigurations
{

    public class BookPreferenceConfiguration : IEntityTypeConfiguration<BookPreference>
    {
        public void Configure(EntityTypeBuilder<BookPreference> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.BookPreferences)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);
            builder.ToTable("BookPreference");
        }
    }
}