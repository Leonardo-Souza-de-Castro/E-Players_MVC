using System.Collections.Generic;
using E_players_MVC.Models;

namespace E_players_MVC.Interfaces
{
    public interface IEquipe
    {
         void Criar(Equipe equipe);

         List<Equipe> Ler_Todas();

         void Alterar(Equipe equipe);

         void Deletar(int id);
    }
}