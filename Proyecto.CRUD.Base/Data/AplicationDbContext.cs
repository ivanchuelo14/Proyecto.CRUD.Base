using Microsoft.EntityFrameworkCore;
using Proyecto.CRUD.Base.Domain;

namespace Proyecto.CRUD.Base.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<EstudianteCurso> EstudianteCursos { get; set; }
    }
}
