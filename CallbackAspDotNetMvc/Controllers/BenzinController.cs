using CallbackAspDotNetMvc.Models;
using System;
using System.Collections.Generic;
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
                model.payed_at = Convert.ToDateTime(collection.Get("payed_at"));
                model.probeg = Convert.ToInt32(collection.Get("probeg"));
                model.litrs = Convert.ToInt32(collection.Get("litrs"));
                model.summa = Convert.ToDecimal(collection.Get("summa"));
                model.Save();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return this.Create();
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
                return this.Edit(id);
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
