using Example.Tdd.Domain.Commons;

namespace Example.Tdd.Domain.Models
{
    public class Bem : Entity
    {
        string Descricao { get; set; }
        string Categoria { get; set; }

        public Bem() { }
        public Bem(string descricao, string categoria)
        {
            this.Descricao = descricao;
            this.Categoria = categoria;
        }
    }
}