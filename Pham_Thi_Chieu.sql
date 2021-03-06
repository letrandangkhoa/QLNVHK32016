USE [master]
GO
/****** Object:  Database [QL_LuongNV_DHM]    Script Date: 08/29/2016 23:00:00 ******/
CREATE DATABASE [QL_LuongNV_DHM] ON  PRIMARY 
( NAME = N'QL_LuongNV_DHM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\QL_LuongNV_DHM.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QL_LuongNV_DHM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\QL_LuongNV_DHM_log.LDF' , SIZE = 1344KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QL_LuongNV_DHM] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QL_LuongNV_DHM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QL_LuongNV_DHM] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET ANSI_NULLS OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET ANSI_PADDING OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET ARITHABORT OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [QL_LuongNV_DHM] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [QL_LuongNV_DHM] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [QL_LuongNV_DHM] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET  DISABLE_BROKER
GO
ALTER DATABASE [QL_LuongNV_DHM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [QL_LuongNV_DHM] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [QL_LuongNV_DHM] SET  READ_WRITE
GO
ALTER DATABASE [QL_LuongNV_DHM] SET RECOVERY SIMPLE
GO
ALTER DATABASE [QL_LuongNV_DHM] SET  MULTI_USER
GO
ALTER DATABASE [QL_LuongNV_DHM] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [QL_LuongNV_DHM] SET DB_CHAINING OFF
GO
USE [QL_LuongNV_DHM]
GO
/****** Object:  Table [dbo].[HeSoCoBan]    Script Date: 08/29/2016 23:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HeSoCoBan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenChiSo] [nchar](20) NOT NULL,
	[ChiSo] [int] NOT NULL,
 CONSTRAINT [PK_HeSoCoBan] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 08/29/2016 23:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten_CV] [nvarchar](200) NULL,
	[MoTa] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BangCap]    Script Date: 08/29/2016 23:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangCap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten_BC] [nvarchar](200) NULL,
	[HeSoLuong] [nvarchar](200) NULL,
	[LuongNgayNghi] [nvarchar](100) NULL,
	[Mota] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Admin1]    Script Date: 08/29/2016 23:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Admin1](
	[UserName] [nvarchar](200) NULL,
	[Pass] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhuCap]    Script Date: 08/29/2016 23:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhuCap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten] [nvarchar](100) NULL,
	[MucPhuCap] [int] NULL,
	[GhiChu] [nvarchar](200) NULL,
 CONSTRAINT [PK__PhuCap__3214EC270326F548] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 08/29/2016 23:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten_PB] [nvarchar](200) NULL,
	[MoTa] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 08/29/2016 23:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ten_NV] [nvarchar](200) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[DiaChi] [nvarchar](200) NULL,
	[So_CMND] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](200) NULL,
	[BangCap] [int] NULL,
	[ChucVu] [int] NULL,
	[PhongBan] [int] NULL,
	[HinhAnh] [image] NULL,
	[NgayVaoLam] [date] NOT NULL,
 CONSTRAINT [PK__NhanVien__3214EC272C433661] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TienThuong]    Script Date: 08/29/2016 23:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TienThuong](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_NhanVien] [int] NOT NULL,
	[ChiPhi] [int] NOT NULL,
	[ThoiGian] [date] NOT NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_TienThuong] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhuCap_NhanVien]    Script Date: 08/29/2016 23:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhuCap_NhanVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_NhanVien] [int] NOT NULL,
	[PhuCap] [int] NOT NULL,
	[GhiChu] [nvarchar](100) NULL,
 CONSTRAINT [PK_PhuCap_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ID_NhanVien] ASC,
	[PhuCap] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiPhiKhac]    Script Date: 08/29/2016 23:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiPhiKhac](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ID_NhanVien] [int] NOT NULL,
	[ChiPhi] [int] NOT NULL,
	[ThoiGian] [date] NOT NULL,
	[MoTa] [nvarchar](max) NULL,
 CONSTRAINT [PK_ChiPhiKhac] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LuongNhanVien]    Script Date: 08/29/2016 23:00:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LuongNhanVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_NhanVien] [int] NOT NULL,
	[LuongCoBan] [int] NOT NULL,
	[Thuong] [int] NULL,
	[MucPhuCap] [int] NULL,
	[ChiPhiKhac] [int] NULL,
	[TongLuong] [nvarchar](100) NOT NULL,
	[NgayTinhLuong] [date] NOT NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK__LuongNha__3214EC272B3F6F97] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK__NhanVien__BangCa__412EB0B6]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__BangCa__412EB0B6] FOREIGN KEY([BangCap])
REFERENCES [dbo].[BangCap] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__BangCa__412EB0B6]
GO
/****** Object:  ForeignKey [FK__NhanVien__BangCa__4F7CD00D]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__BangCa__4F7CD00D] FOREIGN KEY([BangCap])
REFERENCES [dbo].[BangCap] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__BangCa__4F7CD00D]
GO
/****** Object:  ForeignKey [FK__NhanVien__BangCa__5FB337D6]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__BangCa__5FB337D6] FOREIGN KEY([BangCap])
REFERENCES [dbo].[BangCap] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__BangCa__5FB337D6]
GO
/****** Object:  ForeignKey [FK__NhanVien__ChucVu__1FCDBCEB]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__ChucVu__1FCDBCEB] FOREIGN KEY([ChucVu])
REFERENCES [dbo].[ChucVu] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__ChucVu__1FCDBCEB]
GO
/****** Object:  ForeignKey [FK__NhanVien__ChucVu__4222D4EF]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__ChucVu__4222D4EF] FOREIGN KEY([ChucVu])
REFERENCES [dbo].[ChucVu] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__ChucVu__4222D4EF]
GO
/****** Object:  ForeignKey [FK__NhanVien__ChucVu__5070F446]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__ChucVu__5070F446] FOREIGN KEY([ChucVu])
REFERENCES [dbo].[ChucVu] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__ChucVu__5070F446]
GO
/****** Object:  ForeignKey [FK__NhanVien__ChucVu__60A75C0F]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__ChucVu__60A75C0F] FOREIGN KEY([ChucVu])
REFERENCES [dbo].[ChucVu] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__ChucVu__60A75C0F]
GO
/****** Object:  ForeignKey [FK__NhanVien__PhongB__20C1E124]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__PhongB__20C1E124] FOREIGN KEY([PhongBan])
REFERENCES [dbo].[PhongBan] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__PhongB__20C1E124]
GO
/****** Object:  ForeignKey [FK__NhanVien__PhongB__4316F928]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__PhongB__4316F928] FOREIGN KEY([PhongBan])
REFERENCES [dbo].[PhongBan] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__PhongB__4316F928]
GO
/****** Object:  ForeignKey [FK__NhanVien__PhongB__5165187F]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__PhongB__5165187F] FOREIGN KEY([PhongBan])
REFERENCES [dbo].[PhongBan] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__PhongB__5165187F]
GO
/****** Object:  ForeignKey [FK__NhanVien__PhongB__619B8048]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__NhanVien__PhongB__619B8048] FOREIGN KEY([PhongBan])
REFERENCES [dbo].[PhongBan] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK__NhanVien__PhongB__619B8048]
GO
/****** Object:  ForeignKey [FK_NhanVien_BangCap]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_BangCap] FOREIGN KEY([BangCap])
REFERENCES [dbo].[BangCap] ([ID])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_BangCap]
GO
/****** Object:  ForeignKey [FK_TienThuong_NhanVien]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[TienThuong]  WITH CHECK ADD  CONSTRAINT [FK_TienThuong_NhanVien] FOREIGN KEY([ID_NhanVien])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[TienThuong] CHECK CONSTRAINT [FK_TienThuong_NhanVien]
GO
/****** Object:  ForeignKey [FK__PhuCap_Nh__ID_Nh__21B6055D]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[PhuCap_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__PhuCap_Nh__ID_Nh__21B6055D] FOREIGN KEY([ID_NhanVien])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[PhuCap_NhanVien] CHECK CONSTRAINT [FK__PhuCap_Nh__ID_Nh__21B6055D]
GO
/****** Object:  ForeignKey [FK__PhuCap_Nh__ID_Nh__440B1D61]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[PhuCap_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__PhuCap_Nh__ID_Nh__440B1D61] FOREIGN KEY([ID_NhanVien])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[PhuCap_NhanVien] CHECK CONSTRAINT [FK__PhuCap_Nh__ID_Nh__440B1D61]
GO
/****** Object:  ForeignKey [FK__PhuCap_Nh__ID_Nh__52593CB8]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[PhuCap_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__PhuCap_Nh__ID_Nh__52593CB8] FOREIGN KEY([ID_NhanVien])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[PhuCap_NhanVien] CHECK CONSTRAINT [FK__PhuCap_Nh__ID_Nh__52593CB8]
GO
/****** Object:  ForeignKey [FK__PhuCap_Nh__ID_Nh__628FA481]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[PhuCap_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__PhuCap_Nh__ID_Nh__628FA481] FOREIGN KEY([ID_NhanVien])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[PhuCap_NhanVien] CHECK CONSTRAINT [FK__PhuCap_Nh__ID_Nh__628FA481]
GO
/****** Object:  ForeignKey [FK__PhuCap_Nh__PhuCa__22AA2996]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[PhuCap_NhanVien]  WITH CHECK ADD  CONSTRAINT [FK__PhuCap_Nh__PhuCa__22AA2996] FOREIGN KEY([PhuCap])
REFERENCES [dbo].[PhuCap] ([ID])
GO
ALTER TABLE [dbo].[PhuCap_NhanVien] CHECK CONSTRAINT [FK__PhuCap_Nh__PhuCa__22AA2996]
GO
/****** Object:  ForeignKey [FK__PhuCap_Nh__PhuCa__44FF419A]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[PhuCap_NhanVien]  WITH CHECK ADD FOREIGN KEY([PhuCap])
REFERENCES [dbo].[PhuCap] ([ID])
GO
/****** Object:  ForeignKey [FK__PhuCap_Nh__PhuCa__534D60F1]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[PhuCap_NhanVien]  WITH CHECK ADD FOREIGN KEY([PhuCap])
REFERENCES [dbo].[PhuCap] ([ID])
GO
/****** Object:  ForeignKey [FK__PhuCap_Nh__PhuCa__6383C8BA]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[PhuCap_NhanVien]  WITH CHECK ADD FOREIGN KEY([PhuCap])
REFERENCES [dbo].[PhuCap] ([ID])
GO
/****** Object:  ForeignKey [FK_ChiPhiKhac_NhanVien]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[ChiPhiKhac]  WITH CHECK ADD  CONSTRAINT [FK_ChiPhiKhac_NhanVien] FOREIGN KEY([ID_NhanVien])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[ChiPhiKhac] CHECK CONSTRAINT [FK_ChiPhiKhac_NhanVien]
GO
/****** Object:  ForeignKey [FK_LuongNhanVien_NhanVien]    Script Date: 08/29/2016 23:00:00 ******/
ALTER TABLE [dbo].[LuongNhanVien]  WITH CHECK ADD  CONSTRAINT [FK_LuongNhanVien_NhanVien] FOREIGN KEY([ID_NhanVien])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[LuongNhanVien] CHECK CONSTRAINT [FK_LuongNhanVien_NhanVien]
GO
