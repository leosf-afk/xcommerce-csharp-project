using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.Servicio.Core.Caja.DTOs;

namespace Xcom.Servicio.Core.Caja
{
    public interface ICajaServicio
    {
        long Abrir(long usuarioId , decimal montoApertura);

        void Cerrar(long usuarioId, decimal MontoCierre , long cajaId , decimal montosistema);

        CajaDto Obtener(long CajaId);

        bool VerificarSiExisteCajaAbierta(long usuarioLogueadoId);

        CajaDto ObtenerIdporUsuario(long UsuarioId);

        void ActualizarMontoDelSistemaPorVenta(decimal MontoVenta , long Cajaid);

        }
}
