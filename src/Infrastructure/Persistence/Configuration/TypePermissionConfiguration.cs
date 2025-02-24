using Domain.Entities.TypePermissions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class TypePermissionConfiguration : IEntityTypeConfiguration<TypePemission>
{
    public void Configure(EntityTypeBuilder<TypePemission> builder)
    {
        builder.ToTable("TipoPermiso");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Descripcion).IsRequired().HasMaxLength(50);

        //builder.HasMany(tp => tp.Permissions)
        //              .WithOne(p => p.TipoPermiso)  
        //              .HasForeignKey(p => p.TipoPermisoId)
        //              .OnDelete(DeleteBehavior.Restrict);


        // Poblar datos iniciales
        builder.HasData(
            new TypePemission { Id = 1, Descripcion = "Vacaciones" },
            new TypePemission { Id = 2, Descripcion = "Vacaciones de Paternidad" }
        );
    }
}

