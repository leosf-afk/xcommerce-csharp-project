

namespace Xcom.Servicio.Core.Cliente
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.Cliente.Dtos;

    public  interface IClienteServicio
    {
        IEnumerable<ClienteDto> ObtenerCliente(string CadenaBuscar);

        IEnumerable<ClienteDto> ObtenerClienteActivos(string CadenaBuscar);

        ClienteDto ObtenerPorId(long ClienteId);

        long Insertar(ClienteDto clienteDto);

        void Modificar(ClienteDto clienteDto);

        void Eliminar(long clienteId);

        ClienteDto ObtenerCFinal();

        decimal MontoDisponibleCtaCte(long ClienteID);

        void PagarCtaCte(long clienteId);

        bool VerificarExistencia(string dni, long? entdidadID);
    }
}
