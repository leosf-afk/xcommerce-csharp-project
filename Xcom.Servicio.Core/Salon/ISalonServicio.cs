

namespace Xcom.Servicio.Core.Salon
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.Salon.DTOs;

    public  interface ISalonServicio
    {
        IEnumerable<SalonDto> Obtener(string CadenaBuscar);

        SalonDto ObtenerPorId(long EntidadId);

        bool VerificarExistencia(string cadenaBuscar, long? entidadId);

       IEnumerable <MesasSalonDto> ObtenerMesas(long?  SalonId , string CadenaBuscar);


        long Insertar(SalonDto dto);

        void Modificar(SalonDto dto);

        void Eliminar(long salonId);
    }
}
