using Application.Permissions.Command.Create;
using Application.Permissions.Command.Update;
using Domain.Entities.Permissions;
using Domain.Primitives;

namespace Web.Api.UnitTest.UpdatePermission;

public class UpdatePermissionCommandHandlerUnitTests
{
    private readonly Mock<IPermissionRepository> _mockPermissionRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly UpdatePermissionsCommandHandler _handler;


    public UpdatePermissionCommandHandlerUnitTests()
    {
        _mockPermissionRepository = new Mock<IPermissionRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();

        _handler = new UpdatePermissionsCommandHandler(_mockPermissionRepository.Object, _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task HandleCreateCustomerReturnValidationError()
    {
        //Arrange
        // Se configura los parametros de entrada de nuestra prueba unitaria.
        UpdatePermissionsCommand command = new UpdatePermissionsCommand(1,"Juan", "Peña", 1, new DateOnly(2025, 10, 25));
        //Act
        // Se ejecuta el metodo a probar de nuestra prueba unitaria
        var result = await _handler.Handle(command, default);
        //Assert
        // Se verifica los datos de retorno de nuestro metodo probado en la prueba unitaria
        result.IsError.Should().BeTrue();
        //result.FirstError.Type.Should().Be(ErrorType.Validation);
    }
}
