using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Exercicio20
{
    internal class Program
    {
        public void Main(string[] args)
        {
            var veiculos = new List<Veiculo>();

            while (true)
            {
                Console.WriteLine("Qual o ano do veículo?");
                var anoVeiculo = Console.ReadLine();

                Console.WriteLine("Qual o valor do veículo?");
                var valorVeiculo = Console.ReadLine();

                var veiculo = new Veiculo();
                veiculo.Ano = short.Parse(anoVeiculo);
                veiculo.Valor = decimal.Parse(valorVeiculo);
                veiculo.Desconto = CalcularDesconto(veiculo.Valor, veiculo.Ano);
                veiculos.Add(veiculo);

                Console.WriteLine("Para finalizar aperte N");
                if (Console.ReadKey().Key == ConsoleKey.N)
                    break;
            }

            ContabilizarExibir(veiculos);
        }

   
        private decimal CalcularDesconto(decimal valorVeiculo, short anoVeiculo)
        {
            if (anoVeiculo < 2000)
                return valorVeiculo * 0.88M;
            else
                return valorVeiculo * 0.93M;
        }
        private void ContabilizarExibir(List< Veiculo > veiculos)
        {
            var totalCarros = veiculos.Count();
            var totalMenor2000 = 0;
            decimal totalDesconto = 0;
            decimal totalPagar = 0;


            foreach (var veiculo in veiculos)
            {
                if (veiculo.Ano < 2000)
                    totalMenor2000++;

                totalDesconto += veiculo.Valor - veiculo.Desconto;
                totalPagar += veiculo.Desconto;
            }

            ExibirResultado(totalCarros, totalMenor2000, totalDesconto, totalPagar);
        }
        private void ExibirResultado(int totalCarros, int totalMenor2000, decimal valorDesconto, decimal valorPagar)
        {
            Console.WriteLine("O comprador ganhou um desconto de R$ " +
                valorDesconto + " e vai ter que pagar somente: R$ " + valorPagar);


            Console.WriteLine("Em um total de " +
                totalMenor2000 +
                " carros com ano inferior a 2000");
            Console.WriteLine("Em um total geral de " +
               totalCarros +
               " carros.");
        }
    }
}
    

