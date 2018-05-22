using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.DAO;
using QLVLXD.Common;
using System.Text.RegularExpressions;

namespace QLVLXD.Controllers
{
    public class StorageController : SecurityController
    {
        // GET: Storage
        public ActionResult StockCur()
        {
            var model = new VatLieuDAO().ListAll();
            return View("StockCur",model);
        }
        public ActionResult StockIn()
        {
            ViewBag.VatLieu = new VatLieuDAO().ListAll().Where(x => x.Status == 1).ToList();
            ViewBag.NhaCC = new NhaCCDAO().ListAll().Where(x => x.Status == 1).ToList();
            ViewBag.PhieuNhap = new PhieuNhapDAO().ListView();
            return View("StockIn");
        }
        public ActionResult StockOut()
        {
            return View("StockOut");
        }
        [HasCredential(RoleID = "ADD_VATLIEU")]
        public ActionResult Add()
        {
            return View("Add");
        }
        [HasCredential(RoleID = "UPDATE__VATLIEU")]
        public ActionResult Edit(int id)
        {
            var model = new VatLieuDAO().GetByID(id);
            return View("Edit",model);
        }
        [HasCredential(RoleID = "UPDATE__VATLIEU")]
        public ContentResult EditClick(int id, string name, HttpPostedFileBase file)
        {
            string content = null;
            var img = new VatLieuDAO().GetByID(id).Image;
            vatlieu item = new vatlieu();
            item.ID = id;
            item.Ten = name;
            item.UpdateDate = DateTime.Now;
            item.Image = img;
            if(file != null)
            {
                System.IO.File.Delete(Server.MapPath(img));
                string pic = ConvertToUnSign(name).Replace(" ", "-").ToLower() + System.IO.Path.GetExtension(file.FileName).ToLower();
                string path = System.IO.Path.Combine(Server.MapPath("/Assets/Images"), pic);
                file.SaveAs(path);
                item.Image = "/Assets/Images/" + pic;
                System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath("/Assets/Images"), file.FileName));
            }
            var result = new VatLieuDAO().Update(item);
            if (result)
            {
                content = "<script type='text/javascript'>alert(' Cập nhật thành công');window.location.href = '/Storage/StockCur/';</script>";
            }
            else
            {
                content = "<script type='text/javascript'>alert(' Cập nhật thất bại');</script>";
            }
            return Content(content);

        }
        [HasCredential(RoleID = "ADD_VATLIEU")]
        public ContentResult AddClick(string name, HttpPostedFileBase file)
        {
            string content = null;
            vatlieu item = new vatlieu();
            item.Ten = name;
            item.SoLuong = 0;
            item.CreateDate = DateTime.Now;
            item.UpdateDate = DateTime.Now;
            if(file != null)
            {
                string pic = ConvertToUnSign(name).Replace(" ", "-").ToLower() + System.IO.Path.GetExtension(file.FileName).ToLower();
                string path = System.IO.Path.Combine(Server.MapPath("/Assets/Images"), pic);
                file.SaveAs(path);
                item.Image = "/Assets/Images/" + pic;
                System.IO.File.Delete(System.IO.Path.Combine(Server.MapPath("/Assets/Images"), file.FileName));
            }
            var result = new VatLieuDAO().Insert(item);
            if (result)
            {
                content = "<script type='text/javascript'>alert(' Thêm thành công');window.location.href = '/Storage/StockCur/';</script>";
            }
            else
            {
                content = "<script type='text/javascript'>alert(' Thêm thất bại');</script>";
            }
            return Content(content);
        }
        [HasCredential(RoleID = "DELETE_VATLIEU")]
        public JsonResult DeleteClick(int id)
        {
            var dao = new VatLieuDAO();
            var img = dao.GetByID(id).Image;
            System.IO.File.Delete(Server.MapPath(img));
            var result = dao.Delete(id);
            return Json(new { status = result});
        }
        [HasCredential(RoleID ="CHANGE_STATUS")]
        public JsonResult ChangeStatus(int id)
        {
            new VatLieuDAO().ChangeStatus(id);
            return Json(new { status = true});
        }
        public static string ConvertToUnSign(string text)
        {

            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            text = text.Replace(" ", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').ToLower();
        }



        //Phiếu nhập
        [HasCredential(RoleID = "ADD_STOCKIN")]
        public ContentResult AddStocIn(int id_vl, int id_nhacc, int soluong, int nv_role, int id_nv)
        {
            string content = null;
            phieunhap item = new phieunhap();
            item.ID_NhaCC = id_nhacc;
            item.ID_NV = id_nv;
            item.ID_VL = id_vl;
            item.SoLuong = soluong;
            item.Status = 0;
            if(nv_role != 2)
            {
                item.NgayNhap = DateTime.Now;
                item.Status = 1;
            }
            var result = new PhieuNhapDAO().Insert(item);
            if (result)
            {
                content = "<script type='text/javascript'>alert(' Thêm thành công');window.location.href = '/Storage/StockIn/';</script>";
            }
            else
            {
                content = "<script type='text/javascript'>alert(' Thêm thất bại !');script>";
            }
            return Content(content);
        }
    }
}