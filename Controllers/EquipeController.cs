using System;
using System.IO;
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
            /* nova_equipe.Imagem = form["Imagem"]; */

            // inicio do Upload
            if (form.Files.Count > 0)
            {

                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                nova_equipe.Imagem = file.FileName;

            }
            else
            {
                nova_equipe.Imagem = "padrao.png";
            }
            // Fim do Upload

            equipe_model.Criar(nova_equipe);

            ViewBag.Equipes = equipe_model.Ler_Todas();

            return LocalRedirect("~/Equipe/Listar");
        }

        [Route("{id}")]
        public IActionResult Excluir(int id){
            equipe_model.Deletar(id);
            ViewBag.Equipes = equipe_model.Ler_Todas();
            return LocalRedirect("~/Equipe/Listar"); 
        }
    }
}