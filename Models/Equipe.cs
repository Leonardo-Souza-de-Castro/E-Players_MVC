using System;
using System.Collections.Generic;
using System.IO;
using E_players_MVC.Interfaces;

namespace E_players_MVC.Models
{
    public class Equipe : EPlayersBase, IEquipe
    {
        public int Id_equipe { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }

        private const string CAMINHO = "Database/equipe.csv";

        public Equipe()
        {
            Criar_Pasta_e_Arquivo(CAMINHO);
        }

        private string Preparar(Equipe equipe)
        {
            return $"{equipe.Id_equipe};{equipe.Nome};{equipe.Imagem}";
        }

        public void Alterar(Equipe equipe)
        {
           List<string> linhas_do_csv = Ler_Todas_as_Linhas_CSV(CAMINHO);
           linhas_do_csv.RemoveAll(item => item.Split(";")[0] == equipe.Id_equipe.ToString());
           linhas_do_csv.Add(Preparar(equipe));
           Reescrever_CSV(CAMINHO, linhas_do_csv);
        }

        public void Criar(Equipe equipe)
        {
            string[] linha = { Preparar(equipe) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public void Deletar(int id)
        {
            List<string> linhas_do_csv = Ler_Todas_as_Linhas_CSV(CAMINHO);
           linhas_do_csv.RemoveAll(item => item.Split(";")[0] == id.ToString());
           Reescrever_CSV(CAMINHO, linhas_do_csv);
        }

        public List<Equipe> Ler_Todas()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe_dados = new Equipe();

                equipe_dados.Id_equipe = Int32.Parse(linha[0]);
                equipe_dados.Nome = linha[1];
                equipe_dados.Imagem = linha[2];

                equipes.Add(equipe_dados);
            }

            return equipes;
        }
    }
}