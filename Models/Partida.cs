using System;

namespace E_players_MVC.Models
{
    public class Partida
    {
        public int Id_Partida { get; set; }
        
        public int Id_Jogador_1 { get; set; }
        
        public int Id_Jogador_2 { get; set; }
        
        public DateTime Horario_inicio { get; set; }
        
        public DateTime Horario_termino { get; set; }
    }
}