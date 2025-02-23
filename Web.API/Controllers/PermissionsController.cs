namespace Web.API.Controllers;

public class Permissions : ApiController
{



    private readonly ISender _mediator;

    public Permissions(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
}