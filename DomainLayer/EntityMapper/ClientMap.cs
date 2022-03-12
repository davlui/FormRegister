using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.EntityMapper
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id).HasName("pk_clientid");
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id")
                .HasColumnType("INT");

            builder.Property(x => x.CreatedDate)
                .HasColumnName("created_date")
                .HasColumnType("datetime");

            builder.Property(x => x.ModifiedDate)
                .HasColumnName("modified_date")
                .HasColumnType("datetime");

        }
    }
}
