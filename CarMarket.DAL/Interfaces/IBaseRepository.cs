using CarMarket.Domain.Entity_Models_;

namespace CarMarket.DAL.Interfaces;

public interface IBaseRepository<T>
{
    Task<bool> Create(T entity);

    Task<T> Get(int id);

    Task<List<T>> Select();

    Task<bool> Delete(T entity);
    
}