using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Model.Reserva.Events;
using NURBNB.Alojamiento.Domain.ValueObjects;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Model.Reserva
{
    public class ReservaPropiedad : AggregateRoot
    {
        public DateTime FechaEntrada { get; private set; }
        public DateTime FechaSalida { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public EstadoReserva EstadoReserva { get; private set; }
        public Precio MontoTotal { get; private set; }
        public TipoPago TipoPago { get; private set; }
        public Guid PropiedadId { get; private set; }
        public Guid GuestId { get; private set; }

        internal ReservaPropiedad()
        {

        }

        internal ReservaPropiedad(DateTime fechaEntrada, DateTime fechaSalida, EstadoReserva estado, 
            TipoPago tipoPago, Precio montoTotal, Guid propiedadId, Guid guestId)
        {
            Id = Guid.NewGuid();
            FechaEntrada = fechaEntrada;
            FechaSalida = fechaSalida;
            EstadoReserva = estado;
            FechaCreacion = DateTime.Now;
            TipoPago = tipoPago;
            MontoTotal = montoTotal;
            PropiedadId = propiedadId;
            GuestId = guestId;
        }

        public void Editar(EstadoReserva estado)
        {
            EstadoReserva = estado;
        }

        public static ReservaPropiedad Create(DateTime fechaEntrada, DateTime fechaSalida, EstadoReserva estado,
            TipoPago tipoPago, Precio montoTotal, Guid propiedadId, Guid guestId)
        {
            var obj = new ReservaPropiedad(fechaEntrada, fechaSalida, estado, tipoPago, montoTotal, propiedadId, guestId);
            obj.AddDomainEvent(new ReservaRegistrada(
                    obj.FechaEntrada,
                    obj.FechaSalida,
                    obj.GuestId,
                    obj.Id,
                    obj.PropiedadId
                ));
            return obj;
        }
    }
}
