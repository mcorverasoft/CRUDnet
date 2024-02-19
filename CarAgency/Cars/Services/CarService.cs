using System;
using Cars.DataAccess;
using Cars.Models;
using Cars.DTOs;
using AutoMapper;

namespace Cars.Services
{
    public class CarService
    {
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;

        public CarService(ApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<CarDTO> GetCars()
        {
            var cars= _dbContext.Car.ToList();
            var carsDTO = _mapper.Map<IEnumerable<CarDTO>>(cars);

            return _mapper.Map<IEnumerable<CarDTO>>(cars);
        }

        public void AddCar(CarDTO carDTO)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, Car>());
            var mapper = new Mapper(config);
            Car car = mapper.Map<CarDTO, Car>(carDTO);

            try
            {
                _dbContext.Car.Add(car);
                _dbContext.SaveChanges();
            }
            catch (Exception e) {
               
            }
           
        }


        public bool UpdateCar(long id, CarDTO carDTO)
        {
            bool updated = false;
            var carToUpdate = _dbContext.Car.Find(id);

            if (carToUpdate == null)
                return false;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CarDTO, Car>());
            var mapper = new Mapper(config);
            Car car = mapper.Map<CarDTO, Car>(carDTO);
            car.id = id;
            try
            {
                _dbContext.Car.Update(car);
                _dbContext.SaveChanges();
                updated = true;
            }
            catch (Exception e)
            {

            }

            return updated;

        }


        public bool DeleteCar(long id)
        {
            bool deleted=false;
            try
            {
                var carToDelete = _dbContext.Car.Find(id);

                if (carToDelete != null)
                {
                    _dbContext.Car.Remove(carToDelete);
                    _dbContext.SaveChanges();
                    deleted = true;
                }
                else
                    deleted = false;
            }
            catch (Exception e)
            {
                
            }
            return deleted;
        }

        public CarDTO GetCarById(long id)
        {
            CarDTO carDTO = null;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Car, CarDTO>());
            var mapper = new Mapper(config);
            

            try
            {
                var car = _dbContext.Car.Find(id);

                if (car != null)
                    carDTO = mapper.Map<Car, CarDTO>(car);
                    
            }
            catch (Exception e)
            {

            }
            return carDTO;
        }

    }

}

