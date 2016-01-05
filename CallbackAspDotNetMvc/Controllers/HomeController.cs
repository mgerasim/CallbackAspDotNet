using AMS.Profile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CallbackAspDotNetMvc.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult doCall(string phoneBgn, string phoneEnd)
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

                return Content("");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            return Content("");
        }
    }
}
