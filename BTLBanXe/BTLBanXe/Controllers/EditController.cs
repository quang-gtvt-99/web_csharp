using BTLBanXe.Models;
using KetNoiCSDL.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTLBanXe.Controllers
{
   
    public class EditController : Controller
    {
        
        QuanLyBanXeEntities1 db = new QuanLyBanXeEntities1();
        // GET: Edit
        public ActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        
        public ActionResult KhachHang()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KhachHang(int a)
        {
            return View();
        }

        public PartialViewResult danhmucsp()
        {
            return PartialView(db.tbSanPhams.OrderByDescending(n => n.MaLoai).ToList());
        }
        public PartialViewResult danhmuckh()
        {
            return PartialView(db.tbKhachHangs.OrderByDescending(n => n.MaKH).ToList());
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var user = new UserDao().Delete(id);
            return RedirectToAction("SanPham","Edit");
        }

        [HttpGet]
        public ActionResult xoa(string MaSP)
        {
            tbSanPham sanpham = db.tbSanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }
        [HttpPost, ActionName("xoa")]
        public ActionResult xacnhanxoa(string MaSP)
        {
            tbSanPham sanpham = db.tbSanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            var anhsp = from p in db.tbAnhSPs where p.MaSP == sanpham.MaSP select p;
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.tbAnhSPs.RemoveRange(anhsp);
            db.tbSanPhams.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("SanPham","Edit");
        }

        [HttpGet]
        public ActionResult xoakh(int MaKH)
        {
            tbKhachHang sanpham = db.tbKhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }
        [HttpPost, ActionName("xoakh")]
        public ActionResult xacnhanxoakh(int MaKH)
        {
            tbKhachHang sanpham = db.tbKhachHangs.SingleOrDefault(n => n.MaKH == MaKH);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.tbKhachHangs.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("KhachHang", "Edit");
        }

        public ActionResult Edit(int id)
        { var user = new UserDao().ViewDetail(id)
                ;
            return View(user);
        }
        [HttpPost]
        


        public ActionResult _layout2()
        {
            var x = new adminmodel();
            ViewBag.user = x.x;
            return View();
        }
        [HttpGet]
        public ActionResult SanPham()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SanPham(tbSanPham sp)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var dbc = new QuanLyBanXeEntities1();
                if (dbc.tbSanPhams.Any(x => x.MaSP == sp.MaSP))
                {
                    ModelState.AddModelError("Thông báo", "Mã sản phẩm này đã tồn tại");
                    SetAlert("Lỗi", "error");
                }
                else
                {
                    string id = dao.Insertsp(sp);
                    if (id != null)
                    {
                        SetAlert("Đăng kí thành công", "success");
                        return RedirectToAction("insertCus", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thông tin khách hàng không thành công.");
                    }
                }



            }
            return View("Create");
        }
        protected void SetAlert(string message, string type) { TempData["AlertMessage"] = message; if (type == "success") { TempData["AlertType"] = "alert-success"; } else if (type == "warning") { TempData["AlertType"] = "alert-warning"; } else if (type == "error") { TempData["AlertType"] = "alert-danger"; } }
    }
}