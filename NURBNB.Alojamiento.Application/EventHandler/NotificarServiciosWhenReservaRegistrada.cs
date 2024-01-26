using MediatR;
using NURBNB.Alojamiento.Application.Services;
using NURBNB.Alojamiento.Domain.Model.Reserva.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.EventHandler
{
    public class NotificarServiciosWhenReservaRegistrada : INotificationHandler<ReservaRegistrada>
    {
        private readonly IBusService _bus;

        public NotificarServiciosWhenReservaRegistrada(IBusService bus)
        {
            _bus = bus;
        }
        public async Task Handle(ReservaRegistrada notification, CancellationToken cancellationToken)
        {
            IntegrationEvents.ReservaRegistrada evento = new IntegrationEvents.ReservaRegistrada
            {
                fechaLlegada = notification.fechaLlegada,
                fechaSalida = notification.fechaSalida,
                GuestId = notification.GuestId,
                reservaId = notification.reservaId,
                PropiedadId = notification.PropiedadId
            };
            await _bus.PublishAsync(evento);
        }
    }
}
