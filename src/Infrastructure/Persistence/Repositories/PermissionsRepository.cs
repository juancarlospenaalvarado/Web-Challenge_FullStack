using Domain.Entities.Permissions;
using Domain.Entities.TypePermissions;
using Nest;

namespace Infrastructure.Persistence.Repositories;

class PermissionsRepository : IPermissionRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IElasticClient _elasticClient;

    public PermissionsRepository(ApplicationDbContext context, IElasticClient elasticClient)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _elasticClient = elasticClient ?? throw new ArgumentNullException(nameof(elasticClient));
    }

    public void Add(Permission permission) => _context.Permission.Add(permission);

    public async Task<bool> AddElastich(Permission permission)
    {
        IEnumerable<Permission> enumerable = new List<Permission> { permission };

        var indexName = typeof(Permission).Name.ToLower();
        var indexResponse =  _elasticClient.Indices.Exists(indexName);

        if (!indexResponse.Exists)
             _elasticClient.Indices.Create(indexName, i => i.Map<Permission>(x=> x.AutoMap()));

        var a =  await _elasticClient.IndexManyAsync(enumerable,indexName);

        return true;

    }

    public void UpdateElastic(Permission permission)
    {
        var response =  _elasticClient.Update<Permission>(permission.Id, u => u.Doc(permission));
    }
    public async Task<Permission> Get(int id)
    {
        var a = (await _elasticClient.GetAsync<Permission>(id)).Source;
        return a;
    }
    public void Update(Permission permission) => _context.Permission.Update(permission);
    public async Task<bool> ExistsAsync(int id) => await _context.Permission.AnyAsync(permission => permission.Id == id);
    public async Task<Permission> GetByIdAsync(int id) => await _context.Permission.Include(x => x.TipoPermiso).SingleOrDefaultAsync(c => c.Id == id);
    public async Task<List<Permission>> GetAll() => await _context.Permission.Include(x => x.TipoPermiso).ToListAsync();



}