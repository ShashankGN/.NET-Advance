using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_management.Contracts;
using Vehicle_management.Controllers;
using Vehicle_management.DTO;
using Vehicle_management.Models;

namespace Vehicle_management.Tests.Controller
{
    public class VehicleControllerTests
    {
        private readonly Mock<IVehicleRepo> _mockRepo;
        private readonly VehicleController _controller;
        public VehicleControllerTests()
        {
            _mockRepo = new Mock<IVehicleRepo>();
            _controller = new VehicleController(_mockRepo.Object);
        }

        [Fact]
        public void Get_ActionExecutes_ReturnsOkResultWithListOfVehicles()
        {
            _mockRepo.Setup(repo=>repo.GetAll())
                .Returns(new List<VehicleDTO>() { new VehicleDTO(),new VehicleDTO() });
            var expectedStatusCode = System.Net.HttpStatusCode.OK;

            var result=_controller.Get() as OkObjectResult;

            var vehicle = Assert.IsType<List<VehicleDTO>>(result.Value);
            Assert.Equal(2, vehicle.Count());
            Assert.Equal(200,(int)expectedStatusCode);
            result.StatusCode.Should().Be(200);

            _mockRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_ActionExecutes_ReturnsEmptyListOfVehicles()
        {
            _mockRepo.Setup(repo => repo.GetAll())
                .Returns(new List<VehicleDTO>() { });
            var expectedStatusCode = System.Net.HttpStatusCode.OK;

            var result = _controller.Get() as OkObjectResult;

            var vehicle = Assert.IsType<List<VehicleDTO>>(result.Value);
            Assert.Equal(0, vehicle.Count());
            Assert.Equal(200, (int)expectedStatusCode);
            result.StatusCode.Should().Be(200);

            _mockRepo.Verify(repo => repo.GetAll(), Times.Once);
        }

        [Fact]
        public void Get_ActtionExecutes_ReturnsOkResultWithVehicle()
        {
            //List<Vehicle> vehicleList = new List<Vehicle>()
            //{
            //    new Vehicle()
            //    {
            //        Id=1,
            //        Model="X",
            //        ManufactureDate=DateTime.Now,
            //        RegNo="ABC",
            //        CreatedBy="1"
            //    },
            //     new Vehicle()
            //    {
            //        Id=2,
            //        Model="Y",
            //        ManufactureDate=DateTime.Now,
            //        RegNo="EFG",
            //        CreatedBy="2"
            //    }
            //};
            //GetVehicleByIdDTO obj=null;
            var vehicle = new Vehicle { Id = 1, RegNo = "KA-21-EZ-2024", Model = "AUDI", ManufactureDate = new DateTime(2024 - 08 - 23), CreatedBy="Shashank"};
            _mockRepo.Setup(repo => repo.GetVehicleById(1))
                //.Callback<int>(v =>
                //{
                //    var vehicle = vehicleList.FirstOrDefault(x => x.Id == v);
                //})
                .Returns(new GetVehicleByIdDTO
                {
                    Id = vehicle.Id,
                    RegNo = vehicle.RegNo,
                    Model = vehicle.Model,
                    ManufactureDate = vehicle.ManufactureDate
                }
                );

            var result = _controller.Get(1) as OkObjectResult;

            _mockRepo.Verify(repo=>repo.GetVehicleById(It.Is<int>(value=> value==1)),Times.Once);
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            Assert.IsType<GetVehicleByIdDTO>(result.Value);
            var returnedVehicle = result.Value as GetVehicleByIdDTO;
            returnedVehicle.Should().NotBeNull();
            returnedVehicle.Id.Should().Be(vehicle.Id);
            returnedVehicle.RegNo.Should().Be(vehicle.RegNo);
            returnedVehicle.Model.Should().Be(vehicle.Model);
            returnedVehicle.ManufactureDate.Should().Be(vehicle.ManufactureDate);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void Get_ActionExecutes_ReturnsNotFound(int id)
        {
            //_mockRepo.Setup(repo => repo.GetVehicleById(It.IsAny<int>()))
            //    .Returns((GetVehicleByIdDTO)null);
            //_mockRepo.Setup(repo => repo.GetVehicleById(0))
            //          .Returns((GetVehicleByIdDTO)null);

            _mockRepo.Setup(repo => repo.GetVehicleById(id))
                      .Returns((GetVehicleByIdDTO)null);

            var result = _controller.Get(id) as NotFoundObjectResult;

            //Assert.IsType<NotFoundResult>(result);
            Assert.Equal($"vehicle with id {id} is not found", result.Value);
            //result.Should().BeOfType<NotFoundResult>();
            result.StatusCode.Should().Be(404);

            _mockRepo.Verify(repo => repo.GetVehicleById(id), Times.Once);
        }


        [Fact]
        public void Add_Action_Executes_ReturnsOkResultWithMessage()
        {
            var vehicleDTO = new VehicleDTO { RegNo = "KA-21-EZ-2024", Model = "AUDI", ManufactureDate = new DateTime(2024 - 08 - 23) };
            List<Vehicle> vehicleList = new List<Vehicle>() { new Vehicle(), new Vehicle() };
            _mockRepo.Setup(repo => repo.AddVehicle(vehicleDTO))
                .Callback<VehicleDTO>(v =>
                {
                    var vehicle = new Vehicle
                    {
                        Id=1,
                        ManufactureDate = v.ManufactureDate,
                        Model = v.Model,
                        RegNo = v.RegNo,
                        CreatedBy = "Shashank"
                    };
                    vehicleList.Add(vehicle);
                })
                .Returns("Vehicle Added");

            var result = _controller.Add(vehicleDTO) as OkObjectResult;

            Assert.Equal(3,vehicleList.Count);
            Assert.Equal("Vehicle Added", result.Value);
            result.StatusCode.Should().Be(200);
            var addedVehicle = vehicleList[2];
            addedVehicle.RegNo.Should().Be(vehicleDTO.RegNo); 
            addedVehicle.ManufactureDate.Should().Be(vehicleDTO.ManufactureDate);
            addedVehicle.Model.Should().Be(vehicleDTO.Model);

            _mockRepo.Verify(repo => repo.AddVehicle(vehicleDTO), Times.Once);
        }

        [Fact]
        public void Delete_ActionExecutes_ReturnsOkResultWithMessage()
        {
            List<Vehicle> vehicleList = new List<Vehicle>()
            {
                new Vehicle()
                {
                    Id=1,
                    Model="X",
                    ManufactureDate=DateTime.Now,
                    RegNo="ABC",
                    CreatedBy="1"
                },
                 new Vehicle()
                {
                    Id=2,
                    Model="Y",
                    ManufactureDate=DateTime.Now,
                    RegNo="EFG",
                    CreatedBy="2"
                }
            };
            _mockRepo.Setup(repo => repo.DeleteVehicle(1))
                .Callback<int>(v =>
                {
                    var vehicle = vehicleList.FirstOrDefault(x => x.Id == v);
                    vehicleList.Remove(vehicle);
                })
                .Returns(true);

            var result = _controller.Delete(1) as OkObjectResult;

            Assert.Equal("Vehicle with id 1 deleted successfully", result.Value);

        }
    }
}
