using Bookshelf.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookshelf.Data.Sql.DAOConfigurations
{

    public class UserConfiguration : IEntityTypeConfiguration<SQL.DAO.User>
    {
        public void Configure(EntityTypeBuilder<SQL.DAO.User> builder)
        {
            builder.Property(c => c.Username).IsRequired();
            builder.Property(c => c.Password).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.ToTable("User");
        }
    }
}