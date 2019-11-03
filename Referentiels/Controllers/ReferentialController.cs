using BusinessContracts.Business.Contracts;
using BusinessDomain.Business.Domain.Models;
using Microsoft.Extensions.Logging;
using Referentiels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Referentiels.Controllers
{
    public class ReferentialController : Controller
    {

        private readonly IClasseListeService _classeListeService;
        private readonly IAbsenceListeService _absenceListeService;

  

        public ReferentialController(IClasseListeService classeListeService, IAbsenceListeService absenceListeService)
        {
            _classeListeService = classeListeService;
            _absenceListeService = absenceListeService;


        }


        public ActionResult Index(ItemListViewModel model)
        {
            var modele = model;

            if (modele == null)
            {
                modele = new ItemListViewModel();
            }

            modele.ClasseListes = _classeListeService.GetAllCatListes();
            

            return View("Index", modele);
        }

        public ActionResult CreateClasseListe()
        {
                
                var model = new ClasseListeViewModel();
          
                return View("CreateClasseListe", model);
            
        }

        public ActionResult CreateAbsenceListe(int id)
        {
             

            var modele = new ItemListViewModel();

               modele.IdClasses = id;
            modele = LoadClasseListAndAbsenceByList(modele);

            return View(modele);
   
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAbsenceListe(ItemListViewModel modele)
        {
            var model = LoadClasseListAndAbsenceByList(modele);

            try
            {
                // check if can modify item : can't have duplicate item
                ItemListe item = CheckItemExist(model.Nom, model.Prenom, model.Horaires, model.IdClasses);

                if (item != null)
                {
                    _absenceListeService.UpdateAbsenceListe(model.Id, model.Date, model.Horaires, model.Nom, model.Prenom, model.Presences, model.Commentaires, model.IdClasses);
                    model.MessageSuccess = "Absences mise à jour avec succès.";
                }
                else
                {
                   
                    var result = _absenceListeService.CreateAbsenceListe(model.Date, model.Horaires, model.Nom, model.Prenom, model.Presences, model.Commentaires, model.IdClasses);

                    model.MessageSuccess = "Absence créé avec succès.";

                }
            }
            catch (Exception e)
            {
                model.MessageError = "Erreur lors de l'édition : " + e.Message;
                return View(model);
            }

            return RedirectToAction("ItemList", new { id = model.IdClasses });
        }



        private ItemListViewModel LoadClasseListAndAbsenceByList(ItemListViewModel model)
        {
            model.ClasseListe = _classeListeService.GetClasseListeById(model.IdClasses);

                model.AbsencesByClasses = new List<ListItem>();

            model.AbsencesByClasses.Add(new ListItem { Text = "", Value = "" });

            model.AbsencesByClasses.Add(
                    new ListItem { Text = "Matin", Value = "Matin" });

                model.AbsencesByClasses.Add(
                    new ListItem { Text = "Apres-Midi", Value = "Apres-Midi" });

            

            return model;
        }


        private ItemListe CheckItemExist(string Nom, string Prenom, string Horaires,int idClasses)
        {
            List<ItemListe> listItem = _absenceListeService.GetAllItemListByList(idClasses).ToList();
            ItemListe item = listItem.FirstOrDefault(x => x.Nom.Equals(Nom) && x.Prenom.Equals(Prenom) && x.Horaires.Equals(Horaires));
            if (item != null)
            {
                return item;
            }
            return null;
        }

        public ActionResult ItemList(int id)
        {
             var modele = new ItemListViewModel();


                modele.ClasseListe = _classeListeService.GetClasseListeById(id);
                //modele.ItemLists = _classeListeService.GetAllItemListByList(id);

                modele.listItemList = _absenceListeService.GetAllItemListByList(Convert.ToInt32(id));


                return View("ItemList", modele);

          

        }

        public ActionResult EditItemLists(int id)
        {
                var item = _absenceListeService.GetItemListById(id);

                var model = new ItemListViewModel();
                model.Id = item.Id;
                model.Date = item.Date;
                model.Horaires = item.Horaires;
                model.Nom = item.Nom;
                model.Prenom = item.Prenom;
                model.Presences = item.Presences;
               model.Commentaires = item.Commentaires;
               model.IdClasses = item.IdClasses;
               model.ClasseListe = _classeListeService.GetClasseListeById(id);

            return View("EditItemLists", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditItemLists(ItemListViewModel modele)
        {

        
            var model = LoadClasseListAndAbsenceByList(modele);

         try
            {
                

                if (model == null)
                {

                    modele.MessageSuccess = "Erreur lors de la modification de l'absence";
                }
                else
                {

                    _absenceListeService.UpdateAbsenceListe(model.Id, model.Date, model.Horaires, model.Nom, model.Prenom, model.Presences, model.Commentaires, model.IdClasses);
                    model.MessageError = "Absence mis à jour avec succès.";
                }

            }
         catch (Exception e)
            {
                model.MessageError = "Erreur lors de l'édition : " + e.Message;
                return View(model);
            }

            return RedirectToAction("ItemList", new { id = model.IdClasses });
            }


        public ActionResult EditClasseListe(int id)
        {
           
            var item = _classeListeService.GetClasseListeById(id);

            var model = new ClasseListeViewModel();
            model.Id = item.Id;
            model.NomClasses = item.NomClasses;
            model.Niveau = item.Niveau;
   

            return View("EditClasseListe", model);



        }

    }
}