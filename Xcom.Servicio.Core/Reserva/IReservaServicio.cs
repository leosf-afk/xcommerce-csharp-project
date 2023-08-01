

namespace Xcom.Servicio.Core.Reserva
{
    using System;
    using System.Collections.Generic;
    using Xcom.Servicio.Core.Reserva.DTOs;

    public interface IReservaServicio
    {

        IEnumerable<ReservaDto> Obtener(string CadenaBuscar);

        ReservaDto ObtenerPorId(long EntidadId);


        long Insertar(ReservaDto dto);

        void Modificar(ReservaDto dto);

        bool verificarFecha(DateTime Fecha, long mesaId);
       
    }
}
