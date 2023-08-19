﻿using Moq;
using NURBNB.Alojamiento.Application.Dto.Propiedad;
using NURBNB.Alojamiento.Application.UseCases.Alojamiento.Command.CrearAlojamiento;
using NURBNB.Alojamiento.Application.UseCases.Ciudad.Command.CrearCiudad;
using NURBNB.Alojamiento.Domain.Factories;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using TipoPropiedad = NURBNB.Alojamiento.Application.Dto.Propiedad.TipoPropiedad;

namespace NURBNB.Alojamiento.Test.Application.UseCases.AlojamientoTest.Command.CrearPropiedad
{
    public class CrearPropiedad_Test
    {
        Mock<IPropiedadRepository> _propiedadRepository;
        Mock<IPropiedadFactory> _propiedadFactory;
        Mock<IUnitOfWork> _unitOfWork;

        public CrearPropiedad_Test()
        {
            _propiedadFactory = new Mock<IPropiedadFactory>();
            _propiedadRepository = new Mock<IPropiedadRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public void CrearPropiedadApartamento()
        {
            var propiedadEsperada = PropiedadMockFactory.getPropiedadApartamento();

            _propiedadFactory.Setup(_propiedadFactory => _propiedadFactory.CreatePropiedadApartamento(propiedadEsperada.Titulo,
                propiedadEsperada.Descripcion, propiedadEsperada.Precio,
                propiedadEsperada.Capacidad.People, propiedadEsperada.Capacidad.Beds, propiedadEsperada.Capacidad.Rooms))
                .Returns(propiedadEsperada);

            var handler = new CrearPropiedadHandler(
                _propiedadRepository.Object,
                _propiedadFactory.Object,
                _unitOfWork.Object
            );
            var tcs = new CancellationTokenSource(1000);
            CrearPropiedadCommand evento = new CrearPropiedadCommand
            {
                Titulo = propiedadEsperada.Titulo,
                Descripcion = propiedadEsperada.Descripcion,
                Camas = propiedadEsperada.Capacidad.Beds,
                Habitaciones = propiedadEsperada.Capacidad.Rooms,
                Personas = propiedadEsperada.Capacidad.People,
                Precio = propiedadEsperada.Precio,
                TipoPropiedad = (TipoPropiedad)propiedadEsperada.TipoPropiedad
            };
            var propiedadId = handler.Handle(evento, tcs.Token);

            Assert.Equal(propiedadEsperada.Id, propiedadId.Result);
        }
    }
}
