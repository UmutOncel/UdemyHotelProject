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
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDAL _sendMessageDAL;

        public SendMessageManager(ISendMessageDAL sendMessageDAL)
        {
            _sendMessageDAL = sendMessageDAL;
        }

        public void TDelete(SendMessage t)
        {
            _sendMessageDAL.Delete(t);
        }

        public SendMessage TGetByID(int id)
        {
            return _sendMessageDAL.GetByID(id);
        }

        public List<SendMessage> TGetList()
        {
            return _sendMessageDAL.GetList();
        }

        public void TInsert(SendMessage t)
        {
            _sendMessageDAL.Insert(t);
        }

        public void TUpdate(SendMessage t)
        {
            _sendMessageDAL.Update(t);
        }
    }
}
