using System.Linq;
using Example.Tdd.Domain.Models;
using Xunit;

namespace Example.Tdd.Domain.Test
{
    public class LeilaoRecebeOfertaTest
    {
        [Fact]
        private void NaoPermiteNovosLancesDadoLeilaoFinalizado()
        {
            // Arrange (Preparação das variáveis necessárias)
            Leilao leilao = new Leilao("I Leilão Bothers Plus", 0, new Bem("Van Gogh", "Arte"));
            Cliente samuel = new Cliente("Samuel", leilao);

            leilao.IniciarPregao();

            leilao.RecebeLance(samuel, 100);
            leilao.RecebeLance(samuel, 1000);
            leilao.RecebeLance(samuel, 75);
            leilao.RecebeLance(samuel, 30);
            // Act (Efetivamente a função que desejo testar)
            leilao.TerminarPregao();

            leilao.RecebeLance(samuel, 75);
            leilao.RecebeLance(samuel, 30);

            // Assert (Confirmação dos dados)
            var valorObtido = leilao.Lances.Count();
            Assert.Equal(4, valorObtido);
        }
    }
}