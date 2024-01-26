using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NURBNB.Alojamiento.Infrastructure.EF.ReadModel
{
    [Table("reservapropiedad")]
    public class ReservaPropiedadReadModel
    {
        [Key]
        [Column("reservaId")]
        public Guid Id { get; set; }

        [Column("fechaEntrada")]
        [Required]
        public DateTime FechaEntrada { get; set; }

        [Column("fechaSalida")]
        [Required]
        public DateTime FechaSalida { get; set; }

        [Column("fechaCreacion")]
        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        [Column("estadoReserva")]
        [MaxLength(25)]
        public string EstadoReserva { get; set; }

        [Required]
        [Column("tipoPago")]
        [MaxLength(25)]
        public string TipoPago { get; set; }


        [Column("montoTotal", TypeName = "decimal(18,2)")]
        [Required]
        public decimal MontoTotal { get; set; }

        [Column("propiedadId")]
        public Guid PropiedadId { get; set; }

        [Column("guestId")]
        public Guid GuestId { get; set; }
    }
}
