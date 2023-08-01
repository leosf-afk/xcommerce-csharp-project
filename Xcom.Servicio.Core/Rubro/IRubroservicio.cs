

namespace Xcom.Servicio.Core.Rubro
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.Rubro.DTOs;

    public  interface IRubroservicio
    {
        IEnumerable<RubroDto> Obtener(string CadenaBuscar);

        RubroDto ObtenerPorId(long EntidadId);


        long Insertar(RubroDto dto);

        void Modificar(RubroDto dto);

        void Eliminar(long RubroId);
    }
}
