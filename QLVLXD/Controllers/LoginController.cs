using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using QLVLXD.Common;
namespace QLVLXD.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(string username, string password)
        {
            ViewBag.Notif = null;
            if (ModelState.IsValid)
            {
                var Dao = new NhanVienDao();
                long result = Dao.Login(username, GetMD5(password));
                if (result != 0)
                {
                    var user = Dao.GetByID(result);
                    var UserSession = new UserLogin();
                    UserSession.Name = user.Ten;
                    UserSession.UserID = user.ID;
                    UserSession.VaiTro = user.ID_VT;
                    var ListCredentials = Dao.GetListCredential(result);
                    Session.Add(CommonConstants.SESSION_CREDENTIAL, ListCredentials);
                    Session.Add(CommonConstants.USER_SESSION, UserSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Notif = "Đăng nhập không thành công ! Thử lại";
                }
            }
            return View("Index") ;
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "Home");
        }
        private String GetMD5(string txt)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }
    }
}