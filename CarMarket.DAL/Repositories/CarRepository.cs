﻿using CarMarket.DAL.Interfaces;
using CarMarket.Domain.Entity_Models_;
using Microsoft.EntityFrameworkCore;

namespace CarMarket.DAL.Repositories;

public class CarRepository:ICarRepository
{
    private readonly ApplicationDbContext _db;

    public CarRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<bool> Create(Car entity)
    {
       await _db.Car.AddAsync(entity);
       await _db.SaveChangesAsync();

       return true;
    }

    public async Task<Car> Get(int id)
    {
        return await _db.Car.FirstOrDefaultAsync(x => x.Id == id );
    }

    public async Task<List<Car>> Select()
    {
        return await _db.Car.ToListAsync();
    }

    public async Task<bool> Delete(Car entity)
    {
       _db.Car.Remove(entity);
       await _db.SaveChangesAsync();

       return true;
    }

    public async Task<Car> GetByName(string name)
    {
        return await _db.Car.FirstOrDefaultAsync(x => x.Name == name );
    }
}