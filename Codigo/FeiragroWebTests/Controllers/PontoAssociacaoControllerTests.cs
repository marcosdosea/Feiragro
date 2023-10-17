using Microsoft.VisualStudio.TestTools.UnitTesting;
using FeiragroWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller?.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result!;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PontoAssociacaoModel>));

            List<PontoAssociacaoModel>? lista = (List<PontoAssociacaoModel>)viewResult.ViewData.Model!;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PontoAssociacaoModel));
            PontoAssociacaoModel pontoAssociacaoModel = (PontoAssociacaoModel)viewResult.ViewData.Model;
            Assert.AreEqual(0, pontoAssociacaoModel.IdAssociacao);
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
            var result = controller?.Create(GetNewPontoAssociacao());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result!;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void EditTest()
        {
            // Act
            var result = controller?.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result!;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PontoAssociacaoModel));
            PontoAssociacaoModel pontoAssociacaoModel = (PontoAssociacaoModel)viewResult.ViewData.Model!;
            Assert.AreEqual(0, pontoAssociacaoModel.IdAssociacao);
        }

        [TestMethod()]
        public void EditTest1()
        {
            // Act
            var result = controller?.Edit(GetTargetPontoAssociacaoModel().IdAssociacao, GetTargetPontoAssociacaoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result!;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Act
            var result = controller.Delete(GetNewPontoAssociacaoModel().IdAssociacao, GetNewPontoAssociacaoModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest1()
        {
            // Act
            var result = controller?.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result!;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PontoAssociacaoModel));
            PontoAssociacaoModel pontoAssociacaoModel = (PontoAssociacaoModel)viewResult.ViewData.Model!;
            Assert.AreEqual(0, pontoAssociacaoModel.IdAssociacao);
        }

        private static PontoAssociacaoModel GetTargetPontoAssociacaoModel()
        {
            return new PontoAssociacaoModel
            {

                Cep = "49500-000",
                Complemento = "Atrás do bar do zequinha",
                Uf = "SE",
                Municipio = "Lagarto",
                Rua = "Francisco Silva da Silva Silva",
                Numero = 348,
                Bairro = "São José",

            };
        }

        private static PontoAssociacaoModel GetNewPontoAssociacao()
        {
            return new PontoAssociacaoModel
            {
                Cep = "49500-000",
                Complemento = "Atrás do bar do zequinha",
                Uf = "SE",
                Municipio = "Lagarto",
                Rua = "Francisco Silva da Silva Silva",
                Numero = 348,
                Bairro = "São José",
            };
        }

        private static PontoAssociacaoModel GetNewPontoAssociacaoModel()
        {
            return new PontoAssociacaoModel
            {
                Cep = "49500-000",
                Complemento = "Atrás do bar do zequinha",
                Uf = "SE",
                Municipio = "Lagarto",
                Rua = "Francisco Silva da Silva Silva",
                Numero = 348,
                Bairro = "São José",
            };
        }

        private Pontoassociacao GetTargetPontoAssociacao()
        {
            return new Pontoassociacao
            {
                Cep = "49500-000",
                Complemento = "Atrás do bar do zequinha",
                Uf = "SE",
                Municipio = "Lagarto",
                Rua = "Francisco Silva da Silva Silva",
                Numero = 348,
                Bairro = "São José",
            };
        }

        private IEnumerable<Pontoassociacao> GetTestPontoAssociacao()
        {
            return new List<Pontoassociacao>
            {
                new Pontoassociacao
                {
                    Cep = "49500-000",
                    Complemento = "Atrás do bar do zequinha",
                    Uf = "SE",
                    Municipio = "Lagarto",
                    Rua = "Francisco Silva da Silva Silva",
                    Numero = 348,
                    Bairro = "São José",
                },

                new Pontoassociacao
                {
                    Cep = "49600-000",
                    Complemento = "Na frente da mercearia do Seu Nestor",
                    Uf = "SE",
                    Municipio = "Itabaiana",
                    Rua = "Francisco Silveira da Silva Silvana",
                    Numero = 349,
                    Bairro = "José",
                },

                new Pontoassociacao
                {
                    Cep = "49700-000",
                    Complemento = "Ao lado do culto do Pastor Zequias",
                    Uf = "SE",
                    Municipio = "Aracaju",
                    Rua = "Francisco Silva da Silva",
                    Numero = 350,
                    Bairro = "José São",
                },
            };
        }
    }
}