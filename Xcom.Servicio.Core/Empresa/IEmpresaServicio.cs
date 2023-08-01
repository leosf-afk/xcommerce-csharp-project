
namespace Xcom.Servicio.Core.Empresa
{
    using System.Collections.Generic;
    using Xcom.Servicio.Core.Empresa.DTOs;

    public interface IEmpresaServicio
    {
        IEnumerable<EmpresaDto> Obtener(string CadenaBuscar);

        EmpresaDto ObtenerPorId(long EntidadId);

        long Insertar(EmpresaDto dto);

        void Modificar(EmpresaDto dto);
    }
}
