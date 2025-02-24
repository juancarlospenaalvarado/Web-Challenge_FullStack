using Domain.Entities.TypePermissions;

namespace Application.Permissions.Common;

public record PermissionsReponse(
int Id,
string NombreEmpleado,
string ApellidoEmpleado,
TypePemission? TipoPermiso,
int TipoPermisoId,
DateOnly FechaPermiso);
