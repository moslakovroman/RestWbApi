using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using api.Interfaces;
using model.ViewModels;

namespace RestWbApi.Controllers
{
    public class EditViewModelController : Controller
    {
        private readonly IEditModelHerper _editModelHerper;

        public EditViewModelController(IEditModelHerper editModelHerper)
        {
            _editModelHerper = editModelHerper;
        }


        // GET: EditViewModel
        public ActionResult EditModelHelper(int id)
        {
            var model = _editModelHerper.GetEditUser(id);

            return View("EditViewModel", model);
        }

        public ActionResult SaveEditedUser(EditViewModel model)
        {
            _editModelHerper.SaveEditUser(model);
            return RedirectToAction("Index","Home");
        }

        public ActionResult CancelEditedUser(EditViewModel model)
        {
            _editModelHerper.CancelEditUser(model);
            return RedirectToAction("Index", "Home");
        }
    }
}