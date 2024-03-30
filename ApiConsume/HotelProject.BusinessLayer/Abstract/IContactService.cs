using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Abstract
{
    public interface IContactService: IGenericService<Contact>
    {
        int TGetContactCount();

        List<Contact> TGetContactsInCategoryThank();

        List<Contact> TGetContactsInCategoryComplaint();

        List<Contact> TGetContactsInCategorySuggestion();

        List<Contact> TGetContactsInCategoryDemand();

        List<Contact> TGetContactsInCategoryJobApplication();

        List<Contact> TGetContactsInCategoryOther();
    }
}
