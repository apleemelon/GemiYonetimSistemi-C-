USE [yuk_gemisi]
GO
/****** Object:  Table [dbo].[firma]    Script Date: 14.04.2019 22:11:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[firma](
	[ad] [nchar](20) NULL,
	[serino] [varchar](50) NULL,
	[iletisim] [varchar](13) NULL,
	[ulke] [nchar](30) NULL,
	[urun] [nchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[personel]    Script Date: 14.04.2019 22:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[personel](
	[Ad] [nchar](20) NULL,
	[Soyad] [nchar](20) NULL,
	[Telefon] [varchar](13) NULL,
	[dogum_tarihi] [nvarchar](10) NULL,
	[gorev] [nchar](25) NULL,
	[cinsiyet] [nchar](5) NULL,
	[maas] [money] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[seferler]    Script Date: 14.04.2019 22:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seferler](
	[baslangıc_yeri] [nvarchar](50) NULL,
	[bitis_yeri] [nvarchar](10) NULL,
	[kalkıs_zamanı] [nvarchar](10) NULL,
	[varis_zamanı] [nvarchar](50) NULL,
	[sefer_durumu] [nchar](11) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ship]    Script Date: 14.04.2019 22:11:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ship](
	[gemiadi] [nchar](10) NULL,
	[gemiserino] [nvarchar](5) NULL,
	[gemibakimtarih] [nvarchar](20) NULL,
	[erzakteslim] [nvarchar](20) NULL,
	[temizliktarih] [nvarchar](20) NULL
) ON [PRIMARY]

GO
