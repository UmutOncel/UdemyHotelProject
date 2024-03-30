using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDAL _contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void TDelete(Contact t)
        {
            _contactDAL.Delete(t);
        }

        public Contact TGetByID(int id)
        {
            return _contactDAL.GetByID(id);
        }

        public int TGetContactCount()
        {
            return _contactDAL.GetContactCount();
        }

        public List<Contact> TGetContactsInCategoryComplaint()
        {
            return _contactDAL.GetContactsInCategoryComplaint();
        }

        public List<Contact> TGetContactsInCategoryDemand()
        {
            return _contactDAL.GetContactsInCategoryDemand();
        }

        public List<Contact> TGetContactsInCategoryJobApplication()
        {
            return _contactDAL.GetContactsInCategoryJobApplication();
        }

        public List<Contact> TGetContactsInCategoryOther()
        {
            return _contactDAL.GetContactsInCategoryOther();
        }

        public List<Contact> TGetContactsInCategorySuggestion()
        {
            return _contactDAL.GetContactsInCategorySuggestion();
        }

        public List<Contact> TGetContactsInCategoryThank()
        {
            return _contactDAL.GetContactsInCategoryThank();
        }

        public List<Contact> TGetList()
        {
            return _contactDAL.GetList();
        }

        public void TInsert(Contact t)
        {
            _contactDAL.Insert(t);
        }

        public void TUpdate(Contact t)
        {
            _contactDAL.Update(t);
        }
    }
}
