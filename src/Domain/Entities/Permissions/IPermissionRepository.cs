namespace Domain.Entities.Permissions;

public interface IPermissionRepository
{

    Task<List<Permission>> GetAll();
    Task<Permission> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int id);
    void Add(Permission permission);
    void Update(Permission permission);
}
