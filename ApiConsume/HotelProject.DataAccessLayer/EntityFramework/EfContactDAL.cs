using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repository;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfContactDAL : GenericRepository<Contact>, IContactDAL
    {
        public EfContactDAL(HotelProjectDbContext context) : base(context)
        {
        }

        public int GetContactCount()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            return context.Contacts.Count();
        }

        public List<Contact> GetContactsInCategoryThank()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            return context.Contacts.Where(x => x.MessageCategoryId == 1).ToList();
        }

        public List<Contact> GetContactsInCategoryComplaint()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            return context.Contacts.Where(x => x.MessageCategoryId == 2).ToList();
        }

        public List<Contact> GetContactsInCategorySuggestion()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            return context.Contacts.Where(x => x.MessageCategoryId == 3).ToList();
        }

        public List<Contact> GetContactsInCategoryDemand()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            return context.Contacts.Where(x => x.MessageCategoryId == 4).ToList();
        }

        public List<Contact> GetContactsInCategoryJobApplication()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            return context.Contacts.Where(x => x.MessageCategoryId == 5).ToList();
        }

        public List<Contact> GetContactsInCategoryOther()
        {
            HotelProjectDbContext context = new HotelProjectDbContext();
            return context.Contacts.Where(x => x.MessageCategoryId == 6).ToList();
        }
    }
}
