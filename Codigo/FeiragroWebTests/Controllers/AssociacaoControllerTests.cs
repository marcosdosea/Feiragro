using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoMapper;
using Core.Service;
using Moq;
using FeiragroWeb.Mappers;
using Core;
using FeiragroWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeiragroWeb.Controllers.Tests
{
    [TestClass()]
    public class AssociacaoControllerTests
    {

        private static AssociacaoController? controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IAssociacaoService>();
            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AssociacaoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestAssociacao());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetAssociacao());
            mockService.Setup(service => service.Edit(It.IsAny<Associacao>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Associacao>()))
                .Verifiable();
            controller = new AssociacaoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller?.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result!;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AssociacaoModel>));

            List<AssociacaoModel>? lista = (List<AssociacaoModel>)viewResult.ViewData.Model!;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Act
            var result = controller?.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result!;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AssociacaoModel));
            AssociacaoModel AssociacaoModel = (AssociacaoModel)viewResult.ViewData.Model!;
            Assert.AreEqual("Cooperafir", AssociacaoModel.Nome);
        }

        [TestMethod()]
        public void CreateTest()
        {
            // Act
            var result = controller?.Create();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Valid()
        {
            // Act
            var result = controller?.Create(GetNewAssociacao());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result!;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void CreateTest_Get_Valido()
        {
            // Act
            var result = controller?.Create();
            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod()]
        public void CreateTest_Post_Invalid()
        {
            // Arrange
            controller?.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller?.Create(GetNewAssociacao());

            // Assert
            Assert.AreEqual(1, controller?.ModelState.ErrorCount);
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result!;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void EditTest_Get_Valid()
        {
            // Act
            var result = controller?.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result!;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AssociacaoModel));
            AssociacaoModel AssociacaoModel = (AssociacaoModel)viewResult.ViewData.Model!;
            Assert.AreEqual("Cooperafir", AssociacaoModel.Nome);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller?.Edit(GetTargetAssociacaoModel().Id, GetTargetAssociacaoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result!;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Post_Valid()
        {
            // Act
            var result = controller?.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result!;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AssociacaoModel));
            AssociacaoModel AssociacaoModel = (AssociacaoModel)viewResult.ViewData.Model!;
            Assert.AreEqual("Cooperafir", AssociacaoModel.Nome);
        }

        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller?.Delete(GetTargetAssociacaoModel().Id, GetTargetAssociacaoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result!;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static AssociacaoModel GetTargetAssociacaoModel()
        {
            return new AssociacaoModel
            {
                Id = 1,
                Nome = "Cooperafir",
                Cnpj = "39.243.939/0001-12",
                Email = "ikaruz.music@hotmail.com",
                Cep = "49400-000",
                Uf = "SE",
                Municipio = "Lagarto",
                Rua = "Francisco Loiola da Silva",
                Bairro = "São José",
                Numero = "348",
                Complemento = null,
                Telefone = "79999451583",
                Status = "Ativa",
                Data = DateTime.Parse("2003-09-16")
            };
        }

        private static AssociacaoModel GetNewAssociacao()
        {
            return new AssociacaoModel
            {
                Id = 4,
                Nome = "Vida boa",
                Cnpj = "39.243.939/0001-12",
                Email = "ikaruz4321.music@hotmail.com",
                Cep = "40400-000",
                Uf = "SE",
                Municipio = "Lagarto",
                Rua = "Francisco Loiola da Silva",
                Bairro = "São José",
                Numero = "300",
                Complemento = null,
                Telefone = "79999999999",
                Status = "Ativa",
                Data = DateTime.Parse("2003-09-16")
            };

        }

        private static Associacao GetTargetAssociacao()
        {
            return new Associacao
            {
                Id = 1,
                Nome = "Cooperafir",
                Cnpj = "39.243.939/0001-12",
                Email = "ikaruz.music@hotmail.com",
                Cep = "49400-000",
                Uf = "SE",
                Municipio = "Lagarto",
                Rua = "Francisco Loiola da Silva",
                Bairro = "São José",
                Numero = "348",
                Complemento = null,
                Telefone = "79999451583",
                Status = "Ativa",
                Data = DateTime.Parse("2003-09-16")
            };
        }

        private static IEnumerable<Associacao> GetTestAssociacao()
        {
            return new List<Associacao>
            {
                new Associacao
                {
                    Id = 1,
                    Nome = "Cooperafir",
                    Cnpj = "39.243.939/0001-12",
                    Email = "ikaruz.music@hotmail.com",
                    Cep = "49400-000",
                    Uf = "SE",
                    Municipio = "Lagarto",
                    Rua = "Francisco Loiola da Silva",
                    Bairro = "São José",
                    Numero = "348",
                    Complemento = null,
                    Telefone = "79999451583",
                    Status = "Ativa",
                    Data = DateTime.Parse("2003-09-16")

                },

                new Associacao
                {
                    Id = 2,
                    Nome = "Itafeira",
                    Cnpj = "39.243.939/0001-12",
                    Email = "ikaruz.music@hotmail.com",
                    Cep = "49400-000",
                    Uf = "SE",
                    Municipio = "Lagarto",
                    Rua = "Francisco Loiola da Silva",
                    Bairro = "São José",
                    Numero = "348",
                    Complemento = null,
                    Telefone = "79999451583",
                    Status = "Ativa",
                    Data = DateTime.Parse("2023-10-15")
                },

                new Associacao
                {
                    Id = 3,
                    Nome = "Feira Livre",
                    Cnpj = "39243939000112",
                    Email = "ikaruz.music@hotmail.com",
                    Cep = "49400-000",
                    Uf = "SE",
                    Municipio = "Lagarto",
                    Rua = "Francisco Loiola da Silva",
                    Bairro = "São José",
                    Numero = "348",
                    Complemento = null,
                    Telefone = "79999451583",
                    Status = "Ativa",
                    Data = DateTime.Parse("2023-10-16")

                },
            };
        }
    }
}