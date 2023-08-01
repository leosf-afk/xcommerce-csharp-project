

namespace Xcom.Servicio.Seguridad.Usuarios
{
    using System.Collections.Generic;
    using Xcom.Servicio.Seguridad.Usuarios.DTOs;

    public interface IUsuarioServicio
    {
        /// <summary>
        ///  Metodo para bloquear o desbloquear el usuario
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario</param>
        /// <param name="estado">true  bloquear , false desbloquear </param>
        void CambiarEstado(string nombreUsuario, bool estado);


       IEnumerable<UsuarioDto> Obtener(string cadenaBuscar);

        void Crear(long personaId, string Apellido, string Nombre);

        UsuarioDto ObtenerPorId(long EntidadId);

        UsuarioDto Obtenernombre(long EntidadId);

        UsuarioDto ObtenerPorUsuario(string Usuario);

        bool VerificarQueExista(long Id);
    }
}
