using Bookshelf.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Data.Sql.DAOConfigurations
{

    public class ReviewPreferenceConfiguration : IEntityTypeConfiguration<ReviewPreference>
    {
        public void Configure(EntityTypeBuilder<ReviewPreference> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.ReviewPreferences)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Review)
                .WithMany(x => x.ReviewPreferences)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.ReviewId);
            builder.ToTable("ReviewPreference");
        }
    }
}