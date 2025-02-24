using Application.TypePermissions.Query.GetAll;

namespace Web.API.Controllers;



[Route("TypePermissions")]
public class TypePermissions : ApiController
{

    private readonly ISender _mediator;

    public TypePermissions(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var typePermissionsResult = await _mediator.Send(new GetAllTypePermissionQuery());

        return typePermissionsResult.Match(
            permisos => Ok(permisos),
            errors => Problem(errors)
        );
    }



}