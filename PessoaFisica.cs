using System;
using System.Collections.Generic;

namespace SistemaDeCadastroPJePF
{
    public class PessoaFisica : Pessoa
    {
        public float RendimentoPf { get; set; }
        public string cpf { get; set; }
        public DateTime dataNascimento { get; set; }
        public bool ValidarDataNascimento(DateTime DataNascimento)
        {
            DateTime DataAtual = DateTime.Today;
            double idade = (DataAtual - DataNascimento).TotalDays / 365;
            if (idade >= 18)
            {
                return true;
            }
            return false;
        }
        public override double PagarImposto(float Rendimento)
        {
            if (Rendimento >= 5000.01)
            {
                double imposto = (double)(Rendimento * 0.05);
                return imposto;
            }
            else if (Rendimento >= 1500.01 && Rendimento <= 5000)
            {
                double imposto = (double)(Rendimento * 0.03);
                return imposto;
            }
            else
            {
                Console.WriteLine("SUA RENDA É BAIXA");
                Rendimento = 0;
                return Rendimento;
            }
        }

        List<string> ListaDePessoaFisica = new List<string>();
        public string ListarPessoaFisica(string DadosPessoais)
        {
            ListaDePessoaFisica.Add(DadosPessoais);

            return DadosPessoais;
        }

        public void MostarLista()
        {
            foreach (var item in ListaDePessoaFisica)
            {                
                Console.WriteLine(item);
            }
        }
    }
}