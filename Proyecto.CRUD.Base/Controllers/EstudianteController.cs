using Microsoft.AspNetCore.Mvc;
using Proyecto.CRUD.Base.Aplicacion.Services;
using Proyecto.CRUD.Base.Domain;
using Proyecto.CRUD.Base.Models;

namespace Proyecto.CRUD.Base.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly IEstudianteService _estudianteService;

        public EstudianteController(IEstudianteService estudianteService)
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

        public IActionResult New()
        {
            EstudianteViewModel model = new();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                Estudiante estudiante = new()
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    FechaNacimiento = model.FechaNacimiento,
                    NumeroDocumento = model.NumeroDocumento
                };

                var result = _estudianteService.CrearEstudiante(estudiante);
                if (result != null)
                {
                    TempData["AlertMessage"] = "Estudiante creado con éxito";
                    return RedirectToAction("Index", "Estudiante");
                }
            }
            return View(model);
        }

        public IActionResult Edit(Guid Id)
        {
            var estudiante = _estudianteService.GetEstudianteById(Id);
            if (estudiante != null)
            {
                EstudianteViewModel model = new()
                {
                    Nombre = estudiante.Nombre,
                    Apellido = estudiante.Apellido,
                    FechaNacimiento = estudiante.FechaNacimiento,
                    NumeroDocumento = estudiante.NumeroDocumento
                };
                return View(model);
            }

            TempData["AlertMessageWarning"] = "Ocurrio un error al consultar el estudiante";
            return RedirectToAction("Index", "Estudiante");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EstudianteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var estudiante = _estudianteService.GetEstudianteById(model.Id);
                if (estudiante != null)
                {
                    estudiante.NumeroDocumento = model.NumeroDocumento;
                    estudiante.FechaNacimiento = model.FechaNacimiento;
                    estudiante.Apellido = model.Apellido;

                    var result = _estudianteService.ActualizarEstudiante(estudiante);
                    if (result)
                    {
                        TempData["AlertMessage"] = "Estudiante actualizado con éxito";
                        return RedirectToAction("Index", "Estudiante");
                    }
                }
                else
                {
                    TempData["AlertMessageWarning"] = "Ocurrio un error al consultar el estudiante";
                    return RedirectToAction("Index", "Estudiante");
                }
            }
            return View(model);
        }

        public IActionResult Delete(Guid Id)
        {
            var estudiante = _estudianteService.GetEstudianteById(Id);
            if (estudiante != null)
            {
                var result = _estudianteService.BorrarEstudiante(Id);
                if (result)
                {
                    TempData["AlertMessage"] = "Estudiante creado con éxito";
                    return RedirectToAction("Index", "Estudiante");
                }
            }
            TempData["AlertMessageWarning"] = "Ocurrio un error al consultar el estudiante";
            return RedirectToAction("Index", "Estudiante");
        }
    }
}
