using System;
using System.Collections.Generic;
using System.Linq;

public class Visitante
{
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public DateTime HorarioChegada { get; set; }
        public DateTime? HorarioSaida { get; set; }
        public bool EPrimeiraVez { get; set; }

        public override string ToString()
        {
            string statusSaida = HorarioSaida.HasValue ? HorarioSaida.Value.ToString("HH:mm") : "Ainda presente";
            return $"ID: {Id} | Nome: {Nome.PadRight(15)} | Entrada: {HorarioChegada:HH:mm} | Saída: {statusSaida} | Novato: {(EPrimeiraVez ? "Sim" : "Não")}";
        }
    }

    class Program
{
    static List<Visitante> visitantes = new List<Visitante>();
    static int contadorId = 1;

    static void Main(string[] args)
    {
        while (true)
            try
            {
                Console.WriteLine("\nControle de Visitantes");
                Console.WriteLine("1. Registrar chegada");
                Console.WriteLine("2. Registrar saída");
                Console.WriteLine("3. Listar visitantes");
                Console.WriteLine("4. Sair");
                Console.Write("Escolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        RegistrarChegada();
                        break;
                    case 2:
                        RegistrarSaida();
                        break;
                    case 3:
                        ListarVisitantes();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
    }

    static void Cadastrar()
    {
        Console.Write("Nome do visitante: ");
        string nome = Console.ReadLine();

        Console.Write("Documento (RG/CPF): ");
        string documento = Console.ReadLine();

        bool ePrimeiraVez = !visitantes.Any(v => v.Documento == documento);

        Visitante novoVisitante = new Visitante
        {
            Id = contadorId++,
            Nome = nome,
            Documento = documento,
            HorarioChegada = DateTime.Now,
            EPrimeiraVez = ePrimeiraVez
        };

        visitantes.Add(novoVisitante);
        Console.WriteLine("Chegada registrada com sucesso.");
    }

    static void Listar()
    {
        Console.WriteLine("\nLista de Visitantes:");
        foreach (var visitante in visitantes)
        {
            Console.WriteLine(visitante);
        }
    }

    static void RegistrarChegada()
    {
        Cadastrar();
    }

    static void RegistrarSaida()
    {
        Console.Write("Digite o ID do visitante para registrar saída: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var visitante = visitantes.FirstOrDefault(v => v.Id == id);
            if (visitante != null)
            {
                if (!visitante.HorarioSaida.HasValue)
                {
                    visitante.HorarioSaida = DateTime.Now;
                    Console.WriteLine("Saída registrada com sucesso.");
                }
                else
                {
                    Console.WriteLine("A saída já foi registrada para este visitante.");
                }
            }
            else
            {
                Console.WriteLine("Visitante não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static void ListarVisitantes()
    {
        Listar();
    }

    static void FiltrarNovatos()
    {
        var novatos = visitantes.Where(v => v.EPrimeiraVez).ToList();
        Console.WriteLine("\nVisitantes Novatos:");
        foreach (var visitante in novatos)
        {
            Console.WriteLine(visitante);
        }
    }
}