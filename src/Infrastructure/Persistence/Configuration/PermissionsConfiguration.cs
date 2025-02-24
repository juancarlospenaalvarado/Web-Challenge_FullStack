using Domain.Entities.Permissions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class PermissionsConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("Permiso");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.NombreEmpleado)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.ApellidoEmpleado)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(c => c.FechaPermiso)
            .IsRequired()
            .HasColumnType("date");

        //builder.HasOne(c => c.TipoPermiso) 
        //       .WithMany(tp => tp.Permissions) 
        //       .HasForeignKey(c => c.TipoPermisoId) 
        //       .OnDelete(DeleteBehavior.Restrict);
    }
}

