using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SecureSales.Domain;
using SecureSales.Domain.Entities;

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


            builder.Property(c => c.Id)
                .HasColumnType("uniqueidentifier")
                .HasColumnName("CLI_ID");


            builder.Property(c => c.Email)
                .HasColumnType("nvarchar(300)")
                .HasColumnName("CLI_EMAIL");

            builder.Property(c => c.Telefone)
                .HasColumnType("nvarchar(20)")
                .HasColumnName("CLI_TELCOM");


            builder.Property(c => c.Celular)
                .HasColumnType("nvarchar(20)")
                .HasColumnName("CLI_TEL_CELULAR");


            builder.Property(c => c.Observacao)
                .HasColumnType("nvarchar(500)")
                .HasColumnName("CLI_OBS");


            builder.Property(c => c.StAtivo)
                .HasColumnType("bit")
                .HasColumnName("CLI_STATIVO");



        }
    }
}
