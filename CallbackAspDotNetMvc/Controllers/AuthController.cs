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

    public class AuthController : Controller
    {
        private readonly Random _rng = new Random();
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        private string RandomString(int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }
        //
        // GET: /Auth/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Telephone(string telephone)
        {
            try
            {
                AMS.Profile.Ini Ini = new AMS.Profile.Ini(AppDomain.CurrentDomain.BaseDirectory + "\\Callback.ini");
                if (!Ini.HasSection("SMSC"))
                {
                    Ini.SetValue("SMSC", "login", "mgerasim");
                    Ini.SetValue("SMSC", "psw", "zaq12wsx");
                }


                string login = Ini.GetValue("SMSC", "login", "some-login");
                string psw = Ini.GetValue("SMSC", "psw", "some-password");

                string code = this.RandomString(4);
                string url = "http://smsc.ru/sys/send.php?login=" + login + "&psw=" + psw + "&phones=" + telephone + "&mes=" + code;

                var request = (HttpWebRequest)WebRequest.Create(url);

                var response = (HttpWebResponse)request.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


                var serializer = new JavaScriptSerializer();

                // For simplicity just use Int32's max value.
                // You could always read the value from the config section mentioned above.
                serializer.MaxJsonLength = Int32.MaxValue;

                CallbackAspDotNetMvc.Models.User theUser = null;
                theUser = Models.User.GetByPhone(telephone);
                if (theUser == null)
                {
                    theUser = new Models.User();
                    theUser.code = code;
                    theUser.telephone = telephone;
                    theUser.result = responseString;
                    theUser.Save();
                }
                else
                {
                    theUser.code = code;
                    theUser.result = responseString;
                    theUser.Update();
                }

                var resultData = new { telephone = telephone, result = responseString };
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


                string err = ex.Message;
                if (ex.InnerException != null)
                {
                    err += ex.InnerException.Message;
                }

                var resultData = new { telephone = telephone, error = err };
                var result = new ContentResult
                {
                    Content = serializer.Serialize(resultData),
                    ContentType = "application/json"
                };
                return result;
            }
            return View();
        }

        public ActionResult Code(string telephone, string code)
        {
            try
            {
                CallbackAspDotNetMvc.Models.User theUser = null;
                theUser = Models.User.GetByPhone(telephone);
                if (theUser == null)
                {
                    return Content("Пользователь с номер " + telephone + " не существует");
                }

                if (theUser.code != code.ToUpper())
                {
                    string err = "Для пользователя с номером " + telephone + "указанный проверочный код " + code + " не верный!";
                    theUser.result = err;
                    theUser.Update();
                    return Content(err);
                }
                
                return Content("");
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                if (ex.InnerException != null)
                {
                    err += ex.InnerException.Message;
                }
                return Content(err);
            }
        }

        public ActionResult Person(string telephone, string code, string lastname, string firstname, string secondname)
        {
            try
            {
                CallbackAspDotNetMvc.Models.User theUser = null;
                theUser = Models.User.GetByPhone(telephone);
                if (theUser == null)
                {
                    return Content("Пользователь с номер " + telephone + " не существует");
                }

                if (theUser.code != code.ToUpper())
                {
                    string err = "Для пользователя с номером " + telephone + "указанный проверочный код " + code + " не верный!";
                    theUser.result = err;
                    theUser.Update();
                    return Content(err);
                }

                theUser.lastname = lastname;
                theUser.firstname = firstname;
                theUser.secondname = secondname;
                theUser.Update();

                return Content("");
            }
            catch (Exception ex)
            {

                string err = ex.Message;
                if (ex.InnerException != null)
                {
                    err += ex.InnerException.Message;
                }
                return Content(err);
            }
        }

        public ActionResult Signin()
        {
            
            return View();
        }

    }
}
