using System.Web.Mvc;
using HealthCareClient.Models.Contact;
using System.Collections.Generic;
using AutoMapper;

namespace HealthCareClient.Controllers
{
    public class ContactController : Controller
    {
        ContactContext contactContext = new ContactContext();

        [HttpGet]
        public ActionResult Contacts()
        {
            IEnumerable<Contact> contacts = contactContext.GetAll();            
            return View(contacts);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactEntity entity)
        {
            if (ModelState.IsValid)
            {
                contactContext.Create(entity.contact);
                return RedirectToAction("Contacts");
            }

            return View(entity);

        }

        [HttpGet]   
        public ActionResult Details(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Contacts");
            }
            else
            {
                ContactEntity contactEntity = new ContactEntity();
                contactEntity.contact = contactContext.Get(id);
                return View(contactEntity);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Contacts");
            }
            else
            {
                ContactEntity contactEntity = new ContactEntity();
                contactEntity.contact = contactContext.Get(id);
                return View(contactEntity);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactEntity entity)
        {
            if (ModelState.IsValid)
            {
                contactContext.Edit(entity.contact);
                return RedirectToAction("Contacts");
            }

            return View(entity);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id = 0)
        {
            if (id != 0)
            {
                ContactEntity contactEntity = new ContactEntity();
                contactEntity.contact = contactContext.Get(id);
                return View(contactEntity);
            }
            return RedirectToAction("Contacts");
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(int id = 0)
        {
            if (id != 0)
            {
                contactContext.Delete(id);
            }
            return RedirectToAction("Contacts");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
