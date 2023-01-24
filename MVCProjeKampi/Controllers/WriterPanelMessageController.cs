using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
		// GET: WriterPanelMessage
		MessageValidator messageValidator = new MessageValidator();

		MessageManager messageManager = new MessageManager(new EfMessageDal());
		public ActionResult Inbox()
		{
			string receiverId = (string)Session["WriterMail"];
			var messagelist = messageManager.GetListInbox(receiverId);
			return View(messagelist);
		}
		public ActionResult Sendbox()
		{
			string senderId = (string)Session["WriterMail"];
			var messagelist = messageManager.GetListSendbox(senderId);
			return View(messagelist);
		}
		public PartialViewResult WriterMessagePartial()
		{
			return PartialView();
		}
		public ActionResult GetSendboxMessageDetails(int id)
		{
			var messagevalues = messageManager.GetById(id);
			return View(messagevalues);
		}
		public ActionResult GetInboxMessageDetails(int id)
		{
			var messagevalues = messageManager.GetById(id);
			return View(messagevalues);
		}
		[HttpGet]
		public ActionResult NewMessage()
		{
			return View();

		}
		[HttpPost]
		public ActionResult NewMessage(Message message)
		{
			string sender = (string)Session["WriterMail"];
			ValidationResult results = messageValidator.Validate(message);
			if (results.IsValid)
			{
				message.SenderMail = sender;
				message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
				messageManager.MessageAdd(message);
				return RedirectToAction("Sendbox");
			}
			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();

		}

	}
}