﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NURBNB.Alojamiento.Domain.Model.Alojamiento;
using NURBNB.Alojamiento.Domain.Model.Reserva;
using NURBNB.Alojamiento.Infrastructure.EF.Config;
using NURBNB.Alojamiento.Infrastructure.EF.ReadModel;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NURBNB.Alojamiento.Infrastructure.EF.Context
{
	public class WriteDbContext : DbContext
	{
		public virtual DbSet<Pais> Pais { set; get; }
		public virtual DbSet<Ciudad> Ciudad { set; get; }
		public virtual DbSet<Propiedad> Propiedad { set; get; }
		public virtual DbSet<Direccion> Direccion { set; get; }
		public virtual DbSet<Comodidad> Comodidad { set; get; }
		public virtual DbSet<PropiedadComodidad> PropiedadComodidad { set; get; }
		public virtual DbSet<ReservaPropiedad> ReservaPropiedad { set; get; }

		public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var paisConfig = new PaisConfig();
			modelBuilder.ApplyConfiguration(paisConfig);

			var ciudadConfig = new CiudadConfig();
			modelBuilder.ApplyConfiguration<Ciudad>(ciudadConfig);

			var propiedadConfig = new PropiedadConfig();
			modelBuilder.ApplyConfiguration<Propiedad>(propiedadConfig);
			modelBuilder.ApplyConfiguration<PropiedadComodidad>(propiedadConfig);

			var reservaConfig = new ReservasConfig();
			modelBuilder.ApplyConfiguration<ReservaPropiedad>(reservaConfig);

			modelBuilder.Ignore<DomainEvent>();
		}
	}
}
