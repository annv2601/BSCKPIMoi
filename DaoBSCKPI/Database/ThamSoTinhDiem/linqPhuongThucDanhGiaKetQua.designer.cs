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
	public partial class linqPhuongThucDanhGiaKetQuaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqPhuongThucDanhGiaKetQuaDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqPhuongThucDanhGiaKetQuaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqPhuongThucDanhGiaKetQuaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqPhuongThucDanhGiaKetQuaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqPhuongThucDanhGiaKetQuaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblcvPhuongThucDanhGiaKetQua_Xoa")]
		public int sp_tblcvPhuongThucDanhGiaKetQua_Xoa([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID", DbType="Int")] System.Nullable<int> iD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblcvPhuongThucDanhGiaKetQua_ThemSua")]
		public int sp_tblcvPhuongThucDanhGiaKetQua_ThemSua([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID", DbType="Int")] System.Nullable<int> iD, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDTanSuatDo", DbType="Int")] System.Nullable<int> iDTanSuatDo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDPhuongThuc", DbType="Int")] System.Nullable<int> iDPhuongThuc, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TuNgay", DbType="Date")] System.Nullable<System.DateTime> tuNgay, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DenNgay", DbType="Date")] System.Nullable<System.DateTime> denNgay, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ThuTu", DbType="Decimal(8,1)")] System.Nullable<decimal> thuTu, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="NguoiTao", DbType="NVarChar(30)")] string nguoiTao)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD, iDTanSuatDo, iDPhuongThuc, tuNgay, denNgay, thuTu, nguoiTao);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblcvPhuongThucDanhGiaKetQua_ThongTin")]
		public ISingleResult<sp_tblcvPhuongThucDanhGiaKetQua_ThongTinResult> sp_tblcvPhuongThucDanhGiaKetQua_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ID", DbType="Int")] System.Nullable<int> iD)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iD);
			return ((ISingleResult<sp_tblcvPhuongThucDanhGiaKetQua_ThongTinResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblcvPhuongThucDanhGiaKetQua_DanhSach")]
		public ISingleResult<sp_tblcvPhuongThucDanhGiaKetQua_DanhSachResult> sp_tblcvPhuongThucDanhGiaKetQua_DanhSach()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<sp_tblcvPhuongThucDanhGiaKetQua_DanhSachResult>)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblcvPhuongThucDanhGiaKetQua_ThongTinResult
	{
		
		private int _ID;
		
		private int _IDTanSuatDo;
		
		private int _IDPhuongThuc;
		
		private System.Nullable<System.DateTime> _TuNgay;
		
		private System.Nullable<System.DateTime> _DenNgay;
		
		private System.Nullable<decimal> _ThuTu;
		
		private string _NguoiTao;
		
		private string _NguoiSua;
		
		private System.Nullable<System.DateTime> _NgayTao;
		
		private System.Nullable<System.DateTime> _NgaySua;
		
		public sp_tblcvPhuongThucDanhGiaKetQua_ThongTinResult()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDTanSuatDo", DbType="Int NOT NULL")]
		public int IDTanSuatDo
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDPhuongThuc", DbType="Int NOT NULL")]
		public int IDPhuongThuc
		{
			get
			{
				return this._IDPhuongThuc;
			}
			set
			{
				if ((this._IDPhuongThuc != value))
				{
					this._IDPhuongThuc = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThuTu", DbType="Decimal(8,1)")]
		public System.Nullable<decimal> ThuTu
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
	
	public partial class sp_tblcvPhuongThucDanhGiaKetQua_DanhSachResult
	{
		
		private System.Nullable<long> _STT;
		
		private int _ID;
		
		private int _IDTanSuatDo;
		
		private string _TanSuat;
		
		private int _IDPhuongThuc;
		
		private string _PhuongThuc;
		
		private System.Nullable<System.DateTime> _TuNgay;
		
		private System.Nullable<System.DateTime> _DenNgay;
		
		private System.Nullable<decimal> _ThuTu;
		
		public sp_tblcvPhuongThucDanhGiaKetQua_DanhSachResult()
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDTanSuatDo", DbType="Int NOT NULL")]
		public int IDTanSuatDo
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TanSuat", DbType="NVarChar(50)")]
		public string TanSuat
		{
			get
			{
				return this._TanSuat;
			}
			set
			{
				if ((this._TanSuat != value))
				{
					this._TanSuat = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDPhuongThuc", DbType="Int NOT NULL")]
		public int IDPhuongThuc
		{
			get
			{
				return this._IDPhuongThuc;
			}
			set
			{
				if ((this._IDPhuongThuc != value))
				{
					this._IDPhuongThuc = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhuongThuc", DbType="NVarChar(50)")]
		public string PhuongThuc
		{
			get
			{
				return this._PhuongThuc;
			}
			set
			{
				if ((this._PhuongThuc != value))
				{
					this._PhuongThuc = value;
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ThuTu", DbType="Decimal(8,1)")]
		public System.Nullable<decimal> ThuTu
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
	}
}
#pragma warning restore 1591
