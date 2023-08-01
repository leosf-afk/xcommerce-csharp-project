

namespace Xcom.Servicio.Core.Cliente.Dtos
{
    using System;
    using Xcom.Servicio.Core.Base;

    public class ClienteDto : BaseDTOs
    {

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string ApyNom => $"{Apellido} {Nombre}";

        public string Dni { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string EMail { get; set; }

        public string Cuil { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public decimal MontoMaximoCtaCte { get; set; }

        public bool EsVisible { get; set; }




        //  ===============   AccesoDatos Del Domicilio ===============

        public string Calle { get; set; }

        public int Numero { get; set; }

        public string Piso { get; set; }

        public string Dpto { get; set; }

        public string Casa { get; set; }

        public string Lote { get; set; }

        public string Mza { get; set; }

        public string Barrio { get; set; }

        public long LocalidadId { get; set; }

        public long ProvinciaId { get; set; }
    }
}
