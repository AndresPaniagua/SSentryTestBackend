using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SSentryTestBackend.Core.Entities;

namespace SSentryTestBackend.Infrastructure.Data.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Empresas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.IdentificationTypeId)
                .HasColumnName("TipoIdentificacionId");

            builder.Property(c => c.CompanyName)
                .HasColumnName("EmpresaNombre")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(c => c.IdentificationNumber)
                .HasColumnName("NumeroIdentificacion")
                .IsRequired()
                .HasMaxLength(9)
                .IsUnicode(false);

            builder.Property(c => c.FirstName)
                .HasColumnName("PrimerNombre")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(c => c.SecondName)
                .HasColumnName("SegundoNombre")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(c => c.FirstLastName)
                .HasColumnName("PrimerApellido")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(c => c.SecondLastName)
                .HasColumnName("SegundoApellido")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(c => c.Email)
                .HasColumnName("CorreoElectronico")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(c => c.AllowCellphoneMessages)
                .HasColumnName("PermiteMensajesCelular");

            builder.Property(c => c.AllowEmailMessages)
                .HasColumnName("PermiteMensajesCorreo");

            builder.HasOne(c => c.IdentificationType)
                .WithMany()
                .HasForeignKey(c => c.IdentificationTypeId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
