using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        // GET: Heading
        public ActionResult Index()
        {
            var HeadingValues = hm.GetList();
            return View(HeadingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text=x.CategoryName,
                                                      Value=x.CategoryId.ToString(),
                                                  }).ToList();

            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                select new SelectListItem
                                                { 
                                                    Text=x.WriterName + " " + x.WriterSurName,
                                                    Value=x.WriterId.ToString(),
                                                }).ToList();

            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate =DateTime.Parse( DateTime.Now.ToLongDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString(),
                                                  }).ToList();

            ViewBag.vlc = valueCategory;
            var headingValue = hm.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingvalue= hm.GetById(id);

            if (headingvalue.HeadingStatus==true)
            {
                headingvalue.HeadingStatus = false;
            }
            else
            {
                headingvalue.HeadingStatus = true;
            }
            hm.HeadingDelete(headingvalue);
            return RedirectToAction("Index");
        }

      


    }
}