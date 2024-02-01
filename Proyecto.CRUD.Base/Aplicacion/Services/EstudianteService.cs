using Proyecto.CRUD.Base.Aplicacion.Repository;
using Proyecto.CRUD.Base.Domain;

namespace Proyecto.CRUD.Base.Aplicacion.Services
{
    public class EstudianteService : IEstudianteService
    {

        private readonly IRespository<Estudiante> _EstudianteRespository;

        public EstudianteService(IRespository<Estudiante> estudianteRespository)
        {
            _EstudianteRespository = estudianteRespository;
        }

        public bool ActualizarEstudiante(Estudiante estudiante)
        {
            var result = false;
            try
            {
                var getEstudiante = _EstudianteRespository.GetById(estudiante.Id);
                if (getEstudiante != null)
                {
                    getEstudiante.FechaNacimiento = estudiante.FechaNacimiento;
                    getEstudiante.Nombre = estudiante.Nombre;
                    getEstudiante.Apellido = estudiante.Apellido;
                    _EstudianteRespository.Update(getEstudiante);
                    result = true;
                }
                else
                    result = false;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool BorrarEstudiante(Guid Id)
        {
            var result = false;
            try
            {
                _EstudianteRespository.Delete(Id);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool CrearEstudiante(Estudiante estudiante)
        {
            try
            {
                _EstudianteRespository.Create(estudiante);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Estudiante> GetAllEstudiantes()
        {
            try
            {
                var result = _EstudianteRespository.GetAll().ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Estudiante GetEstudianteById(Guid Id)
        {
            return _EstudianteRespository.GetById(Id);
        }
    }

}
