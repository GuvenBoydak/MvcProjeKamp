using BusinessLayer.Concrete;
using BusinessLayer.ValidetionRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();

        // GET: Contact
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {

            var contactValues = cm.GetById(id);
            return View(contactValues);
        }

        public PartialViewResult ContactPartial()
        {

            var contant = cm.GetList().Count();
            ViewBag.contant = contant;

            var sendMail = mm.GetListSendbox().Count();
            ViewBag.sendMail = sendMail;

            var ınboxMail = mm.GetListInbox().Count();
            ViewBag.ınboxMail = ınboxMail;

            var draftMail = mm.GetListSendbox().Where(x => x.IsDraft == true).Count();
            ViewBag.ısDraft = draftMail;

            var draftCount = mm.GetListSendbox().Count();
            ViewBag.draftCount = draftCount;



            return PartialView();
        }

    }
}