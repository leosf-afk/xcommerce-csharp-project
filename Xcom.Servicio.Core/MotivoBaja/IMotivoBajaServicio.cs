

namespace Xcom.Servicio.Core.MotivoBaja
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.MotivoBaja.DTOs;

    public interface IMotivoBajaServicio
    {

        IEnumerable<MotivoBajaDto> Obtener(string CadenaBuscar);

        MotivoBajaDto ObtenerPorId(long EntidadId);


        long Insertar(MotivoBajaDto dto);

        void Modificar(MotivoBajaDto dto);

       

    }
}
