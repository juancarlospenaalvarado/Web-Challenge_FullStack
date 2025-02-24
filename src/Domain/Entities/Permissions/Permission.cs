using Domain.Entities.TypePermissions;
using Domain.Primitives;
using System.Text.Json.Serialization;

namespace Domain.Entities.Permissions;

public class Permission : AggregateRoot
{

    public Permission()
    {
    }
    public Permission(string nombre ,string apellido, int tipoPermisoId, DateOnly fechaPermiso)
    {
        NombreEmpleado = nombre;
        ApellidoEmpleado = apellido;
        TipoPermisoId = tipoPermisoId;
        FechaPermiso = fechaPermiso;
    }
    public Permission(int id, string nombreEmpleado, string apellidoEmpleado, int tipoPermiso, DateOnly fechaPermiso)
    {
        Id = id;
        NombreEmpleado = nombreEmpleado;
        ApellidoEmpleado = apellidoEmpleado;
        TipoPermisoId = tipoPermiso;
        FechaPermiso = fechaPermiso;
    }

    public static Permission UpdatPermiso(int id, string NombreEmpleado, string ApellidoEmpleado, int TipoPermiso, DateOnly fechaPermiso)
    {
        return new Permission(id, NombreEmpleado, ApellidoEmpleado, TipoPermiso, fechaPermiso);
    }

    public int Id { get; set; }

    public string NombreEmpleado { get; set; } 
    public string ApellidoEmpleado { get; set; }
    public TypePemission? TipoPermiso { get; set; }
    public int TipoPermisoId { get; set; }
    public DateOnly FechaPermiso { get; set; } 


}
