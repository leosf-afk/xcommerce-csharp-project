

namespace Xcom.Servicio.Core.Empleado
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.Empleado.DTOs;

    public interface IEmpleadoServicio
    {

        long Insertar(EmpleadoDto dto);

        void Modificar(EmpleadoDto dto);

        void Eliminar(long empleadoId);

        bool VerificarSiExisteLegajo(int legajo , long entidadId);

        bool VerificarSiExisteLegajoNuevo(int legajo);

        //=======================================================//


        IEnumerable<EmpleadoDto> Obtener(string cadenaBuscar);

        EmpleadoDto ObtenerPorId(long empleadoId);

        int ObtenerSiguienteNumeroLegajo();

        EmpleadoDto ObtenerPorLegajo(long Legajo);
    }
}
