

namespace Xcom.Servicio.Core.ListaPrecio
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.ListaPrecio.DTOs;

    public interface IListaPrecioServicio
    {

        long Insertar(ListaPrecioDto dto);

        void Modificar(ListaPrecioDto dto);

        void Eliminar(long ListaPrecioId);



        //=======================================================//

        IEnumerable<ListaPrecioDto> Obtener(string cadenaBuscar);


        ListaPrecioDto ObtenerPorId(long? ArticuloId);

        bool verificarExisteListaPrecio();

       
    }
}
