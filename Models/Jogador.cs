using System;
using System.Collections.Generic;
using System.IO;
using E_Players_MVC.Interfaces;

namespace E_players_MVC.Models
{
    public class Jogador : EPlayersBase, IJogador
    {
        public int Id_Jogador { get; set; }

        public string Nome { get; set; }

        public int Id_Equipe { get; set; }
        
        public string Email { get; set; }

        public string Senha { get; set; }
        
        private const string CAMINHO = "Database/Jogador.csv";

        public Jogador(){
            Criar_Pasta_e_Arquivo(CAMINHO);
        }

        private string PrepararLinha(Jogador j){
            return $"{j.Id_Jogador};{j.Nome};{j.Id_Equipe};{j.Email};{j.Senha}";
        }

        public void Criar(Jogador j)
        {
            string[] linha = {PrepararLinha(j)};
            File.AppendAllLines(CAMINHO, linha);

        }

        public List<Jogador> LerTodos()
        {
            List<Jogador> jogadores = new List<Jogador>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Jogador jogador_dados = new Jogador();

                jogador_dados.Id_Jogador = Int32.Parse(linha[0]);
                jogador_dados.Nome = linha[1];
                jogador_dados.Id_Equipe = Int32.Parse(linha[2]);
                jogador_dados.Email = linha[3];
                jogador_dados.Senha = linha[4];

                jogadores.Add(jogador_dados);
            }
            return jogadores;
        }

        public void Alterar(Jogador j)
        {
            List<string> linhas_do_csv = Ler_Todas_as_Linhas_CSV(CAMINHO);
           linhas_do_csv.RemoveAll(item => item.Split(";")[0] == j.Id_Jogador.ToString());
           linhas_do_csv.Add(PrepararLinha(j));
           Reescrever_CSV(CAMINHO, linhas_do_csv);
        }

        public void Deletar(int IdJogador)
        {
            throw new System.NotImplementedException();
        }
    }
}