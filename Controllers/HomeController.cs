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
            /*
            ClientDAO clientDAO = new ClientDAO();
            ClientVO clientVO = new ClientVO();
            clientVO = ClientDAO.Get;
            */
            return View("Acceuil");
        }
        public ActionResult Cataloge()
        {
            return View("Cataloge");
        }

        public ActionResult Commander(int id)
        {
            if(id == null)
            {
                return View("Commander");
            }
            VoitureDAO voitureDAO = new VoitureDAO();
            VoitureVO voitureVO = new VoitureVO();
            voitureVO = voitureDAO.getVoitureVOById(id);
            return View("Commander", voitureVO);
        }
        
        public ActionResult ListeVoiture()
        {
            VoitureDAO voitureDAO = new VoitureDAO();
            List<VoitureVO> voitures = voitureDAO.recupererVoitures();
            return View("ListeVoiture", voitures);
        }

        public ActionResult Confirmation(string TxtNomVoiture, int IdVoiture, string TxtNom, string TxtPrenom, string Adresse, string Ville, string Pays, string telephone)
        {
            ClientVO clientVO = new ClientVO();
            ClientDAO clientDAO = new ClientDAO();

            clientVO.NomClient = TxtNom;
            clientVO.Prenom = TxtPrenom;
            clientVO.Adresse = Adresse;
            clientVO.Ville = Ville;
            clientVO.Pays = Pays;
            clientVO.Codepostal = telephone;
            clientVO.VoitureCommande = IdVoiture;
            
            ViewData["numeroconfirmation"] = clientDAO.sauvegardeClient(clientVO);
            ViewData["nom"] = TxtNom;
            ViewData["Adresse"] = Adresse;
            ViewData["Ville"] = Ville;
            ViewData["Pays"] = Pays;
            ViewData["telephone"] = telephone;
            ViewData["voiture"] = TxtNomVoiture;
            ViewData["voitureId"] = IdVoiture;
            ViewData["Date"] = DateTime.Now.ToString();
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