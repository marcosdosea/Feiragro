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