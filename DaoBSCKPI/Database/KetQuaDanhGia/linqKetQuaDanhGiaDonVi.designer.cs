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
	public partial class linqKetQuaDanhGiaDonViDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqKetQuaDanhGiaDonViDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqKetQuaDanhGiaDonViDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqKetQuaDanhGiaDonViDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqKetQuaDanhGiaDonViDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqKetQuaDanhGiaDonViDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKKetQuaDanhGiaDonVi_CapNhat")]
		public int sp_tblBKKetQuaDanhGiaDonVi_CapNhat([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKPI", DbType="Int")] System.Nullable<int> iDKPI, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="KetQua", DbType="Decimal(22,3)")] System.Nullable<decimal> ketQua, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDDonVi, iDPhongBan, iDKPI, ketQua, nguoiTao);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKKetQuaDanhGiaDonVi_KhoiTao")]
		public int sp_tblBKKetQuaDanhGiaDonVi_KhoiTao([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDDonVi, iDPhongBan, nguoiTao);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKKetQuaDanhGiaDonVi_DanhSach")]
		public ISingleResult<sp_tblBKKetQuaDanhGiaDonVi_DanhSachResult> sp_tblBKKetQuaDanhGiaDonVi_DanhSach([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDDonVi, iDPhongBan);
			return ((ISingleResult<sp_tblBKKetQuaDanhGiaDonVi_DanhSachResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKKetQuaDanhGiaDonVi_ThongTin")]
		public ISingleResult<sp_tblBKKetQuaDanhGiaDonVi_ThongTinResult> sp_tblBKKetQuaDanhGiaDonVi_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Thang", DbType="SmallInt")] System.Nullable<short> thang, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKPI", DbType="Int")] System.Nullable<int> iDKPI)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), thang, nam, iDDonVi, iDPhongBan, iDKPI);
			return ((ISingleResult<sp_tblBKKetQuaDanhGiaDonVi_ThongTinResult>)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblBKKetQuaDanhGiaDonVi_DanhSachResult
	{
		
		private System.Nullable<long> _STT;
		
		private System.Nullable<short> _Thang;
		
		private System.Nullable<int> _Nam;
		
		private System.Nullable<int> _IDDonVi;
		
		private System.Nullable<int> _IDPhongBan;
		
		private System.Nullable<int> _IDKPI;
		
		private System.Nullable<decimal> _MucTieu;
		
		private System.Nullable<decimal> _KetQua;
		
		private string _NguoiTao;
		
		private string _NguoiSua;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		private string _Ma;
		
		private string _Ten;
		
		private string _DonViTinh;
		
		private string _TanSuatDo;
		
		private string _XuHuongYeuCau;
		
		public sp_tblBKKetQuaDanhGiaDonVi_DanhSachResult()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDDonVi", DbType="Int")]
		public System.Nullable<int> IDDonVi
		{
			get
			{
				return this._IDDonVi;
			}
			set
			{
				if ((this._IDDonVi != value))
				{
					this._IDDonVi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDPhongBan", DbType="Int")]
		public System.Nullable<int> IDPhongBan
		{
			get
			{
				return this._IDPhongBan;
			}
			set
			{
				if ((this._IDPhongBan != value))
				{
					this._IDPhongBan = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ma", DbType="NVarChar(15)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ten", DbType="NVarChar(250)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DonViTinh", DbType="NVarChar(50)")]
		public string DonViTinh
		{
			get
			{
				return this._DonViTinh;
			}
			set
			{
				if ((this._DonViTinh != value))
				{
					this._DonViTinh = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TanSuatDo", DbType="NVarChar(50)")]
		public string TanSuatDo
		{
			get
			{
				return this._TanSuatDo;
			}
			set
			{
				if ((this._TanSuatDo != value))
				{
					this._TanSuatDo = value;
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
	}
	
	public partial class sp_tblBKKetQuaDanhGiaDonVi_ThongTinResult
	{
		
		private System.Nullable<short> _Thang;
		
		private System.Nullable<int> _Nam;
		
		private System.Nullable<int> _IDDonVi;
		
		private System.Nullable<int> _IDPhongBan;
		
		private System.Nullable<int> _IDKPI;
		
		private System.Nullable<decimal> _MucTieu;
		
		private System.Nullable<decimal> _KetQua;
		
		private string _NguoiTao;
		
		private string _NguoiSua;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		public sp_tblBKKetQuaDanhGiaDonVi_ThongTinResult()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDDonVi", DbType="Int")]
		public System.Nullable<int> IDDonVi
		{
			get
			{
				return this._IDDonVi;
			}
			set
			{
				if ((this._IDDonVi != value))
				{
					this._IDDonVi = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDPhongBan", DbType="Int")]
		public System.Nullable<int> IDPhongBan
		{
			get
			{
				return this._IDPhongBan;
			}
			set
			{
				if ((this._IDPhongBan != value))
				{
					this._IDPhongBan = value;
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