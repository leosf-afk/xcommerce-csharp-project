

namespace Xcom.Servicio.Core.Marca
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.Marca.DTOs;

    public  interface IMarcaServicio
     {
        IEnumerable<MarcaDto> Obtener(string CadenaBuscar);

        MarcaDto ObtenerPorId(long EntidadId);


        long Insertar(MarcaDto dto);
     
        void Modificar(MarcaDto dto);

        void Eliminar(long MarcaId);
     
     
     }
}
