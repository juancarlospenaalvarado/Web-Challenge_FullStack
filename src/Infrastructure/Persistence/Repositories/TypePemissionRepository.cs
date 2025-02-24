using Domain.Entities.Permissions;
using Domain.Entities.TypePermissions;

namespace Infrastructure.Persistence.Repositories;

public class TypePemissionRepository : ITypePemissionRepository
{
    
    private readonly ApplicationDbContext _context;

    public TypePemissionRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    public async Task<List<TypePemission>> GetAll() => await _context.TypePemission.ToListAsync();
}
