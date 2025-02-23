using Domain.Primitives;

namespace Domain.Entities;

public class Permissions : AggregateRoot
{

    public int id { get; set; }

    public string NombreEmpleado { get; set; } 
    public string ApellidoEmpleado { get; set; } 
    public DateOnly FechaPermiso { get; set; } 


}
