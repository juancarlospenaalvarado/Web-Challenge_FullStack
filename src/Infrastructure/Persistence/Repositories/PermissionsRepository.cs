using Domain.Entities;

namespace Infrastructure.Persistence.Repositories;

class PermissionsRepository : IPermissionsRepository
{
    private readonly ApplicationDbContext _context;

    public PermissionsRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
}