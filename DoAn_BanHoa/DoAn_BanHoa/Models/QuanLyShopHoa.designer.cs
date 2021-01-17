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

namespace DoAn_BanHoa.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="QuanLyShopHoa")]
	public partial class QuanLyShopHoaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCHUDE(CHUDE instance);
    partial void UpdateCHUDE(CHUDE instance);
    partial void DeleteCHUDE(CHUDE instance);
    partial void InsertTAIKHOAN(TAIKHOAN instance);
    partial void UpdateTAIKHOAN(TAIKHOAN instance);
    partial void DeleteTAIKHOAN(TAIKHOAN instance);
    partial void InsertCTDONHANG(CTDONHANG instance);
    partial void UpdateCTDONHANG(CTDONHANG instance);
    partial void DeleteCTDONHANG(CTDONHANG instance);
    partial void InsertDONHANG(DONHANG instance);
    partial void UpdateDONHANG(DONHANG instance);
    partial void DeleteDONHANG(DONHANG instance);
    partial void InsertHOA(HOA instance);
    partial void UpdateHOA(HOA instance);
    partial void DeleteHOA(HOA instance);
    partial void InsertLOAIHOA(LOAIHOA instance);
    partial void UpdateLOAIHOA(LOAIHOA instance);
    partial void DeleteLOAIHOA(LOAIHOA instance);
    #endregion
		
		public QuanLyShopHoaDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["QuanLyShopHoaConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public QuanLyShopHoaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QuanLyShopHoaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QuanLyShopHoaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QuanLyShopHoaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CHUDE> CHUDEs
		{
			get
			{
				return this.GetTable<CHUDE>();
			}
		}
		
		public System.Data.Linq.Table<TAIKHOAN> TAIKHOANs
		{
			get
			{
				return this.GetTable<TAIKHOAN>();
			}
		}
		
		public System.Data.Linq.Table<CTDONHANG> CTDONHANGs
		{
			get
			{
				return this.GetTable<CTDONHANG>();
			}
		}
		
		public System.Data.Linq.Table<DONHANG> DONHANGs
		{
			get
			{
				return this.GetTable<DONHANG>();
			}
		}
		
		public System.Data.Linq.Table<HOA> HOAs
		{
			get
			{
				return this.GetTable<HOA>();
			}
		}
		
		public System.Data.Linq.Table<LOAIHOA> LOAIHOAs
		{
			get
			{
				return this.GetTable<LOAIHOA>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CHUDE")]
	public partial class CHUDE : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MACHUDE;
		
		private string _TENCHUDE;
		
		private EntitySet<HOA> _HOAs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMACHUDEChanging(string value);
    partial void OnMACHUDEChanged();
    partial void OnTENCHUDEChanging(string value);
    partial void OnTENCHUDEChanged();
    #endregion
		
		public CHUDE()
		{
			this._HOAs = new EntitySet<HOA>(new Action<HOA>(this.attach_HOAs), new Action<HOA>(this.detach_HOAs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MACHUDE", DbType="NChar(5) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MACHUDE
		{
			get
			{
				return this._MACHUDE;
			}
			set
			{
				if ((this._MACHUDE != value))
				{
					this.OnMACHUDEChanging(value);
					this.SendPropertyChanging();
					this._MACHUDE = value;
					this.SendPropertyChanged("MACHUDE");
					this.OnMACHUDEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TENCHUDE", DbType="NVarChar(50)")]
		public string TENCHUDE
		{
			get
			{
				return this._TENCHUDE;
			}
			set
			{
				if ((this._TENCHUDE != value))
				{
					this.OnTENCHUDEChanging(value);
					this.SendPropertyChanging();
					this._TENCHUDE = value;
					this.SendPropertyChanged("TENCHUDE");
					this.OnTENCHUDEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CHUDE_HOA", Storage="_HOAs", ThisKey="MACHUDE", OtherKey="MACHUDE")]
		public EntitySet<HOA> HOAs
		{
			get
			{
				return this._HOAs;
			}
			set
			{
				this._HOAs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_HOAs(HOA entity)
		{
			this.SendPropertyChanging();
			entity.CHUDE = this;
		}
		
		private void detach_HOAs(HOA entity)
		{
			this.SendPropertyChanging();
			entity.CHUDE = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TAIKHOAN")]
	public partial class TAIKHOAN : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MAKH;
		
		private string _HOTEN;
		
		private string _TENDN;
		
		private string _MATKHAU;
		
		private string _SDT;
		
		private System.Nullable<System.DateTime> _NGAYSINH;
		
		private string _EMAIL;
		
		private string _DIACHI;
		
		private System.Nullable<bool> _QUYEN;
		
		private EntitySet<DONHANG> _DONHANGs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMAKHChanging(int value);
    partial void OnMAKHChanged();
    partial void OnHOTENChanging(string value);
    partial void OnHOTENChanged();
    partial void OnTENDNChanging(string value);
    partial void OnTENDNChanged();
    partial void OnMATKHAUChanging(string value);
    partial void OnMATKHAUChanged();
    partial void OnSDTChanging(string value);
    partial void OnSDTChanged();
    partial void OnNGAYSINHChanging(System.Nullable<System.DateTime> value);
    partial void OnNGAYSINHChanged();
    partial void OnEMAILChanging(string value);
    partial void OnEMAILChanged();
    partial void OnDIACHIChanging(string value);
    partial void OnDIACHIChanged();
    partial void OnQUYENChanging(System.Nullable<bool> value);
    partial void OnQUYENChanged();
    #endregion
		
		public TAIKHOAN()
		{
			this._DONHANGs = new EntitySet<DONHANG>(new Action<DONHANG>(this.attach_DONHANGs), new Action<DONHANG>(this.detach_DONHANGs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MAKH", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MAKH
		{
			get
			{
				return this._MAKH;
			}
			set
			{
				if ((this._MAKH != value))
				{
					this.OnMAKHChanging(value);
					this.SendPropertyChanging();
					this._MAKH = value;
					this.SendPropertyChanged("MAKH");
					this.OnMAKHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HOTEN", DbType="NVarChar(50)")]
		public string HOTEN
		{
			get
			{
				return this._HOTEN;
			}
			set
			{
				if ((this._HOTEN != value))
				{
					this.OnHOTENChanging(value);
					this.SendPropertyChanging();
					this._HOTEN = value;
					this.SendPropertyChanged("HOTEN");
					this.OnHOTENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TENDN", DbType="NVarChar(50)")]
		public string TENDN
		{
			get
			{
				return this._TENDN;
			}
			set
			{
				if ((this._TENDN != value))
				{
					this.OnTENDNChanging(value);
					this.SendPropertyChanging();
					this._TENDN = value;
					this.SendPropertyChanged("TENDN");
					this.OnTENDNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MATKHAU", DbType="NChar(50)")]
		public string MATKHAU
		{
			get
			{
				return this._MATKHAU;
			}
			set
			{
				if ((this._MATKHAU != value))
				{
					this.OnMATKHAUChanging(value);
					this.SendPropertyChanging();
					this._MATKHAU = value;
					this.SendPropertyChanged("MATKHAU");
					this.OnMATKHAUChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SDT", DbType="NChar(12)")]
		public string SDT
		{
			get
			{
				return this._SDT;
			}
			set
			{
				if ((this._SDT != value))
				{
					this.OnSDTChanging(value);
					this.SendPropertyChanging();
					this._SDT = value;
					this.SendPropertyChanged("SDT");
					this.OnSDTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NGAYSINH", DbType="DateTime")]
		public System.Nullable<System.DateTime> NGAYSINH
		{
			get
			{
				return this._NGAYSINH;
			}
			set
			{
				if ((this._NGAYSINH != value))
				{
					this.OnNGAYSINHChanging(value);
					this.SendPropertyChanging();
					this._NGAYSINH = value;
					this.SendPropertyChanged("NGAYSINH");
					this.OnNGAYSINHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMAIL", DbType="VarChar(50)")]
		public string EMAIL
		{
			get
			{
				return this._EMAIL;
			}
			set
			{
				if ((this._EMAIL != value))
				{
					this.OnEMAILChanging(value);
					this.SendPropertyChanging();
					this._EMAIL = value;
					this.SendPropertyChanged("EMAIL");
					this.OnEMAILChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DIACHI", DbType="NVarChar(MAX)")]
		public string DIACHI
		{
			get
			{
				return this._DIACHI;
			}
			set
			{
				if ((this._DIACHI != value))
				{
					this.OnDIACHIChanging(value);
					this.SendPropertyChanging();
					this._DIACHI = value;
					this.SendPropertyChanged("DIACHI");
					this.OnDIACHIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QUYEN", DbType="Bit")]
		public System.Nullable<bool> QUYEN
		{
			get
			{
				return this._QUYEN;
			}
			set
			{
				if ((this._QUYEN != value))
				{
					this.OnQUYENChanging(value);
					this.SendPropertyChanging();
					this._QUYEN = value;
					this.SendPropertyChanged("QUYEN");
					this.OnQUYENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TAIKHOAN_DONHANG", Storage="_DONHANGs", ThisKey="MAKH", OtherKey="MAKH")]
		public EntitySet<DONHANG> DONHANGs
		{
			get
			{
				return this._DONHANGs;
			}
			set
			{
				this._DONHANGs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_DONHANGs(DONHANG entity)
		{
			this.SendPropertyChanging();
			entity.TAIKHOAN = this;
		}
		
		private void detach_DONHANGs(DONHANG entity)
		{
			this.SendPropertyChanging();
			entity.TAIKHOAN = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CTDONHANG")]
	public partial class CTDONHANG : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MADONHANG;
		
		private string _MAHOA;
		
		private System.Nullable<int> _SOLUONG;
		
		private System.Nullable<decimal> _DONGIA;
		
		private EntityRef<DONHANG> _DONHANG;
		
		private EntityRef<HOA> _HOA;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMADONHANGChanging(int value);
    partial void OnMADONHANGChanged();
    partial void OnMAHOAChanging(string value);
    partial void OnMAHOAChanged();
    partial void OnSOLUONGChanging(System.Nullable<int> value);
    partial void OnSOLUONGChanged();
    partial void OnDONGIAChanging(System.Nullable<decimal> value);
    partial void OnDONGIAChanged();
    #endregion
		
		public CTDONHANG()
		{
			this._DONHANG = default(EntityRef<DONHANG>);
			this._HOA = default(EntityRef<HOA>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MADONHANG", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int MADONHANG
		{
			get
			{
				return this._MADONHANG;
			}
			set
			{
				if ((this._MADONHANG != value))
				{
					if (this._DONHANG.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMADONHANGChanging(value);
					this.SendPropertyChanging();
					this._MADONHANG = value;
					this.SendPropertyChanged("MADONHANG");
					this.OnMADONHANGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MAHOA", DbType="NChar(5) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MAHOA
		{
			get
			{
				return this._MAHOA;
			}
			set
			{
				if ((this._MAHOA != value))
				{
					if (this._HOA.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMAHOAChanging(value);
					this.SendPropertyChanging();
					this._MAHOA = value;
					this.SendPropertyChanged("MAHOA");
					this.OnMAHOAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SOLUONG", DbType="Int")]
		public System.Nullable<int> SOLUONG
		{
			get
			{
				return this._SOLUONG;
			}
			set
			{
				if ((this._SOLUONG != value))
				{
					this.OnSOLUONGChanging(value);
					this.SendPropertyChanging();
					this._SOLUONG = value;
					this.SendPropertyChanged("SOLUONG");
					this.OnSOLUONGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DONGIA", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> DONGIA
		{
			get
			{
				return this._DONGIA;
			}
			set
			{
				if ((this._DONGIA != value))
				{
					this.OnDONGIAChanging(value);
					this.SendPropertyChanging();
					this._DONGIA = value;
					this.SendPropertyChanged("DONGIA");
					this.OnDONGIAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DONHANG_CTDONHANG", Storage="_DONHANG", ThisKey="MADONHANG", OtherKey="MADONHANG", IsForeignKey=true)]
		public DONHANG DONHANG
		{
			get
			{
				return this._DONHANG.Entity;
			}
			set
			{
				DONHANG previousValue = this._DONHANG.Entity;
				if (((previousValue != value) 
							|| (this._DONHANG.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DONHANG.Entity = null;
						previousValue.CTDONHANGs.Remove(this);
					}
					this._DONHANG.Entity = value;
					if ((value != null))
					{
						value.CTDONHANGs.Add(this);
						this._MADONHANG = value.MADONHANG;
					}
					else
					{
						this._MADONHANG = default(int);
					}
					this.SendPropertyChanged("DONHANG");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="HOA_CTDONHANG", Storage="_HOA", ThisKey="MAHOA", OtherKey="MAHOA", IsForeignKey=true)]
		public HOA HOA
		{
			get
			{
				return this._HOA.Entity;
			}
			set
			{
				HOA previousValue = this._HOA.Entity;
				if (((previousValue != value) 
							|| (this._HOA.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._HOA.Entity = null;
						previousValue.CTDONHANGs.Remove(this);
					}
					this._HOA.Entity = value;
					if ((value != null))
					{
						value.CTDONHANGs.Add(this);
						this._MAHOA = value.MAHOA;
					}
					else
					{
						this._MAHOA = default(string);
					}
					this.SendPropertyChanged("HOA");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DONHANG")]
	public partial class DONHANG : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _MADONHANG;
		
		private System.Nullable<System.DateTime> _NGAYGIAO;
		
		private System.Nullable<System.DateTime> _NGAYDAT;
		
		private string _DATHANHTOAN;
		
		private string _TINHTRANGGIAOHANG;
		
		private System.Nullable<int> _MAKH;
		
		private EntitySet<CTDONHANG> _CTDONHANGs;
		
		private EntityRef<TAIKHOAN> _TAIKHOAN;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMADONHANGChanging(int value);
    partial void OnMADONHANGChanged();
    partial void OnNGAYGIAOChanging(System.Nullable<System.DateTime> value);
    partial void OnNGAYGIAOChanged();
    partial void OnNGAYDATChanging(System.Nullable<System.DateTime> value);
    partial void OnNGAYDATChanged();
    partial void OnDATHANHTOANChanging(string value);
    partial void OnDATHANHTOANChanged();
    partial void OnTINHTRANGGIAOHANGChanging(string value);
    partial void OnTINHTRANGGIAOHANGChanged();
    partial void OnMAKHChanging(System.Nullable<int> value);
    partial void OnMAKHChanged();
    #endregion
		
		public DONHANG()
		{
			this._CTDONHANGs = new EntitySet<CTDONHANG>(new Action<CTDONHANG>(this.attach_CTDONHANGs), new Action<CTDONHANG>(this.detach_CTDONHANGs));
			this._TAIKHOAN = default(EntityRef<TAIKHOAN>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MADONHANG", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int MADONHANG
		{
			get
			{
				return this._MADONHANG;
			}
			set
			{
				if ((this._MADONHANG != value))
				{
					this.OnMADONHANGChanging(value);
					this.SendPropertyChanging();
					this._MADONHANG = value;
					this.SendPropertyChanged("MADONHANG");
					this.OnMADONHANGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NGAYGIAO", DbType="Date")]
		public System.Nullable<System.DateTime> NGAYGIAO
		{
			get
			{
				return this._NGAYGIAO;
			}
			set
			{
				if ((this._NGAYGIAO != value))
				{
					this.OnNGAYGIAOChanging(value);
					this.SendPropertyChanging();
					this._NGAYGIAO = value;
					this.SendPropertyChanged("NGAYGIAO");
					this.OnNGAYGIAOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NGAYDAT", DbType="Date")]
		public System.Nullable<System.DateTime> NGAYDAT
		{
			get
			{
				return this._NGAYDAT;
			}
			set
			{
				if ((this._NGAYDAT != value))
				{
					this.OnNGAYDATChanging(value);
					this.SendPropertyChanging();
					this._NGAYDAT = value;
					this.SendPropertyChanged("NGAYDAT");
					this.OnNGAYDATChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DATHANHTOAN", DbType="NVarChar(50)")]
		public string DATHANHTOAN
		{
			get
			{
				return this._DATHANHTOAN;
			}
			set
			{
				if ((this._DATHANHTOAN != value))
				{
					this.OnDATHANHTOANChanging(value);
					this.SendPropertyChanging();
					this._DATHANHTOAN = value;
					this.SendPropertyChanged("DATHANHTOAN");
					this.OnDATHANHTOANChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TINHTRANGGIAOHANG", DbType="NVarChar(MAX)")]
		public string TINHTRANGGIAOHANG
		{
			get
			{
				return this._TINHTRANGGIAOHANG;
			}
			set
			{
				if ((this._TINHTRANGGIAOHANG != value))
				{
					this.OnTINHTRANGGIAOHANGChanging(value);
					this.SendPropertyChanging();
					this._TINHTRANGGIAOHANG = value;
					this.SendPropertyChanged("TINHTRANGGIAOHANG");
					this.OnTINHTRANGGIAOHANGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MAKH", DbType="Int")]
		public System.Nullable<int> MAKH
		{
			get
			{
				return this._MAKH;
			}
			set
			{
				if ((this._MAKH != value))
				{
					if (this._TAIKHOAN.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMAKHChanging(value);
					this.SendPropertyChanging();
					this._MAKH = value;
					this.SendPropertyChanged("MAKH");
					this.OnMAKHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DONHANG_CTDONHANG", Storage="_CTDONHANGs", ThisKey="MADONHANG", OtherKey="MADONHANG")]
		public EntitySet<CTDONHANG> CTDONHANGs
		{
			get
			{
				return this._CTDONHANGs;
			}
			set
			{
				this._CTDONHANGs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="TAIKHOAN_DONHANG", Storage="_TAIKHOAN", ThisKey="MAKH", OtherKey="MAKH", IsForeignKey=true)]
		public TAIKHOAN TAIKHOAN
		{
			get
			{
				return this._TAIKHOAN.Entity;
			}
			set
			{
				TAIKHOAN previousValue = this._TAIKHOAN.Entity;
				if (((previousValue != value) 
							|| (this._TAIKHOAN.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._TAIKHOAN.Entity = null;
						previousValue.DONHANGs.Remove(this);
					}
					this._TAIKHOAN.Entity = value;
					if ((value != null))
					{
						value.DONHANGs.Add(this);
						this._MAKH = value.MAKH;
					}
					else
					{
						this._MAKH = default(Nullable<int>);
					}
					this.SendPropertyChanged("TAIKHOAN");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CTDONHANGs(CTDONHANG entity)
		{
			this.SendPropertyChanging();
			entity.DONHANG = this;
		}
		
		private void detach_CTDONHANGs(CTDONHANG entity)
		{
			this.SendPropertyChanging();
			entity.DONHANG = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.HOA")]
	public partial class HOA : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MAHOA;
		
		private string _TENHOA;
		
		private string _MALOAI;
		
		private System.Nullable<decimal> _GIA;
		
		private string _MOTA;
		
		private string _ANH;
		
		private string _MACHUDE;
		
		private EntitySet<CTDONHANG> _CTDONHANGs;
		
		private EntityRef<CHUDE> _CHUDE;
		
		private EntityRef<LOAIHOA> _LOAIHOA;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMAHOAChanging(string value);
    partial void OnMAHOAChanged();
    partial void OnTENHOAChanging(string value);
    partial void OnTENHOAChanged();
    partial void OnMALOAIChanging(string value);
    partial void OnMALOAIChanged();
    partial void OnGIAChanging(System.Nullable<decimal> value);
    partial void OnGIAChanged();
    partial void OnMOTAChanging(string value);
    partial void OnMOTAChanged();
    partial void OnANHChanging(string value);
    partial void OnANHChanged();
    partial void OnMACHUDEChanging(string value);
    partial void OnMACHUDEChanged();
    #endregion
		
		public HOA()
		{
			this._CTDONHANGs = new EntitySet<CTDONHANG>(new Action<CTDONHANG>(this.attach_CTDONHANGs), new Action<CTDONHANG>(this.detach_CTDONHANGs));
			this._CHUDE = default(EntityRef<CHUDE>);
			this._LOAIHOA = default(EntityRef<LOAIHOA>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MAHOA", DbType="NChar(5) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MAHOA
		{
			get
			{
				return this._MAHOA;
			}
			set
			{
				if ((this._MAHOA != value))
				{
					this.OnMAHOAChanging(value);
					this.SendPropertyChanging();
					this._MAHOA = value;
					this.SendPropertyChanged("MAHOA");
					this.OnMAHOAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TENHOA", DbType="NVarChar(MAX)")]
		public string TENHOA
		{
			get
			{
				return this._TENHOA;
			}
			set
			{
				if ((this._TENHOA != value))
				{
					this.OnTENHOAChanging(value);
					this.SendPropertyChanging();
					this._TENHOA = value;
					this.SendPropertyChanged("TENHOA");
					this.OnTENHOAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MALOAI", DbType="NChar(5)")]
		public string MALOAI
		{
			get
			{
				return this._MALOAI;
			}
			set
			{
				if ((this._MALOAI != value))
				{
					if (this._LOAIHOA.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMALOAIChanging(value);
					this.SendPropertyChanging();
					this._MALOAI = value;
					this.SendPropertyChanged("MALOAI");
					this.OnMALOAIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GIA", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> GIA
		{
			get
			{
				return this._GIA;
			}
			set
			{
				if ((this._GIA != value))
				{
					this.OnGIAChanging(value);
					this.SendPropertyChanging();
					this._GIA = value;
					this.SendPropertyChanged("GIA");
					this.OnGIAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MOTA", DbType="NVarChar(MAX)")]
		public string MOTA
		{
			get
			{
				return this._MOTA;
			}
			set
			{
				if ((this._MOTA != value))
				{
					this.OnMOTAChanging(value);
					this.SendPropertyChanging();
					this._MOTA = value;
					this.SendPropertyChanged("MOTA");
					this.OnMOTAChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ANH", DbType="NVarChar(MAX)")]
		public string ANH
		{
			get
			{
				return this._ANH;
			}
			set
			{
				if ((this._ANH != value))
				{
					this.OnANHChanging(value);
					this.SendPropertyChanging();
					this._ANH = value;
					this.SendPropertyChanged("ANH");
					this.OnANHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MACHUDE", DbType="NChar(5)")]
		public string MACHUDE
		{
			get
			{
				return this._MACHUDE;
			}
			set
			{
				if ((this._MACHUDE != value))
				{
					if (this._CHUDE.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMACHUDEChanging(value);
					this.SendPropertyChanging();
					this._MACHUDE = value;
					this.SendPropertyChanged("MACHUDE");
					this.OnMACHUDEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="HOA_CTDONHANG", Storage="_CTDONHANGs", ThisKey="MAHOA", OtherKey="MAHOA")]
		public EntitySet<CTDONHANG> CTDONHANGs
		{
			get
			{
				return this._CTDONHANGs;
			}
			set
			{
				this._CTDONHANGs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CHUDE_HOA", Storage="_CHUDE", ThisKey="MACHUDE", OtherKey="MACHUDE", IsForeignKey=true)]
		public CHUDE CHUDE
		{
			get
			{
				return this._CHUDE.Entity;
			}
			set
			{
				CHUDE previousValue = this._CHUDE.Entity;
				if (((previousValue != value) 
							|| (this._CHUDE.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CHUDE.Entity = null;
						previousValue.HOAs.Remove(this);
					}
					this._CHUDE.Entity = value;
					if ((value != null))
					{
						value.HOAs.Add(this);
						this._MACHUDE = value.MACHUDE;
					}
					else
					{
						this._MACHUDE = default(string);
					}
					this.SendPropertyChanged("CHUDE");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LOAIHOA_HOA", Storage="_LOAIHOA", ThisKey="MALOAI", OtherKey="MALOAI", IsForeignKey=true)]
		public LOAIHOA LOAIHOA
		{
			get
			{
				return this._LOAIHOA.Entity;
			}
			set
			{
				LOAIHOA previousValue = this._LOAIHOA.Entity;
				if (((previousValue != value) 
							|| (this._LOAIHOA.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._LOAIHOA.Entity = null;
						previousValue.HOAs.Remove(this);
					}
					this._LOAIHOA.Entity = value;
					if ((value != null))
					{
						value.HOAs.Add(this);
						this._MALOAI = value.MALOAI;
					}
					else
					{
						this._MALOAI = default(string);
					}
					this.SendPropertyChanged("LOAIHOA");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CTDONHANGs(CTDONHANG entity)
		{
			this.SendPropertyChanging();
			entity.HOA = this;
		}
		
		private void detach_CTDONHANGs(CTDONHANG entity)
		{
			this.SendPropertyChanging();
			entity.HOA = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LOAIHOA")]
	public partial class LOAIHOA : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _MALOAI;
		
		private string _TENLOAI;
		
		private EntitySet<HOA> _HOAs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMALOAIChanging(string value);
    partial void OnMALOAIChanged();
    partial void OnTENLOAIChanging(string value);
    partial void OnTENLOAIChanged();
    #endregion
		
		public LOAIHOA()
		{
			this._HOAs = new EntitySet<HOA>(new Action<HOA>(this.attach_HOAs), new Action<HOA>(this.detach_HOAs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MALOAI", DbType="NChar(5) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string MALOAI
		{
			get
			{
				return this._MALOAI;
			}
			set
			{
				if ((this._MALOAI != value))
				{
					this.OnMALOAIChanging(value);
					this.SendPropertyChanging();
					this._MALOAI = value;
					this.SendPropertyChanged("MALOAI");
					this.OnMALOAIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TENLOAI", DbType="NVarChar(50)")]
		public string TENLOAI
		{
			get
			{
				return this._TENLOAI;
			}
			set
			{
				if ((this._TENLOAI != value))
				{
					this.OnTENLOAIChanging(value);
					this.SendPropertyChanging();
					this._TENLOAI = value;
					this.SendPropertyChanged("TENLOAI");
					this.OnTENLOAIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="LOAIHOA_HOA", Storage="_HOAs", ThisKey="MALOAI", OtherKey="MALOAI")]
		public EntitySet<HOA> HOAs
		{
			get
			{
				return this._HOAs;
			}
			set
			{
				this._HOAs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_HOAs(HOA entity)
		{
			this.SendPropertyChanging();
			entity.LOAIHOA = this;
		}
		
		private void detach_HOAs(HOA entity)
		{
			this.SendPropertyChanging();
			entity.LOAIHOA = null;
		}
	}
}
#pragma warning restore 1591
