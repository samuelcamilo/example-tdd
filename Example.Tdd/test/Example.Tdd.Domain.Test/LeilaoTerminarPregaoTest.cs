using System;
using Example.Tdd.Domain.Models;
using Xunit;

namespace Example.Tdd.Domain.Test
{
    public class LeilaoTerminarPregao
    {
        [Theory]
        [InlineData(1200, new double []{800, 900, 1000, 1200})]
        [InlineData(1200, new double []{900, 1200, 800, 1000})]
        [InlineData(800, new double []{800})]
        private void RetornaMaiorValorDadoLeilaoComPeloMenosUmLance(double valorEsperado, double[] ofertas)
        {
            // Arrange (Preparação das variáveis necessárias)
            Leilao leilao = new Leilao("I Leilão Bothers Plus", 0, new Bem("Van Gogh", "Arte"));
            Cliente samuel = new Cliente("Samuel Camilo", leilao);

            leilao.IniciarPregao();

            foreach(var oferta in ofertas)
                leilao.RecebeLance(samuel, oferta);

            // Act (Efetivamente a função que desejo testar)
            leilao.TerminarPregao();

            // Assert (Confirmação dos dados)
            var valorObtido = leilao.Vencedor.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void RotornaInvalidOperationExceptionDadoPregaoNaoIniciado()
        {
            // Arrange
            Leilao leilao = new Leilao("I Leilão Bothers Plus", 0, new Bem("Van Gogh", "Arte"));

            // Assert
            Assert.Throws<InvalidOperationException>(
                
                // Act
                () => leilao.TerminarPregao()
            );
        }

        [Fact]
        private void RetornaZeroDadoUmLeilaoSemLance()
        {
            // Arrange (Preparação das variáveis necessárias)
            Leilao leilao = new Leilao("I Leilão Bothers Plus", 0, new Bem("Van Gogh", "Arte"));

            leilao.IniciarPregao(); 
            
            // Act (Efetivamente a função que desejo testar)
            leilao.TerminarPregao();

            // Assert (Confirmação dos dados)
            var valorObtido = leilao.Vencedor.Valor;
            Assert.Equal(0, valorObtido);
        }

        [Theory]
        [InlineData(1000, 1000, new double []{800, 900, 1000, 1200})]
        [InlineData(1250, 1200, new double []{900, 1250, 800, 1000})]
        [InlineData(800, 0, new double []{800})]
        private void RetornaValorSuperiorMaisProx(double valorEsperado, double valorBase, double[] ofertas)
        {
            // Arrange (Preparação das variáveis necessárias)
            Leilao leilao = new Leilao("I Leilão Bothers Plus", valorBase, new Bem("Van Gogh", "Arte"));
            Cliente samuel = new Cliente("Samuel Camilo", leilao);

            leilao.IniciarPregao();

            foreach(var oferta in ofertas)
                leilao.RecebeLance(samuel, oferta);

            // Act (Efetivamente a função que desejo testar)
            leilao.TerminarPregao();

            // Assert (Confirmação dos dados)
            var valorObtido = leilao.Vencedor.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }
    }
}
