using Entities;
using System.Collections.Generic;


namespace BusinessLogic
{
   public interface IContactServices
    {
        ContactEntity GetContactById(int Id);
        IEnumerable<ContactEntity> GetAllContacts();
        int CreateContact(ContactEntity contactEntity);
        bool UpdateContact(int Id, ContactEntity contactEntity);
        bool DeleteContact(int Id);
    }
}
