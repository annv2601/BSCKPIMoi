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

namespace DaoBSCKPI.Database.NhanVien
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
	public partial class linqNhanVienDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqNhanVienDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqNhanVienDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqNhanVienDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqNhanVienDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqNhanVienDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblNhanVien_SuaHoatDong")]
		public int sp_tblNhanVien_SuaHoatDong([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhanVien", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNhanVien, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="HoatDong", DbType="Bit")] System.Nullable<bool> hoatDong)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDNhanVien, hoatDong);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblNhanVien_ThemSua")]
		public ISingleResult<sp_tblNhanVien_ThemSuaResult> sp_tblNhanVien_ThemSua([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhanVien", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNhanVien, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MaNhanVien", DbType="NVarChar(20)")] string maNhanVien, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TenNhanVien", DbType="NVarChar(50)")] string tenNhanVien, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="HoDem", DbType="NVarChar(30)")] string hoDem, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Ten", DbType="NVarChar(20)")] string ten, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NgaySinh", DbType="Date")] System.Nullable<System.DateTime> ngaySinh, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="GioiTinh", DbType="Bit")] System.Nullable<bool> gioiTinh, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DienThoaiDiDong", DbType="NVarChar(20)")] string dienThoaiDiDong, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Email", DbType="NVarChar(80)")] string email, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="HoatDong", DbType="Bit")] System.Nullable<bool> hoatDong, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(250)")] string urlAnh, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDNhanVien, maNhanVien, tenNhanVien, hoDem, ten, ngaySinh, gioiTinh, dienThoaiDiDong, email, hoatDong, urlAnh, nguoiTao);
			return ((ISingleResult<sp_tblNhanVien_ThemSuaResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblNhanVien_ThongTin")]
		public ISingleResult<sp_tblNhanVien_ThongTinResult> sp_tblNhanVien_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhanVien", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNhanVien)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDNhanVien);
			return ((ISingleResult<sp_tblNhanVien_ThongTinResult>)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblNhanVien_ThemSuaResult
	{
		
		private System.Nullable<System.Guid> _IDNhanVien;
		
		public sp_tblNhanVien_ThemSuaResult()
		{
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
	}
	
	public partial class sp_tblNhanVien_ThongTinResult
	{
		
		private System.Guid _IDNhanVien;
		
		private string _MaNhanVien;
		
		private string _TenNhanVien;
		
		private string _HoDem;
		
		private string _Ten;
		
		private System.Nullable<System.DateTime> _NgaySinh;
		
		private System.Nullable<bool> _GioiTinh;
		
		private string _DienThoaiDiDong;
		
		private string _Email;
		
		private System.Nullable<bool> _HoatDong;
		
		private string _NguoiTao;
		
		private string _NguoiSua;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		private string _urlAnh;
		
		public sp_tblNhanVien_ThongTinResult()
		{
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaNhanVien", DbType="NVarChar(20)")]
		public string MaNhanVien
		{
			get
			{
				return this._MaNhanVien;
			}
			set
			{
				if ((this._MaNhanVien != value))
				{
					this._MaNhanVien = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgaySinh", DbType="Date")]
		public System.Nullable<System.DateTime> NgaySinh
		{
			get
			{
				return this._NgaySinh;
			}
			set
			{
				if ((this._NgaySinh != value))
				{
					this._NgaySinh = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GioiTinh", DbType="Bit")]
		public System.Nullable<bool> GioiTinh
		{
			get
			{
				return this._GioiTinh;
			}
			set
			{
				if ((this._GioiTinh != value))
				{
					this._GioiTinh = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DienThoaiDiDong", DbType="NVarChar(20)")]
		public string DienThoaiDiDong
		{
			get
			{
				return this._DienThoaiDiDong;
			}
			set
			{
				if ((this._DienThoaiDiDong != value))
				{
					this._DienThoaiDiDong = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(80)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this._Email = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HoatDong", DbType="Bit")]
		public System.Nullable<bool> HoatDong
		{
			get
			{
				return this._HoatDong;
			}
			set
			{
				if ((this._HoatDong != value))
				{
					this._HoatDong = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_urlAnh", DbType="NVarChar(250)")]
		public string urlAnh
		{
			get
			{
				return this._urlAnh;
			}
			set
			{
				if ((this._urlAnh != value))
				{
					this._urlAnh = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
