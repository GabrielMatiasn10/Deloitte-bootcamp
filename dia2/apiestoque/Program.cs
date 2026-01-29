using System;
using System.Collections.Generic;

namespace GerenciamentoEstoque
{
    // modelo do produto
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

        // construtor do objeto
        public Produto(int id, string nome, double preco, int quantidade)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        // Formata a exibição
        public override string ToString()
        {
            return $"ID: {Id} | Nome: {Nome} | Preço: {Preco:C2} | Qtd: {Quantidade}";
        }
    }

    class Program
    {
        // armazena os produtos
        static List<Produto> listaEstoque = new List<Produto>();
        
        // Gerador de ID
        static int proximoId = 1;

        static void Main(string[] args)
        {
            bool exibirMenu = true;

            // loop do menu
            while (exibirMenu)
            {
                Console.WriteLine("\n SISTEMA ESTOQUE ");
                Console.WriteLine("1 - Cadastrar");
                Console.WriteLine("2 - Listar");
                Console.WriteLine("3 - Editar");
                Console.WriteLine("4 - Remover");
                Console.WriteLine("5 - Sair");
                Console.Write("Opção: ");

                string opcao = Console.ReadLine();

                // seleciona a ação
                switch (opcao)
                {
                    case "1": Cadastrar(); break;
                    case "2": Listar(); break;
                    case "3": Editar(); break;
                    case "4": Remover(); break;
                    case "5": exibirMenu = false; break;
                    default: Console.WriteLine("Invalido!"); break;
                }
            }
        }

        // adiciona novo produto
        static void Cadastrar()
        {
            try
            {
                Console.Write("Nome: ");

                string nome = Console.ReadLine();

                Console.Write("Preço: ");
                double preco = double.Parse(Console.ReadLine());

                Console.Write("Quantidade: ");
                int qtd = int.Parse(Console.ReadLine());

                if (preco <= 0 || qtd < 0)
                {
                    Console.WriteLine("Preço e quantidade devem ser positivos!");
                    return;
                }

                // salva na lista
                listaEstoque.Add(new Produto(proximoId, nome, preco, qtd));
                proximoId++; 

                Console.WriteLine("Sucesso!");
            }
            catch
            {
                Console.WriteLine("Erro nos dados!");
            }
        }

        // mostra todos produtos
        static void Listar()
        {
            if (listaEstoque.Count == 0) Console.WriteLine("Vazio!");
            // Percorre a lista
            foreach (var p in listaEstoque) Console.WriteLine(p);
        }

        // altera o preço
        static void Editar()
        {
          try
            {
                    Console.Write("ID para editar: ");
                    int id = int.Parse(Console.ReadLine());
    
                    // procura por ID
                    Produto p = listaEstoque.Find(x => x.Id == id);
    
                    if (p != null)
                    {
                        Console.Write("Novo preço: ");
                        double novoPreco = double.Parse(Console.ReadLine());
    
                        if (novoPreco <= 0)
                        {
                            Console.WriteLine("Preço deve ser positivo!");
                            return;
                        }
    
                        // atualiza o preço
                        p.Preco = novoPreco;
                        Console.WriteLine("Atualizado!");
                    }
                    else Console.WriteLine("Não encontrado!");
                }
                catch
                {
                    Console.WriteLine("Erro nos dados!");
                }
        }

        // exclui da lista
        static void Remover()
        {
            Console.Write("ID para remover: ");
            int id = int.Parse(Console.ReadLine());

            // procura por ID
            Produto p = listaEstoque.Find(x => x.Id == id);

            if (p != null)
            {
                // Remove o item
                listaEstoque.Remove(p);
                Console.WriteLine("Removido!");
            }
            else Console.WriteLine("Não encontrado!");
        }
    }
}