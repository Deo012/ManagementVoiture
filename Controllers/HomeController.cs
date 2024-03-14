using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabMVC.Models;

namespace LabMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Acceuil()
        {
            return View("Acceuil");
        }
        public ActionResult Cataloge()
        {
            return View("Cataloge");
        }

        public ActionResult Commander()
        {
            return View("Commander");
        }
        public ActionResult ListeVoiture()
        {
            VoitureDAO voitureDAO = new VoitureDAO();
            List<VoitureVO> voitures = voitureDAO.recupererVoitures();
            return View("ListeVoiture", voitures);
        }

        public ActionResult Confirmation(string TxtNom)
        {
            ClientVO clientVO = new ClientVO();
            ClientDAO clientDAO = new ClientDAO();

            clientVO.NomClient = TxtNom;
            
            ViewData["numeroconfirmation"] = clientDAO.sauvegardeClient(clientVO);
            ViewData["nom"] = TxtNom;
            return View("Confirmation");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}