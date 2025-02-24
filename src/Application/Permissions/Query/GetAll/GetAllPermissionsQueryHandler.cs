using Application.Permissions.Common;
using Domain.Entities.Permissions;

namespace Application.Permissions.Query.GetAll;

public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, ErrorOr<IReadOnlyList<PermissionsReponse>>>
{
    private readonly IPermissionRepository _permisoRepository;

    public GetAllPermissionsQueryHandler(IPermissionRepository permisoRepository)
    {
        _permisoRepository = permisoRepository ?? throw new ArgumentNullException(nameof(permisoRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<PermissionsReponse>>> Handle(GetAllPermissionsQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<Permission> permisos = await _permisoRepository.GetAll();

        return permisos.Select(permiso => new PermissionsReponse(
                permiso.Id,
                permiso.NombreEmpleado,
                permiso.ApellidoEmpleado,
                permiso.TipoPermiso,
                permiso.TipoPermisoId,
                permiso.FechaPermiso
            )).ToList();
    }
}