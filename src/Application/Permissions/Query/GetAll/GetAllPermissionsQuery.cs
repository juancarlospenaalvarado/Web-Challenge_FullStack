using Application.Permissions.Common;

namespace Application.Permissions.Query.GetAll;


public record GetAllPermissionsQuery() : IRequest<ErrorOr<IReadOnlyList<PermissionsReponse>>>;