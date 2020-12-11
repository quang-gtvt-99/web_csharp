using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BTLBanXe.Models;
using System.Data.Entity;
using System.Net;
using PagedList;
using KetNoiCSDL.DAO;

namespace BTLBanXe.Controllers
{
    public class HomeController : Controller
    {
        QuanLyBanXeEntities1 db = new QuanLyBanXeEntities1();
        // GET: Home
        public ActionResult Index()
        {

            return View(db.tbSanPhams.ToList());
        }
        public PartialViewResult spNoiBatPartial(int? page)
        {

            return PartialView(db.tbSanPhams.Where(n => n.MaDacTinh == "NB").ToList());
        }
        public PartialViewResult spMoiVePartial()
        {


            return PartialView(db.tbSanPhams.Where(n => n.MaDacTinh == "New").OrderByDescending(n => n.TenSP).ToList());
        }

        public PartialViewResult spBanChayPartial()
        {


            return PartialView(db.tbSanPhams.Where(n => n.SLBAN >= 5).OrderByDescending(n => n.TenSP).ToList());
        }
        public ViewResult XemChiTiet(string masp)
        {
            tbSanPham loai = db.tbSanPhams.SingleOrDefault(n => n.MaSP == masp);
           
            tbSanPham sanpham = db.tbSanPhams.SingleOrDefault(n => n.MaSP == masp);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);


        }
        public PartialViewResult spLienQuanPartial(string MaSP, string HangSX, string loaixe)
        {


            return PartialView(db.tbSanPhams.Where(n => n.MaHangSX == HangSX).Where(n => n.MaSP != MaSP).Where(n => n.MaLoai == loaixe).OrderByDescending(n => n.TenSP).ToList());
        }
        public ActionResult spTheoHang(string hangsx)
        {
            tbHangSX sanpham = db.tbHangSXes.SingleOrDefault(n => n.MaHangSX == hangsx);

            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.hangsx = hangsx;

            return View(db.tbSanPhams.Where(n => n.MaHangSX == hangsx).Where(n => n.MaLoai == "XEOTO").OrderByDescending(n => n.MaHangSX).ToList());

        }
        public PartialViewResult spTheoHangPartial()
        {


            return PartialView(db.tbHangSXes.ToList());
        }
        public ViewResult spOto()
        {
            tbLoai sanpham = db.tbLoais.SingleOrDefault(n => n.MaLoai == "XEOTO");
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(db.tbSanPhams.Where(n => n.MaLoai == "XEOTO").OrderByDescending(n => n.TenSP).ToList());
        }
        public ViewResult spTimKiem(string searchString)
        {
            ViewBag.chuoitimkiem = searchString;
            return View(db.tbSanPhams.Where((n=>n.TenSP == searchString)).ToList());
        }

        public ViewResult spTimKiem2(int searchStringSDT,string searchStringTKH)
        {
            ViewBag.chuoitimkiemSDT= searchStringSDT;
            ViewBag.chuoitimkiemTKH = searchStringTKH;

            return View(db.tbKhachHangs.Where(n => n.TenKH == searchStringTKH).Where(n => n.SDT == searchStringSDT).ToList());
        }


        
        public ViewResult spXemay()
        {
            tbLoai sanpham = db.tbLoais.SingleOrDefault(n => n.MaLoai == "XEMAY");
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(db.tbSanPhams.Where(n => n.MaLoai == "XEMAY").OrderByDescending(n => n.TenSP).ToList());
        }
        public ViewResult spLoaiXeMay(string loaixe)
        {
            ViewBag.loaixe = loaixe;
            return View(db.tbSanPhams.Where(n => n.DongXe == loaixe).ToList());

        }

        public ViewResult Mota1()
        {
            return View();
        }
        public PartialViewResult TTins(string masp)
        {
            DateTime now = new DateTime();
            now = DateTime.Now;
            ViewBag.daynow = now;
            tbSanPham sanpham = db.tbSanPhams.SingleOrDefault(n => n.MaSP == masp);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return PartialView(sanpham);
        }


        public PartialViewResult AnhSP(string masp)
        {

            return PartialView(db.tbAnhSPs.Where(n => n.MaSP == masp).ToList());
        }
        [HttpGet]

        public ActionResult insertCus(string masp)
        {
            DateTime now = new DateTime();
            now = DateTime.Now;
            ViewBag.daynow = now;
            ViewBag.masp = masp;
            Random r = new Random();
            int x = db.tbKhachHangs.Count();
            ViewBag.makh = x + r.Next(1, 10000);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult insertCus(tbKhachHang KH)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var dbc = new QuanLyBanXeEntities1();
                if (dbc.tbKhachHangs.Any(x => x.MaKH == KH.MaKH))
                {
                    ModelState.AddModelError("Thông báo", "Mã khách hàng này đã tồn tại");
                }
                else
                {
                    long id = dao.Insert(KH);
                    if (id > 0)
                    {
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
        public PartialViewResult Search(string searchString, int page = 1, int pageSize = 3)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return PartialView(model);
        }

        public ViewResult Search2(string searchString, int page = 1, int pageSize = 3)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            return View(model);
        }
        public ActionResult insertCusLT(string masp)
        {
            DateTime now = new DateTime();
            now = DateTime.Now;
            ViewBag.daynow = now;
            ViewBag.masp = masp;
            Random r = new Random();
            int x = db.tbKhachHangs.Count();
            ViewBag.makh = x + r.Next(1, 10000);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult insertCusLT(tbKhachHang KH)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var dbc = new QuanLyBanXeEntities1();
                if (dbc.tbKhachHangs.Any(x => x.MaKH == KH.MaKH))
                {
                    ModelState.AddModelError("Thông báo", "Mã khách hàng này đã tồn tại");
                    SetAlert("Lỗi", "error");
                }
                else
                {
                    long id = dao.Insert(KH);
                    if (id > 0)
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
        protected void SetAlert(string message, string type)
        { TempData["AlertMessage"] = message; if (type == "success") { TempData["AlertType"] = "alert-success"; } else if (type == "warning") { TempData["AlertType"] = "alert-warning"; } else if (type == "error") { TempData["AlertType"] = "alert-danger"; }
        }

       
    } 

    
}