namespace Xcom.Servicio.Core.BajaArticulo
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.BajaArticulo.DTOs;

    public interface IArticuloBajaServicio
    {

        IEnumerable<ArticuloBajaDto> Obtener(string CadenaBuscar);

        ArticuloBajaDto ObtenerPorId(long EntidadId);


        long Insertar(ArticuloBajaDto dto);

        void Modificar(ArticuloBajaDto dto);

        void DescontarStock(long Id, decimal Cantidad);



    }
}
