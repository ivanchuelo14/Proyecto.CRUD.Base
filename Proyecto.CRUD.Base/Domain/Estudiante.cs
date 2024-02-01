namespace Proyecto.CRUD.Base.Domain
{
    public class Estudiante
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
