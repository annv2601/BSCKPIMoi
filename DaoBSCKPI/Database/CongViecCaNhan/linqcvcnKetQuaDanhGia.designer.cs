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

namespace DaoBSCKPI.Database.CongViecCaNhan
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
	public partial class linqcvcnKetQuaDanhGiaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public linqcvcnKetQuaDanhGiaDataContext() : 
				base(global::DaoBSCKPI.Properties.Settings.Default.BSCKPIConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public linqcvcnKetQuaDanhGiaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqcvcnKetQuaDanhGiaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqcvcnKetQuaDanhGiaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public linqcvcnKetQuaDanhGiaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblcvCongViecCaNhanKetQuaDanhGia_ThongTin")]
		public ISingleResult<sp_tblcvCongViecCaNhanKetQuaDanhGia_ThongTinResult> sp_tblcvCongViecCaNhanKetQuaDanhGia_ThongTin([global::System.Data.Linq.Mapping.ParameterAttribute(Name="MaCongViecCaNhan", DbType="Decimal(20,0)")] System.Nullable<decimal> maCongViecCaNhan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNguoiDuocDanhGia", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNguoiDuocDanhGia)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCongViecCaNhan, iDNguoiDuocDanhGia);
			return ((ISingleResult<sp_tblcvCongViecCaNhanKetQuaDanhGia_ThongTinResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblcvCongViecCaNhanKetQuaDanhGia_ThemSua")]
		public int sp_tblcvCongViecCaNhanKetQuaDanhGia_ThemSua([global::System.Data.Linq.Mapping.ParameterAttribute(Name="MaCongViecCaNhan", DbType="Decimal(20,0)")] System.Nullable<decimal> maCongViecCaNhan, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNguoiDanhGia", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNguoiDanhGia, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDNguoiDuocDanhGia", DbType="UniqueIdentifier")] System.Nullable<System.Guid> iDNguoiDuocDanhGia, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ChatLuong", DbType="NVarChar(100)")] string chatLuong, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="KhoiLuong", DbType="NVarChar(100)")] string khoiLuong, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TienDo", DbType="NVarChar(100)")] string tienDo, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="DoPhucTap", DbType="NVarChar(100)")] string doPhucTap, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="TrachNhiem", DbType="NVarChar(100)")] string trachNhiem, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="IDKetQua", DbType="Int")] System.Nullable<int> iDKetQua)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCongViecCaNhan, iDNguoiDanhGia, iDNguoiDuocDanhGia, chatLuong, khoiLuong, tienDo, doPhucTap, trachNhiem, iDKetQua);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_tblcvCongViecCaNhanKetQuaDanhGia_DanhSach")]
		public ISingleResult<sp_tblcvCongViecCaNhanKetQuaDanhGia_DanhSachResult> sp_tblcvCongViecCaNhanKetQuaDanhGia_DanhSach([global::System.Data.Linq.Mapping.ParameterAttribute(Name="MaCongViecCaNhan", DbType="Decimal(20,0)")] System.Nullable<decimal> maCongViecCaNhan)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), maCongViecCaNhan);
			return ((ISingleResult<sp_tblcvCongViecCaNhanKetQuaDanhGia_DanhSachResult>)(result.ReturnValue));
		}
	}
	
	public partial class sp_tblcvCongViecCaNhanKetQuaDanhGia_ThongTinResult
	{
		
		private System.Nullable<decimal> _MaCongViecCaNhan;
		
		private System.Nullable<System.Guid> _IDNguoiDanhGia;
		
		private System.Nullable<System.Guid> _IDNguoiDuocDanhGia;
		
		private System.Nullable<System.DateTime> _NgayDanhGia;
		
		private string _ChatLuong;
		
		private string _KhoiLuong;
		
		private string _TienDo;
		
		private string _DoPhucTap;
		
		private string _TrachNhiem;
		
		private System.Nullable<int> _IDKetQua;
		
		public sp_tblcvCongViecCaNhanKetQuaDanhGia_ThongTinResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaCongViecCaNhan", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> MaCongViecCaNhan
		{
			get
			{
				return this._MaCongViecCaNhan;
			}
			set
			{
				if ((this._MaCongViecCaNhan != value))
				{
					this._MaCongViecCaNhan = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNguoiDanhGia", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> IDNguoiDanhGia
		{
			get
			{
				return this._IDNguoiDanhGia;
			}
			set
			{
				if ((this._IDNguoiDanhGia != value))
				{
					this._IDNguoiDanhGia = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNguoiDuocDanhGia", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> IDNguoiDuocDanhGia
		{
			get
			{
				return this._IDNguoiDuocDanhGia;
			}
			set
			{
				if ((this._IDNguoiDuocDanhGia != value))
				{
					this._IDNguoiDuocDanhGia = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayDanhGia", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayDanhGia
		{
			get
			{
				return this._NgayDanhGia;
			}
			set
			{
				if ((this._NgayDanhGia != value))
				{
					this._NgayDanhGia = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChatLuong", DbType="NVarChar(100)")]
		public string ChatLuong
		{
			get
			{
				return this._ChatLuong;
			}
			set
			{
				if ((this._ChatLuong != value))
				{
					this._ChatLuong = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KhoiLuong", DbType="NVarChar(100)")]
		public string KhoiLuong
		{
			get
			{
				return this._KhoiLuong;
			}
			set
			{
				if ((this._KhoiLuong != value))
				{
					this._KhoiLuong = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TienDo", DbType="NVarChar(100)")]
		public string TienDo
		{
			get
			{
				return this._TienDo;
			}
			set
			{
				if ((this._TienDo != value))
				{
					this._TienDo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DoPhucTap", DbType="NVarChar(100)")]
		public string DoPhucTap
		{
			get
			{
				return this._DoPhucTap;
			}
			set
			{
				if ((this._DoPhucTap != value))
				{
					this._DoPhucTap = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrachNhiem", DbType="NVarChar(100)")]
		public string TrachNhiem
		{
			get
			{
				return this._TrachNhiem;
			}
			set
			{
				if ((this._TrachNhiem != value))
				{
					this._TrachNhiem = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDKetQua", DbType="Int")]
		public System.Nullable<int> IDKetQua
		{
			get
			{
				return this._IDKetQua;
			}
			set
			{
				if ((this._IDKetQua != value))
				{
					this._IDKetQua = value;
				}
			}
		}
	}
	
	public partial class sp_tblcvCongViecCaNhanKetQuaDanhGia_DanhSachResult
	{
		
		private System.Nullable<int> _STT;
		
		private System.Nullable<decimal> _MaCongViecCaNhan;
		
		private System.Nullable<System.Guid> _IDNguoiDanhGia;
		
		private string _NguoiDanhGia;
		
		private System.Nullable<System.Guid> _IDNguoiDuocDanhGia;
		
		private string _NguoiDuocDanhGia;
		
		private System.Nullable<System.DateTime> _NgayDanhGia;
		
		private string _ChatLuong;
		
		private string _KhoiLuong;
		
		private string _TienDo;
		
		private string _DoPhucTap;
		
		private string _TrachNhiem;
		
		private System.Nullable<int> _IDKetQua;
		
		private string _TenKetQua;
		
		public sp_tblcvCongViecCaNhanKetQuaDanhGia_DanhSachResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STT", DbType="Int")]
		public System.Nullable<int> STT
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MaCongViecCaNhan", DbType="Decimal(20,0)")]
		public System.Nullable<decimal> MaCongViecCaNhan
		{
			get
			{
				return this._MaCongViecCaNhan;
			}
			set
			{
				if ((this._MaCongViecCaNhan != value))
				{
					this._MaCongViecCaNhan = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNguoiDanhGia", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> IDNguoiDanhGia
		{
			get
			{
				return this._IDNguoiDanhGia;
			}
			set
			{
				if ((this._IDNguoiDanhGia != value))
				{
					this._IDNguoiDanhGia = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiDanhGia", DbType="NVarChar(50)")]
		public string NguoiDanhGia
		{
			get
			{
				return this._NguoiDanhGia;
			}
			set
			{
				if ((this._NguoiDanhGia != value))
				{
					this._NguoiDanhGia = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDNguoiDuocDanhGia", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> IDNguoiDuocDanhGia
		{
			get
			{
				return this._IDNguoiDuocDanhGia;
			}
			set
			{
				if ((this._IDNguoiDuocDanhGia != value))
				{
					this._IDNguoiDuocDanhGia = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NguoiDuocDanhGia", DbType="NVarChar(50)")]
		public string NguoiDuocDanhGia
		{
			get
			{
				return this._NguoiDuocDanhGia;
			}
			set
			{
				if ((this._NguoiDuocDanhGia != value))
				{
					this._NguoiDuocDanhGia = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayDanhGia", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayDanhGia
		{
			get
			{
				return this._NgayDanhGia;
			}
			set
			{
				if ((this._NgayDanhGia != value))
				{
					this._NgayDanhGia = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChatLuong", DbType="NVarChar(100)")]
		public string ChatLuong
		{
			get
			{
				return this._ChatLuong;
			}
			set
			{
				if ((this._ChatLuong != value))
				{
					this._ChatLuong = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KhoiLuong", DbType="NVarChar(100)")]
		public string KhoiLuong
		{
			get
			{
				return this._KhoiLuong;
			}
			set
			{
				if ((this._KhoiLuong != value))
				{
					this._KhoiLuong = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TienDo", DbType="NVarChar(100)")]
		public string TienDo
		{
			get
			{
				return this._TienDo;
			}
			set
			{
				if ((this._TienDo != value))
				{
					this._TienDo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DoPhucTap", DbType="NVarChar(100)")]
		public string DoPhucTap
		{
			get
			{
				return this._DoPhucTap;
			}
			set
			{
				if ((this._DoPhucTap != value))
				{
					this._DoPhucTap = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TrachNhiem", DbType="NVarChar(100)")]
		public string TrachNhiem
		{
			get
			{
				return this._TrachNhiem;
			}
			set
			{
				if ((this._TrachNhiem != value))
				{
					this._TrachNhiem = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IDKetQua", DbType="Int")]
		public System.Nullable<int> IDKetQua
		{
			get
			{
				return this._IDKetQua;
			}
			set
			{
				if ((this._IDKetQua != value))
				{
					this._IDKetQua = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TenKetQua", DbType="NVarChar(50)")]
		public string TenKetQua
		{
			get
			{
				return this._TenKetQua;
			}
			set
			{
				if ((this._TenKetQua != value))
				{
					this._TenKetQua = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
