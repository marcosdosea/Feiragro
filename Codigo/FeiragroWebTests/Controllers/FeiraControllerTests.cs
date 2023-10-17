using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeiragroWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Core.Service;
using AutoMapper;
using FeiragroWeb.Mappers;
using Core;
using Microsoft.AspNetCore.Mvc;
using FeiragroWeb.Models;
using System.Diagnostics;
using MySqlX.XDevAPI;

namespace FeiragroWeb.Controllers.Tests
{
    [TestClass()]
    public class FeiraControllerTests
    {

        private static FeiraController? controller;

        [TestInitialize]
        public void Initialize()
        {
            var mockService = new Mock<IFeiraService>();

            IMapper mapper = new MapperConfiguration(cfg => cfg.AddProfile(new FeiraProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll()).Returns(GetTestFeiras());

            mockService.Setup(service => service.Get(1)).Returns(GetTargetFeira());

            mockService.Setup(service => service.Edit(It.IsAny<Feira>())).Verifiable();

            mockService.Setup(service => service.Create(It.IsAny<Feira>())).Verifiable();

            controller = new FeiraController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            var result = controller?.Index();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<FeiraModel>));

            List<FeiraModel>? lista = (List<FeiraModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(FeiraModel));
            FeiraModel feiraModel = (FeiraModel)viewResult.ViewData.Model;
            Assert.AreEqual(1, feiraModel.Id);
            Assert.AreEqual(2, feiraModel.IdPontoAssociacao);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Arrange
            var newFeiraModel = GetNewFeiraModel();

            // Act
            var result = controller?.Create(newFeiraModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result!;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);

        }

        [TestMethod()]
        public void CreateTestView()
        {
            var result = controller?.Create();
     
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void EditTest()
        {
            // Arrange
            int feiraId = 1;
            var targetFeira = GetTargetFeira();

            // Act
            var result = controller?.Edit(feiraId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result!;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(FeiraModel));
            FeiraModel feiraModel = (FeiraModel)viewResult.ViewData.Model!;

            Assert.AreEqual(targetFeira.Id, feiraModel.Id);
            Assert.AreEqual(targetFeira.IdPontoAssociacao, feiraModel.IdPontoAssociacao);
            Assert.AreEqual(targetFeira.IdAssociacao, feiraModel.IdAssociacao);
            Assert.AreEqual(targetFeira.DataInicio, feiraModel.DataInicio);
            Assert.AreEqual(targetFeira.DataFim, feiraModel.DataFim);
            Assert.AreEqual(targetFeira.Status, feiraModel.Status);
        }

        [TestMethod()]
        public void EditTest_Post()
        {
            // Arrange
            var feiraModel = GetUpdatedFeiraModel();
            var result = controller?.Edit(feiraModel);

            // Act
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result!;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Get()
        {
            // Act
            var result = controller.Delete(GetNewFeiraModel().Id, GetNewFeiraModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Post()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(FeiraModel));
            FeiraModel feiraModel = (FeiraModel)viewResult.ViewData.Model;
            Assert.AreEqual(2, feiraModel.IdPontoAssociacao);
        }

        private static FeiraModel GetUpdatedFeiraModel()
        {
            return new FeiraModel
            {
                Id = 1,
                IdPontoAssociacao = 2, // Atualizar o ponto de associação
                IdAssociacao = 1,
                DataInicio = DateTime.Parse("2023-06-03"),
            };
        }

        private static FeiraModel GetNewFeiraModel()
        {
            return new FeiraModel
            {
                IdPontoAssociacao = 1,
                IdAssociacao = 1,
                DataInicio = DateTime.Parse("2023-06-03"),
            };
        }

        private static Feira GetTargetFeira()
        {
            return new Feira
            {
                Id = 1,
                IdPontoAssociacao = 2,
                IdAssociacao = 1,
                DataInicio = DateTime.Parse("2023-06-08"),
                DataFim = DateTime.Parse("2023-06-10"),
                Status = "ABERTO"
            };
        }

        private static IEnumerable<Feira> GetTestFeiras()
        {
            return new List<Feira>
            {
                new Feira
                {
                    Id = 1,
                    IdPontoAssociacao = 1,
                    IdAssociacao = 1,
                    DataInicio = DateTime.Parse("2023-06-03"),
                    DataFim = DateTime.Parse("2023-06-06"),
                    Status = "ABERTO"
                },
                new Feira
                {
                    Id = 2,
                    IdPontoAssociacao = 1,
                    IdAssociacao = 1,
                    DataInicio = DateTime.Parse("2023-06-04"),
                    DataFim = DateTime.Parse("2023-06-04"),
                    Status = "ABERTO"
                },
                new Feira
                {
                    Id = 3,
                    IdPontoAssociacao = 2,
                    IdAssociacao = 1,
                    DataInicio = DateTime.Parse("2023-06-08"),
                    DataFim = DateTime.Parse("2023-06-10"),
                    Status = "ABERTO"
                }
            };
        }
    }
}