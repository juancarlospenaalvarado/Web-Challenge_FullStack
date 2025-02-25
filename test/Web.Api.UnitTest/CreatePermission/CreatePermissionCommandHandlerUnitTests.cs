using Application.Permissions.Command.Create;
using Domain.Entities.Permissions;
using Domain.Primitives;

namespace Web.Api.UnitTest.CreatePermission;

public class CreatePermissionCommandHandlerUnitTests
{
    private readonly Mock<IPermissionRepository> _mockPermissionRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly CreatePermissionCommandHandler _handler;


    public CreatePermissionCommandHandlerUnitTests()
    {
        _mockPermissionRepository = new Mock<IPermissionRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();

        _handler = new CreatePermissionCommandHandler(_mockPermissionRepository.Object, _mockUnitOfWork.Object);
    }

    [Fact]
    public async Task HandleCreateCustomerReturnValidationError()
    {
        //Arrange
        // Se configura los parametros de entrada de nuestra prueba unitaria.
        CreatePermissionCommand command = new CreatePermissionCommand("Juan","Peña",1,new DateOnly(2025,10,25) );
        //Act
        // Se ejecuta el metodo a probar de nuestra prueba unitaria
        var result = await _handler.Handle(command, default);
        //Assert
        // Se verifica los datos de retorno de nuestro metodo probado en la prueba unitaria
        result.IsError.Should().BeFalse();
        //result.FirstError.Type.Should().Be(ErrorType.Validation);
    }



}
