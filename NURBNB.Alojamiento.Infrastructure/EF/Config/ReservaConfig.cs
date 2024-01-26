using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Model.Reserva;
using NURBNB.Alojamiento.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.Config
{
    public class ReservasConfig : IEntityTypeConfiguration<ReservaPropiedad>
    {
        public void Configure(EntityTypeBuilder<ReservaPropiedad> builder)
        {
            builder.ToTable("reservapropiedad");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("reservaId");

            builder.Property(x => x.FechaEntrada)
                .HasColumnName("fechaEntrada");

            builder.Property(x => x.FechaSalida)
                .HasColumnName("fechaSalida");

            builder.Property(x => x.FechaCreacion)
                .HasColumnName("FechaCreacion");

            var tipoConverter = new ValueConverter<EstadoReserva, string>(
                tipoEnumValue => tipoEnumValue.ToString(),
                tipo => (EstadoReserva)Enum.Parse(typeof(EstadoReserva), tipo)
            );

            builder.Property(x => x.EstadoReserva)
                 .HasConversion(tipoConverter)
                 .HasColumnName("estadoReserva")
                 .HasMaxLength(20)
                 .IsRequired();

            var tipoPagoConverter = new ValueConverter<TipoPago, string>(
                tipoEnumValue => tipoEnumValue.ToString(),
                tipo => (TipoPago)Enum.Parse(typeof(TipoPago), tipo)
            );

            builder.Property(x => x.TipoPago)
                 .HasConversion(tipoPagoConverter)
                 .HasColumnName("TipoPago")
                 .HasMaxLength(20)
                 .IsRequired();

            var montoTotalConverter = new ValueConverter<Precio, decimal>(
                montoTotalValue => montoTotalValue.Value,
                montoTotal => new Precio(montoTotal)
            );

            builder.Property(x => x.MontoTotal)
                .HasConversion(montoTotalConverter)
                .HasColumnName("montoTotal");

            builder.Property(x => x.PropiedadId).HasColumnName("propiedadId");
            builder.Property(x => x.GuestId).HasColumnName("guestId");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
