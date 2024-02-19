using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Services;
using Microsoft.AspNetCore.Mvc;
using Cars.Models;
using Cars.DTOs;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cars.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly CarService _carService;

        public CarController(CarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _carService.GetCars();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult getCarById(long id)
        {
            var car = _carService.GetCarById(id);
            return Ok(car);
        }

        [HttpPost]
        public IActionResult AddCar([FromBody] CarDTO car)
        {
            _carService.AddCar(car);
            return Ok("Vehículo agregado exitosamente.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(long id, [FromBody] CarDTO car)
        {
            if(_carService.UpdateCar(id, car))
                return Ok("Vehículo actualizado exitosamente.");
            else
                return NotFound("Vehículo no encontrado");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(long id)
        {
           if(_carService.DeleteCar(id))
                return Ok("Vehículo eliminado exitosamente.");
           else
                return NotFound("Vehículo no encontrado");
        }
    }
}

