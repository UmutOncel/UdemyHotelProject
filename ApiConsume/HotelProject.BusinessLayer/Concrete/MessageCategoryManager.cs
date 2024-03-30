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
    public class MessageCategoryManager : IMessageCategoryService
    {
        private readonly IMessageCategoryDAL _messageCategoryDAL;

        public MessageCategoryManager(IMessageCategoryDAL messageCategoryDAL)
        {
            _messageCategoryDAL = messageCategoryDAL;
        }

        public void TDelete(MessageCategory t)
        {
            _messageCategoryDAL.Delete(t);
        }

        public MessageCategory TGetByID(int id)
        {
            return _messageCategoryDAL.GetByID(id);
        }

        public List<MessageCategory> TGetList()
        {
            return _messageCategoryDAL.GetList();
        }

        public void TInsert(MessageCategory t)
        {
            _messageCategoryDAL.Insert(t);
        }

        public void TUpdate(MessageCategory t)
        {
            _messageCategoryDAL.Update(t);
        }
    }
}
