

namespace Xcom.Servicio.Core.Precio.DTOs
{
    using System.Collections.Generic;

    public interface IPrecioServicio
    {


        long Insertar(PrecioDto dto);

        void Modificar(PrecioDto dto);





        //=======================================================//

       

        long obtenerId(long ? ArticuloId);

        IEnumerable<PrecioProductoDto> obtenerPrecios(string CadenaBuscar , decimal Rentabilidad);

        PrecioDto ObtenerPorId(long? PrecioId);

       
    }
}
