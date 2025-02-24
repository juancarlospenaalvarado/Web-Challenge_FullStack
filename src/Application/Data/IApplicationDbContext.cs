
using Domain.Entities.Permissions;
using Domain.Entities.TypePermissions;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{

    public DbSet<Permission> Permission { get; set; }
    public DbSet<TypePemission> TypePemission { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}