using System;
using System.Collections.Generic;
using System.Linq;
using Example.Tdd.Domain.Commons;

namespace Example.Tdd.Domain.Models
{
    public enum EstadoLeilao
    {
        LeilaoAntesDoPregao,
        LeilaoEmAndamento,
        LeilaoFinalizado
    }

    public class Leilao : Entity
    {
        public string Description { get; private set; }
        public double ValorBase { get; private set; }
        public Bem Bem { get; private set; }
        public IList<Lance> Lances { get; private set; }
        public Lance Vencedor { get; private set; }
        public EstadoLeilao Estado { get; private set; }

        public Leilao(string description, double valorBase, Bem bem) 
        { 
            this.Description = description;
            this.ValorBase = valorBase;
            this.Bem = bem;
            this.Lances = new List<Lance>();
            this.Estado = EstadoLeilao.LeilaoAntesDoPregao;
        }

        public void RecebeLance(Cliente cliente, double valor)
        {
            if(Estado.Equals(EstadoLeilao.LeilaoEmAndamento))
                Lances.Add(new Lance(cliente, valor));
        }
        
        public void IniciarPregao() =>
            this.Estado = EstadoLeilao.LeilaoEmAndamento;

        public void TerminarPregao()
        {
            if(this.Estado != EstadoLeilao.LeilaoEmAndamento)
                throw new InvalidOperationException();

            if(ValorBase > 0)
            {
                Vencedor = Lances.DefaultIfEmpty(new Lance(new Cliente("", new Leilao("", 0, new Bem("",""))), 0))
                                    .Where(x => x.Valor >= ValorBase)
                                        .OrderBy(x => x.Valor).FirstOrDefault();
            }
            else
            {
                Vencedor = Lances.DefaultIfEmpty(new Lance(new Cliente("", new Leilao("", 0, new Bem("",""))), 0))
                                    .OrderBy(x => x.Valor).LastOrDefault();
            }

            this.Estado = EstadoLeilao.LeilaoFinalizado;
        }
    }
}