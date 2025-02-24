namespace Application.Permissions.Command.Update;

public record UpdatePermissionsCommand(
    int Id,
    string NombreEmpleado,
    string ApellidoEmpleado,
    int TipoPermiso,
    DateOnly FechaPermiso) : IRequest<ErrorOr<int>>;
