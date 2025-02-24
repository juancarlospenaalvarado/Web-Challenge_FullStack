using Domain.Entities.Permissions;
using Domain.Entities.TypePermissions;

namespace Infrastructure.Persistence.Repositories;

class PermissionsRepository : IPermissionRepository
{
    private readonly ApplicationDbContext _context;

    public PermissionsRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void Add(Permission permission) => _context.Permission.Add(permission);
    public void Update(Permission permission) => _context.Permission.Update(permission);
    public async Task<bool> ExistsAsync(int id) => await _context.Permission.AnyAsync(permission => permission.Id == id);
    public async Task<Permission> GetByIdAsync(int id) => await _context.Permission.Include(x => x.TipoPermiso).SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<Permission>> GetAll() => await _context.Permission.Include(x => x.TipoPermiso).ToListAsync();



}