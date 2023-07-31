using CarMarket.Domain.Entity_Models_;

namespace CarMarket.DAL.Interfaces;

public interface ICarRepository:IBaseRepository<Car>
{
    Task<Car> GetByName(string name);
}