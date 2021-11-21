using System;
using System.Collections.Generic;
using System.Threading;

namespace SistemaDeCadastroPJePF
{
    class Program
    {
        static void Main(string[] args)
        {
            PessoaFisica UsuarioPessoaFisica = new PessoaFisica();
            PessoaFisica ValidadorPessoaFisica = new PessoaFisica();
            Endereco localidade = new Endereco();

            PessoaJuridica UsuarioPessoaJuridica = new PessoaJuridica();
            PessoaJuridica ValidadorPessoaJuridica = new PessoaJuridica();

            string respostaUsuario;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            carregarPagina("INICIANDO");

            do
            {

                Console.WriteLine($@"
            =================================================
            |SISTEMA DE CADASTRO DE PESSOA FÍSICA E JURÍDICA|
            |-----------------------------------------------|
            |       DIGITE 1 - FAZER CADASTRO CADASTRO      |
            |                                               |
            |                  PESSSOA FÍSICA               |
            |       DIGITE 2 - PARA LISTAR DADOS            |
            |                                               |
            |                  PESSOA JURÍDICA              |
            |       DIGITE 3 - PARA LISTAR DADOS            |
            |                                               |
            |       DIGITE 0 - PARA SAIR                    |
            =================================================
            ");

                respostaUsuario = Console.ReadLine();
                if (respostaUsuario == "1")
                {
                    carregarPagina("INICIANDO");

                    Console.WriteLine(@$"
                =================================================
                |SISTEMA DE CADASTRO DE PESSOA FÍSICA E JURÍDICA|
                |-----------------------------------------------|
                |       DIGITE 1 - PARA PESSOA FÍSICA           |
                |       DIGITE 2 - PARA PESSOA JURÍDICA         |
                |       DIGITE 0 - PARA SAIR                    |
                =================================================
                ");


                    respostaUsuario = Console.ReadLine();

                    switch (respostaUsuario)
                    {
                        case "1":

                            carregarPagina("CARREGANDO");


                            Console.WriteLine($"INSIRA O SEU NOME");
                            UsuarioPessoaFisica.nome = Console.ReadLine();

                            Console.WriteLine($"INSIRA O DIA DE NASCIMENTO");
                            var DIA = int.Parse(Console.ReadLine());

                            Console.WriteLine($"INSIRA O MÊS DE NASCIMENTO");
                            var MES = int.Parse(Console.ReadLine());

                            Console.WriteLine($"INSIRA O ANO DE NASCIMENTO");
                            var ANO = int.Parse(Console.ReadLine());

                            UsuarioPessoaFisica.dataNascimento = new DateTime(ANO, MES, DIA);

                            Console.WriteLine($"INSIRA O SEU cpf");
                            UsuarioPessoaFisica.cpf = Console.ReadLine();

                            bool IdadeValidada = ValidadorPessoaFisica.ValidarDataNascimento(UsuarioPessoaFisica.dataNascimento);

                            Console.WriteLine("SEU ENDEREÇO É COMERCIAL? DIGITE true PARA SIM E false PARA NÃO");
                            localidade.EnderecoComercial = bool.Parse(Console.ReadLine());


                            Console.WriteLine($"INSIRA O LOGRADOURO");
                            localidade.Logradouro = Console.ReadLine();

                            Console.WriteLine($"INSIRA O NÚMERO");
                            localidade.Numero = int.Parse(Console.ReadLine());

                            Console.WriteLine($"INSIRA O COMPLEMENTO. CASO NÃO TENHA DIGITE nenhum");
                            localidade.Complemento = Console.ReadLine();

                            UsuarioPessoaFisica.Localizacao = localidade;

                            if (IdadeValidada == true)
                            {
                                Console.WriteLine(@"
                                ___________________________
                                |DESEJA LISTAR SEUS DADOS?|
                                |=========================|
                                |    SE SIM DIGITE: 0     |
                                |    SE NÃO DIGITE: 1     |
                                ===========================
                                ");

                                string respostaUsuarioPf;
                                do
                                {
                                    respostaUsuarioPf = Console.ReadLine();


                                    if (respostaUsuarioPf == "0")
                                    {
                                        string DadosPessoaisDaPessoaFisica = $"{UsuarioPessoaFisica.nome}, {UsuarioPessoaFisica.dataNascimento}, {UsuarioPessoaFisica.Localizacao}, {UsuarioPessoaFisica.cpf}";

                                        UsuarioPessoaFisica.ListarPessoaFisica("DadosPessoaisDaPessoaFisica");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"ERRO! DIGITE SOMENTE 0 OU 1 NA SUA RESPOSTA!");
                                    }
                                } while (respostaUsuarioPf != "0" && respostaUsuarioPf != "1");

                                Console.WriteLine($"\nAcesso Permitido!\n");

                                Console.WriteLine($"DIGITE SEU SALÁRIO. USE (.) AO INVÉS DE (,):");
                                UsuarioPessoaFisica.RendimentoPf = float.Parse(Console.ReadLine());

                                float rendimentoPF = UsuarioPessoaFisica.RendimentoPf;

                                double impostoPagoPf = UsuarioPessoaFisica.PagarImposto(rendimentoPF);

                                if (impostoPagoPf > 0)
                                {
                                    Console.WriteLine($"IMPOSTO QUITADO COM SUCESSO!");
                                }

                                Thread.Sleep(3000);
                                carregarPagina("REDIRECIONANDO");
                            }
                            else
                            {
                                Console.WriteLine($"Acesso Negado! Acesso Permitido Somente Para Maiores de Idade");
                                Thread.Sleep(3000);
                                carregarPagina("REDIRECIONANDO");
                            }
                            break;

                        case "2":

                            carregarPagina("Carregando");

                            Console.WriteLine("DIGITE O SEU NOME:");
                            UsuarioPessoaJuridica.nome = Console.ReadLine();

                            Console.WriteLine("DIGITE A SUA RAZÃO SOCIAL:");
                            UsuarioPessoaJuridica.RazaoSocial = Console.ReadLine();

                            Console.WriteLine("DIGITE O SEU cnpj:");
                            UsuarioPessoaJuridica.cnpj = Console.ReadLine();


                            Console.WriteLine("SEU ENDEREÇO É COMERCIAL? DIGITE true PARA SIM E false PARA NÃO");
                            localidade.EnderecoComercial = bool.Parse(Console.ReadLine());

                            Console.WriteLine("DIGITE O SEU LOGRADOURO:");
                            localidade.Logradouro = Console.ReadLine();

                            Console.WriteLine("DIGITE O SEU COMPLEMENTO. CASO NÃO TENHA DIGITE nenhum");
                            localidade.Complemento = Console.ReadLine();

                            Console.WriteLine("DIGITE O SEU NÚMERO:");
                            localidade.Numero = int.Parse(Console.ReadLine());

                            UsuarioPessoaJuridica.Localizacao = localidade;

                            bool cnpjValidado = ValidadorPessoaJuridica.validarCnpj(UsuarioPessoaJuridica.cnpj);

                            if (cnpjValidado)
                            {
                                Console.WriteLine(@"
                                ___________________________
                                |DESEJA LISTAR SEUS DADOS?|
                                |=========================|
                                |    SE SIM DIGITE: 0     |
                                |    SE NÃO DIGITE: 1     |
                                ===========================
                                ");

                                string respostaUsuarioPj;

                                do
                                {
                                    respostaUsuarioPj = Console.ReadLine();


                                    if (respostaUsuarioPj == "0")
                                    {
                                        string DadosPessoaisDaPessoaJuridica = $"{UsuarioPessoaJuridica.nome}, {UsuarioPessoaJuridica.RazaoSocial}, {UsuarioPessoaJuridica.Localizacao}, {UsuarioPessoaJuridica.cnpj}, {UsuarioPessoaJuridica.RendimentoPj}";

                                        UsuarioPessoaJuridica.ListarPessoaJuridica(DadosPessoaisDaPessoaJuridica);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"ERRO! DIGITE SOMENTE 0 OU 1 NA SUA RESPOSTA!");
                                    }
                                } while (respostaUsuarioPj != "0" && respostaUsuarioPj != "1");

                                Console.WriteLine("CADASTRO REALIZADO COM SUCESSO");

                                Console.WriteLine($"DIGITE SEU SALÁRIO. USE (.) AO INVÉS DE (,):");
                                UsuarioPessoaJuridica.RendimentoPj = float.Parse(Console.ReadLine());

                                float RendimentoPJ = UsuarioPessoaJuridica.RendimentoPj;

                                double impostoPagoPj = UsuarioPessoaJuridica.PagarImposto(RendimentoPJ);

                                if (impostoPagoPj > 0)
                                {
                                    Console.WriteLine($"IMPOSTO QUITADO COM SUCESSO!");
                                }

                                Thread.Sleep(3000);
                                carregarPagina("REDIRECIONANDO");
                            }
                            else
                            {
                                Console.WriteLine($"CADASTRO NEGADO! SEU cnpj NÃO POSSUI OS NÚMEROS 0001 DE UMA MATRIZ OU 0002 DE UMA FILIAL");
                                Thread.Sleep(3000);
                                carregarPagina("REDIRECIONANDO");
                            }
                            break;

                        default:

                            Console.WriteLine($"OBRIGADO POR  ACESSAR NOSSO SERVIÇO!");
                            Thread.Sleep(3000);
                            carregarPagina("REDIRECIONANDO");
                            break;
                    }

                }
                else if (respostaUsuario == "2")
                {
                    carregarPagina("INICIANDO");

                    Thread.Sleep(1000);


                    string respostaUsuarioPf;

                    do
                    {

                        UsuarioPessoaFisica.MostarLista();

                        Console.WriteLine(@"
                        ===================================
                        |     DESEJA SAIR DO SISTEMA?     |
                        |---------------------------------|
                        |           0 - PARA SIM          |
                        |           1 - PARA NÃO          |
                        |_________________________________|
                        ");

                        respostaUsuarioPf = Console.ReadLine();

                        if (respostaUsuarioPf == "0")
                        {
                            carregarPagina("RETORNANDO");
                        }
                        else if (respostaUsuarioPf == "1")
                        {
                            Console.WriteLine($"OBRIGADO POR  ACESSAR NOSSO SERVIÇO!");
                            Thread.Sleep(3000);
                            carregarPagina("REDIRECIONANDO");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"ERRO! DIGITE SOMENTE 0 OU 1");
                            Thread.Sleep(3000);
                            carregarPagina("REDIRECIONANDO");
                        }
                    } while (respostaUsuarioPf == "0" || respostaUsuarioPf != "0" && respostaUsuarioPf != "1");
                }
                else if (respostaUsuario == "3")
                {
                    UsuarioPessoaJuridica.MostarLista();

                    string respostaUsuarioPj;

                    do
                    {
                        Console.WriteLine(@"
                        ===================================
                        |     DESEJA SAIR DO SISTEMA?     |
                        |---------------------------------|
                        |           0 - PARA SIM          |
                        |           1 - PARA NÃO          |
                        |_________________________________|
                        ");

                        respostaUsuarioPj = Console.ReadLine();

                        if (respostaUsuarioPj == "0")
                        {
                            carregarPagina("RETORNANDO");
                        }
                        else if (respostaUsuarioPj == "1")
                        {
                            Console.WriteLine($"OBRIGADO POR  ACESSAR NOSSO SERVIÇO!");
                            Thread.Sleep(3000);
                            carregarPagina("REDIRECIONANDO");
                        }
                        else
                        {
                            Console.WriteLine($"ERRO! DIGITE SOMENTE 0 OU 1");
                            Thread.Sleep(3000);
                            carregarPagina("REDIRECIONANDO");
                        }
                    } while (respostaUsuarioPj == "0" || respostaUsuarioPj != "0" && respostaUsuarioPj != "1");
                }
            }
            while (respostaUsuario == "1" || respostaUsuario == "2" || respostaUsuario == "3" || respostaUsuario == "4" || respostaUsuario != "0" && respostaUsuario != "1" && respostaUsuario != "2" && respostaUsuario != "3" && respostaUsuario != "4");
            Console.ResetColor();

            // UsuarioPessoaFisica.ListarPessoaFisica("dadaaa");
            // UsuarioPessoaFisica.MostarLista();

        }

        static void carregarPagina(string mensagemDeCarregamento)
        {
            Console.Clear();
            Console.Write(mensagemDeCarregamento);
            for (int vez = 0; vez < 10; vez++)
            {
                Console.Write('.');

                Thread.Sleep(300);

                if (vez == 9)
                {
                    Console.Clear();
                }
            }
        }
    }
}
