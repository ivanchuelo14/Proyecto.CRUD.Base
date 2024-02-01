namespace Proyecto.CRUD.Base.Aplicacion.Repository
{
    public interface IRespository<T> where T : class
    {
        T GetById(Guid Id);
        T GetByIdM(int Id);
        IQueryable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(Guid Id);
    }
}
