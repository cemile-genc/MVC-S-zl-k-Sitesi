using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class MessageManager : IMessageService
	{
		IMessageDal _messageDal;

		public MessageManager(IMessageDal messageDal)
		{
			_messageDal = messageDal;
		}

		public Message GetById(int id)
		{
			return _messageDal.Get(x => x.MessageId == id);
		}

		public List<Message> GetListInbox(string receiverId) //admine gelen mesajlar
		{

			//return _messageDal.List(x => x.ReceiverMail == "egünn@gmail.com"); //sağlıklı bir yöntem değil.
			return _messageDal.List(x => x.ReceiverMail == receiverId); //sağlıklı bir yöntem değil.

		}
		public List<Message> GetListSendbox(string senderId)
		{
			return _messageDal.List(x => x.SenderMail == senderId);

		}

		public void MessageAdd(Message message)
		{
			_messageDal.İnsert(message);
		}

		public void MessageDelete(Message message)
		{
			throw new NotImplementedException();
		}

		public void MessageUpdate(Message message)
		{
			throw new NotImplementedException();
		}
	}
}
