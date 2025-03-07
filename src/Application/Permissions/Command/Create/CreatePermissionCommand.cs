﻿namespace Application.Permissions.Command.Create;

public record CreatePermissionCommand(
    string NombreEmpleado,
    string ApellidoEmpleado,
    int TipoPermiso,
    DateOnly FechaPermiso) : IRequest<ErrorOr<int>>;
