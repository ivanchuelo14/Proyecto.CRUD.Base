using Proyecto.CRUD.Base.Domain;

namespace Proyecto.CRUD.Base.Aplicacion.Services
{
    public interface IEstudianteService
    {
        public List<Estudiante> GetAllEstudiantes();
        public bool CrearEstudiante(Estudiante estudiante);
        public Estudiante GetEstudianteById(Guid Id);
        public bool ActualizarEstudiante(Estudiante estudiante);
        public bool BorrarEstudiante(Guid Id);
    }
}
