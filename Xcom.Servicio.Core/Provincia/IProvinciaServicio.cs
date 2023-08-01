

namespace Xcom.Servicio.Core.Provincia
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.Provincia.DTOs;

    public interface IProvinciaServicio
    {
       
        IEnumerable<ProvinciaDto> Obtener(string cadenaBuscar);

        ProvinciaDto ObtenerPorId(long EntidadId);

      

        long Insertar(ProvinciaDto dto);

        void Modificar(ProvinciaDto dto);

        void Eliminar(long ProvinciaId);

        bool VerificarExistencia(string cadenaBuscar,  long? entidadid);

    }
}
