using Microsoft.AspNetCore.Mvc;
using Proyecto.CRUD.Base.Aplicacion.Services;
using Proyecto.CRUD.Base.Models;

namespace Proyecto.CRUD.Base.Controllers
{
    public class CursoController : Controller
    {
        private readonly IEstudianteService _estudianteService;

        public CursoController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        public IActionResult Index()
        {
            EstudianteFilterViewModel model = new()
            {
                Estudiantes = _estudianteService.GetAllEstudiantes()
            };

            return View(model);
        }
    }
}
