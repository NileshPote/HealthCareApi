using System;
using System.Collections.Generic;
using DataAccess.GenericRepository;
using System.Data.Entity.Validation;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HealthCareModel _context = null;
        private GenericRepository<Contact> _contactRepo;
        public UnitOfWork()
        {
            _context = new HealthCareModel();
        }
        GenericRepository<Contact> IUnitOfWork.ContactRepository
        {
            get
            {
                if (this._contactRepo == null)
                    this._contactRepo = new GenericRepository<Contact>(_context);
                return _contactRepo;
            }
        }

        void IUnitOfWork.Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var error = new List<string>();
                foreach (var entityError in e.EntityValidationErrors)
                {
                    error.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, entityError.Entry.Entity.GetType().Name, entityError.Entry.State));
                    foreach (var validationError in entityError.ValidationErrors)
                    {
                        error.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", error);

                throw e;
            }
        }
    }
}
