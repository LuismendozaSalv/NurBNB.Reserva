using MediatR;
using NURBNB.Alojamiento.Application.Dto.Reserva;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Reserva.Query
{
    public class GetReservaListQuery : IRequest<ICollection<ReservaListDto>>
    {
        
    }
}
