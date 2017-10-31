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

namespace DaoBSCKPI.Database.ChiTieuBSC
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
	public partial class linqChiTieuBSCPhongDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqChiTieuBSCPhongDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqChiTieuBSCPhongDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqChiTieuBSCPhongDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqChiTieuBSCPhongDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqChiTieuBSCPhongDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuBSC_LayTrongSo")]
		public ISingleResult<sp_tblBKChiTieuBSC_LayTrongSoResult> sp_tblBKChiTieuBSC_LayTrongSo([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID", DbType="Int")] System.Nullable<int> iD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD);
			return ((ISingleResult<sp_tblBKChiTieuBSC_LayTrongSoResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuBSCPhong_CapNhat")]
		public int sp_tblBKChiTieuBSCPhong_CapNhat([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDBSC", DbType="Int")] System.Nullable<int> iDBSC, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TrongSoChiTieu", DbType="Decimal(22,3)")] System.Nullable<decimal> trongSoChiTieu, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TrongSoChung", DbType="Decimal(22,3)")] System.Nullable<decimal> trongSoChung, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieu", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieu)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nam, iDDonVi, iDPhongBan, iDBSC, trongSoChiTieu, trongSoChung, mucTieu);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuBSCPhong_ThongTinHienThi")]
		public ISingleResult<sp_tblBKChiTieuBSCPhong_ThongTinHienThiResult> sp_tblBKChiTieuBSCPhong_ThongTinHienThi([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDBSC", DbType="Int")] System.Nullable<int> iDBSC)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nam, iDDonVi, iDPhongBan, iDBSC);
			return ((ISingleResult<sp_tblBKChiTieuBSCPhong_ThongTinHienThiResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuBSCPhong_DanhSach")]
		public ISingleResult<sp_tblBKChiTieuBSCPhong_DanhSachResult> sp_tblBKChiTieuBSCPhong_DanhSach([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nam, iDDonVi, iDPhongBan);
			return ((ISingleResult<sp_tblBKChiTieuBSCPhong_DanhSachResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuBSCPhong_DanhSach_NhomID")]
		public ISingleResult<sp_tblBKChiTieuBSCPhong_DanhSach_NhomIDResult> sp_tblBKChiTieuBSCPhong_DanhSach_NhomID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDChiTieuTren", DbType="Int")] System.Nullable<int> iDChiTieuTren)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nam, iDDonVi, iDPhongBan, iDChiTieuTren);
			return ((ISingleResult<sp_tblBKChiTieuBSCPhong_DanhSach_NhomIDResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuBSCPhong_KhoiTao")]
		public int sp_tblBKChiTieuBSCPhong_KhoiTao([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nam, iDDonVi, iDPhongBan, nguoiTao);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuBSCPhong_ThemSua")]
		public int sp_tblBKChiTieuBSCPhong_ThemSua([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDBSC", DbType="Int")] System.Nullable<int> iDBSC, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonViTinh", DbType="Int")] System.Nullable<int> iDDonViTinh, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDTanSuatDo", DbType="Int")] System.Nullable<int> iDTanSuatDo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDXuHuongYeuCau", DbType="Int")] System.Nullable<int> iDXuHuongYeuCau, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TrongSoChung", DbType="Decimal(22,3)")] System.Nullable<decimal> trongSoChung, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TrongSoChiTieu", DbType="Decimal(22,3)")] System.Nullable<decimal> trongSoChiTieu, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="MucTieu", DbType="Decimal(22,3)")] System.Nullable<decimal> mucTieu, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nam, iDDonVi, iDPhongBan, iDBSC, iDDonViTinh, iDTanSuatDo, iDXuHuongYeuCau, trongSoChung, trongSoChiTieu, mucTieu, nguoiTao);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblBKChiTieuBSCPhong_ThongTin")]
		public ISingleResult<sp_tblBKChiTieuBSCPhong_ThongTinResult> sp_tblBKChiTieuBSCPhong_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Nam", DbType="Int")] System.Nullable<int> nam, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDDonVi", DbType="Int")] System.Nullable<int> iDDonVi, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhongBan", DbType="Int")] System.Nullable<int> iDPhongBan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDBSC", DbType="Int")] System.Nullable<int> iDBSC)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), nam, iDDonVi, iDPhongBan, iDBSC);
			return ((ISingleResult<sp_tblBKChiTieuBSCPhong_ThongTinResult>)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblBKChiTieuBSC_LayTrongSoResult
	{
		
		private System.Nullable<decimal> _TrongSoChung;
		
		public sp_tblBKChiTieuBSC_LayTrongSoResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrongSoChung", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> TrongSoChung
		{
			get
			{
				return this._TrongSoChung;
			}
			set
			{
				if ((this._TrongSoChung != value))
				{
					this._TrongSoChung = value;
				}
			}
		}
	}
	
	public partial class sp_tblBKChiTieuBSCPhong_ThongTinHienThiResult
	{
		
		private System.Nullable<int> _Nam;
		
		private System.Nullable<int> _IDDonVi;
		
		private System.Nullable<int> _IDPhongBan;
		
		private System.Nullable<int> _IDBSC;
		
		private string _Ma;
		
		private string _TenBSC;
		
		private System.Nullable<int> _IDChiTieuTren;
		
		private System.Nullable<int> _IDXuHuongYeuCau;
		
		private string _XuHuongYeuCau;
		
		private System.Nullable<decimal> _TrongSoChung;
		
		private System.Nullable<decimal> _TrongSoChiTieu;
		
		private System.Nullable<decimal> _MucTieu;
		
		private System.Nullable<int> _IDDonViTinh;
		
		private string _DonViTing;
		
		private System.Nullable<int> _IDTanSuatDo;
		
		private string _TanSuatDo;
		
		public sp_tblBKChiTieuBSCPhong_ThongTinHienThiResult()
		{
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDBSC", DbType="Int")]
		public System.Nullable<int> IDBSC
		{
			get
			{
				return this._IDBSC;
			}
			set
			{
				if ((this._IDBSC != value))
				{
					this._IDBSC = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenBSC", DbType="NVarChar(250)")]
		public string TenBSC
		{
			get
			{
				return this._TenBSC;
			}
			set
			{
				if ((this._TenBSC != value))
				{
					this._TenBSC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDChiTieuTren", DbType="Int")]
		public System.Nullable<int> IDChiTieuTren
		{
			get
			{
				return this._IDChiTieuTren;
			}
			set
			{
				if ((this._IDChiTieuTren != value))
				{
					this._IDChiTieuTren = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrongSoChung", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> TrongSoChung
		{
			get
			{
				return this._TrongSoChung;
			}
			set
			{
				if ((this._TrongSoChung != value))
				{
					this._TrongSoChung = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrongSoChiTieu", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> TrongSoChiTieu
		{
			get
			{
				return this._TrongSoChiTieu;
			}
			set
			{
				if ((this._TrongSoChiTieu != value))
				{
					this._TrongSoChiTieu = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDDonViTinh", DbType="Int")]
		public System.Nullable<int> IDDonViTinh
		{
			get
			{
				return this._IDDonViTinh;
			}
			set
			{
				if ((this._IDDonViTinh != value))
				{
					this._IDDonViTinh = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DonViTing", DbType="NVarChar(50)")]
		public string DonViTing
		{
			get
			{
				return this._DonViTing;
			}
			set
			{
				if ((this._DonViTing != value))
				{
					this._DonViTing = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDTanSuatDo", DbType="Int")]
		public System.Nullable<int> IDTanSuatDo
		{
			get
			{
				return this._IDTanSuatDo;
			}
			set
			{
				if ((this._IDTanSuatDo != value))
				{
					this._IDTanSuatDo = value;
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
	}
	
	public partial class sp_tblBKChiTieuBSCPhong_DanhSachResult
	{
		
		private System.Nullable<int> _Nam;
		
		private System.Nullable<int> _IDDonVi;
		
		private System.Nullable<int> _IDPhongBan;
		
		private System.Nullable<int> _IDBSC;
		
		private string _Ma;
		
		private string _TenBSC;
		
		private System.Nullable<int> _IDChiTieuTren;
		
		private System.Nullable<int> _IDXuHuongYeuCau;
		
		private string _XuHuongYeuCau;
		
		private System.Nullable<decimal> _TrongSoChung;
		
		private System.Nullable<decimal> _TrongSoChiTieu;
		
		private System.Nullable<decimal> _MucTieu;
		
		private System.Nullable<int> _IDDonViTinh;
		
		private string _DonViTing;
		
		private System.Nullable<int> _IDTanSuatDo;
		
		private string _TanSuatDo;
		
		public sp_tblBKChiTieuBSCPhong_DanhSachResult()
		{
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDBSC", DbType="Int")]
		public System.Nullable<int> IDBSC
		{
			get
			{
				return this._IDBSC;
			}
			set
			{
				if ((this._IDBSC != value))
				{
					this._IDBSC = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenBSC", DbType="NVarChar(250)")]
		public string TenBSC
		{
			get
			{
				return this._TenBSC;
			}
			set
			{
				if ((this._TenBSC != value))
				{
					this._TenBSC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDChiTieuTren", DbType="Int")]
		public System.Nullable<int> IDChiTieuTren
		{
			get
			{
				return this._IDChiTieuTren;
			}
			set
			{
				if ((this._IDChiTieuTren != value))
				{
					this._IDChiTieuTren = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrongSoChung", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> TrongSoChung
		{
			get
			{
				return this._TrongSoChung;
			}
			set
			{
				if ((this._TrongSoChung != value))
				{
					this._TrongSoChung = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrongSoChiTieu", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> TrongSoChiTieu
		{
			get
			{
				return this._TrongSoChiTieu;
			}
			set
			{
				if ((this._TrongSoChiTieu != value))
				{
					this._TrongSoChiTieu = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDDonViTinh", DbType="Int")]
		public System.Nullable<int> IDDonViTinh
		{
			get
			{
				return this._IDDonViTinh;
			}
			set
			{
				if ((this._IDDonViTinh != value))
				{
					this._IDDonViTinh = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DonViTing", DbType="NVarChar(50)")]
		public string DonViTing
		{
			get
			{
				return this._DonViTing;
			}
			set
			{
				if ((this._DonViTing != value))
				{
					this._DonViTing = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDTanSuatDo", DbType="Int")]
		public System.Nullable<int> IDTanSuatDo
		{
			get
			{
				return this._IDTanSuatDo;
			}
			set
			{
				if ((this._IDTanSuatDo != value))
				{
					this._IDTanSuatDo = value;
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
	}
	
	public partial class sp_tblBKChiTieuBSCPhong_DanhSach_NhomIDResult
	{
		
		private System.Nullable<int> _Nam;
		
		private System.Nullable<int> _IDDonVi;
		
		private System.Nullable<int> _IDPhongBan;
		
		private System.Nullable<int> _IDBSC;
		
		private string _Ma;
		
		private string _TenBSC;
		
		private System.Nullable<int> _IDChiTieuTren;
		
		public sp_tblBKChiTieuBSCPhong_DanhSach_NhomIDResult()
		{
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDBSC", DbType="Int")]
		public System.Nullable<int> IDBSC
		{
			get
			{
				return this._IDBSC;
			}
			set
			{
				if ((this._IDBSC != value))
				{
					this._IDBSC = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenBSC", DbType="NVarChar(250)")]
		public string TenBSC
		{
			get
			{
				return this._TenBSC;
			}
			set
			{
				if ((this._TenBSC != value))
				{
					this._TenBSC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDChiTieuTren", DbType="Int")]
		public System.Nullable<int> IDChiTieuTren
		{
			get
			{
				return this._IDChiTieuTren;
			}
			set
			{
				if ((this._IDChiTieuTren != value))
				{
					this._IDChiTieuTren = value;
				}
			}
		}
	}
	
	public partial class sp_tblBKChiTieuBSCPhong_ThongTinResult
	{
		
		private System.Nullable<int> _Nam;
		
		private System.Nullable<int> _IDDonVi;
		
		private System.Nullable<int> _IDPhongBan;
		
		private System.Nullable<int> _IDBSC;
		
		private System.Nullable<int> _IDDonViTinh;
		
		private System.Nullable<int> _IDTanSuatDo;
		
		private System.Nullable<int> _IDXuHuongYeuCau;
		
		private System.Nullable<decimal> _TrongSoChung;
		
		private System.Nullable<decimal> _TrongSoChiTieu;
		
		private System.Nullable<decimal> _MucTieu;
		
		private string _NguoiTao;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		public sp_tblBKChiTieuBSCPhong_ThongTinResult()
		{
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDBSC", DbType="Int")]
		public System.Nullable<int> IDBSC
		{
			get
			{
				return this._IDBSC;
			}
			set
			{
				if ((this._IDBSC != value))
				{
					this._IDBSC = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDDonViTinh", DbType="Int")]
		public System.Nullable<int> IDDonViTinh
		{
			get
			{
				return this._IDDonViTinh;
			}
			set
			{
				if ((this._IDDonViTinh != value))
				{
					this._IDDonViTinh = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDTanSuatDo", DbType="Int")]
		public System.Nullable<int> IDTanSuatDo
		{
			get
			{
				return this._IDTanSuatDo;
			}
			set
			{
				if ((this._IDTanSuatDo != value))
				{
					this._IDTanSuatDo = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrongSoChung", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> TrongSoChung
		{
			get
			{
				return this._TrongSoChung;
			}
			set
			{
				if ((this._TrongSoChung != value))
				{
					this._TrongSoChung = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrongSoChiTieu", DbType="Decimal(22,3)")]
		public System.Nullable<decimal> TrongSoChiTieu
		{
			get
			{
				return this._TrongSoChiTieu;
			}
			set
			{
				if ((this._TrongSoChiTieu != value))
				{
					this._TrongSoChiTieu = value;
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
	}
}
#pragma warning restore 1591
