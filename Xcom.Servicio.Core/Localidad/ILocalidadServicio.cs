

namespace Xcom.Servicio.Core.Localidad
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.Localidad.DTOs;

    public interface ILocalidadServicio
    {
        IEnumerable<LocalidadDto> Obtener(long provinciaId , string CadenaBuscar);

        IEnumerable<LocalidadDto> ObtenerLocalidades(string CadenaBuscar);

        LocalidadDto obtenerPorId(long? EntidadId);

        long Insertar(LocalidadDto dto);

        void Modificar(LocalidadDto dto);

        void Eliminar(long LocalidadId);

        bool VerificarExistencia(string cadenaBuscar, long? entidadid , long? provinciaId);
    }
}
