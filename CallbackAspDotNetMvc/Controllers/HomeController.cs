using AMS.Profile;
using CallbackAspDotNetMvc.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CallbackAspDotNetMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            try
            {
                ViewBag.Error = "";
                List<Call> theList = Call.GetAll();
                return View(theList);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                string err = ex.Message;
                if (ex.InnerException != null)
                {
                    ViewBag.Error += ": " + ex.InnerException.Message;
                }

                return View();
            }
        }

        public ActionResult UpdateSchema()
        {
            try
            {
                CallbackAspDotNetMvc.Common.NHibernateHelper.UpdateSchema();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                if (ex.InnerException != null)
                {
                    err += ": " + ex.InnerException.Message;
                }
                return Content(err);
            }
            return Content("База данных успешно обновлена!");
        }
        public ActionResult doCall(string Name, string phoneBgn, string phoneEnd)
        {
            try
            {
                AMS.Profile.Ini Ini = new AMS.Profile.Ini(AppDomain.CurrentDomain.BaseDirectory + "\\Callback.ini");
                if (!Ini.HasSection("COMMON"))
                {
                    Ini.SetValue("COMMON", "account_id", "12345");
                    Ini.SetValue("COMMON", "api_key", "some-as-uuid-string");
                }


                string account_id = Ini.GetValue("COMMON", "account_id", "12345");
                string api_key = Ini.GetValue("COMMON", "api_key", "some-as-uuid-string");

                string url = "https://api.voximplant.com/platform_api/StartScenarios/?account_id="+ account_id +"&api_key=" + api_key + "&rule_id=135498&script_custom_data=" + phoneBgn + "%3A" + phoneEnd + "";

                var request = (HttpWebRequest)WebRequest.Create(url);

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                
                Call theCall = Call.GetByCall(phoneBgn, phoneEnd);
                if (theCall == null) {
                    theCall = new Call();
                    theCall.Name = Name;
                    theCall.phoneBgn = phoneBgn;
                    theCall.phoneEnd = phoneEnd;
                    theCall.Save();
                }
                else
                {
                    theCall.CallsCount++;
                    theCall.Name = Name;
                    theCall.Update();
                }

                var serializer = new JavaScriptSerializer();

                // For simplicity just use Int32's max value.
                // You could always read the value from the config section mentioned above.
                serializer.MaxJsonLength = Int32.MaxValue;

                var resultData = new { phone_bgn = phoneBgn, phone_end = phoneEnd, result = responseString };
                var result = new ContentResult
                {
                    Content = serializer.Serialize(resultData),
                    ContentType = "application/json"
                };
                return result;
            }
            catch (Exception ex)
            {
                var serializer = new JavaScriptSerializer();

                // For simplicity just use Int32's max value.
                // You could always read the value from the config section mentioned above.
                serializer.MaxJsonLength = Int32.MaxValue;

                var resultData = new { phone_bgn = phoneBgn, phone_end = phoneEnd, error = ex.Message };
                var result = new ContentResult
                {
                    Content = serializer.Serialize(resultData),
                    ContentType = "application/json"
                };
                return result;
            }
        }
    }
}
