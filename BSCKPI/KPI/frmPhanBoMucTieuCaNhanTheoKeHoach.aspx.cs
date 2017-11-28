using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DaoBSCKPI.PhanBoMucTieu;
using DaoBSCKPI.ChiTieuKPI;
using DaoBSCKPI.NhanVien;
using DaoBSCKPI;
using DaoBSCKPI.KeHoachDanhGia;
using DaoBSCKPI.CongViec;
using DaoBSCKPI.KetQuaDanhGia;
using DaoBSCKPI.DonVi;

using Ext.Net;
using BSCKPI.UIHelper;

namespace BSCKPI.KPI
{
    public partial class frmPhanBoMucTieuCaNhanTheoKeHoach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!X.IsAjaxRequest)
            {
                DanhSachThangNam();
                DanhSachDonVi(DateTime.Now,daPhien.NguoiDung.IDDonVi.Value);
                DanhSachKeHoachDG();
            }
        }

        #region Rieng
        private void DanhSachThangNam()
        {
            daThamSo dTS = new daThamSo();
            stoThang.DataSource = dTS.DanhSachThang();
            stoThang.DataBind();

            stoNam.DataSource = dTS.DanhSachNam();
            stoNam.DataBind();
        }

        private void DanhSachDonVi(DateTime rNgay, int rIDDVQL)
        {
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.TuNgay = rNgay;
            dMHDV.MHDV.IDDonViQuanLy = rIDDVQL;
            stoDonVi.DataSource = dMHDV.DanhSach();
            stoDonVi.DataBind();
        }

        private void DanhSachKeHoachDG()
        {
            daKeHoachDanhGia dKHDG = new daKeHoachDanhGia();
            stoKHDG.DataSource = dKHDG.DanhSach();
            stoKHDG.DataBind();
        }

        private void DanhSachNhanVienDanhGia()
        {
            if(slbKeHoachDG.SelectedItem.Value!=null)
            {
                daKeHoachDanhGia dKHDG = new daKeHoachDanhGia();
                dKHDG.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dKHDG.Nam = int.Parse(slbNam.SelectedItem.Value);
                dKHDG.KHDG.ID = int.Parse(slbKeHoachDG.SelectedItem.Value);
                stoNhanVien.DataSource = dKHDG.DanhSachNhanVien();
                stoNhanVien.DataBind();
            }            
        }

        private void DanhSachNhanVienDanhGiaDonVi()
        {
            if (slbKeHoachDG.SelectedItem.Value != null)
            {
                daKeHoachDanhGia dKHDG = new daKeHoachDanhGia();
                dKHDG.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dKHDG.Nam = int.Parse(slbNam.SelectedItem.Value);
                dKHDG.KHDG.ID = int.Parse(slbKeHoachDG.SelectedItem.Value);

                int _IDDV, _IDPB;
                _IDDV = int.Parse(slbDonVi.SelectedItem.Value);
                _IDPB = int.Parse(slbPhongBan.SelectedItem.Value);
                if(_IDPB<0)
                {
                    _IDPB = 0 - _IDPB;
                }
                else
                {
                    _IDDV = _IDPB;
                    _IDPB = 0;
                }
                stoNhanVien.DataSource = dKHDG.DanhSachNhanVienDonVi(_IDDV, _IDPB);
                stoNhanVien.DataBind();
            }
        }

        private bool KiemTraChonThangNam()
        {
            if (slbThang.SelectedItem.Value==null || slbNam.SelectedItem.Value==null)
            {
                /*X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Thông báo",
                    Message = "Đề nghị chọn tháng hoặc năm!",
                    Buttons = MessageBox.Button.OK,
                    Icon = (MessageBox.Icon)Enum.Parse(typeof(MessageBox.Icon), "WARNING")
                });*/
                return false;
            }
            else
            {
                return true;
            }
        }

        private Ext.Net.Window CuaSoChucNang(string rTieuDe, string Url)
        {
            Ext.Net.Window _CSo = new Ext.Net.Window();
            ComponentLoader _Loader = new ComponentLoader();
            _Loader.Url = Url; 
            _Loader.Mode = LoadMode.Frame;
            _Loader.LoadMask.ShowMask = true;
            _Loader.LoadMask.Msg = "Đang xử lý .....";

            _CSo.ID = "IDcsBaoCao";
            _CSo.Title = rTieuDe;
            _CSo.TitleAlign = TitleAlign.Center;
            _CSo.AutoRender = true;
            _CSo.Maximizable = false;
            _CSo.Icon = Icon.Printer;
            _CSo.Width = 900;
            _CSo.Height = 500;
            _CSo.Loader = _Loader;

            return _CSo;
        }
        #endregion

        #region Su kien
        protected void DanhSachNhanVien(object sender, StoreReadDataEventArgs e)
        {
            if (slbThang.SelectedItem.Value==null || slbNam.SelectedItem.Value==null)
            {
                return;
            }
            if (slbDonVi.SelectedItem.Value == null && slbPhongBan.SelectedItem.Value == null)
            {
                DanhSachNhanVienDanhGia();
            }
            else
            {
                if (slbDonVi.SelectedItem.Value != null && slbPhongBan.SelectedItem.Value != null)
                {
                    DanhSachNhanVienDanhGiaDonVi();
                }
            }
        }

        protected void DanhSachPhongBan(object sender, StoreReadDataEventArgs e)
        {
            slbPhongBan.SelectedItems.Clear();
            slbPhongBan.UpdateSelectedItems();
            daMoHinhDonVi dMHDV = new daMoHinhDonVi();
            dMHDV.MHDV.TuNgay = DateTime.Now;
            dMHDV.MHDV.IDDonViQuanLy = int.Parse(slbDonVi.SelectedItem.Value);
            stoPhong.DataSource = dMHDV.DanhSachGopVoiPhongBan();
            stoPhong.DataBind();
        }

        protected void DanhSachPBMTNV(object sender, StoreReadDataEventArgs e)
        {
            if (KiemTraChonThangNam()&& slbNhanVien.SelectedItem.Value!=null)
            {
                daPhanBoMucTieu dPBMT = new daPhanBoMucTieu();
                dPBMT.MT.Thang = byte.Parse(slbThang.SelectedItem.Value);
                dPBMT.MT.Nam = int.Parse(slbNam.SelectedItem.Value);
                dPBMT.MT.IDNhanVien = Guid.Parse(slbNhanVien.SelectedItem.Value);
                dPBMT.MT.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

                dPBMT.KhoiTaoTheoNhanVien();

                daPBNhiemVuTrongTam dPBNV = new daPBNhiemVuTrongTam();
                dPBNV.PBNV.Thang = dPBMT.MT.Thang;
                dPBNV.PBNV.Nam = dPBMT.MT.Nam;
                dPBNV.PBNV.NguoiTao = dPBMT.MT.NguoiTao;
                dPBNV.KhoiTaovaBoSung(dPBMT.MT.IDNhanVien.Value);

                daBangDanhGia dBDG = new daBangDanhGia();
                dBDG.Thang = Convert.ToByte(dPBMT.MT.Thang.Value);
                dBDG.Nam = dPBMT.MT.Nam.Value;
                dBDG.IDNhanVien = dPBMT.MT.IDNhanVien.Value;

                stoPhanBoCT.DataSource = dBDG.BangPhanBoNhap();//dPBMT.DanhSach();
                stoPhanBoCT.DataBind();

                daThongTinNhanVien dTTNV = new daThongTinNhanVien();
                dTTNV.TTNV.IDNhanVien = dPBMT.MT.IDNhanVien;
                dTTNV.TTNV.Thang = dPBMT.MT.Thang;
                dTTNV.TTNV.Nam = dPBMT.MT.Nam;
                
                
                if(dTTNV.TimTT()!=null)
                {
                    lblChucVu.Text = "CV: "+dTTNV.Tim.ChucVu;
                    lblChucDanh.Text = "CD: "+dTTNV.Tim.ChucDanh;
                    lblMoTaCongViec.Text = "MTCV: "+dTTNV.Tim.MoTaCongViec;
                }
                else
                {
                    lblChucVu.Text = "";
                    lblChucDanh.Text = "";
                    lblMoTaCongViec.Text = "";
                }
            }
        }
        
        [DirectMethod(Namespace = "BangPBMTCTX")]
        public void EditCT(int id, string field, string oldvalue, string newvalue, object BangPB)
        {
            
            Newtonsoft.Json.Linq.JObject node = JSON.Deserialize<Newtonsoft.Json.Linq.JObject>(BangPB.ToString());

            switch(node.Property("LoaiChiTieu").Value.ToString())
            {
                case "1":
                    daPhanBoMucTieu dPBMT = new daPhanBoMucTieu();
                    dPBMT.MT.Thang = byte.Parse(slbThang.SelectedItem.Value);
                    dPBMT.MT.Nam = int.Parse(slbNam.SelectedItem.Value);
                    dPBMT.MT.IDNhanVien = Guid.Parse(slbNhanVien.SelectedItem.Value);
                    dPBMT.MT.NguoiTao = daPhien.NguoiDung.IDNhanVien.Value.ToString();
                    dPBMT.MT.IDKPI = int.Parse(node.Property("ID").Value.ToString());
                    try
                    {
                        dPBMT.MT.TrongSo = decimal.Parse(node.Property("TrongSo").Value.ToString());
                    }
                    catch { dPBMT.MT.TrongSo = 0; }
                    try
                    {
                        dPBMT.MT.MucTieu = decimal.Parse(node.Property("MucTieu").Value.ToString());
                    }
                    catch { dPBMT.MT.MucTieu = 0; }

                    dPBMT.ThemSua();
                    break;
                case "2":
                    daPBNhiemVuTrongTam dPBNV = new daPBNhiemVuTrongTam();
                    dPBNV.PBNV.Thang = byte.Parse(slbThang.SelectedItem.Value);
                    dPBNV.PBNV.Nam = int.Parse(slbNam.SelectedItem.Value);
                    dPBNV.PBNV.NguoiTao = daPhien.NguoiDung.IDNhanVien.Value.ToString();
                    dPBNV.PBNV.IDNhiemVu = int.Parse(node.Property("ID").Value.ToString());
                    try
                    {
                        dPBNV.PBNV.TrongSo = decimal.Parse(node.Property("TrongSo").Value.ToString());
                    }
                    catch { dPBNV.PBNV.TrongSo = 0; }
                    dPBNV.CapNhat();
                    break;
            }
            
            grdPBChiTieu.GetStore().GetById(id).Commit();
        }
        
        protected void btnInbangPhanBo_Click(object sender, DirectEventArgs e)
        {
            Ext.Net.Window CSo = new Ext.Net.Window();
            CSo = CuaSoChucNang("Bảng giao kế hoạch mục tiêu", "frmHienThiBaoCaoKPI.aspx?ThangBaoCao=" + slbThang.SelectedItem.Value + "&&NamBaoCao=" + slbNam.SelectedItem.Value + "&&NhanVienBaoCao=" + slbNhanVien.SelectedItem.Value + "&&BieuBaoCao=1");            
            
            this.Form.Controls.Add(CSo);
            CSo.Render();
            CSo.Show();
        }

        protected void btnInKeHoach_Click(object sender, DirectEventArgs e)
        {
            if (slbThang.SelectedItem.Value == null || slbNam.SelectedItem.Value == null)
            {
                X.Msg.Alert("", "Thiếu dữ liệu chọn để in báo cáo").Show();
                return;
            }
            Ext.Net.Window CSo = new Ext.Net.Window();
            if (slbDonVi.SelectedItem.Value == null)
            {
                CSo = CuaSoChucNang("Bảng đánh giá kết quả", "frmHienThiBaoCaoKPI.aspx?ThangBaoCao=" + slbThang.SelectedItem.Value + "&&NamBaoCao=" + slbNam.SelectedItem.Value + "&&NhanVienBaoCao=" + slbNhanVien.SelectedItem.Value + "&&IDKeHoach=" + slbKeHoachDG.SelectedItem.Value + "&&BieuBaoCao=2&&IDDonVi=0&&IDPhongBan=0");
            }
            else
            {
                CSo = CuaSoChucNang("Bảng đánh giá kết quả", "frmHienThiBaoCaoKPI.aspx?ThangBaoCao=" + slbThang.SelectedItem.Value + "&&NamBaoCao=" + slbNam.SelectedItem.Value + "&&NhanVienBaoCao=" + slbNhanVien.SelectedItem.Value + "&&IDKeHoach=" + slbKeHoachDG.SelectedItem.Value + "&&BieuBaoCao=2&&IDDonVi="+slbDonVi.SelectedItem.Value+"&&IDPhongBan="+slbPhongBan.SelectedItem.Value);
            }
            this.Form.Controls.Add(CSo);
            CSo.Render();
            CSo.Show();
        }

        protected void btnCapNhatMucTieu_Click(object sender, DirectEventArgs e)
        {
            daPhanBoMucTieu dPBMT = new daPhanBoMucTieu();
            dPBMT.MT.Thang = byte.Parse(slbThang.SelectedItem.Value);
            dPBMT.MT.Nam = int.Parse(slbNam.SelectedItem.Value);
            dPBMT.MT.IDNhanVien = Guid.Parse(slbNhanVien.SelectedItem.Value);
            dPBMT.MT.NguoiTao = daPhien.NguoiDung.IDNhanVien.ToString();

            dPBMT.CapNhatMucTieu();

            daBangDanhGia dBDG = new daBangDanhGia();
            dBDG.Thang = Convert.ToByte(dPBMT.MT.Thang.Value);
            dBDG.Nam = dPBMT.MT.Nam.Value;
            dBDG.IDNhanVien = dPBMT.MT.IDNhanVien.Value;

            stoPhanBoCT.DataSource = dBDG.BangPhanBoNhap();//dPBMT.DanhSach();
            stoPhanBoCT.DataBind();

            /*stoPhanBoCT.DataSource = dPBMT.DanhSach();
            stoPhanBoCT.DataBind();*/

            X.Msg.Alert("","Đã cập nhật mục tiêu từ dữ liệu KPI 12 tháng xong.").Show();
        }
        #endregion
    }
}