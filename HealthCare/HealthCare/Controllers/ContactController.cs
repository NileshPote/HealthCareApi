using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic;
using Entities;
using System.Web.Http.Description;
namespace HealthCare.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IContactServices _ContactServices;
        public ContactController(IContactServices ContactServices)
        {
            this._ContactServices = ContactServices;
        }

        // GET api/Contact
        [HttpGet]
        [ResponseType(typeof(ContactEntity))]
        public IHttpActionResult GetAllContacts()
        {
           var contacts = _ContactServices.GetAllContacts();
            if (contacts != null)
            {
                var contactsEntities = contacts as List<ContactEntity> ?? contacts.ToList();
                if (contactsEntities.Any())
                    return Ok(contactsEntities);
            }
            return BadRequest("Contacts not found");
        }

        // GET api/Contact/id
        [HttpGet]
        [ResponseType(typeof(ContactEntity))]
        public IHttpActionResult GetContactById(int id)
        {
            ContactEntity contacts = _ContactServices.GetContactById(id);
            if (contacts != null)
            {
                return Ok(contacts);
            }
            return BadRequest("Contacts not found for ID : " + id);
        }

        // POST api/Contact
        [HttpPost]
        [ResponseType(typeof(ContactEntity))]
        public IHttpActionResult CreateContact([FromBody] ContactEntity contactEntity)
        {
            if (ModelState.IsValid)
            {
                return Ok(_ContactServices.CreateContact(contactEntity));
            }
            else
            {
                return BadRequest("Invalid Contact information");
            }
        }

        // PUT api/Contact/id
        [HttpPut]
        [ResponseType(typeof(ContactEntity))]
        public IHttpActionResult UpdateContact(int id, [FromBody] ContactEntity contactEntity)
        {
            if (ModelState.IsValid && id > 0)
            {
                return Ok(_ContactServices.UpdateContact(id, contactEntity));
            }
            return BadRequest("Invalid Contact information");

        }

        // DELETE api/Contact/id
        [HttpDelete]
        [ResponseType(typeof(ContactEntity))]
        public IHttpActionResult DeleteContact(int id)
        {
            ContactEntity contact;
            if (id > 0)
            {
                contact  = _ContactServices.GetContactById(id);
                if (contact == null)
                {
                    return NotFound();
                }
                return Ok(_ContactServices.DeleteContact(id));
            }
            return BadRequest("Invalid Contact");
        }

    }
}
