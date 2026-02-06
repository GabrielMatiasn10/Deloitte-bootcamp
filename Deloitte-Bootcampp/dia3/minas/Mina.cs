public Minerio minerio = new Minerio();
 class Mina1
    {
      private string codigo;
      private string nome;
      private decimal capacidade;
       

         public Mina1(string codigo, string nome, decimal capacidade)
         {
            this.codigo = codigo;
            this.nome = nome;
            this.capacidade = capacidade;
         }

         public string GetCodigo()
         {
            return codigo;
         }


         public void extrairMinerio(string tipo, decimal quantidade)
         {
            Console.WriteLine($"Extraindo {quantidade} toneladas de {tipo} da mina {nome}.");
         }

      
    };


    

