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
    public class GetReservaByPropiedadIdHandler : IRequestHandler<GetReservaByPropiedadIdQuery, ICollection<ReservaListDto>>
    {
        private readonly DbSet<ReservaPropiedadReadModel> _reserva;

        public GetReservaByPropiedadIdHandler(ReadDbContext reserva)
        {
            _reserva = reserva.ReservaPropiedad;
        }

        public async Task<ICollection<ReservaListDto>> Handle(GetReservaByPropiedadIdQuery request, CancellationToken cancellationToken)
        {
            var query = _reserva.AsNoTracking();
            if (!String.IsNullOrEmpty(request.SearchTerm.ToString()))
            {
                query = query.Where(x => x.PropiedadId == request.SearchTerm);
            }

            return await query.Select(reservas =>
                new ReservaListDto
                {
                    PropiedadId = reservas.PropiedadId,
                    FechaEntrada = reservas.FechaEntrada,
                    FechaSalida = reservas.FechaSalida,
                    Estado = reservas.EstadoReserva
                }).ToListAsync(cancellationToken);
        }
    }
}
