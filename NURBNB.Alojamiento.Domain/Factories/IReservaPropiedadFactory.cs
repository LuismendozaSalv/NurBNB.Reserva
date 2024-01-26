using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Model.Reserva;
using NURBNB.Alojamiento.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Factories
{
    public interface IReservaPropiedadFactory
    {
        public ReservaPropiedad Crear(DateTime fechaEntrada, DateTime fechaSalida, EstadoReserva estado, TipoPago tipoPago,
            Precio montoTotal, Guid propiedadId, Guid guestId);
    }
}
