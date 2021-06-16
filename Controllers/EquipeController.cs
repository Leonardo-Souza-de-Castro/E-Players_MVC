using System;
using E_players_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Players_MVC.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipe_model = new Equipe();
        
        [Route ("Listar")]
        public IActionResult Index()
        {

            ViewBag.Equipes = equipe_model.Ler_Todas();
            return View();
        }

        [Route("Cadastrar")]

        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe nova_equipe = new Equipe();
            nova_equipe.Id_equipe = Int32.Parse(form["Id_equipe"]);
            nova_equipe.Nome = form["Nome"];
            nova_equipe.Imagem = form["Imagem"];

            equipe_model.Criar(nova_equipe);

            ViewBag.Equipes = equipe_model.Ler_Todas();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}