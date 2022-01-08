using System;
using System.Collections.Generic;
using IRepositorio;
using SerieRepositorio;
using Entidade;
using EnumGenero;


namespace Catalogo
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();


        //Inicialização Main
        static void Main(string[] args)
        {


            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;

                    case "2":
                        InserirSerie();
                        break;

                    case "3":
                        AtualizarSerie();
                        break;

                    case "4":
                        ExcluirSerie();
                        break;

                    case "5":
                        VizualizarSerie();
                        break;

                    case "C":
                        Clear();
                        break;

                    default:
                        throw new ArgumentException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por usar nossos serviços");
            Console.WriteLine();

        }

        //Metodo Listar
        private static void ListarSerie()
        {
            Console.WriteLine("Listar Série");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série Cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                //var excluido = serie.RetornaExcluido();
                
                Console.WriteLine("#ID {0} - {1}", serie.retornaId(), serie.retornaTitulo(), serie.retornaTitulo(), "\n" + serie.RetornaDescrição());
                
            }
        }

        //Metodo Inseir
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova Série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno, descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }

        //Metodo atualizar
        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Id da Série");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaserie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaserie);
        }

        //Metodo Excluir
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o Id da Série");
            int indiceSerie = int.Parse(Console.ReadLine());


            repositorio.Exclui(indiceSerie);
        }

        //Metodo Visualizar 
        private static void VizualizarSerie()
        {
            Console.WriteLine("Digite o Id da Série");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);

        }

        //Metodo limpar
        private static void Clear()
        {
            var volta = ObterOpcaoUsuario();
        }

        //Metodo Obter opção do usuario
        private static string ObterOpcaoUsuario()
        {

            Console.WriteLine();
            Console.WriteLine("InSeries a seu dispor");
            Console.WriteLine("Informe a opção desejada");


            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Vizualizar Série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }




    }
}
