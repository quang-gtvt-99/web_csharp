using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BTLBanXe.Models;
using PagedList;


namespace KetNoiCSDL.DAO
{
    class UserDao
    {
        QuanLyBanXeEntities1 db = null;
        public UserDao()
        {
            db = new QuanLyBanXeEntities1();
        }
        public bool Update(tbKhachHang entity)
        { try { var user = db.tbKhachHangs.Find(entity.MaKH);
                user.TenKH = entity.TenKH;
                user.SDT = entity.SDT;
                user.Email = entity.Email;
                user.NgayMua = entity.NgayMua;
                user.NgayHenLay = entity.NgayHenLay;
                user.NhuCau = entity.NhuCau;
                db.SaveChanges();
                return true;
            } catch
            { return false; } }

        public tbKhachHang ViewDetail(int id) { return db.tbKhachHangs.Find(id); }

        public long Insert(tbKhachHang entity)
        { db.tbKhachHangs.Add(entity);
            db.SaveChanges();
            return entity.MaKH;
        }
        public string Insertsp(tbSanPham entity)
        {
            db.tbSanPhams.Add(entity);
            db.SaveChanges();
            return entity.MaSP;
        }
        public bool Login(String UserName, string PassWord)
        {
            var res = db.Logins.Count(x => x.Username == UserName && x.Password == PassWord); 
                if (res > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public IEnumerable<tbSanPham> ListAllPaging(string searchString, int page, int pageSize)
        { IQueryable<tbSanPham> model = db.tbSanPhams;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenSP.Contains(searchString) || x.MaHangSX.Contains(searchString));
            }
            return model.OrderByDescending(x => x.MaSP).ToPagedList(page, pageSize);

        }
        public bool DeleteKH(int id)
        {
            try
            {
                var kh = db.tbKhachHangs.Find(id);
                db.tbKhachHangs.Remove(kh);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                var sp = db.tbSanPhams.Find(id);
                db.tbSanPhams.Remove(sp);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
            public IEnumerable<tbKhachHang> ListAllPaging2(string searchString, int page, int pageSize)
        {
            IQueryable<tbKhachHang> model = db.tbKhachHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenKH.Contains(searchString) || (Convert.ToString(x.SDT)).Contains(searchString));
            }
            return model.OrderByDescending(x => x.TenKH).ToPagedList(page, pageSize);
        }
        
public IEnumerable<tbSanPham> ListAllPaging3(int page, int pageSize)
    { return db.tbSanPhams.OrderByDescending(x => x.MaSP).ToPagedList(page, pageSize); }

}

}


