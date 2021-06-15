using System.Collections.Generic;
using System.IO;

namespace E_players_MVC.Models
{
    public abstract class EPlayersBase
    {
        public void Criar_Pasta_e_Arquivo(string _caminho)
        {

            string pasta = _caminho.Split("/")[0];

            string arquivo = _caminho.Split("/")[1];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(_caminho))
            {
                File.Create(_caminho).Close();
            }
        }

        public List<string> Ler_Todas_as_Linhas_CSV(string _caminho)
        {

            List<string> linhas = new List<string>();
            using (StreamReader file = new StreamReader(_caminho))
            {
                string linha;

                while ((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            return linhas;

        }

        public void Reescrever_CSV(string _caminho, List<string> linhas)
        {
            using (StreamWriter output = new StreamWriter(_caminho))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
    }
}