using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Abstract
{
    public interface IContactDAL: IGenericDAL<Contact>
    {
        int GetContactCount();

        List<Contact> GetContactsInCategoryThank();

        List<Contact> GetContactsInCategoryComplaint();

        List<Contact> GetContactsInCategorySuggestion();

        List<Contact> GetContactsInCategoryDemand();

        List<Contact> GetContactsInCategoryJobApplication();

        List<Contact> GetContactsInCategoryOther();
    }
}
