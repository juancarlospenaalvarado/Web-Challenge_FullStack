using Domain.Entities.Permissions;
using Domain.Primitives;

namespace Application.Permissions.Command.Create;

class CreatePermissionCommandHandler : IRequestHandler<CreatePermissionCommand, ErrorOr<int>>
{
    private readonly IPermissionRepository _permisoRepository;
    private readonly IUnitOfWork _unitOfWork;
    public CreatePermissionCommandHandler(IPermissionRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _permisoRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }
    public async Task<ErrorOr<int>> Handle(CreatePermissionCommand command, CancellationToken cancellationToken)
    {

        var permiso = new Permission(
            command.NombreEmpleado,
            command.ApellidoEmpleado,
            command.TipoPermiso,
            command.FechaPermiso
        );

        _permisoRepository.Add(permiso);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return permiso.Id;
    }
}

