using System.Linq;
using Example.Tdd.Domain.Models;
using Xunit;

namespace Example.Tdd.Domain.Test
{
    public class LeilaoIniciaPregaoTest
    {
        [Theory]
        [InlineData(new double[] { 1000, 322.00, 4332.11, 100 })]
        private void InvalidaLancesLeilaoNaoIniciado(double[] ofertas)
        {
            // Arrange
            Leilao leilao = new Leilao("I Leilão Bothers Plus", 0, new Bem("Van Gogh", "Arte"));
            Cliente samuel = new Cliente("Samuel", leilao);

            // Act
            foreach(var item in ofertas)
                leilao.RecebeLance(samuel, item);
            
            // Assert
            Assert.Equal(0, leilao.Lances.Count());
        }
    }
}