using Moq;
using web_app_domain;
using web_app_repository;
using web_app_performance.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Test
{
    public class ProdutoControllerTest
    {
        private readonly Mock<IProdutoRepository> _productRepositoryMock;
        private readonly ProdutoController _controller;

        public ProdutoControllerTest()
        {
            _productRepositoryMock = new Mock<IProdutoRepository>();
            _controller = new ProdutoController(_productRepositoryMock.Object);
        }

        [Fact]

        public async Task Get_ListarProdutosOk()
        {
            //Arrange
            var Produtos = new List<Produto>()
            {
                new Produto()
                {
                    Nome = "lapis",
                    Id = 1,
                    Preco = 5.0,
                    DataCriacao = "20/10/2024",
                    QuantidadeEstoque = 100
                }
            };
            _productRepositoryMock.Setup(r => r.ListarProdutos()).ReturnsAsync(Produtos);

            //Act
            var result = await _controller.GetProduto();

            //Asserts
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(JsonConvert.SerializeObject(Produtos), JsonConvert.SerializeObject(okResult.Value));
        }

        //[Fact]
        //public async Task Get_ListarRetornandoNotFound()
        //{
        //    _productRepositoryMock.Setup(u => u.ListarProdutos())
        //        .ReturnsAsync((IEnumerable))
        //}
    }
}
