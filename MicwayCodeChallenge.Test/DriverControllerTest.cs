using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MicwayCodeChallenge.Controllers;
using MicwayCodeChallenge.Entities;
using MicwayCodeChallenge.RepositoryServices;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace MicwayCodeChallenge.Test
{
    public class DriverControllerTests
    {
        private readonly Mock<IDriverRepository> repositoryStub = new Mock<IDriverRepository>();
        private readonly Mock<ILogger<DriverController>> loggerStub = new Mock<ILogger<DriverController>>();
        private readonly DriverController driverController;


        public DriverControllerTests()
        {
            driverController = new DriverController(loggerStub.Object, repositoryStub.Object);
        }

        [Fact]
        public async Task GetDriverAsync_WithUnExistingDriver_ShouldReturnNotFound()
        {
             //Arrange

         repositoryStub.Setup(repo => repo.GetDriverByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Driver)null);
           

            //Act
            var result = await  driverController.GetDriverAsync(Guid.NewGuid());
           
            //Assert

            Assert.IsType<NotFoundResult>(result.Result);



        }
        
        [Fact]
        public async Task GetDriverAsync_WithExistingDriver_ShouldReturnExistingDriver()
        {
            // Arrange
            var expectedDriver = CreateRandomDriver();

            repositoryStub.Setup(repo => repo.GetDriverByIdAsync(It.IsAny<Guid>())).ReturnsAsync(expectedDriver);
           

            //Act
            var response = await driverController.GetDriverAsync(Guid.NewGuid());

            //Assert
            var okObject = Assert.IsType<OkObjectResult>(response.Result);
            var result = Assert.IsType<Driver>(okObject.Value);
            Assert.IsType<Driver>(okObject.Value);
            Assert.Equal(expectedDriver.FirstName, result.FirstName);
            
        }
        
        [Fact]
        public async Task CreateDriverAsync_WithNewDriver_ShouldReturnNewDriver()
        {
            // Arrange
         var newDriver = CreateRandomDriver();
         repositoryStub.Setup(repo => repo.AddDriverAsync(newDriver)).ReturnsAsync(newDriver);
         
         //Act
         var response = await driverController.AddDriverAsync(newDriver);

         //Assert
         var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(response);
         var result = Assert.IsType<Driver>(createdAtActionResult.Value);
         Assert.Equal(newDriver.FirstName, result.FirstName);

        }
        
        [Fact]
        public async Task CreateDriverAsync_WithNewDriver_ShouldThrowException()
        {
            // Arrange
            var newDriver = CreateRandomDriver();
            repositoryStub.Setup(repo => repo.AddDriverAsync(newDriver)).Throws(new Exception("error while inserting driver"));

            //Act
            var response = await driverController.AddDriverAsync(newDriver);

            //Assert
            var objectResult = Assert.IsType<ObjectResult>(response);
            Assert.Equal(objectResult.StatusCode, (int)HttpStatusCode.InternalServerError);

        }

        [Fact]
        public void DeleteDriverAsync_ShouldReturnOk()
        {
            // Arrange
            Guid driverId = Guid.NewGuid();
            repositoryStub.Setup(repo => repo.DeleteDriverAsync(driverId));

            // Act
            var response = driverController.DeleteDriverAsync(driverId);

            // Assert
            var okObjectResult = Assert.IsType<OkResult>(response.Result);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

        }


        [Fact]
        public void UpdateDriverAsync_ShouldReturnOk()
        {
            // Arrange
            Driver updateDriver = CreateRandomDriver();
            repositoryStub.Setup(repo => repo.UpdateDriverAsync(updateDriver));

            // Act
            var response = driverController.UpdateDriverAsync(updateDriver.Id, updateDriver);

            // Assert
            var okObjectResult = Assert.IsType<OkResult>(response.Result);
            Assert.Equal(okObjectResult.StatusCode, (int)HttpStatusCode.OK);

        }



        [Fact]
        public void DeleteDriverAsync_ShouldReturnInternalServerErrorException()
        {
            // Arrange
            Guid driverId = Guid.NewGuid();
            repositoryStub.Setup(repo => repo.DeleteDriverAsync(driverId)).Throws(new Exception());

            // Act
            var response = driverController.DeleteDriverAsync(driverId);

            //Assert
            var objectResult = Assert.IsType<ObjectResult>(response.Result);
            Assert.Equal(objectResult.StatusCode, (int)HttpStatusCode.InternalServerError);

        }


        [Fact]
        public void ListDriversAsync_ShouldReturnList()
        {
            // Arrange
            var driverList = GetDriverList();
            repositoryStub.Setup(repo => repo.GetDriverListAsync()).ReturnsAsync(driverList);

            // Act
            var response = driverController.GetDriverListAsync();

            //Assert
            var result = Assert.IsType<List<Driver>>(response.Result);
            Assert.Equal(driverList.Count(), result.Count());

        }


        private Driver CreateRandomDriver()
        {
            return new Driver
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Paul",
                Email = "paul@example.com",
                Dob = new DateTime(2001, 10, 24)

            };
        }

        public IEnumerable<Driver> GetDriverList()
        {
            List<Driver> drivers = new List<Driver>()
            {
                new Driver()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Otto",
                    LastName = "Grissom",
                    Dob = new DateTime(1999, 7, 23),
                    Email = "otto.grissom@micway.com"
                },
                new Driver()
                {
                    Id =Guid.NewGuid(),
                    FirstName = "Fredrick",
                    LastName = "Janson",
                    Dob = new DateTime(1986, 5, 21),
                    Email = "fredrick.janson@micway.com"
                }
            };
            return drivers.AsEnumerable();
        }
    }
    
}
