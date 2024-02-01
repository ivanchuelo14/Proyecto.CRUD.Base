namespace Proyecto.CRUD.Base.Domain
{
    public class EstudianteCurso
    {
        public Guid Id { get; set; }
        public int CursoId { get; set; }
        public Guid EstudianteId { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
