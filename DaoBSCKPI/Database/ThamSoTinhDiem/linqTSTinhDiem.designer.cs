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

namespace DaoBSCKPI.Database.ThamSoTinhDiem
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
	public partial class linqTSTinhDiemDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqTSTinhDiemDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqTSTinhDiemDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqTSTinhDiemDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqTSTinhDiemDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqTSTinhDiemDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKThamSoTinhDiem_DanhSach")]
		public ISingleResult<sp_tblBKThamSoTinhDiem_DanhSachResult> sp_tblBKThamSoTinhDiem_DanhSach()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<sp_tblBKThamSoTinhDiem_DanhSachResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKThamSoTinhDiem_ThongTin")]
		public ISingleResult<sp_tblBKThamSoTinhDiem_ThongTinResult> sp_tblBKThamSoTinhDiem_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID", DbType="Int")] System.Nullable<int> iD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD);
			return ((ISingleResult<sp_tblBKThamSoTinhDiem_ThongTinResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKThamSoTinhDiem_ThemSua")]
		public int sp_tblBKThamSoTinhDiem_ThemSua([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID", DbType="Int")] System.Nullable<int> iD, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Ten", DbType="NVarChar(80)")] string ten, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDXuHuongYeuCau", DbType="Int")] System.Nullable<int> iDXuHuongYeuCau, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CanDuoi", DbType="Decimal(22,3)")] System.Nullable<decimal> canDuoi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="CanTren", DbType="Decimal(22,3)")] System.Nullable<decimal> canTren, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DiemCanDuoi", DbType="Decimal(18,3)")] System.Nullable<decimal> diemCanDuoi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DiemCanTren", DbType="Decimal(18,3)")] System.Nullable<decimal> diemCanTren, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhomThamSo", DbType="Int")] System.Nullable<int> iDNhomThamSo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDGiaTri", DbType="Int")] System.Nullable<int> iDGiaTri, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD, ten, iDXuHuongYeuCau, canDuoi, canTren, diemCanDuoi, diemCanTren, iDNhomThamSo, iDGiaTri, nguoiTao);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKThamSoTinhDiem_Tim")]
		public ISingleResult<sp_tblBKThamSoTinhDiem_TimResult> sp_tblBKThamSoTinhDiem_Tim([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Ten", DbType="NVarChar(50)")] string ten)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), ten);
			return ((ISingleResult<sp_tblBKThamSoTinhDiem_TimResult>)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblBKThamSoTinhDiem_DanhSachResult
	{
		
		private int _ID;
		
		private string _Ten;
		
		private System.Nullable<int> _IDXuHuongYeuCau;
		
		private string _XuHuongYeuCau;
		
		private System.Nullable<decimal> _CanDuoi;
		
		private System.Nullable<decimal> _CanTren;
		
		private System.Nullable<decimal> _DiemCanDuoi;
		
		private System.Nullable<decimal> _DiemCanTren;
		
		private System.Nullable<int> _IDNhomThamSo;
		
		private string _NhomThamSo;
		
		private System.Nullable<int> _IDGiaTri;
		
		private string _Giatri;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		private string _NguoiTao;
		
		private string _NguoiSua;
		
		public sp_tblBKThamSoTinhDiem_DanhSachResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL")]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ten", DbType="NVarChar(80)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDXuHuongYeuCau", DbType="Int")]
		public System.Nullable<int> IDXuHuongYeuCau
		{
			get
			{
				return this._IDXuHuongYeuCau;
			}
			set
			{
				if ((this._IDXuHuongYeuCau != value))
				{
					this._IDXuHuongYeuCau = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_XuHuongYeuCau", DbType="NVarChar(50)")]
		public string XuHuongYeuCau
		{
			get
			{
				return this._XuHuongYeuCau;
			}
			set
			{
				if ((this._XuHuongYeuCau != value))
				{
					this._XuHuongYeuCau = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CanDuoi", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> CanDuoi
		{
			get
			{
				return this._CanDuoi;
			}
			set
			{
				if ((this._CanDuoi != value))
				{
					this._CanDuoi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CanTren", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> CanTren
		{
			get
			{
				return this._CanTren;
			}
			set
			{
				if ((this._CanTren != value))
				{
					this._CanTren = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiemCanDuoi", DbType="Decimal(18,3)")]
		public System.Nullable<decimal> DiemCanDuoi
		{
			get
			{
				return this._DiemCanDuoi;
			}
			set
			{
				if ((this._DiemCanDuoi != value))
				{
					this._DiemCanDuoi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiemCanTren", DbType="Decimal(18,3)")]
		public System.Nullable<decimal> DiemCanTren
		{
			get
			{
				return this._DiemCanTren;
			}
			set
			{
				if ((this._DiemCanTren != value))
				{
					this._DiemCanTren = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNhomThamSo", DbType="Int")]
		public System.Nullable<int> IDNhomThamSo
		{
			get
			{
				return this._IDNhomThamSo;
			}
			set
			{
				if ((this._IDNhomThamSo != value))
				{
					this._IDNhomThamSo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NhomThamSo", DbType="NVarChar(50)")]
		public string NhomThamSo
		{
			get
			{
				return this._NhomThamSo;
			}
			set
			{
				if ((this._NhomThamSo != value))
				{
					this._NhomThamSo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDGiaTri", DbType="Int")]
		public System.Nullable<int> IDGiaTri
		{
			get
			{
				return this._IDGiaTri;
			}
			set
			{
				if ((this._IDGiaTri != value))
				{
					this._IDGiaTri = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Giatri", DbType="NVarChar(50)")]
		public string Giatri
		{
			get
			{
				return this._Giatri;
			}
			set
			{
				if ((this._Giatri != value))
				{
					this._Giatri = value;
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
	}
	
	public partial class sp_tblBKThamSoTinhDiem_ThongTinResult
	{
		
		private int _ID;
		
		private string _Ten;
		
		private System.Nullable<int> _IDXuHuongYeuCau;
		
		private System.Nullable<decimal> _CanDuoi;
		
		private System.Nullable<decimal> _CanTren;
		
		private System.Nullable<decimal> _DiemCanDuoi;
		
		private System.Nullable<decimal> _DiemCanTren;
		
		private System.Nullable<int> _IDNhomThamSo;
		
		private System.Nullable<int> _IDGiaTri;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		private string _NguoiTao;
		
		private string _NguoiSua;
		
		public sp_tblBKThamSoTinhDiem_ThongTinResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL")]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ten", DbType="NVarChar(80)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDXuHuongYeuCau", DbType="Int")]
		public System.Nullable<int> IDXuHuongYeuCau
		{
			get
			{
				return this._IDXuHuongYeuCau;
			}
			set
			{
				if ((this._IDXuHuongYeuCau != value))
				{
					this._IDXuHuongYeuCau = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CanDuoi", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> CanDuoi
		{
			get
			{
				return this._CanDuoi;
			}
			set
			{
				if ((this._CanDuoi != value))
				{
					this._CanDuoi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CanTren", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> CanTren
		{
			get
			{
				return this._CanTren;
			}
			set
			{
				if ((this._CanTren != value))
				{
					this._CanTren = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiemCanDuoi", DbType="Decimal(18,3)")]
		public System.Nullable<decimal> DiemCanDuoi
		{
			get
			{
				return this._DiemCanDuoi;
			}
			set
			{
				if ((this._DiemCanDuoi != value))
				{
					this._DiemCanDuoi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiemCanTren", DbType="Decimal(18,3)")]
		public System.Nullable<decimal> DiemCanTren
		{
			get
			{
				return this._DiemCanTren;
			}
			set
			{
				if ((this._DiemCanTren != value))
				{
					this._DiemCanTren = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNhomThamSo", DbType="Int")]
		public System.Nullable<int> IDNhomThamSo
		{
			get
			{
				return this._IDNhomThamSo;
			}
			set
			{
				if ((this._IDNhomThamSo != value))
				{
					this._IDNhomThamSo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDGiaTri", DbType="Int")]
		public System.Nullable<int> IDGiaTri
		{
			get
			{
				return this._IDGiaTri;
			}
			set
			{
				if ((this._IDGiaTri != value))
				{
					this._IDGiaTri = value;
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
	}
	
	public partial class sp_tblBKThamSoTinhDiem_TimResult
	{
		
		private int _ID;
		
		private string _Ten;
		
		private System.Nullable<int> _IDXuHuongYeuCau;
		
		private System.Nullable<decimal> _CanDuoi;
		
		private System.Nullable<decimal> _CanTren;
		
		private System.Nullable<decimal> _DiemCanDuoi;
		
		private System.Nullable<decimal> _DiemCanTren;
		
		private System.Nullable<int> _IDNhomThamSo;
		
		private System.Nullable<int> _IDGiaTri;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		private string _NguoiTao;
		
		private string _NguoiSua;
		
		public sp_tblBKThamSoTinhDiem_TimResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL")]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this._ID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ten", DbType="NVarChar(80)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDXuHuongYeuCau", DbType="Int")]
		public System.Nullable<int> IDXuHuongYeuCau
		{
			get
			{
				return this._IDXuHuongYeuCau;
			}
			set
			{
				if ((this._IDXuHuongYeuCau != value))
				{
					this._IDXuHuongYeuCau = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CanDuoi", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> CanDuoi
		{
			get
			{
				return this._CanDuoi;
			}
			set
			{
				if ((this._CanDuoi != value))
				{
					this._CanDuoi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CanTren", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> CanTren
		{
			get
			{
				return this._CanTren;
			}
			set
			{
				if ((this._CanTren != value))
				{
					this._CanTren = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiemCanDuoi", DbType="Decimal(18,3)")]
		public System.Nullable<decimal> DiemCanDuoi
		{
			get
			{
				return this._DiemCanDuoi;
			}
			set
			{
				if ((this._DiemCanDuoi != value))
				{
					this._DiemCanDuoi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiemCanTren", DbType="Decimal(18,3)")]
		public System.Nullable<decimal> DiemCanTren
		{
			get
			{
				return this._DiemCanTren;
			}
			set
			{
				if ((this._DiemCanTren != value))
				{
					this._DiemCanTren = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNhomThamSo", DbType="Int")]
		public System.Nullable<int> IDNhomThamSo
		{
			get
			{
				return this._IDNhomThamSo;
			}
			set
			{
				if ((this._IDNhomThamSo != value))
				{
					this._IDNhomThamSo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDGiaTri", DbType="Int")]
		public System.Nullable<int> IDGiaTri
		{
			get
			{
				return this._IDGiaTri;
			}
			set
			{
				if ((this._IDGiaTri != value))
				{
					this._IDGiaTri = value;
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
	}
}
#pragma warning restore 1591