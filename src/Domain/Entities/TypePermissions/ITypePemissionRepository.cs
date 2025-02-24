

namespace Domain.Entities.TypePermissions;

public interface ITypePemissionRepository
{

    Task<List<TypePemission>> GetAll();
}
