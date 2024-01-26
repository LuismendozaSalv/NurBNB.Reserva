using Restaurant.SharedKernel.Core;
using MediatR;
namespace NURBNB.Alojamiento.Domain.Model.Reserva.Events
{
    public record ReservaRegistrada : DomainEvent, INotification
    {
        public DateTime fechaLlegada { get; set; }
        public DateTime fechaSalida { get; set; }
        public Guid GuestId { get; set; }
        public Guid reservaId { get; set; }
        public Guid PropiedadId { get; set; }

        public ReservaRegistrada(DateTime fechaLlegada, DateTime fechaSalida,
            Guid GuestId, Guid reservaId, Guid propiedadId) : base(DateTime.Now)
        {
            this.fechaLlegada = fechaLlegada;
            this.fechaSalida = fechaSalida;
            this.GuestId = GuestId;
            this.reservaId = reservaId;
            this.PropiedadId = propiedadId;
        }
    }
}
