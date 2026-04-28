using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecureSales.Domain;

namespace SecureSales.Infrastructure.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.Id);              

            builder.Property(c => c.Id)
                .HasColumnType("uniqueidentifier")
                .HasColumnName("CLI_ID");

            builder.Property(c => c.Nome)
                .HasColumnName("CLI_NOME")
                .IsRequired()
                .HasMaxLength(300);
            
        }
    }
}
