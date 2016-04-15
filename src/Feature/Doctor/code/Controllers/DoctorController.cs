using Sitecore.Data;
using Sitecore.Feature.Doctor.Repositories;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sitecore.Feature.Doctor.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorsRepositoryFactory doctorRepositoryFactory;
        public DoctorController() : this(new DoctorsRepositoryFactory())
        {
        }
        public DoctorController(IDoctorsRepositoryFactory doctorRepositoryFactory)
        {
            this.doctorRepositoryFactory = doctorRepositoryFactory;
        }
        [HttpGet]
        public ActionResult DoctorSearch()
        {
            return this.View("DoctorSearch", new List<Models.Doctor>());
        }
        [HttpPost]
        public ViewResult DoctorSearch(string q,string free)
        {
            IEnumerable<Models.Doctor> doctorList;
            DoctorsRepository repository = (DoctorsRepository)doctorRepositoryFactory.Create(Context.Database.GetItem(Templates.DoctorList.ID));
            if(!string.IsNullOrEmpty(q))
                doctorList = repository.searchByLetter(q);
            else
                doctorList = repository.searchByfreeText(free);
            return View("DoctorSearch", doctorList);
        }

    }
}