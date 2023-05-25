using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using introductionMVC.Model;
using introductionMVC.View;

namespace introductionMVC.Controller
{
    public class ProdutoController
    {
        //instanciar objeto produto e produtoView
        Produto produto = new Produto();
        ProdutoView produtoView = new ProdutoView();

        public void ListarProdutos()
        {
            //lista de produtos chamada pela model
            List<Produto> produtos = produto.Ler();

            //chamado o método do view recebendo argumento da lista a cima como parametro
            produtoView.Listar(produtos);

        }

        public void CadastrarProduto()
        {
            //novo objeto que recebe cada objeto da view a ser inserido no csv
            Produto novoProduto = produtoView.Cadastrar();

            //chamada para a model para inserir esse objeto no csv
            produto.Inserir(novoProduto);
        }
    }
}