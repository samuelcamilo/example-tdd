using System;
using Example.Tdd.Domain.Models;
using Xunit;

namespace Example.Tdd.Domain.Test
{
    public class LeilaoTest
    {
        [Fact]
        private void LeilaoComVariosLances()
        {
            // Arrange (Preparação das variáveis necessárias)
            Leilao leilao = new Leilao("I Leilão Bothers Plus", new Bem("Van Gogh", "Arte"));
            Cliente samuel = new Cliente("Samuel Camilo", leilao);
            Cliente sabrina = new Cliente("Sabrina Camilo", leilao);
            Cliente eliza = new Cliente("Elizamar Camilo", leilao);

            leilao.RecebeLance(samuel, 100);
            leilao.RecebeLance(sabrina, 200);
            leilao.RecebeLance(eliza, 50);

            // Act (Efetivamente a função que desejo testar)
            leilao.TerminarPregao();

            // Assert (Confirmação dos dados)
            var valorObtido = leilao.Vencedor.Valor;
            Assert.Equal(200, valorObtido);
        }

        [Fact]
        private void LeilaoComApenasUmTeste()
        {
            // Arrange (Preparação das variáveis necessárias)
            Leilao leilao = new Leilao("I Leilão Bothers Plus", new Bem("Van Gogh", "Arte"));
            Cliente samuel = new Cliente("Samuel Camilo", leilao);

            leilao.RecebeLance(samuel, 100);

            // Act (Efetivamente a função que desejo testar)
            leilao.TerminarPregao();

            // Assert (Confirmação dos dados)
            var valorObtido = leilao.Vencedor.Valor;
            Assert.Equal(100, valorObtido);
        }
    }
}
