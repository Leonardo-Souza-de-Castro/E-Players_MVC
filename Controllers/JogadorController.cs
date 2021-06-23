using System;
using E_players_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_MVC.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador JogadorModel = new Jogador();
        Equipe Equipe = new Equipe();

        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.Jogadores = JogadorModel.LerTodos();
            ViewBag.Equipe = Equipe.Ler_Todas();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();
            novoJogador.Id_Jogador = Int32.Parse(form["IdJogador"]);
            novoJogador.Id_Equipe = Int32.Parse(form["IdEquipe"]);
            novoJogador.Nome = form["Nome"];
            novoJogador.Email = form["Email"];
            novoJogador.Senha = form["Senha"];

            JogadorModel.Criar(novoJogador);
            ViewBag.Jogadores = JogadorModel.LerTodos();

            return LocalRedirect("~/Jogador/Index");
        }

        [Route("Excluir/{Id_Jogador}")]
        public IActionResult Excluir(int Id_Jogador){
            JogadorModel.Deletar(Id_Jogador);
            ViewBag.Jogadores = JogadorModel.LerTodos();
            return LocalRedirect("~/Jogador/Index"); 
        }
    }
}