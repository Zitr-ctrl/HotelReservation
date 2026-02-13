using System.ComponentModel.DataAnnotations;

namespace SistemaHotel.Models
{
    public class Habitacion
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(10)]
        public string Numero { get; set; } = string.Empty;
        
        [Required]
        public TipoHabitacion Tipo { get; set; }
        
        [Required]
        [Range(1, 10)]
        public int Capacidad { get; set; }
        
        [Required]
        [Range(0, double.MaxValue)]
        public decimal PrecioPorNoche { get; set; }
        
        public bool Disponible { get; set; } = true;
        
        public string? Descripcion { get; set; }
        
        // Relación con reservas
        public ICollection<Reserva>? Reservas { get; set; }
    }
    
    public enum TipoHabitacion
    {
        Individual,
        Doble,
        Suite,
        Familiar
    }
}