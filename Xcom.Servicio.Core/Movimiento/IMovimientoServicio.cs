using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xcom.Servicio.Core.Movimiento.DTOs;

namespace Xcom.Servicio.Core.Movimiento
{
  public  interface IMovimientoServicio
    {
        long insertar(MovimientoDto dto);


    }
}
