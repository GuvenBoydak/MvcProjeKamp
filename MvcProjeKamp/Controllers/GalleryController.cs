using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ıfm = new ImageFileManager(new EfImageFileDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var ımageValue = ıfm.List();
            return View(ımageValue);
        }

  
    }
}