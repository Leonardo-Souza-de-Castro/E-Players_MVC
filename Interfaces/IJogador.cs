using System.Collections.Generic;
using E_players_MVC.Models;

namespace E_Players_MVC.Interfaces
{
    public interface IJogador
    {
         void Criar(Jogador j);

         List<Jogador> LerTodos();

         void Alterar(Jogador j);

         void Deletar(int IdJogador);
    }
}