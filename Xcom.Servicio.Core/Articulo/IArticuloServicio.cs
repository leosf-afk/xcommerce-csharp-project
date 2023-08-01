
namespace Xcom.Servicio.Core.Articulo
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.Articulo.DTOs;

    public interface IArticuloServicio
    {

        ArticuloMesaDto ObtenerPorCodigoMesa(string codigo , long mesaId);

        long Insertar(ArticuloDto dto);

        void Modificar(ArticuloDto dto);

        void Eliminar(long ArticuloId);



        //=======================================================//

        IEnumerable<ArticuloDto> Obtener(string cadenaBuscar);


        ArticuloDto ObtenerPorId(long ArticuloId);

        bool VerificarExistencia(string cadenaBuscar, long? entidadid, string codigo, string CodigoBarra);

        bool VerificarSobreExistencia(string codigo, string CodigoBarra);

        bool VerificarPorCodigo(string cadenaBuscar);

        ArticuloKioscoDto ObtenerventaKiosko(string codigo , decimal Cantidad);
        
    }
}
