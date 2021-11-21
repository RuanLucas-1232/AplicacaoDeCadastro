using System;
using System.Collections.Generic;

namespace SistemaDeCadastroPJePF
{
    public class PessoaJuridica : Pessoa
    {
        public float RendimentoPj { get; set; }
        public string cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public override double PagarImposto(float Rendimento)
        {
            if (Rendimento >= 10000.01)
            {
                double imposto = (double)(Rendimento * 0.1);
                return imposto;
            }
            else if (Rendimento >= 5000.01 && Rendimento <= 10000)
            {
                double imposto = (double)(Rendimento * 0.08);
                return imposto;
            }
            else
            {
                double imposto = (double)(Rendimento * 0.06);
                return imposto;
            }

        }

        public bool validarCnpj(string cnpj)
        {
            if (cnpj.Substring(8, 4) == "0001")
            {
                return true;
            }
            else if (cnpj.Substring(8, 4) == "0002")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        List<string> ListaDePessoaJuridica = new List<string>();
        public string ListarPessoaJuridica(string DadosPessoais)
        {
            ListaDePessoaJuridica.Add(DadosPessoais);

            return DadosPessoais;
        }

        public void MostarLista()
        {
            foreach (var item in ListaDePessoaJuridica)
            {                
                Console.WriteLine(item);
            }
        }
    }
}