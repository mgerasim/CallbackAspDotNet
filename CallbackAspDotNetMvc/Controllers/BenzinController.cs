using CallbackAspDotNetMvc.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallbackAspDotNetMvc.Controllers
{
    public class BenzinController : Controller
    {
        //
        // GET: /Benzin/
        public ActionResult Control()
        {
            Control theControl = new Control();
            return View(theControl);
        }
        public ActionResult Index()
        {
            List<Benzin> theBenzinList = Benzin.GetAll();
            return View(theBenzinList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Benzin model = new Benzin();
                model.payed_at = DateTime.ParseExact(collection.Get("payed_at"), "dd.MM.yyyy",
                                  CultureInfo.InvariantCulture);

                model.probeg = Convert.ToInt32(collection.Get("probeg"));
                model.litrs = Convert.ToInt32(collection.Get("litrs"));
                model.summa = Convert.ToDecimal(collection.Get("summa"));
                model.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                if (ex.InnerException != null)
                {
                    err += ex.InnerException.Message;
                }
                return RedirectToAction("Create", "Gorod", new { error = err, notice = "" });
            }
        }

        public ActionResult Edit(int id)
        {
            return View(Benzin.GetById(id));
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Benzin model = Benzin.GetById(id);
                model.payed_at = Convert.ToDateTime(collection.Get("payed_at"));
                model.probeg = Convert.ToInt32(collection.Get("probeg"));
                model.litrs = Convert.ToInt32(collection.Get("litrs"));
                model.summa = Convert.ToDecimal(collection.Get("summa"));
                model.Update();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                if (ex.InnerException != null)
                {
                    err += ex.InnerException.Message;
                }
                return RedirectToAction("Edit", "Gorod", new { error = err, notice = "" });
            }
        }

        public ActionResult Delete(int id)
        {
            Benzin model = Benzin.GetById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Benzin model = Benzin.GetById(id);

                model.Delete();

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.error = e.ToString();

                return View();
            }
        }

    }
}
