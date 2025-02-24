using Application.Permissions.Common;

namespace Application.Permissions.Query.GetById;


public record GetPermissionByIdQuery(int Id) :
    IRequest<ErrorOr<PermissionsReponse>>;