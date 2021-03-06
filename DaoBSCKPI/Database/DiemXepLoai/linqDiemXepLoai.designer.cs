﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DaoBSCKPI.Database.DiemXepLoai
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BSCKPI")]
	public partial class linqDiemXepLoaiDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqDiemXepLoaiDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqDiemXepLoaiDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqDiemXepLoaiDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqDiemXepLoaiDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqDiemXepLoaiDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKDiemXepLoai_Lay")]
		public ISingleResult<sp_tblBKDiemXepLoai_LayResult> sp_tblBKDiemXepLoai_Lay([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhanVien", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNhanVien)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDNhanVien);
			return ((ISingleResult<sp_tblBKDiemXepLoai_LayResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKDiemXepLoai_ThongTin")]
		public ISingleResult<sp_tblBKDiemXepLoai_ThongTinResult> sp_tblBKDiemXepLoai_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhanVien", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNhanVien)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDNhanVien);
			return ((ISingleResult<sp_tblBKDiemXepLoai_ThongTinResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKDiemXepLoai_BaoCao_TatCa")]
		public ISingleResult<sp_tblBKDiemXepLoai_BaoCao_TatCaResult> sp_tblBKDiemXepLoai_BaoCao_TatCa([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam);
			return ((ISingleResult<sp_tblBKDiemXepLoai_BaoCao_TatCaResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKDiemXepLoai_BaoCao_KeHoach")]
		public ISingleResult<sp_tblBKDiemXepLoai_BaoCao_TatCaResult> sp_tblBKDiemXepLoai_BaoCao_KeHoach([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKeHoach", DbType="Int")] System.Nullable<int> iDKeHoach)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDKeHoach);
			return ((ISingleResult<sp_tblBKDiemXepLoai_BaoCao_TatCaResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKDiemXepLoai_BaoCao_DonVi")]
		public ISingleResult<sp_tblBKDiemXepLoai_BaoCao_DonViResult> sp_tblBKDiemXepLoai_BaoCao_DonVi([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDDonVi, iDPhongBan);
			return ((ISingleResult<sp_tblBKDiemXepLoai_BaoCao_DonViResult>)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblBKDiemXepLoai_LayResult
	{
		
		private System.Nullable<decimal> _TongDiemKPI;
		
		private string _Ma;
		
		private string _Ten;
		
		public sp_tblBKDiemXepLoai_LayResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TongDiemKPI", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> TongDiemKPI
		{
			get
			{
				return this._TongDiemKPI;
			}
			set
			{
				if ((this._TongDiemKPI != value))
				{
					this._TongDiemKPI = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ma", DbType="NVarChar(20)")]
		public string Ma
		{
			get
			{
				return this._Ma;
			}
			set
			{
				if ((this._Ma != value))
				{
					this._Ma = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ten", DbType="NVarChar(50)")]
		public string Ten
		{
			get
			{
				return this._Ten;
			}
			set
			{
				if ((this._Ten != value))
				{
					this._Ten = value;
				}
			}
		}
	}
	
	public partial class sp_tblBKDiemXepLoai_ThongTinResult
	{
		
		private System.Nullable<short> _Thang;
		
		private System.Nullable<int> _Nam;
		
		private System.Nullable<System.Guid> _IDNhanVien;
		
		private System.Nullable<decimal> _TongDiemKPI;
		
		private System.Nullable<int> _IDXepLoai;
		
		private System.Nullable<int> _IDTrangThai;
		
		private System.Nullable<System.DateTime> _NgayDanhGia;
		
		private string _NguoiDanhGia;
		
		public sp_tblBKDiemXepLoai_ThongTinResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Thang", DbType="SmallInt")]
		public System.Nullable<short> Thang
		{
			get
			{
				return this._Thang;
			}
			set
			{
				if ((this._Thang != value))
				{
					this._Thang = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nam", DbType="Int")]
		public System.Nullable<int> Nam
		{
			get
			{
				return this._Nam;
			}
			set
			{
				if ((this._Nam != value))
				{
					this._Nam = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNhanVien", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> IDNhanVien
		{
			get
			{
				return this._IDNhanVien;
			}
			set
			{
				if ((this._IDNhanVien != value))
				{
					this._IDNhanVien = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TongDiemKPI", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> TongDiemKPI
		{
			get
			{
				return this._TongDiemKPI;
			}
			set
			{
				if ((this._TongDiemKPI != value))
				{
					this._TongDiemKPI = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDXepLoai", DbType="Int")]
		public System.Nullable<int> IDXepLoai
		{
			get
			{
				return this._IDXepLoai;
			}
			set
			{
				if ((this._IDXepLoai != value))
				{
					this._IDXepLoai = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDTrangThai", DbType="Int")]
		public System.Nullable<int> IDTrangThai
		{
			get
			{
				return this._IDTrangThai;
			}
			set
			{
				if ((this._IDTrangThai != value))
				{
					this._IDTrangThai = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayDanhGia", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayDanhGia
		{
			get
			{
				return this._NgayDanhGia;
			}
			set
			{
				if ((this._NgayDanhGia != value))
				{
					this._NgayDanhGia = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiDanhGia", DbType="NVarChar(30)")]
		public string NguoiDanhGia
		{
			get
			{
				return this._NguoiDanhGia;
			}
			set
			{
				if ((this._NguoiDanhGia != value))
				{
					this._NguoiDanhGia = value;
				}
			}
		}
	}
	
	public partial class sp_tblBKDiemXepLoai_BaoCao_TatCaResult
	{
		
		private string _ThuTu;
		
		private string _TenNhanVien;
		
		private string _HoDem;
		
		private string _Ten;
		
		private string _DonVi;
		
		private string _ChucDanhChucVu;
		
		private string _MoTaCongViec;
		
		private System.Nullable<bool> _DanhDauRieng;
		
		private System.Nullable<decimal> _TongDiemKPI;
		
		private System.Nullable<decimal> _DiemCongTru;
		
		private System.Nullable<decimal> _TongDiemKPICong;
		
		private string _XepLoai;
		
		private string _XepLoaiCong;
		
		private System.Nullable<bool> _Dam;
		
		private System.Nullable<bool> _Nghieng;
		
		public sp_tblBKDiemXepLoai_BaoCao_TatCaResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThuTu", DbType="NVarChar(10)")]
		public string ThuTu
		{
			get
			{
				return this._ThuTu;
			}
			set
			{
				if ((this._ThuTu != value))
				{
					this._ThuTu = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenNhanVien", DbType="NVarChar(50)")]
		public string TenNhanVien
		{
			get
			{
				return this._TenNhanVien;
			}
			set
			{
				if ((this._TenNhanVien != value))
				{
					this._TenNhanVien = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoDem", DbType="NVarChar(30)")]
		public string HoDem
		{
			get
			{
				return this._HoDem;
			}
			set
			{
				if ((this._HoDem != value))
				{
					this._HoDem = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ten", DbType="NVarChar(20)")]
		public string Ten
		{
			get
			{
				return this._Ten;
			}
			set
			{
				if ((this._Ten != value))
				{
					this._Ten = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DonVi", DbType="NVarChar(50)")]
		public string DonVi
		{
			get
			{
				return this._DonVi;
			}
			set
			{
				if ((this._DonVi != value))
				{
					this._DonVi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChucDanhChucVu", DbType="NVarChar(50)")]
		public string ChucDanhChucVu
		{
			get
			{
				return this._ChucDanhChucVu;
			}
			set
			{
				if ((this._ChucDanhChucVu != value))
				{
					this._ChucDanhChucVu = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MoTaCongViec", DbType="NVarChar(250)")]
		public string MoTaCongViec
		{
			get
			{
				return this._MoTaCongViec;
			}
			set
			{
				if ((this._MoTaCongViec != value))
				{
					this._MoTaCongViec = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DanhDauRieng", DbType="Bit")]
		public System.Nullable<bool> DanhDauRieng
		{
			get
			{
				return this._DanhDauRieng;
			}
			set
			{
				if ((this._DanhDauRieng != value))
				{
					this._DanhDauRieng = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TongDiemKPI", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> TongDiemKPI
		{
			get
			{
				return this._TongDiemKPI;
			}
			set
			{
				if ((this._TongDiemKPI != value))
				{
					this._TongDiemKPI = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiemCongTru", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> DiemCongTru
		{
			get
			{
				return this._DiemCongTru;
			}
			set
			{
				if ((this._DiemCongTru != value))
				{
					this._DiemCongTru = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TongDiemKPICong", DbType="Decimal(18,3)")]
		public System.Nullable<decimal> TongDiemKPICong
		{
			get
			{
				return this._TongDiemKPICong;
			}
			set
			{
				if ((this._TongDiemKPICong != value))
				{
					this._TongDiemKPICong = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_XepLoai", DbType="NVarChar(50)")]
		public string XepLoai
		{
			get
			{
				return this._XepLoai;
			}
			set
			{
				if ((this._XepLoai != value))
				{
					this._XepLoai = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_XepLoaiCong", DbType="NVarChar(50)")]
		public string XepLoaiCong
		{
			get
			{
				return this._XepLoaiCong;
			}
			set
			{
				if ((this._XepLoaiCong != value))
				{
					this._XepLoaiCong = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Dam", DbType="Bit")]
		public System.Nullable<bool> Dam
		{
			get
			{
				return this._Dam;
			}
			set
			{
				if ((this._Dam != value))
				{
					this._Dam = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nghieng", DbType="Bit")]
		public System.Nullable<bool> Nghieng
		{
			get
			{
				return this._Nghieng;
			}
			set
			{
				if ((this._Nghieng != value))
				{
					this._Nghieng = value;
				}
			}
		}
	}
	
	public partial class sp_tblBKDiemXepLoai_BaoCao_DonViResult
	{
		
		private string _ThuTu;
		
		private string _TenNhanVien;
		
		private string _HoDem;
		
		private string _Ten;
		
		private string _DonVi;
		
		private string _ChucDanhChucVu;
		
		private string _MoTaCongViec;
		
		private System.Nullable<bool> _DanhDauRieng;
		
		private System.Nullable<decimal> _TongDiemKPI;
		
		private System.Nullable<decimal> _DiemCongTru;
		
		private System.Nullable<decimal> _TongDiemKPICong;
		
		private string _XepLoai;
		
		private string _XepLoaiCong;
		
		private System.Nullable<bool> _Dam;
		
		private System.Nullable<bool> _Nghieng;
		
		public sp_tblBKDiemXepLoai_BaoCao_DonViResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThuTu", DbType="NVarChar(10)")]
		public string ThuTu
		{
			get
			{
				return this._ThuTu;
			}
			set
			{
				if ((this._ThuTu != value))
				{
					this._ThuTu = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenNhanVien", DbType="NVarChar(50)")]
		public string TenNhanVien
		{
			get
			{
				return this._TenNhanVien;
			}
			set
			{
				if ((this._TenNhanVien != value))
				{
					this._TenNhanVien = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoDem", DbType="NVarChar(30)")]
		public string HoDem
		{
			get
			{
				return this._HoDem;
			}
			set
			{
				if ((this._HoDem != value))
				{
					this._HoDem = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ten", DbType="NVarChar(20)")]
		public string Ten
		{
			get
			{
				return this._Ten;
			}
			set
			{
				if ((this._Ten != value))
				{
					this._Ten = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DonVi", DbType="NVarChar(30)")]
		public string DonVi
		{
			get
			{
				return this._DonVi;
			}
			set
			{
				if ((this._DonVi != value))
				{
					this._DonVi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChucDanhChucVu", DbType="NVarChar(50)")]
		public string ChucDanhChucVu
		{
			get
			{
				return this._ChucDanhChucVu;
			}
			set
			{
				if ((this._ChucDanhChucVu != value))
				{
					this._ChucDanhChucVu = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MoTaCongViec", DbType="NVarChar(250)")]
		public string MoTaCongViec
		{
			get
			{
				return this._MoTaCongViec;
			}
			set
			{
				if ((this._MoTaCongViec != value))
				{
					this._MoTaCongViec = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DanhDauRieng", DbType="Bit")]
		public System.Nullable<bool> DanhDauRieng
		{
			get
			{
				return this._DanhDauRieng;
			}
			set
			{
				if ((this._DanhDauRieng != value))
				{
					this._DanhDauRieng = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TongDiemKPI", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> TongDiemKPI
		{
			get
			{
				return this._TongDiemKPI;
			}
			set
			{
				if ((this._TongDiemKPI != value))
				{
					this._TongDiemKPI = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiemCongTru", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> DiemCongTru
		{
			get
			{
				return this._DiemCongTru;
			}
			set
			{
				if ((this._DiemCongTru != value))
				{
					this._DiemCongTru = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TongDiemKPICong", DbType="Decimal(18,3)")]
		public System.Nullable<decimal> TongDiemKPICong
		{
			get
			{
				return this._TongDiemKPICong;
			}
			set
			{
				if ((this._TongDiemKPICong != value))
				{
					this._TongDiemKPICong = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_XepLoai", DbType="NVarChar(50)")]
		public string XepLoai
		{
			get
			{
				return this._XepLoai;
			}
			set
			{
				if ((this._XepLoai != value))
				{
					this._XepLoai = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_XepLoaiCong", DbType="NVarChar(50)")]
		public string XepLoaiCong
		{
			get
			{
				return this._XepLoaiCong;
			}
			set
			{
				if ((this._XepLoaiCong != value))
				{
					this._XepLoaiCong = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Dam", DbType="Bit")]
		public System.Nullable<bool> Dam
		{
			get
			{
				return this._Dam;
			}
			set
			{
				if ((this._Dam != value))
				{
					this._Dam = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nghieng", DbType="Bit")]
		public System.Nullable<bool> Nghieng
		{
			get
			{
				return this._Nghieng;
			}
			set
			{
				if ((this._Nghieng != value))
				{
					this._Nghieng = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
