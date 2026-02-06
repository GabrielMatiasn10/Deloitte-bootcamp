using System;

namespace SistemaEscolar
{
    class Aluno
    {
        // Atributos 
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }
        public string[] Disciplinas { get; set; } = new string[3];
        public double[] Notas { get; set; } = new double[3];

        // Construtor
        public Aluno(string nome, string matricula, string curso)
        {
            Nome = nome;
            Matricula = matricula;
            Curso = curso;
        }

        // verificar aprovação
        public bool EstaAprovado(int indice)
        {
            return Notas[indice] >= 7.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cadastro de Aluno \n");
            
            Console.Write("Nome do aluno: ");
            string nome = Console.ReadLine();
            
            Console.Write("Matrícula: ");
            string mat = Console.ReadLine();
            
            Console.Write("Curso: ");
            string curso = Console.ReadLine();

            // Instanciando a classe
            Aluno aluno = new Aluno(nome, mat, curso);

            // Coletando Disciplinas e Notas
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"\nNome da {i + 1}ª disciplina: ");
                aluno.Disciplinas[i] = Console.ReadLine();

                Console.Write($"Nota em {aluno.Disciplinas[i]}: ");
                // Convertendo a entrada para double
                aluno.Notas[i] = double.Parse(Console.ReadLine());
            }

            

            // Exibindo Relatório
            Console.WriteLine("\n");
            Console.WriteLine($"RELATÓRIO DO ALUNO: {aluno.Nome}");
            Console.WriteLine($"Matrícula: {aluno.Matricula} | Curso: {aluno.Curso}");
            Console.WriteLine("");

            for (int i = 0; i < 3; i++)
            {
                string status = aluno.EstaAprovado(i) ? "APROVADO" : "REPROVADO";
                Console.WriteLine($"Disciplina: {aluno.Disciplinas[i]}");
                Console.WriteLine($"Nota: {aluno.Notas[i]:F1} -> Status: {status}");
                Console.WriteLine("");
            }
        }
    }
}