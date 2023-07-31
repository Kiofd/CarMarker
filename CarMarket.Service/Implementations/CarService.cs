using CarMarket.DAL.Interfaces;
using CarMarket.Domain.Entity_Models_;
using CarMarket.Domain.Enum;
using CarMarket.Domain.Response;
using CarMarket.Domain.ViewModel.Car;
using CarMarket.Service.Interfaces;

namespace CarMarket.Service.Implementations;

public class CarService:ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<IBaseResponse<Car>> GetCar(int id)
    { 
        var baseResponse = new BaseResponse<Car>() { };
        try
        {
            var car = await _carRepository.Get(id);
            if (car == null)
            {
                baseResponse.Description = "User not found";
                baseResponse.StatusCode = StatusCode.UserNotFound;
                return baseResponse;
            }
            baseResponse.Data =car;
            return baseResponse;

        }
        catch (Exception e)
        {
            return new BaseResponse<Car>()
            {
                Description = $"[GetCar]:{e.Message}"
            };
        }

    }
    public async Task<IBaseResponse<Car>> GetCarByName(string name)
    { 
        var baseResponse = new BaseResponse<Car>() { };
        try
        {
            var car = await _carRepository.GetByName(name);
            if (car == null)
            {
                baseResponse.Description = "User not found";
                baseResponse.StatusCode = StatusCode.UserNotFound;
                return baseResponse;
            }
            baseResponse.Data =car;
            return baseResponse;

        }
        catch (Exception e)
        {
            return new BaseResponse<Car>()
            {
                Description = $"[GetByName]:{e.Message}"
            };
        }

    }

    public async Task<IBaseResponse<CarViewModel>> CreateCar(CarViewModel carViewModel)
    {
        var baseResponse = new BaseResponse<CarViewModel>();
        try
        {
            var car = new Car()
            {
                Description   = carViewModel.Description,
                DateCreate = carViewModel.DateCreate,
                Speed = carViewModel.Speed,
                Model = carViewModel.Model,
                Price = carViewModel.Price,
                Name = carViewModel.Name,
                TypeCar = (TypeCar)Convert.ToInt32(carViewModel.TypeCar)
            };
            
            await _carRepository.Create(car);
        }
        catch (Exception e)
        {
            return new BaseResponse<CarViewModel>()
            {
                Description = $"[CreateCar]:{e.Message}"
            };
        }

        return baseResponse;
    }

    public async Task<IBaseResponse<bool>> DeleteCar(int id)
    {
        var baseResponse = new BaseResponse<bool>()
        {
            Data = false
        };
        try
        {
            var car = await _carRepository.Get(id);
            if (car == null)
            {
                baseResponse.Description = "User not found";
                baseResponse.StatusCode = StatusCode.UserNotFound;
                baseResponse.Data = false;
                return baseResponse;
            }
            baseResponse.Data = true;
            await _carRepository.Delete(car);
            
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Description = $"[DeleteCar]:{e.Message}"
            };
        }

        return baseResponse;

    }

    public async Task<IBaseResponse<IEnumerable<Car>>> GetCars()
    {
        var baseResponse = new BaseResponse<IEnumerable<Car>>() { };
        try
        {
            var cars = await _carRepository.Select();

            if (cars.Count == 0)
            {
                baseResponse.Description = "Found 0 element";
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }

            baseResponse.Data = cars;
            baseResponse.StatusCode = StatusCode.OK;

            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<Car>>()
            {
                Description = $"[GetCars]:{e.Message}"
            };
        }
    }
}