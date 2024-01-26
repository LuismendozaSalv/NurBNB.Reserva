using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Model.Reserva;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Domain.Repositories
{
    public interface IReservaPropiedadRepository : IRepository<ReservaPropiedad, Guid>
    {
        Task<List<ReservaPropiedad>> FindAll();
        Task UpdateAsync(ReservaPropiedad reservaPropiedad);

    }
}