using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DaoBSCKPI.Database.NhanVien;

namespace BSCKPI.UIHelper
{
    public static class daPhien
    {
        public static sp_tblThongTinNhanVien_ThongTinResult NguoiDung
        {
            get { return (sp_tblThongTinNhanVien_ThongTinResult)HttpContext.Current.Session["PhienLamViecBSC"]; }
            set { HttpContext.Current.Session["PhienLamViecBSC"] = value; }
        }

        public static string LayDiaChiURL(string rDuongDan)
        {
            HttpRequest r = HttpContext.Current.Request;
            if(r.ApplicationPath=="/")
            {
                return r.Url.Scheme + "://" + r.Url.Authority + rDuongDan;
            }
            else
            {
                return r.Url.Scheme + "://" + r.Url.Authority + r.ApplicationPath + rDuongDan;
            }
        }

        public static string LayDiaChiURLChucNang(int rID,string rDuongDan)
        {
            HttpRequest r = HttpContext.Current.Request;
            if (r.ApplicationPath == "/")
            {
                return r.Url.Scheme + "://" + r.Url.Authority + rDuongDan + "?CN=" + rID.ToString();
            }
            else
            {
                return r.Url.Scheme + "://" + r.Url.Authority + r.ApplicationPath + rDuongDan + "?CN=" + rID.ToString(); ;
            }
        }

        public static void KiemTraXacThuc()
        {
            if(HttpContext.Current.Session["PhienLamViecBSC"]==null)
            {
                HttpContext.Current.Response.Redirect("frmChuaLogin.aspx");
            }
        }
    }
}