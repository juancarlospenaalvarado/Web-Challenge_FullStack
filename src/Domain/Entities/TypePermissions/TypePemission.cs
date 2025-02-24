using Domain.Entities.Permissions;
using Domain.Primitives;

namespace Domain.Entities.TypePermissions;

public class TypePemission : AggregateRoot
{
    public int Id { get; set; }
    public string Descripcion { get; set; }


}
