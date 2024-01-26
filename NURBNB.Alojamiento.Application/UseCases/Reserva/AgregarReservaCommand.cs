using MediatR;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Model.Reserva;
using NURBNB.Alojamiento.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Reserva
{
    public class AgregarReservaCommand : IRequest<Guid>
    {
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public EstadoReserva Estado { get; set; }
        public Precio MontoTotal { get; set; }
        public TipoPago TipoPago { get; set; }
        public Guid PropiedadId { get; set; }
        public Guid GuestId { get; set; }
    }
}
