using Bookshelf.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Data.Sql.DAOConfigurations
{

    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(c => c.ReviewText).IsRequired();
            builder.HasOne(x => x.Book)
                .WithMany(x => x.Reviews)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.BookId);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Reviews)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);
            builder.ToTable("Review");
        }
    }
}