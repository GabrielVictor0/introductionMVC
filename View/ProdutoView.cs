using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using introductionMVC.Model;

namespace introductionMVC.View
{
    public class ProdutoView
    {
        public void Listar(List<Produto> produtos)
        {
            Console.Clear();
            foreach (var item in produtos)
            {
                Console.WriteLine($"\nCodigo: {item.Codigo}");
                Console.WriteLine($"Nome: {item.Nome}");
                Console.WriteLine($"Preço: {item.Preco}");
            }
        }

        public Produto Cadastrar()
        {
            Produto novoProduto = new Produto();

            Console.WriteLine($"Informe o código: ");
            novoProduto.Codigo = int.Parse(Console.ReadLine());

            Console.WriteLine($"Informe o nome: ");
            novoProduto.Nome = Console.ReadLine();
            
            Console.WriteLine($"Informe o preço: ");
            novoProduto.Preco = float.Parse(Console.ReadLine());
            
            return novoProduto;
        }
    }
}