using Application.Permissions.Common;
using Application.Permissions.Query.GetAll;
using Domain.Entities.Permissions;

namespace Application.Permissions.Query.GetById;

class GetPermissionByIdQueryHandler : IRequestHandler<GetPermissionByIdQuery, ErrorOr<PermissionsReponse>>
{
    private readonly IPermissionRepository _permisoRepository;

    public GetPermissionByIdQueryHandler(IPermissionRepository permisoRepository)
    {
        _permisoRepository = permisoRepository ?? throw new ArgumentNullException(nameof(permisoRepository));
    }

    public async Task<ErrorOr<PermissionsReponse>> Handle(GetPermissionByIdQuery query, CancellationToken cancellationToken)
    {

        if (await _permisoRepository.GetByIdAsync((query.Id)) is not Permission permission)
        {
            return Error.NotFound("Permission.NotFound", "The permission with the provided Id was not found.");
        }

        return  new PermissionsReponse(
                permission.Id,
                permission.NombreEmpleado,
                permission.ApellidoEmpleado,
                permission.TipoPermiso,
                permission.TipoPermisoId,
                permission.FechaPermiso);
    }
}