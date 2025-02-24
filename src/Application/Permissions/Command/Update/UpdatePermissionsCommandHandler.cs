using Domain.Entities.Permissions;
using Domain.Primitives;
using System.Security;

namespace Application.Permissions.Command.Update;

class UpdatePermissionsCommandHandler : IRequestHandler<UpdatePermissionsCommand, ErrorOr<int>>
{
    private readonly IPermissionRepository _permisoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePermissionsCommandHandler(IPermissionRepository permisoRepository, IUnitOfWork unitOfWork)
    {
        _permisoRepository = permisoRepository ?? throw new ArgumentNullException(nameof(permisoRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<int>> Handle(UpdatePermissionsCommand command, CancellationToken cancellationToken)
    {
        if (!await _permisoRepository.ExistsAsync((command.Id)))
        {
            return Error.NotFound("Permission.NotFound", "The permission with the provided Id was not found.");
        }

        

        Permission permission = Permission.UpdatPermiso(
            command.Id,
            command.NombreEmpleado,
            command.ApellidoEmpleado,
            command.TipoPermiso,
            command.FechaPermiso);

        _permisoRepository.Update(permission);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return permission.Id;
    }
}