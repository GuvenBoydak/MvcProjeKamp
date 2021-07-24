using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKamp.Controllers
{
    public class StatisticsController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context c = new Context();
        // GET: Statistics
        public ActionResult Statistics()
        {
            // Kategori Sayısı
            ViewBag.TotalCategory = c.Categories.Count();

            //Yazılım Kategorisine ait Başlıklar
            ViewBag.SoftwareCategory = c.Headings.Count(x => x.CategoryId == 22);

            //"A" Harfı olan Yazar sayısı
            ViewBag.WriterName = c.Writers.Count(x => x.WriterName.Contains("A") || x.WriterName.Contains("a"));

            // En fazla başlığa sahip kategori
            ViewBag.maximumtitle = c.Categories
                .Where(x => x.CategoryId == c.Headings.GroupBy(y => y.CategoryId)
                .OrderByDescending(y => y.Count()).Select(y => y.Key)
                .FirstOrDefault()).Select(z => z.CategoryName)
                .FirstOrDefault();

            // Aktif ve Pasif kategori arasındaki sayısal fark

            var difference = c.Categories.Count(x => x.CategoryStatus == true) - c.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.StatusDiffrerent = difference;
            return View();

        }
    }
}