

namespace Xcom.Servicio.Core.CondicionIva
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.CondicionIva.DTOs;

    public interface ICondicionIvaServicio
    {
        IEnumerable<CondicionIvaDto> Obtener(string CadenaBuscar);

        CondicionIvaDto ObtenerPorId(long EntidadId);


        long Insertar(CondicionIvaDto dto);

        void Modificar(CondicionIvaDto dto);
    }
}
