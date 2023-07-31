using System.ComponentModel.DataAnnotations;

namespace CarMarket.Domain.Enum;

public enum TypeCar
{
    [Display(Name = "Легковий автомобіль")]
    PassengerCar = 0,
    [Display(Name = "Седан")]
    Sedan = 1,
    [Display(Name = "Хетчбек")]
    HatchBack = 2,
    [Display(Name = "Мінівен")]
    Minivan = 3,
    [Display(Name = "Спортивна машина")]
    SportCar = 4,
    [Display(Name = "Позашляховик")]
    Suv = 5,
}