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

namespace DaoBSCKPI.Database.NguoiDung
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
	public partial class linqNguoiDungQuyenDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqNguoiDungQuyenDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqNguoiDungQuyenDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqNguoiDungQuyenDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqNguoiDungQuyenDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqNguoiDungQuyenDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblHTNguoiDungQuyenTruyNhap_ThemSua")]
		public int sp_tblHTNguoiDungQuyenTruyNhap_ThemSua([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhanVien", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNhanVien, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDQuyenTruyNhap", DbType="Int")] System.Nullable<int> iDQuyenTruyNhap, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDChucNang", DbType="Int")] System.Nullable<int> iDChucNang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDNhanVien, iDQuyenTruyNhap, iDChucNang, nguoiTao);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblHTNguoiDungQuyenTruyNhap_ThongTin")]
		public ISingleResult<sp_tblHTNguoiDungQuyenTruyNhap_ThongTinResult> sp_tblHTNguoiDungQuyenTruyNhap_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhanVien", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNhanVien)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDNhanVien);
			return ((ISingleResult<sp_tblHTNguoiDungQuyenTruyNhap_ThongTinResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblHTNguoiDungQuyenTruyNhap_DanhSach")]
		public ISingleResult<sp_tblHTNguoiDungQuyenTruyNhap_DanhSachResult> sp_tblHTNguoiDungQuyenTruyNhap_DanhSach([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhanVien", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNhanVien, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDQuyenTruyNhap", DbType="Int")] System.Nullable<int> iDQuyenTruyNhap, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDChucNang", DbType="Int")] System.Nullable<int> iDChucNang)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDNhanVien, iDQuyenTruyNhap, iDChucNang);
			return ((ISingleResult<sp_tblHTNguoiDungQuyenTruyNhap_DanhSachResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblHTNguoiDungQuyenTruyNhap_Xoa")]
		public int sp_tblHTNguoiDungQuyenTruyNhap_Xoa([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhanVien", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNhanVien, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDQuyenTruyNhap", DbType="Int")] System.Nullable<int> iDQuyenTruyNhap, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDChucNang", DbType="Int")] System.Nullable<int> iDChucNang)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDNhanVien, iDQuyenTruyNhap, iDChucNang);
			return ((int)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblHTNguoiDungQuyenTruyNhap_ThongTinResult
	{
		
		private System.Nullable<System.Guid> _IDNhanVien;
		
		private System.Nullable<int> _IDQuyenTruyNhap;
		
		private System.Nullable<int> _IDChucNang;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private string _NguoiTao;
		
		public sp_tblHTNguoiDungQuyenTruyNhap_ThongTinResult()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDQuyenTruyNhap", DbType="Int")]
		public System.Nullable<int> IDQuyenTruyNhap
		{
			get
			{
				return this._IDQuyenTruyNhap;
			}
			set
			{
				if ((this._IDQuyenTruyNhap != value))
				{
					this._IDQuyenTruyNhap = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDChucNang", DbType="Int")]
		public System.Nullable<int> IDChucNang
		{
			get
			{
				return this._IDChucNang;
			}
			set
			{
				if ((this._IDChucNang != value))
				{
					this._IDChucNang = value;
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
	}
	
	public partial class sp_tblHTNguoiDungQuyenTruyNhap_DanhSachResult
	{
		
		private System.Nullable<System.Guid> _IDNhanVien;
		
		private System.Nullable<int> _IDChucNang;
		
		private string _ChucNang;
		
		private System.Nullable<int> _IDQuyenTruyNhap;
		
		private string _QuyenTruyNhap;
		
		public sp_tblHTNguoiDungQuyenTruyNhap_DanhSachResult()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDChucNang", DbType="Int")]
		public System.Nullable<int> IDChucNang
		{
			get
			{
				return this._IDChucNang;
			}
			set
			{
				if ((this._IDChucNang != value))
				{
					this._IDChucNang = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChucNang", DbType="NVarChar(50)")]
		public string ChucNang
		{
			get
			{
				return this._ChucNang;
			}
			set
			{
				if ((this._ChucNang != value))
				{
					this._ChucNang = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDQuyenTruyNhap", DbType="Int")]
		public System.Nullable<int> IDQuyenTruyNhap
		{
			get
			{
				return this._IDQuyenTruyNhap;
			}
			set
			{
				if ((this._IDQuyenTruyNhap != value))
				{
					this._IDQuyenTruyNhap = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QuyenTruyNhap", DbType="NVarChar(50)")]
		public string QuyenTruyNhap
		{
			get
			{
				return this._QuyenTruyNhap;
			}
			set
			{
				if ((this._QuyenTruyNhap != value))
				{
					this._QuyenTruyNhap = value;
				}
			}
		}
	}
}
#pragma warning restore 1591