namespace GESTOR_TORNEOS.Domain.Ports;

public interface IRepository<T>
{
    bool Add(T entity);
    bool Update(T entity);
    bool Delete(int id);
    T GetById(int id);
    List<T> GetAll();
}
