using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio27Avaliativo.Entidades
{
    internal class CarangoVendas
    {
        public void VendasCont()

        {
            var listaVeiculos = new List<VeiculosCarango>();

            while (true)
            {
                var veiculo = Perguntas();

                if (veiculo == null)
                    break;

                veiculo = Calculos(veiculo);
                listaVeiculos.Add(veiculo);
            }

            ExibirResultados(listaVeiculos);
        }

        private VeiculosCarango Perguntas()
        {
            var veiculo = new VeiculosCarango();

            Console.WriteLine("Qual o valor do carro?");
            Console.WriteLine("Ou digite 0 para cancelar!");
            veiculo.VeiculoValor = Convert.ToDecimal(Console.ReadLine());

            if (veiculo.VeiculoValor == 0)
                return null;

            Console.WriteLine("Qual o combustivel do carro?");
            Console.WriteLine("1 para Alcool");
            Console.WriteLine("2 para Gasolina");
            Console.WriteLine("3 para Diesel");
            veiculo.CombustivelTipo = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Qual o modelo do veículo?");
            veiculo.NomeVeiculo = Console.ReadLine();

            Console.Clear();
            return veiculo;
        }

        private VeiculosCarango Calculos(VeiculosCarango veiculo)
        {
            decimal porcentagemDesconto = 0M;

            switch (veiculo.CombustivelTipo)
            {
                case 1:
                    porcentagemDesconto = 0.25M;
                    break;
                case 2:
                    porcentagemDesconto = 0.21M;
                    break;
                case 3:
                    porcentagemDesconto = 0.14M;
                    break;
                default:
                    break;
            }

            veiculo.Desconto = veiculo.VeiculoValor * porcentagemDesconto;
            veiculo.FinalValor = veiculo.VeiculoValor - veiculo.Desconto;

            return veiculo;
        }

        private void ExibirResultados(List<VeiculosCarango> veiculos)
        {
            decimal total = 0M, totalDesconto = 0M;

            foreach (var veiculo in veiculos)
            {
                Console.WriteLine(veiculo.NomeVeiculo + " - " +
                    " Valor Original: R$" + veiculo.VeiculoValor +
                    " Valor Desconto: R$" + veiculo.Desconto +
                    " Valor a Pagar: R$" + veiculo.FinalValor);
                total += veiculo.FinalValor;
                totalDesconto += veiculo.Desconto;
            }

            Console.WriteLine("O valor total do desconto: R$" +  totalDesconto + " e o total a pagar é "  + total);
        }
    }



}


    

