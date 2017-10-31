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

namespace DaoBSCKPI.Database.ChiTieuKPI
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
	public partial class linqTrongSoNhomKPIDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqTrongSoNhomKPIDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqTrongSoNhomKPIDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqTrongSoNhomKPIDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqTrongSoNhomKPIDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqTrongSoNhomKPIDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKTrongSoNhomKPI_DanhSach")]
		public ISingleResult<sp_tblBKTrongSoNhomKPI_DanhSachResult> sp_tblBKTrongSoNhomKPI_DanhSach()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<sp_tblBKTrongSoNhomKPI_DanhSachResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKTrongSoNhomKPI_ThongTin")]
		public ISingleResult<sp_tblBKTrongSoNhomKPI_ThongTinResult> sp_tblBKTrongSoNhomKPI_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhomKPI", DbType="Int")] System.Nullable<int> iDNhomKPI, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Ngay", DbType="Date")] System.Nullable<System.DateTime> ngay)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDNhomKPI, ngay);
			return ((ISingleResult<sp_tblBKTrongSoNhomKPI_ThongTinResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKTrongSoNhomKPI_ThemSua")]
		public int sp_tblBKTrongSoNhomKPI_ThemSua([global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNhomKPI", DbType="Int")] System.Nullable<int> iDNhomKPI, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="GiaTri", DbType="Decimal(18,0)")] System.Nullable<decimal> giaTri, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TuNgay", DbType="Date")] System.Nullable<System.DateTime> tuNgay, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DenNgay", DbType="Date")] System.Nullable<System.DateTime> denNgay, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iDNhomKPI, giaTri, tuNgay, denNgay, nguoiTao);
			return ((int)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblBKTrongSoNhomKPI_DanhSachResult
	{
		
		private System.Nullable<long> _STT;
		
		private int _IDNhomKPI;
		
		private string _Ten;
		
		private string _TenChon;
		
		private string _Ma;
		
		private System.Nullable<decimal> _GiaTri;
		
		private System.Nullable<System.DateTime> _TuNgay;
		
		private System.Nullable<System.DateTime> _DenNgay;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		private string _NguoiTao;
		
		private string _NguoiSua;
		
		public sp_tblBKTrongSoNhomKPI_DanhSachResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STT", DbType="BigInt")]
		public System.Nullable<long> STT
		{
			get
			{
				return this._STT;
			}
			set
			{
				if ((this._STT != value))
				{
					this._STT = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNhomKPI", DbType="Int NOT NULL")]
		public int IDNhomKPI
		{
			get
			{
				return this._IDNhomKPI;
			}
			set
			{
				if ((this._IDNhomKPI != value))
				{
					this._IDNhomKPI = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenChon", DbType="NVarChar(85)")]
		public string TenChon
		{
			get
			{
				return this._TenChon;
			}
			set
			{
				if ((this._TenChon != value))
				{
					this._TenChon = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GiaTri", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> GiaTri
		{
			get
			{
				return this._GiaTri;
			}
			set
			{
				if ((this._GiaTri != value))
				{
					this._GiaTri = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TuNgay", DbType="Date")]
		public System.Nullable<System.DateTime> TuNgay
		{
			get
			{
				return this._TuNgay;
			}
			set
			{
				if ((this._TuNgay != value))
				{
					this._TuNgay = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DenNgay", DbType="Date")]
		public System.Nullable<System.DateTime> DenNgay
		{
			get
			{
				return this._DenNgay;
			}
			set
			{
				if ((this._DenNgay != value))
				{
					this._DenNgay = value;
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
	
	public partial class sp_tblBKTrongSoNhomKPI_ThongTinResult
	{
		
		private int _IDNhomKPI;
		
		private System.Nullable<decimal> _GiaTri;
		
		private System.Nullable<System.DateTime> _TuNgay;
		
		private System.Nullable<System.DateTime> _DenNgay;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		private string _NguoiTao;
		
		private string _NguoiSua;
		
		public sp_tblBKTrongSoNhomKPI_ThongTinResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNhomKPI", DbType="Int NOT NULL")]
		public int IDNhomKPI
		{
			get
			{
				return this._IDNhomKPI;
			}
			set
			{
				if ((this._IDNhomKPI != value))
				{
					this._IDNhomKPI = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GiaTri", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> GiaTri
		{
			get
			{
				return this._GiaTri;
			}
			set
			{
				if ((this._GiaTri != value))
				{
					this._GiaTri = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TuNgay", DbType="Date")]
		public System.Nullable<System.DateTime> TuNgay
		{
			get
			{
				return this._TuNgay;
			}
			set
			{
				if ((this._TuNgay != value))
				{
					this._TuNgay = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DenNgay", DbType="Date")]
		public System.Nullable<System.DateTime> DenNgay
		{
			get
			{
				return this._DenNgay;
			}
			set
			{
				if ((this._DenNgay != value))
				{
					this._DenNgay = value;
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
