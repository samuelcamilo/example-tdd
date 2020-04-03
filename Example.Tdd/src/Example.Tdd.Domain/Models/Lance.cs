using Example.Tdd.Domain.Commons;

namespace Example.Tdd.Domain.Models
{
    public class Lance : Entity
    {
        public Cliente Cliente { get; set; }
        public double Valor { get; set; }

        public Lance() { }
        public Lance(Cliente cliente, double valor)
        {
            this.Cliente = cliente;
            this.Valor = valor;
        }
    }
}