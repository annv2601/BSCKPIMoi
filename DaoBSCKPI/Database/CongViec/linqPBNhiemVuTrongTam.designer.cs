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

namespace DaoBSCKPI.Database.CongViec
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
	public partial class linqPBNhiemVuTrongTamDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqPBNhiemVuTrongTamDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqPBNhiemVuTrongTamDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqPBNhiemVuTrongTamDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqPBNhiemVuTrongTamDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqPBNhiemVuTrongTamDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblcvPhanBoNhiemVuTrongTam_CapNhat")]
		public int sp_tblcvPhanBoNhiemVuTrongTam_CapNhat([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhiemVu", DbType="Int")] System.Nullable<int> iDNhiemVu, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TrongSo", DbType="Decimal(18,2)")] System.Nullable<decimal> trongSo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDNhiemVu, trongSo, nguoiTao);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblcvPhanBoNhiemVuTrongTam_ThongTin")]
		public ISingleResult<sp_tblcvPhanBoNhiemVuTrongTam_ThongTinResult> sp_tblcvPhanBoNhiemVuTrongTam_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhiemVu", DbType="Int")] System.Nullable<int> iDNhiemVu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDNhiemVu);
			return ((ISingleResult<sp_tblcvPhanBoNhiemVuTrongTam_ThongTinResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblcvPhanBoNhiemVuTrongTam_KhoiTao_NhanVien")]
		public int sp_tblcvPhanBoNhiemVuTrongTam_KhoiTao_NhanVien([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhanVien", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNhanVien, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDNhanVien, nguoiTao);
			return ((int)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblcvPhanBoNhiemVuTrongTam_ThongTinResult
	{
		
		private System.Nullable<short> _Thang;
		
		private System.Nullable<int> _Nam;
		
		private System.Nullable<int> _IDNhiemVu;
		
		private System.Nullable<int> _IDXuHuongYeuCau;
		
		private System.Nullable<decimal> _MucTieu;
		
		private System.Nullable<decimal> _TrongSo;
		
		private System.Nullable<decimal> _TrongSoNhom;
		
		private string _NguoiTao;
		
		private string _NguoiSua;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		public sp_tblcvPhanBoNhiemVuTrongTam_ThongTinResult()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNhiemVu", DbType="Int")]
		public System.Nullable<int> IDNhiemVu
		{
			get
			{
				return this._IDNhiemVu;
			}
			set
			{
				if ((this._IDNhiemVu != value))
				{
					this._IDNhiemVu = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MucTieu", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> MucTieu
		{
			get
			{
				return this._MucTieu;
			}
			set
			{
				if ((this._MucTieu != value))
				{
					this._MucTieu = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrongSo", DbType="Decimal(18,2)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrongSoNhom", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> TrongSoNhom
		{
			get
			{
				return this._TrongSoNhom;
			}
			set
			{
				if ((this._TrongSoNhom != value))
				{
					this._TrongSoNhom = value;
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
