using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        //DBset de prueba proximo a eliminar en futuros refactorings...
        public DbSet<TodoItem> TodoItems { get; set; }

        //DBset de Eventos
        public DbSet<Event> EventItems { get; set; }
        //DBset de Organizaciones-Usuarios
        public DbSet<Organization> OrganizationItems { get; set; }

    }
}