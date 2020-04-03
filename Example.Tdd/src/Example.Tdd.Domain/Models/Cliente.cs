using Example.Tdd.Domain.Commons;

namespace Example.Tdd.Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public Leilao Leilao { get;set; }

        public Cliente() { }
        public Cliente(string nome, Leilao leilao)
        {
            this.Nome = nome;
            this.Leilao = leilao;
        }
    }
}