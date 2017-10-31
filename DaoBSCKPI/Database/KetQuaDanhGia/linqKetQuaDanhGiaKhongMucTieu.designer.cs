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

namespace DaoBSCKPI.Database.KetQuaDanhGia
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
	public partial class linqKetQuaDanhGiaKhongMucTieuDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqKetQuaDanhGiaKhongMucTieuDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqKetQuaDanhGiaKhongMucTieuDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqKetQuaDanhGiaKhongMucTieuDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqKetQuaDanhGiaKhongMucTieuDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqKetQuaDanhGiaKhongMucTieuDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKKetQuaDanhGia_KhongMucTieu_CapNhat")]
		public int sp_tblBKKetQuaDanhGia_KhongMucTieu_CapNhat([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhanVien", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNhanVien, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKPI", DbType="Int")] System.Nullable<int> iDKPI, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="KetQua", DbType="Decimal(22,3)")] System.Nullable<decimal> ketQua, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TrongSo", DbType="Decimal(22,3)")] System.Nullable<decimal> trongSo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Diem", DbType="Int")] System.Nullable<int> diem, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DienGiai", DbType="NVarChar(500)")] string dienGiai, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiSua", DbType="NVarChar(30)")] string nguoiSua)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDNhanVien, iDKPI, ketQua, trongSo, diem, dienGiai, nguoiSua);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKKetQuaDanhGia_KhongMucTieu_ThongTin")]
		public ISingleResult<sp_tblBKKetQuaDanhGia_KhongMucTieu_ThongTinResult> sp_tblBKKetQuaDanhGia_KhongMucTieu_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam);
			return ((ISingleResult<sp_tblBKKetQuaDanhGia_KhongMucTieu_ThongTinResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKKetQuaDanhGia_KhongMucTieu_KhoiTao")]
		public int sp_tblBKKetQuaDanhGia_KhongMucTieu_KhoiTao([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDDonVi, iDPhongBan, nguoiTao);
			return ((int)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblBKKetQuaDanhGia_KhongMucTieu_ThongTinResult
	{
		
		private System.Nullable<short> _Thang;
		
		private System.Nullable<int> _Nam;
		
		private System.Nullable<System.Guid> _IDNhanVien;
		
		private System.Nullable<int> _IDKPI;
		
		private System.Nullable<decimal> _KetQua;
		
		private System.Nullable<decimal> _TrongSo;
		
		private System.Nullable<int> _Diem;
		
		private string _DienGiai;
		
		private string _NguoiTao;
		
		private string _NguoiSua;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		public sp_tblBKKetQuaDanhGia_KhongMucTieu_ThongTinResult()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDKPI", DbType="Int")]
		public System.Nullable<int> IDKPI
		{
			get
			{
				return this._IDKPI;
			}
			set
			{
				if ((this._IDKPI != value))
				{
					this._IDKPI = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KetQua", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> KetQua
		{
			get
			{
				return this._KetQua;
			}
			set
			{
				if ((this._KetQua != value))
				{
					this._KetQua = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrongSo", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> TrongSo
		{
			get
			{
				return this._TrongSo;
			}
			set
			{
				if ((this._TrongSo != value))
				{
					this._TrongSo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Diem", DbType="Int")]
		public System.Nullable<int> Diem
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DienGiai", DbType="NVarChar(500)")]
		public string DienGiai
		{
			get
			{
				return this._DienGiai;
			}
			set
			{
				if ((this._DienGiai != value))
				{
					this._DienGiai = value;
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
}
#pragma warning restore 1591
