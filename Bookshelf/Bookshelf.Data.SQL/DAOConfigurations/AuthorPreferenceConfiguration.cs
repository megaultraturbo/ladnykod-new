using Bookshelf.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Data.Sql.DAOConfigurations
{

    public class AuthorPreferenceConfiguration : IEntityTypeConfiguration<AuthorPreference>
    {
        public void Configure(EntityTypeBuilder<AuthorPreference> builder)
        {
            builder.HasOne(x => x.Author)
                .WithMany(x => x.AuthorPreferences)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.AuthorId);
            builder.ToTable("AuthorPreference");
        }
    }
}