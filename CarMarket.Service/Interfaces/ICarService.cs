using CarMarket.Domain.Entity_Models_;
using CarMarket.Domain.Response;

namespace CarMarket.Service.Interfaces;

public interface ICarService
{
    Task<IBaseResponse<IEnumerable<Car>>> GetCars();
}