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
    public class PessoaControllerTests
    {
        private static PessoaController? controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IPessoaService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new PessoaProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestPessoa());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetPessoa());
            mockService.Setup(service => service.Edit(It.IsAny<Pessoa>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Pessoa>()))
                .Verifiable();
            controller = new PessoaController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller?.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result!;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<PessoaModel>));

            List<PessoaModel>? lista = (List<PessoaModel>)viewResult.ViewData.Model!;
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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
            PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model!;
            Console.WriteLine(pessoaModel.Nome);
            Assert.AreEqual("Verenilson Vere", pessoaModel.Nome);
            Assert.AreEqual("12345678912",pessoaModel.Cpf);
            Assert.AreEqual(DateTime.Parse("1996-06-21"), pessoaModel.DataNascimento);
            Assert.AreEqual("999999999", pessoaModel.Telefone);
            Assert.AreEqual("PRODUTOR", pessoaModel.TipoPessoa);
            Assert.AreEqual("verelindo@gmail.com", pessoaModel.Email);
            Assert.AreEqual(8, pessoaModel.IdAssociacao);
        }

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
            var result = controller?.Create(GetNewPessoa());

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
            var result = controller?.Create(GetNewPessoa());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
            PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model!;
            Assert.AreEqual(1,pessoaModel.Id);
            Assert.AreEqual("Verenilson Vere", pessoaModel.Nome);
            Assert.AreEqual("12345678912", pessoaModel.Cpf);
            Assert.AreEqual(DateTime.Parse("1996-06-21"), pessoaModel.DataNascimento);
            Assert.AreEqual("999999999", pessoaModel.Telefone);
            Assert.AreEqual("PRODUTOR", pessoaModel.TipoPessoa);
            Assert.AreEqual("verelindo@gmail.com", pessoaModel.Email);
            Assert.AreEqual(8, pessoaModel.IdAssociacao);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller?.Edit(GetTargetPessoaModel().Id, GetTargetPessoaModel());

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
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(PessoaModel));
            PessoaModel pessoaModel = (PessoaModel)viewResult.ViewData.Model!;
            Assert.AreEqual(1, pessoaModel.Id);
            Assert.AreEqual("Verenilson Vere", pessoaModel.Nome);
            Assert.AreEqual("12345678912", pessoaModel.Cpf);
            Assert.AreEqual(DateTime.Parse("1996-06-21"), pessoaModel.DataNascimento);
            Assert.AreEqual("999999999", pessoaModel.Telefone);
            Assert.AreEqual("PRODUTOR", pessoaModel.TipoPessoa);
            Assert.AreEqual("verelindo@gmail.com", pessoaModel.Email);
            Assert.AreEqual(8, pessoaModel.IdAssociacao);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller?.Delete(GetTargetPessoaModel().Id, GetTargetPessoaModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result!;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private static PessoaModel GetNewPessoa()
        {
            return new PessoaModel
            {
                Id = 4,
                Nome = "Rafael Mendez",
                Cpf = "12345678912",
                DataNascimento = DateTime.Parse("1996-06-21"),
                Telefone = "999999999",
                TipoPessoa = "CLIENTE",
                Email = "wwwwqq@gmail.com",
                IdAssociacao = null,
            };
        }
        private static Pessoa GetTargetPessoa()
        {
            return new Pessoa
            {
                Id = 1,
                Nome = "Verenilson Vere",
                Cpf = "12345678912",
                DataNascimento = DateTime.Parse("1996-06-21"),
                Telefone = "999999999",
                TipoPessoa = "PRODUTOR",
                Email = "verelindo@gmail.com",
                IdAssociacao = 8,
            };
        }

        private static PessoaModel GetTargetPessoaModel()
        {
            return new PessoaModel
            {
                Id = 2,
                Nome = "Galvao Galvona Santos",
                Cpf = "12345678912",
                DataNascimento = DateTime.Parse("1997-06-03"),
                Telefone = "999999999",
                TipoPessoa = "ADM",
                Email = "galvoninha@gmail.com",
                IdAssociacao = 8,
            };
        }


        private static IEnumerable<Pessoa> GetTestPessoa()
        {
            return new List<Pessoa>
            {
                new Pessoa
                {
                    Id = 1,
                    Nome = "Ikarus Djei",
                    Cpf = "12345678912",
                    DataNascimento = DateTime.Parse("1996-06-03"),
                    Telefone = "999999999",
                    TipoPessoa = "ADM",
                    Email = "djeicontatme@gmail.com",
                    IdAssociacao = 8,
                },
                new Pessoa
                {
                    Id = 2,
                    Nome = "Edu Eduardo",
                    Cpf = "12345678912",
                    DataNascimento = DateTime.Parse("1996-06-03"),
                    Telefone = "999999999",
                    TipoPessoa = "ADM",
                    Email = "eduardinho@gmail.com",
                    IdAssociacao = null,
                },
                new Pessoa
                {
                    Id = 3,
                    Nome = "Amanda Queiroz",
                    Cpf = "12345678912",
                    DataNascimento = DateTime.Parse("1993-06-03"),
                    Telefone = "999999999",
                    TipoPessoa = "Cliente",
                    Email = "amandaqueiroz@gmail.com",
                    IdAssociacao = null,
                },
            };
        }
    }
}