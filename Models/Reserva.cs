using System.ComponentModel.DataAnnotations;

namespace SistemaHotel.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        
        // Relación con Cliente
        [Required]
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        
        // Relación con Habitación
        [Required]
        public int HabitacionId { get; set; }
        public Habitacion? Habitacion { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaEntrada { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaSalida { get; set; }
        
        [Range(1, 20)]
        public int NumeroHuespedes { get; set; }
        
        [Required]
        [Range(0, double.MaxValue)]
        public decimal PrecioTotal { get; set; }
        
        public EstadoReserva Estado { get; set; } = EstadoReserva.Pendiente;
        
        public string? Observaciones { get; set; }
        
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
    }
    
    public enum EstadoReserva
    {
        Pendiente,
        Confirmada,
        CheckIn,
        CheckOut,
        Cancelada
    }
}