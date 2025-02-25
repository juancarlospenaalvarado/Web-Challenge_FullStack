using Application.Permissions.Command.Create;
using Application.Permissions.Query.GetAll;
using Domain.Entities.Permissions;
using Domain.Primitives;
using Moq;

namespace Web.Api.UnitTest.GetPermissionAll;

public class GetPermissionAllQueryHandlerUnitTest
{
    private readonly Mock<IPermissionRepository> _mockPermissionRepository;
    private readonly GetAllPermissionsQueryHandler _handler;

    public GetPermissionAllQueryHandlerUnitTest()

    {
        _mockPermissionRepository = new Mock<IPermissionRepository>();
        _handler = new GetAllPermissionsQueryHandler(_mockPermissionRepository.Object);
    }

    [Fact]
    public async Task GetPermisos_ShouldReturnListOfEmpleadoPermisos()
    {
        var mockPermisos = new List<Permission>
        {
            new Permission { Id = 1, NombreEmpleado = "Juan", ApellidoEmpleado = "Perez", TipoPermisoId = 1, FechaPermiso = new DateOnly(2024, 2, 25) },
            new Permission { Id = 2, NombreEmpleado = "Maria", ApellidoEmpleado = "Gomez", TipoPermisoId = 2, FechaPermiso = new DateOnly(2024, 3, 10) }
        };
        var asa = _mockPermissionRepository.Setup(repo => repo.GetAll()).ReturnsAsync(mockPermisos);

        GetAllPermissionsQuery a = new GetAllPermissionsQuery();
        // Act: Llamamos al método del servicio
        var List = await _handler.Handle(a,default);
        var result = List.Value;

        // Assert: Verificamos que los datos son correctos
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
        result.Should().Contain(x => x.NombreEmpleado == "Juan" && x.ApellidoEmpleado == "Perez");
        result.Should().Contain(x => x.TipoPermisoId == 2 && x.FechaPermiso == new DateOnly(2024, 3, 10));
    }

}
