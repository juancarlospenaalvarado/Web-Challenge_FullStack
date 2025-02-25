namespace Domain.Entities.Permissions;

public interface IPermissionRepository
{

    Task<List<Permission>> GetAll();
    Task<Permission> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    void Add(Permission permission);
    //void AddElastich(Permission permission);
    //Task<IEnumerable<string>> AddElastich(IEnumerable<Permission> permission);
    Task<bool> AddElastich(Permission permission);
    void UpdateElastic(Permission permission);
    void Update(Permission permission);
}
