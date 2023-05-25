using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace introductionMVC.Model
{
    public class Produto
    {
        //Propriedades
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        //Caminho da pasta e do arquivo
        private const string PATH = "Database/Produto.csv";

        //criar construtor
        public Produto()
        {
            // Obter o caminho da pasta 
            string pasta = PATH.Split("/")[0];//Database

            //Se nao existir uma pasta Database, cria-se uma
            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }
            //Se nao existir um arquivo csv no caminho, criar-se uma
            if(!File.Exists(PATH))
            {
                File.Create(PATH);
            }

        }

        public List<Produto> Ler()
        {
            //Instanciar uma lista
            List<Produto> produto = new List<Produto>();

            //Array de string que receb cada linha do csv
            string[] linhas = File.ReadAllLines(PATH);

            //leitura das linhas 
            foreach (var item in linhas)
            {
                //array que receb os itens da linha separada por ";"
                string[] atributos = item.Split(";");

                //apos o split 
                // atributo[0] = "001"
                // atributo[1] = "Coca"
                // atributo[2] = "6,50"

                //instanciar o objeto produto
                Produto p = new Produto();

                //atribuir os dados dentro de um objeto 

                p.Codigo = int.Parse(atributos[0]);
                p.Nome = atributos[1];
                p.Preco = float.Parse(atributos[2]);
                
                // Adiciona os produtos na lista
                produto.Add(p);
            }

            return produto;
        }

        //prepara a linha do csv
        public string PrepararLinhaCSV(Produto p)
        {
            return $"{p.Codigo};{p.Nome};{p.Preco}";
        }

        //inserir um produto no arquivo csv
        public void Inserir(Produto p)
        {
            // array que vai armazenar as linhas(cada "objeto")
            string[] linhas = {PrepararLinhaCSV(p)};

            //vai até o arquivo e insere todas as linhas
            File.AppendAllLines(PATH, linhas);
        }
    }
}