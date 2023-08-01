

namespace Xcom.Servicio.Core.Mesa
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.Mesa.DTOs;

    public  interface IMesaServicio
    {
        IEnumerable<MesaDto> Obtener(string CadenaBuscar);

        IEnumerable<MesaDto> ObtenerMesaEstado(string CadenaBuscar);

        MesaDto ObtenerPorId(long EntidadId);

        bool VerificarExistencia(string cadenaBuscar,int numero , long? entidadid);


        long Insertar(MesaDto dto);

        void Modificar(MesaDto dto);

        void Eliminar(long MesaId);

        void CerrarMesa(long mesaId);

        decimal CargarLabelprecio(long? mesaId);

        int ObtenerSiguienteNumeroMesa();

        
    }
}
