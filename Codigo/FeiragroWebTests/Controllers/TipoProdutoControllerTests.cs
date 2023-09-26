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
    public class TipoProdutoControllerTests
    {
        private static TipoProdutoController? controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<ITipoProdutoService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new TipoProdutoProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestTipoProdutos());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetTipoProduto());
            mockService.Setup(service => service.Edit(It.IsAny<Tipoproduto>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Tipoproduto>()))
                .Verifiable();
            controller = new TipoProdutoController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller?.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result!;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<TipoProdutoModel>));

            List<TipoProdutoModel>? lista = (List<TipoProdutoModel>)viewResult.ViewData.Model!;
            Assert.AreEqual(3, lista.Count);
        }


        [TestMethod()]
        public void DetailsTest_Valido()
        {
            // Act
            var result = controller?.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result!;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(TipoProdutoModel));
            TipoProdutoModel tipoProdutoModel = (TipoProdutoModel)viewResult.ViewData.Model!;
            Assert.AreEqual("Fruta", tipoProdutoModel.Nome);

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
            var result = controller?.Create(GetNewTipoProduto());

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
            var result = controller?.Create(GetNewTipoProduto());

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
            Assert.AreEqual("Fruta", tipoProdutoModel.Nome);
        }


        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller?.Edit(GetTargetTipoProdutoModel().Id, GetTargetTipoProdutoModel());

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
            Assert.AreEqual("Fruta", tipoProdutoModel.Nome);
        }


        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller?.Delete(GetTargetTipoProdutoModel().Id, GetTargetTipoProdutoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result!;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static TipoProdutoModel GetNewTipoProduto()
        {
            return new TipoProdutoModel
            {
                Id = 4,
                Nome = "Pimenta"
            };

        }
        private static Tipoproduto GetTargetTipoProduto()
        {
            return new Tipoproduto
            {
                Id = 1,
                Nome = "Fruta"
            };
        }

        private static TipoProdutoModel GetTargetTipoProdutoModel()
        {
            return new TipoProdutoModel
            {
                Id = 2,
                Nome = "Fruta"
            };
        }


        private static IEnumerable<Tipoproduto> GetTestTipoProdutos()
        {
            return new List<Tipoproduto>
            {
                new Tipoproduto
                {
                    Id = 1,
                    Nome = "Doce",

                },
                new Tipoproduto
                {
                    Id = 2,
                    Nome = "Fruta"
                },
                new Tipoproduto
                {
                    Id = 3,
                    Nome = "Folhas"

                },
            };
        }
    }
}