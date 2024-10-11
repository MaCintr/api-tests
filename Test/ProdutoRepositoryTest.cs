using Microsoft.AspNetCore.Identity;
using Moq;
using web_app_domain;
using web_app_repository;

namespace Test
{
    public class ProdutoRepositoryTest
    {
        [Fact]
        public async Task ListarUsuarios()
        {
            var Produtos = new List<Produto>()
            {
                new Produto()
                {
                    Nome = "lapis",
                    Id = 1,
                    Preco = 5.0,
                    DataCriacao = "20/10/2024",
                    QuantidadeEstoque = 100
                },
                new Produto()
                {
                    Nome = "caneta",
                    Id = 2,
                    Preco = 7.0,
                    DataCriacao = "21/10/2024",
                    QuantidadeEstoque = 150
                }
            };

            var productRepositoryMock = new Mock<IProdutoRepository>();
            productRepositoryMock.Setup(u => u.ListarProdutos()).ReturnsAsync(Produtos);

            var productRepository = productRepositoryMock.Object;

            var result = await productRepository.ListarProdutos();

            Assert.Equal(Produtos, result);
        }

        [Fact]
        public async Task SalvarProduto()
        {
            var produto = new Produto()
            {
                Nome = "lapis",
                Id = 1,
                Preco = 5.0,
                DataCriacao = "20/10/2024",
                QuantidadeEstoque = 100
            };


            var productRepositoryMock = new Mock<IProdutoRepository>();
            productRepositoryMock
                .Setup(u => u.SalvarProduto(It.IsAny<Produto>()))
                .Returns(Task.CompletedTask);

            var productRepository = productRepositoryMock.Object;

            await productRepository.SalvarProduto(produto);

            productRepositoryMock.Verify(u => u.SalvarProduto(It.IsAny<Produto>()), Times.Once);

        }
    }
}
