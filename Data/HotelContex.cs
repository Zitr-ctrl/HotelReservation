using Microsoft.EntityFrameworkCore;
using SistemaHotel.Models;

namespace SistemaHotel.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) 
            : base(options)
        {
        }
        
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configurar relaciones
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Cliente)
                .WithMany(c => c.Reservas)
                .HasForeignKey(r => r.ClienteId);
                
            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Habitacion)
                .WithMany(h => h.Reservas)
                .HasForeignKey(r => r.HabitacionId);
                
            // Datos iniciales de habitaciones
            modelBuilder.Entity<Habitacion>().HasData(
                new Habitacion 
                { 
                    Id = 1, 
                    Numero = "101", 
                    Tipo = TipoHabitacion.Individual, 
                    Capacidad = 1, 
                    PrecioPorNoche = 50, 
                    Descripcion = "Habitación individual básica" 
                },
                new Habitacion 
                { 
                    Id = 2, 
                    Numero = "102", 
                    Tipo = TipoHabitacion.Doble, 
                    Capacidad = 2, 
                    PrecioPorNoche = 80, 
                    Descripcion = "Habitación doble confortable" 
                },
                new Habitacion 
                { 
                    Id = 3, 
                    Numero = "201", 
                    Tipo = TipoHabitacion.Suite, 
                    Capacidad = 4, 
                    PrecioPorNoche = 150, 
                    Descripcion = "Suite de lujo" 
                },
                new Habitacion 
                { 
                    Id = 4, 
                    Numero = "301", 
                    Tipo = TipoHabitacion.Familiar, 
                    Capacidad = 6, 
                    PrecioPorNoche = 120, 
                    Descripcion = "Habitación familiar amplia" 
                }
            );
        }
    }
}