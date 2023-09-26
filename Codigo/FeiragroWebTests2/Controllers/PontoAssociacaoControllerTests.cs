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
    public class PontoAssociacaoControllerTests
    {
        private static PontoAssociacaoController? controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IPontoAssociacaoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new PontoAssociacaoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                       .Returns(GetTestPontoAssociacao());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetPontoAssociacao());
            mockService.Setup(service => service.Edit(It.IsAny<Pontoassociacao>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Pontoassociacao>()))
                .Verifiable();
            controller = new PontoAssociacaoController(mockService.Object, mapper);
        }

        private Pontoassociacao GetTargetPontoAssociacao()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Pontoassociacao> GetTestPontoAssociacao()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void PontoAssociacaoControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            var result = controller?.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result!;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PontoAssociacaoModel>));

            List<PontoAssociacaoModel>? lista = (List<PontoAssociacaoModel>)viewResult.ViewData.Model!;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest_Valido()
        {
            var result = controller?.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result!;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PontoAssociacaoModel));
            PontoAssociacaoModel pontoAssociacaoModel = (PontoAssociacaoModel)viewResult.ViewData.Model!;
            Assert.AreEqual("COAGRO", pontoAssociacaoModel.Nome);
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
        public void CreateTest_Valid()
        {
            // Act
            var result = controller?.Create(GetNewPontoAssociacao());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result!;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }


        [TestMethod()]
        public void CreateTest_Post_Invalid()
        {
            // Arrange
            controller?.ModelState.AddModelError("Nome", "Campo requerido");

            // Act
            var result = controller?.Create(GetNewPontoAssociacao());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipoProdutoModel));
            TipoProdutoModel tipoProdutoModel = (TipoProdutoModel)viewResult.ViewData.Model!;
            Assert.AreEqual("COAGRO", tipoProdutoModel.Nome);
        }


        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller?.Edit(GetTargetPontoAssociacaoModel().Id, GetTargetPontoAssociacaoModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipoProdutoModel));
            TipoProdutoModel tipoProdutoModel = (TipoProdutoModel)viewResult.ViewData.Model!;
            Assert.AreEqual("COAGRO", tipoProdutoModel.Nome);
        }


        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller?.Delete(GetTargetPontoAssociacaoModel().Id, GetTargetPontoAssociacaoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result!;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }
        private static PontoAssociacaoModel GetNewPontoAssociacao()
        {
            return new PontoAssociacaoModel
            {
                Id = 4,
                Nome = "EMDAGRO"
            };

        }

        private static PontoAssociacaoModel GetTargetPontoAssociacaoModel()
        {
            return new PontoAssociacaoModel
            {
                Id = 2,
                Nome = "COAGRO"
            };
        }
    }
}