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

namespace DaoBSCKPI.Database.DiemCongTru
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
	public partial class lineDiemCongTruDanhGiaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public lineDiemCongTruDanhGiaDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public lineDiemCongTruDanhGiaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public lineDiemCongTruDanhGiaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public lineDiemCongTruDanhGiaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public lineDiemCongTruDanhGiaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKDiemCongTruDanhGia_ThongTin")]
		public ISingleResult<sp_tblBKDiemCongTruDanhGia_ThongTinResult> sp_tblBKDiemCongTruDanhGia_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhanVien", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNhanVien)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDNhanVien);
			return ((ISingleResult<sp_tblBKDiemCongTruDanhGia_ThongTinResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKDiemCongTruDanhGia_ThemSua")]
		public int sp_tblBKDiemCongTruDanhGia_ThemSua([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhanVien", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNhanVien, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Diem", DbType="Decimal(18,3)")] System.Nullable<decimal> diem, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDNhanVien, diem, nguoiTao);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKDiemCongTruDanhGia_DanhSach_KeHoach")]
		public ISingleResult<sp_tblBKDiemCongTruDanhGia_DanhSach_KeHoachResult> sp_tblBKDiemCongTruDanhGia_DanhSach_KeHoach([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKeHoach", DbType="Int")] System.Nullable<int> iDKeHoach)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDKeHoach);
			return ((ISingleResult<sp_tblBKDiemCongTruDanhGia_DanhSach_KeHoachResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKDiemCongTruDanhGia_DanhSach_DonVi")]
		public ISingleResult<sp_tblBKDiemCongTruDanhGia_DanhSach_DonViResult> sp_tblBKDiemCongTruDanhGia_DanhSach_DonVi([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDDonVi, iDPhongBan);
			return ((ISingleResult<sp_tblBKDiemCongTruDanhGia_DanhSach_DonViResult>)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblBKDiemCongTruDanhGia_ThongTinResult
	{
		
		private short _Thang;
		
		private int _Nam;
		
		private System.Guid _IDNhanVien;
		
		private System.Nullable<decimal> _Diem;
		
		private string _NguoiTao;
		
		private string _NguoiSua;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		public sp_tblBKDiemCongTruDanhGia_ThongTinResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Thang", DbType="SmallInt NOT NULL")]
		public short Thang
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nam", DbType="Int NOT NULL")]
		public int Nam
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNhanVien", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid IDNhanVien
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Diem", DbType="Decimal(18,3)")]
		public System.Nullable<decimal> Diem
		{
			get
			{
				return this._Diem;
			}
			set
			{
				if ((this._Diem != value))
				{
					this._Diem = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiTao", DbType="NVarChar(30)")]
		public string NguoiTao
		{
			get
			{
				return this._NguoiTao;
			}
			set
			{
				if ((this._NguoiTao != value))
				{
					this._NguoiTao = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiSua", DbType="NVarChar(30)")]
		public string NguoiSua
		{
			get
			{
				return this._NguoiSua;
			}
			set
			{
				if ((this._NguoiSua != value))
				{
					this._NguoiSua = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayTao", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayTao
		{
			get
			{
				return this._NgayTao;
			}
			set
			{
				if ((this._NgayTao != value))
				{
					this._NgayTao = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgaySua", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgaySua
		{
			get
			{
				return this._NgaySua;
			}
			set
			{
				if ((this._NgaySua != value))
				{
					this._NgaySua = value;
				}
			}
		}
	}
	
	public partial class sp_tblBKDiemCongTruDanhGia_DanhSach_KeHoachResult
	{
		
		private System.Nullable<long> _ThuTu;
		
		private System.Nullable<System.Guid> _IDNhanVien;
		
		private string _TenNhanVien;
		
		private System.Nullable<decimal> _TongDiemKPI;
		
		private System.Nullable<decimal> _Diem;
		
		private System.Nullable<decimal> _TongDiemCong;
		
		public sp_tblBKDiemCongTruDanhGia_DanhSach_KeHoachResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThuTu", DbType="BigInt")]
		public System.Nullable<long> ThuTu
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenNhanVien", DbType="NVarChar(83)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Diem", DbType="Decimal(18,3)")]
		public System.Nullable<decimal> Diem
		{
			get
			{
				return this._Diem;
			}
			set
			{
				if ((this._Diem != value))
				{
					this._Diem = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TongDiemCong", DbType="Decimal(20,3)")]
		public System.Nullable<decimal> TongDiemCong
		{
			get
			{
				return this._TongDiemCong;
			}
			set
			{
				if ((this._TongDiemCong != value))
				{
					this._TongDiemCong = value;
				}
			}
		}
	}
	
	public partial class sp_tblBKDiemCongTruDanhGia_DanhSach_DonViResult
	{
		
		private System.Nullable<long> _ThuTu;
		
		private System.Nullable<System.Guid> _IDNhanVien;
		
		private string _TenNhanVien;
		
		private System.Nullable<decimal> _TongDiemKPI;
		
		private System.Nullable<decimal> _Diem;
		
		private System.Nullable<decimal> _TongDiemCong;
		
		public sp_tblBKDiemCongTruDanhGia_DanhSach_DonViResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThuTu", DbType="BigInt")]
		public System.Nullable<long> ThuTu
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenNhanVien", DbType="NVarChar(83)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Diem", DbType="Decimal(18,3)")]
		public System.Nullable<decimal> Diem
		{
			get
			{
				return this._Diem;
			}
			set
			{
				if ((this._Diem != value))
				{
					this._Diem = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TongDiemCong", DbType="Decimal(20,3)")]
		public System.Nullable<decimal> TongDiemCong
		{
			get
			{
				return this._TongDiemCong;
			}
			set
			{
				if ((this._TongDiemCong != value))
				{
					this._TongDiemCong = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
