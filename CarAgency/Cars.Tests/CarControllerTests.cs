namespace Cars.Tests;

using Xunit;
using Moq;
using Cars.Controllers;
using Cars.Services;
using Cars.Models;
using Cars.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

public class CarControllerTests
{
    [Fact]
    public void GetCars_ReturnsOkResult()
    {
        // Arrange
        var carServiceMock = new Mock<CarService>();
        carServiceMock.Setup(service => service.GetCars()).Returns(new List<CarDTO>());

        var controller = new CarController(carServiceMock.Object);

        // Act
        var result = controller.GetCars();

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void getCarById_WithValidId_ReturnsOkResult()
    {
        // Arrange
        var carServiceMock = new Mock<CarService>();
        carServiceMock.Setup(service => service.GetCarById(It.IsAny<long>())).Returns(new CarDTO());

        var controller = new CarController(carServiceMock.Object);

        // Act
        var result = controller.getCarById(1);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void AddCar_ReturnsOkResult()
    {
        // Arrange
        var carServiceMock = new Mock<CarService>();

        var controller = new CarController(carServiceMock.Object);

        // Act
        var result = controller.AddCar(new CarDTO());

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void UpdateCar_WithValidId_ReturnsOkResult()
    {
        // Arrange
        var carServiceMock = new Mock<CarService>();
        carServiceMock.Setup(service => service.UpdateCar(It.IsAny<int>(), It.IsAny<CarDTO>())).Returns(true);

        var controller = new CarController(carServiceMock.Object);

        // Act
        var result = controller.UpdateCar(1, new CarDTO());

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void UpdateCar_WithInvalidId_ReturnsNotFoundResult()
    {
        // Arrange
        var carServiceMock = new Mock<CarService>();
        carServiceMock.Setup(service => service.UpdateCar(It.IsAny<int>(), It.IsAny<CarDTO>())).Returns(false);

        var controller = new CarController(carServiceMock.Object);

        // Act
        var result = controller.UpdateCar(1, new CarDTO());

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }

    [Fact]
    public void DeleteCar_WithValidId_ReturnsOkResult()
    {
        // Arrange
        var carServiceMock = new Mock<CarService>();
        carServiceMock.Setup(service => service.DeleteCar(It.IsAny<long>())).Returns(true);

        var controller = new CarController(carServiceMock.Object);

        // Act
        var result = controller.DeleteCar(1);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void DeleteCar_WithInvalidId_ReturnsNotFoundResult()
    {
        // Arrange
        var carServiceMock = new Mock<CarService>();
        carServiceMock.Setup(service => service.DeleteCar(It.IsAny<long>())).Returns(false);

        var controller = new CarController(carServiceMock.Object);

        // Act
        var result = controller.DeleteCar(1);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result);
    }
}

