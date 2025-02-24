using Application.TypePermissions.Common;

namespace Application.TypePermissions.Query.GetAll;

public class GetAllTypePermissionQuery() :
    IRequest<ErrorOr<IReadOnlyList<TypePermissionResponse>>>;
