using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class MessageController : Controller
    {
        MessageValidator messageValidator = new MessageValidator();

        // GET: Message
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        [Authorize]
        public ActionResult Inbox(string receiverId)
        {
            var messagelist = messageManager.GetListInbox(receiverId);
            return View(messagelist);
        }
        public ActionResult Sendbox(string senderId)
        {
            var messagelist = messageManager.GetListSendbox(senderId);
            return View(messagelist);
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
            ValidationResult results = messageValidator.Validate(message);
            if (results.IsValid)
            {
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