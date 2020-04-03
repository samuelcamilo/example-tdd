using System.Collections.Generic;
using System.Linq;
using Example.Tdd.Domain.Commons;

namespace Example.Tdd.Domain.Models
{
    public class Leilao : Entity
    {
        public string Description { get; private set; }
        public Bem Bem { get; private set; }
        public IList<Lance> Lances { get; private set; }
        public Lance Vencedor { get; private set; }

        public Leilao(string description, Bem bem) 
        { 
            this.Description = description;
            this.Bem = bem;
            this.Lances = new List<Lance>();
        }

        public void RecebeLance(Cliente cliente, double valor) =>
            Lances.Add(new Lance(cliente, valor));
        
        public void IniciarPregao()
        {

        }

        public void TerminarPregao() =>
            Vencedor = Lances.OrderBy(x => x.Valor).Last();
    }
}