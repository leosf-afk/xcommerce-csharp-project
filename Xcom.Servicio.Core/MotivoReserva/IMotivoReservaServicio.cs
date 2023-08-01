

namespace Xcom.Servicio.Core.MotivoReserva
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.MotivoReserva.DTOs;

    public interface IMotivoReservaServicio
    {
        IEnumerable<MotivoReservaDto> Obtener(string CadenaBuscar);

        MotivoReservaDto ObtenerPorId(long EntidadId);

        long Insertar(MotivoReservaDto dto);

        void Modificar(MotivoReservaDto dto);

    }
}
