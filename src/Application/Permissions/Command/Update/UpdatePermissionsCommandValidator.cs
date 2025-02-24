namespace Application.Permissions.Command.Update;

public class UpdatePermissionsCommandValidator : AbstractValidator<UpdatePermissionsCommand>
{
    public UpdatePermissionsCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.NombreEmpleado)
            .NotEmpty().WithMessage("NombreEmpleado is required.")
            .MaximumLength(50).WithMessage("NombreEmpleado must not exceed 50 characters.");
        RuleFor(x => x.ApellidoEmpleado)
            .NotEmpty().WithMessage("ApellidoEmpleado is required.")
            .MaximumLength(50).WithMessage("ApellidoEmpleado must not exceed 50 characters.");
        RuleFor(x => x.TipoPermiso)
            .NotEmpty().WithMessage("TipoPermiso is required.");
        RuleFor(x => x.FechaPermiso)
            .NotEmpty().WithMessage("FechaPermiso is required.");
    }
}
