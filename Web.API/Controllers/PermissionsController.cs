using Application.Permissions.Command.Create;
using Application.Permissions.Command.Update;
using Application.Permissions.Query.GetAll;
using Application.Permissions.Query.GetById;

namespace Web.API.Controllers;

[Route("Permissions")]
public class Permissions : ApiController
{



    private readonly ISender _mediator;

    public Permissions(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var PermissionsResult = await _mediator.Send(new GetAllPermissionsQuery());

        return PermissionsResult.Match(
            permisos => Ok(permisos),
            errors => Problem(errors)
        );
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(int Id)
    {
        var PermissionsResult = await _mediator.Send(new GetPermissionByIdQuery(Id));

        return PermissionsResult.Match(
            permisos => Ok(permisos),
            errors => Problem(errors)
        );
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePermissionCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            permisoId => Ok(permisoId),
            errors => Problem(errors)
        );
    }


    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePermissionsCommand command)
    {
        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            permisoId => Ok(permisoId),
            errors => Problem(errors)
        );
    }


}