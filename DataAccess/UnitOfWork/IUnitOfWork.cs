using System;
using DataAccess.GenericRepository;
namespace DataAccess.UnitOfWork
{
   public interface IUnitOfWork
    {
        #region Properties
        GenericRepository<Contact> ContactRepository { get; }

        #endregion

        /// <summary>
        /// Save method.
        /// </summary>
        void Save();
    }
}
