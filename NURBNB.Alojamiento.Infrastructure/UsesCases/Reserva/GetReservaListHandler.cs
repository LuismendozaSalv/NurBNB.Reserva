using MediatR;
using Microsoft.EntityFrameworkCore;
using NURBNB.Alojamiento.Application.Dto.Reserva;
using NURBNB.Alojamiento.Application.UseCases.Reserva.Query;
using NURBNB.Alojamiento.Infrastructure.EF.Context;
using NURBNB.Alojamiento.Infrastructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.UsesCases.Reserva
{
    public class GetReservaListHandler : IRequestHandler<GetReservaListQuery, ICollection<ReservaListDto>>
    {
        private readonly DbSet<ReservaPropiedadReadModel> _reserva;

        public GetReservaListHandler(ReadDbContext reserva)
        {
            _reserva = reserva.ReservaPropiedad;
        }

        public async Task<ICollection<ReservaListDto>> Handle(GetReservaListQuery request, CancellationToken cancellationToken)
        {
            var query = _reserva.AsNoTracking();
            return await query.Select(reserva =>
                new ReservaListDto
                {
                    FechaEntrada = reserva.FechaEntrada,
                    FechaSalida = reserva.FechaSalida,
                    PropiedadId= reserva.PropiedadId,
                    Estado = reserva.EstadoReserva
                }).ToListAsync(cancellationToken);
        }
    }
}
