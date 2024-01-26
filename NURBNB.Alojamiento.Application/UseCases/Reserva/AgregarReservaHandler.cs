using MediatR;
using NURBNB.Alojamiento.Application.Services;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Model.Reserva;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Application.UseCases.Reserva
{
    internal class AgregarReservaHandler : IRequestHandler<AgregarReservaCommand, Guid>
    {
        private IReservaPropiedadRepository _reservaPropiedadRepository;
        private IReservaPropiedadFactory _reservaPropiedadFactory;
        private IUnitOfWork _unitOfWork;

        public AgregarReservaHandler(IReservaPropiedadRepository reservaPropiedadRepository, IReservaPropiedadFactory reservaPropiedadFactory,
            IUnitOfWork unitOfWork)
        {
            _reservaPropiedadRepository = reservaPropiedadRepository;
            _reservaPropiedadFactory = reservaPropiedadFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(AgregarReservaCommand request, CancellationToken cancellationToken)
        {
            var reserva = ReservaPropiedad.Create(request.FechaEntrada, request.FechaSalida, request.Estado, 
                request.TipoPago, request.MontoTotal, request.PropiedadId, request.GuestId);
            await _reservaPropiedadRepository.CreateAsync(reserva);

            await _unitOfWork.Commit();

            return reserva.Id;
        }
    }
}
