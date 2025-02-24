using Application.TypePermissions.Common;
using Domain.Entities.TypePermissions;

namespace Application.TypePermissions.Query.GetAll;

class GetAllTypePermissionQueryHandler : IRequestHandler<GetAllTypePermissionQuery, ErrorOr<IReadOnlyList<TypePermissionResponse>>>
{
    private readonly ITypePemissionRepository _permisoRepository;

    public GetAllTypePermissionQueryHandler(ITypePemissionRepository permisoRepository)
    {
        _permisoRepository = permisoRepository ?? throw new ArgumentNullException(nameof(permisoRepository));
    }

    public async Task<ErrorOr<IReadOnlyList<TypePermissionResponse>>> Handle(GetAllTypePermissionQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<TypePemission> typePemissions = await _permisoRepository.GetAll();

        return typePemissions.Select(type => new TypePermissionResponse(
                type.Id,
                type.Descripcion
            )).ToList();
    }
}