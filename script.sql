USE [Otomasyon]
GO
/****** Object:  User [deneme]    Script Date: 11/28/2023 15:14:34 ******/
CREATE USER [deneme] FOR LOGIN [deneme] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[TBL_STOKLAR]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_STOKLAR](
	[STOKBARKOD] [nvarchar](50) NOT NULL,
	[STOKKODU] [nvarchar](50) NULL,
	[STOKADI] [nvarchar](50) NULL,
	[STOKBIRIM] [nvarchar](50) NULL,
	[STOKALISFIYAT] [decimal](8, 2) NULL,
	[STOKSATISFIYAT] [decimal](8, 2) NULL,
	[STOKALISKDV] [decimal](8, 2) NULL,
	[STOKSATISKDV] [decimal](8, 2) NULL,
	[STOKGRUPID] [int] NULL,
	[STOKRESIM] [image] NULL,
	[STOKSAVEUSER] [int] NULL,
	[STOKSAVEDATE] [datetime] NULL,
	[STOKEDITUSER] [int] NULL,
	[STOKEDITTIME] [datetime] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TBL_STOKLAR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_STOKLAR] ON
INSERT [dbo].[TBL_STOKLAR] ([STOKBARKOD], [STOKKODU], [STOKADI], [STOKBIRIM], [STOKALISFIYAT], [STOKSATISFIYAT], [STOKALISKDV], [STOKSATISKDV], [STOKGRUPID], [STOKRESIM], [STOKSAVEUSER], [STOKSAVEDATE], [STOKEDITUSER], [STOKEDITTIME], [ID]) VALUES (N'q', N'S000001', N'q', N'ADET', CAST(1.00 AS Decimal(8, 2)), CAST(1.00 AS Decimal(8, 2)), CAST(1.00 AS Decimal(8, 2)), CAST(1.00 AS Decimal(8, 2)), 4, NULL, 1, CAST(0x0000B0C500BA0C6D AS DateTime), NULL, NULL, 2)
INSERT [dbo].[TBL_STOKLAR] ([STOKBARKOD], [STOKKODU], [STOKADI], [STOKBIRIM], [STOKALISFIYAT], [STOKSATISFIYAT], [STOKALISKDV], [STOKSATISKDV], [STOKGRUPID], [STOKRESIM], [STOKSAVEUSER], [STOKSAVEDATE], [STOKEDITUSER], [STOKEDITTIME], [ID]) VALUES (N'222', N'S000002', N'qq', N'ADET', CAST(2.00 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), 4, NULL, 1, CAST(0x0000B0C500BEC482 AS DateTime), NULL, NULL, 3)
INSERT [dbo].[TBL_STOKLAR] ([STOKBARKOD], [STOKKODU], [STOKADI], [STOKBIRIM], [STOKALISFIYAT], [STOKSATISFIYAT], [STOKALISKDV], [STOKSATISKDV], [STOKGRUPID], [STOKRESIM], [STOKSAVEUSER], [STOKSAVEDATE], [STOKEDITUSER], [STOKEDITTIME], [ID]) VALUES (N'2121', N'S000003', N'222121', N'ADET', CAST(2.00 AS Decimal(8, 2)), CAST(22.00 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), 2, NULL, 1, CAST(0x0000B0C500C4332F AS DateTime), NULL, NULL, 4)
INSERT [dbo].[TBL_STOKLAR] ([STOKBARKOD], [STOKKODU], [STOKADI], [STOKBIRIM], [STOKALISFIYAT], [STOKSATISFIYAT], [STOKALISKDV], [STOKSATISKDV], [STOKGRUPID], [STOKRESIM], [STOKSAVEUSER], [STOKSAVEDATE], [STOKEDITUSER], [STOKEDITTIME], [ID]) VALUES (N'11', N'S000004', N'111', N'ADET', CAST(11.00 AS Decimal(8, 2)), CAST(1.00 AS Decimal(8, 2)), CAST(1.00 AS Decimal(8, 2)), CAST(1.00 AS Decimal(8, 2)), 4, NULL, 1, CAST(0x0000B0C500C4E090 AS DateTime), NULL, NULL, 5)
INSERT [dbo].[TBL_STOKLAR] ([STOKBARKOD], [STOKKODU], [STOKADI], [STOKBIRIM], [STOKALISFIYAT], [STOKSATISFIYAT], [STOKALISKDV], [STOKSATISKDV], [STOKGRUPID], [STOKRESIM], [STOKSAVEUSER], [STOKSAVEDATE], [STOKEDITUSER], [STOKEDITTIME], [ID]) VALUES (N'222', N'S000005', N'2121', N'ADET', CAST(2.00 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), CAST(2.00 AS Decimal(8, 2)), 4, NULL, 1, CAST(0x0000B0C500C65561 AS DateTime), NULL, NULL, 6)
SET IDENTITY_INSERT [dbo].[TBL_STOKLAR] OFF
/****** Object:  Table [dbo].[TBL_STOKHAREKETLERI]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_STOKHAREKETLERI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FATURAID] [int] NULL,
	[IRSALIYEID] [int] NULL,
	[STOKKODU] [nvarchar](30) NULL,
	[GCKODU] [nvarchar](1) NULL,
	[MIKTAR] [int] NULL,
	[BIRIMFIYAT] [decimal](18, 2) NULL,
	[KDV] [decimal](8, 2) NULL,
	[TIPI] [nvarchar](20) NULL,
	[SAVEUSER] [int] NULL,
	[SAVEDATE] [datetime] NULL,
	[EDITUSER] [int] NULL,
	[EDITDATE] [datetime] NULL,
 CONSTRAINT [PK_TBL_STOKHAREKETLERI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_STOKHAREKETLERI] ON
INSERT [dbo].[TBL_STOKHAREKETLERI] ([ID], [FATURAID], [IRSALIYEID], [STOKKODU], [GCKODU], [MIKTAR], [BIRIMFIYAT], [KDV], [TIPI], [SAVEUSER], [SAVEDATE], [EDITUSER], [EDITDATE]) VALUES (1, 1, 1, N'S000001', N'C', 1, CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(8, 2)), N'Satış Faturası', 1, CAST(0x0000B0C500BA1929 AS DateTime), NULL, NULL)
INSERT [dbo].[TBL_STOKHAREKETLERI] ([ID], [FATURAID], [IRSALIYEID], [STOKKODU], [GCKODU], [MIKTAR], [BIRIMFIYAT], [KDV], [TIPI], [SAVEUSER], [SAVEDATE], [EDITUSER], [EDITDATE]) VALUES (2, 2, 2, N'S000005', N'C', 1, CAST(2.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(8, 2)), N'Satış Faturası', 1, CAST(0x0000B0C500C72FEE AS DateTime), NULL, NULL)
INSERT [dbo].[TBL_STOKHAREKETLERI] ([ID], [FATURAID], [IRSALIYEID], [STOKKODU], [GCKODU], [MIKTAR], [BIRIMFIYAT], [KDV], [TIPI], [SAVEUSER], [SAVEDATE], [EDITUSER], [EDITDATE]) VALUES (3, 3, 3, N'S000004', N'C', 1, CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(8, 2)), N'Satış Faturası', 1, CAST(0x0000B0C500C79C5C AS DateTime), NULL, NULL)
INSERT [dbo].[TBL_STOKHAREKETLERI] ([ID], [FATURAID], [IRSALIYEID], [STOKKODU], [GCKODU], [MIKTAR], [BIRIMFIYAT], [KDV], [TIPI], [SAVEUSER], [SAVEDATE], [EDITUSER], [EDITDATE]) VALUES (4, 4, 4, N'S000004', N'C', 1, CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(8, 2)), N'Satış Faturası', 1, CAST(0x0000B0C500C89DFF AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBL_STOKHAREKETLERI] OFF
/****** Object:  Table [dbo].[TBL_STOKGRUPLARI]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_STOKGRUPLARI](
	[GRUPADI] [nvarchar](50) NULL,
	[GRUPKODU] [nvarchar](50) NULL,
	[GRUPSAVEUSER] [int] NULL,
	[GRUPSAVEDATE] [datetime] NULL,
	[GRUPEDITUSER] [int] NULL,
	[GRUPEDITDATE] [datetime] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TBL_STOKGRUPLARI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_STOKGRUPLARI] ON
INSERT [dbo].[TBL_STOKGRUPLARI] ([GRUPADI], [GRUPKODU], [GRUPSAVEUSER], [GRUPSAVEDATE], [GRUPEDITUSER], [GRUPEDITDATE], [ID]) VALUES (N'1', N'1', 1, CAST(0x0000B0C50089A6BF AS DateTime), NULL, NULL, 1)
INSERT [dbo].[TBL_STOKGRUPLARI] ([GRUPADI], [GRUPKODU], [GRUPSAVEUSER], [GRUPSAVEDATE], [GRUPEDITUSER], [GRUPEDITDATE], [ID]) VALUES (N'111', N'G000001', 1, CAST(0x0000B0C50094CC82 AS DateTime), NULL, NULL, 2)
INSERT [dbo].[TBL_STOKGRUPLARI] ([GRUPADI], [GRUPKODU], [GRUPSAVEUSER], [GRUPSAVEDATE], [GRUPEDITUSER], [GRUPEDITDATE], [ID]) VALUES (N'222', N'22', 1, CAST(0x0000B0C50094D08E AS DateTime), NULL, NULL, 3)
INSERT [dbo].[TBL_STOKGRUPLARI] ([GRUPADI], [GRUPKODU], [GRUPSAVEUSER], [GRUPSAVEDATE], [GRUPEDITUSER], [GRUPEDITDATE], [ID]) VALUES (N'2222', N'G000002', 1, CAST(0x0000B0C50094D3E9 AS DateTime), NULL, NULL, 4)
SET IDENTITY_INSERT [dbo].[TBL_STOKGRUPLARI] OFF
/****** Object:  Table [dbo].[TBL_KULLANICILAR]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_KULLANICILAR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KULLANICI] [nvarchar](50) NULL,
	[SIFRE] [nvarchar](50) NULL,
	[ISIM] [nvarchar](50) NULL,
	[SOYISIM] [nvarchar](50) NULL,
	[AKTIF] [bit] NULL,
	[KODU] [nvarchar](50) NULL,
	[SAVEDATE] [datetime] NULL,
	[EDITDATE] [datetime] NULL,
	[LASTLOGIN] [datetime] NULL,
 CONSTRAINT [PK_TBL_KULLANICILAR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_TBL_KULLANICILAR] UNIQUE NONCLUSTERED 
(
	[KULLANICI] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_KULLANICILAR] ON
INSERT [dbo].[TBL_KULLANICILAR] ([ID], [KULLANICI], [SIFRE], [ISIM], [SOYISIM], [AKTIF], [KODU], [SAVEDATE], [EDITDATE], [LASTLOGIN]) VALUES (1, N'1', N'1', N'1', N'1', 1, N'1', NULL, NULL, CAST(0x0000B0C5011C5FC1 AS DateTime))
SET IDENTITY_INSERT [dbo].[TBL_KULLANICILAR] OFF
/****** Object:  Table [dbo].[TBL_KASALAR]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_KASALAR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KASAKODU] [nvarchar](50) NULL,
	[KASAADI] [nvarchar](50) NULL,
	[ACIKLAMA] [text] NULL,
	[SAVEDATE] [datetime] NULL,
	[SAVEUSER] [int] NULL,
	[EDITDATE] [datetime] NULL,
	[EDITUSER] [int] NULL,
 CONSTRAINT [PK_TBL_KASALAR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_KASALAR] ON
INSERT [dbo].[TBL_KASALAR] ([ID], [KASAKODU], [KASAADI], [ACIKLAMA], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (1, N'K000001', N'111', N'111', CAST(0x0000B0C5009FBC68 AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBL_KASALAR] OFF
/****** Object:  Table [dbo].[TBL_KASAHAREKETLERI]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_KASAHAREKETLERI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[KASAID] [int] NULL,
	[BELGENO] [nvarchar](50) NULL,
	[TARIH] [datetime] NULL,
	[EVRAKTURU] [nvarchar](50) NULL,
	[EVRAKID] [int] NULL,
	[GCKODU] [nvarchar](50) NULL,
	[TUTAR] [decimal](18, 2) NULL,
	[CARIID] [int] NULL,
	[ACIKLAMA] [text] NULL,
	[SAVEDATE] [datetime] NULL,
	[SAVEUSER] [int] NULL,
	[EDITDATE] [datetime] NULL,
	[EDITUSER] [int] NULL,
 CONSTRAINT [PK_TBL_KASAHAREKETLERI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_KASAHAREKETLERI] ON
INSERT [dbo].[TBL_KASAHAREKETLERI] ([ID], [KASAID], [BELGENO], [TARIH], [EVRAKTURU], [EVRAKID], [GCKODU], [TUTAR], [CARIID], [ACIKLAMA], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (1, 1, N'H000001', CAST(0x0000B0C500000000 AS DateTime), N'Kasa Devir Kartı', NULL, N'G', CAST(250.00 AS Decimal(18, 2)), NULL, N'deneme', CAST(0x0000B0C500AFBC52 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[TBL_KASAHAREKETLERI] ([ID], [KASAID], [BELGENO], [TARIH], [EVRAKTURU], [EVRAKID], [GCKODU], [TUTAR], [CARIID], [ACIKLAMA], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (2, 1, N'H000002', CAST(0x0000B0C500000000 AS DateTime), N'Kasa Tahsilat', NULL, N'G', CAST(150.00 AS Decimal(18, 2)), 8, N'11', CAST(0x0000B0C500AFF427 AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBL_KASAHAREKETLERI] OFF
/****** Object:  Table [dbo].[TBL_IRSALIYELER]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_IRSALIYELER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IRSALIYESERI] [nvarchar](25) NULL,
	[IRSALIYENO] [nvarchar](15) NULL,
	[IRSALIYEID] [int] NULL,
	[FATURAID] [int] NULL,
	[CARIKODU] [nvarchar](30) NULL,
	[TARIHI] [datetime] NULL,
	[ACIKLAMA] [text] NULL,
	[SAVEUSER] [int] NULL,
	[SAVEDATE] [datetime] NULL,
	[EDITUSER] [int] NULL,
	[EDITDATE] [datetime] NULL,
 CONSTRAINT [PK_TBLIRSALIYELER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_IRSALIYELER] ON
INSERT [dbo].[TBL_IRSALIYELER] ([ID], [IRSALIYESERI], [IRSALIYENO], [IRSALIYEID], [FATURAID], [CARIKODU], [TARIHI], [ACIKLAMA], [SAVEUSER], [SAVEDATE], [EDITUSER], [EDITDATE]) VALUES (1, NULL, N'I000001', NULL, 1, N'C000001', CAST(0x0000B0C500000000 AS DateTime), N'', 1, CAST(0x0000B0C500BA1922 AS DateTime), NULL, NULL)
INSERT [dbo].[TBL_IRSALIYELER] ([ID], [IRSALIYESERI], [IRSALIYENO], [IRSALIYEID], [FATURAID], [CARIKODU], [TARIHI], [ACIKLAMA], [SAVEUSER], [SAVEDATE], [EDITUSER], [EDITDATE]) VALUES (2, NULL, N'I000002', NULL, 2, N'C000005', CAST(0x0000B0C500000000 AS DateTime), N'', 1, CAST(0x0000B0C500C72FE7 AS DateTime), NULL, NULL)
INSERT [dbo].[TBL_IRSALIYELER] ([ID], [IRSALIYESERI], [IRSALIYENO], [IRSALIYEID], [FATURAID], [CARIKODU], [TARIHI], [ACIKLAMA], [SAVEUSER], [SAVEDATE], [EDITUSER], [EDITDATE]) VALUES (3, NULL, N'I000003', NULL, 3, N'C000005', CAST(0x0000B0C500000000 AS DateTime), N'', 1, CAST(0x0000B0C500C79C53 AS DateTime), NULL, NULL)
INSERT [dbo].[TBL_IRSALIYELER] ([ID], [IRSALIYESERI], [IRSALIYENO], [IRSALIYEID], [FATURAID], [CARIKODU], [TARIHI], [ACIKLAMA], [SAVEUSER], [SAVEDATE], [EDITUSER], [EDITDATE]) VALUES (4, NULL, N'I000004', NULL, 4, N'C000005', CAST(0x0000B0C500000000 AS DateTime), N'', 1, CAST(0x0000B0C500C89DF8 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBL_IRSALIYELER] OFF
/****** Object:  Table [dbo].[TBL_FATURALAR]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_FATURALAR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FATURATURU] [nvarchar](25) NULL,
	[FATURASERI] [nvarchar](5) NULL,
	[FATURANO] [nvarchar](15) NULL,
	[IRSALIYEID] [int] NULL,
	[CARIKODU] [nvarchar](30) NULL,
	[TARIHI] [datetime] NULL,
	[ACIKLAMA] [text] NULL,
	[GENELTOPLAM] [decimal](18, 2) NULL,
	[ODEMEYERI] [nvarchar](10) NULL,
	[ODEMEYERIID] [int] NULL,
	[SAVEUSER] [int] NULL,
	[SAVEDATE] [datetime] NULL,
	[EDITUSER] [int] NULL,
	[EDITDATE] [datetime] NULL,
 CONSTRAINT [PK_TBLFATURALAR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_FATURALAR] ON
INSERT [dbo].[TBL_FATURALAR] ([ID], [FATURATURU], [FATURASERI], [FATURANO], [IRSALIYEID], [CARIKODU], [TARIHI], [ACIKLAMA], [GENELTOPLAM], [ODEMEYERI], [ODEMEYERIID], [SAVEUSER], [SAVEDATE], [EDITUSER], [EDITDATE]) VALUES (1, N'Satış Faturası', NULL, N'F000001', 1, N'C000001', CAST(0x0000B0C500000000 AS DateTime), N'', CAST(1.01 AS Decimal(18, 2)), N'', -1, 1, CAST(0x0000B0C500BA191E AS DateTime), NULL, NULL)
INSERT [dbo].[TBL_FATURALAR] ([ID], [FATURATURU], [FATURASERI], [FATURANO], [IRSALIYEID], [CARIKODU], [TARIHI], [ACIKLAMA], [GENELTOPLAM], [ODEMEYERI], [ODEMEYERIID], [SAVEUSER], [SAVEDATE], [EDITUSER], [EDITDATE]) VALUES (2, N'Satış Faturası', NULL, N'F000002', 2, N'C000005', CAST(0x0000B0C500000000 AS DateTime), N'', CAST(2.04 AS Decimal(18, 2)), N'', -1, 1, CAST(0x0000B0C500C72FD6 AS DateTime), NULL, NULL)
INSERT [dbo].[TBL_FATURALAR] ([ID], [FATURATURU], [FATURASERI], [FATURANO], [IRSALIYEID], [CARIKODU], [TARIHI], [ACIKLAMA], [GENELTOPLAM], [ODEMEYERI], [ODEMEYERIID], [SAVEUSER], [SAVEDATE], [EDITUSER], [EDITDATE]) VALUES (3, N'Satış Faturası', NULL, N'F000003', 3, N'C000005', CAST(0x0000B0C500000000 AS DateTime), N'', CAST(1.01 AS Decimal(18, 2)), N'', -1, 1, CAST(0x0000B0C500C79C42 AS DateTime), NULL, NULL)
INSERT [dbo].[TBL_FATURALAR] ([ID], [FATURATURU], [FATURASERI], [FATURANO], [IRSALIYEID], [CARIKODU], [TARIHI], [ACIKLAMA], [GENELTOPLAM], [ODEMEYERI], [ODEMEYERIID], [SAVEUSER], [SAVEDATE], [EDITUSER], [EDITDATE]) VALUES (4, N'Satış Faturası', NULL, N'F000004', 4, N'C000005', CAST(0x0000B0C500000000 AS DateTime), N'', CAST(1.01 AS Decimal(18, 2)), N'', -1, 1, CAST(0x0000B0C500C89DE7 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBL_FATURALAR] OFF
/****** Object:  Table [dbo].[TBL_CEKLER]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_CEKLER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BELGENO] [nvarchar](50) NULL,
	[CEKNO] [nvarchar](50) NULL,
	[TIPI] [nvarchar](50) NULL,
	[ASILBORCLU] [nvarchar](50) NULL,
	[ALINANCARIID] [int] NULL,
	[VERILENCARIID] [int] NULL,
	[ACKODU] [nvarchar](50) NULL,
	[VADETARIHI] [datetime] NULL,
	[BANKA] [nvarchar](50) NULL,
	[SUBE] [nvarchar](50) NULL,
	[HESAPNO] [nvarchar](50) NULL,
	[TUTAR] [decimal](18, 2) NULL,
	[ACIKLAMA] [text] NULL,
	[VERILENBANKA_TARIHI] [datetime] NULL,
	[VERILENBANKA_BELGENO] [nvarchar](50) NULL,
	[VERILENCARI_TARIHI] [datetime] NULL,
	[VERILENCARI_BELGENO] [nvarchar](50) NULL,
	[VERILENBANKAID] [int] NULL,
	[DURUMU] [nvarchar](50) NULL,
	[TAHSIL] [nvarchar](50) NULL,
	[BORDROID] [int] NULL,
	[TARIH] [datetime] NULL,
	[SAVEUSER] [int] NULL,
	[SAVEDATE] [datetime] NULL,
	[EDITUSER] [int] NULL,
	[EDITDATE] [datetime] NULL,
 CONSTRAINT [PK_TBL_CEKLER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_CEKLER] ON
INSERT [dbo].[TBL_CEKLER] ([ID], [BELGENO], [CEKNO], [TIPI], [ASILBORCLU], [ALINANCARIID], [VERILENCARIID], [ACKODU], [VADETARIHI], [BANKA], [SUBE], [HESAPNO], [TUTAR], [ACIKLAMA], [VERILENBANKA_TARIHI], [VERILENBANKA_BELGENO], [VERILENCARI_TARIHI], [VERILENCARI_BELGENO], [VERILENBANKAID], [DURUMU], [TAHSIL], [BORDROID], [TARIH], [SAVEUSER], [SAVEDATE], [EDITUSER], [EDITDATE]) VALUES (1, N'C000001', N'1', N'Kendi Çekimiz', NULL, NULL, NULL, N'A', CAST(0x0000B0C500000000 AS DateTime), N'111', N'11', N'111', CAST(1.00 AS Decimal(18, 2)), N'1', NULL, NULL, NULL, NULL, NULL, N'Portföy', N'Hayır', NULL, CAST(0x0000B0C5011C6F06 AS DateTime), 1, CAST(0x0000B0C5011C6F06 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBL_CEKLER] OFF
/****** Object:  Table [dbo].[TBL_CARILER]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_CARILER](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CARIKODU] [nvarchar](50) NULL,
	[CARIADI] [nvarchar](50) NULL,
	[VERGIDAIRESI] [nvarchar](50) NULL,
	[VERGINO] [nvarchar](50) NULL,
	[GRUPID] [int] NULL,
	[ULKE] [nvarchar](50) NULL,
	[SEHIR] [nvarchar](50) NULL,
	[ILCE] [nvarchar](50) NULL,
	[ADRES] [text] NULL,
	[TELEFON1] [nvarchar](50) NULL,
	[TELEFON2] [nvarchar](50) NULL,
	[FAX1] [nvarchar](50) NULL,
	[FAX2] [nvarchar](50) NULL,
	[WEBADRES] [nvarchar](50) NULL,
	[MAILINFO] [nvarchar](50) NULL,
	[YETKILI1] [nvarchar](50) NULL,
	[YETKILIMAIL1] [nvarchar](50) NULL,
	[YETKILI2] [nvarchar](50) NULL,
	[YETKILIMAIL2] [nvarchar](50) NULL,
	[SAVEDATE] [datetime] NULL,
	[SAVEUSER] [int] NULL,
	[EDITDATE] [datetime] NULL,
	[EDITUSER] [int] NULL,
 CONSTRAINT [PK_TBL_CARILER] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_CARILER] ON
INSERT [dbo].[TBL_CARILER] ([ID], [CARIKODU], [CARIADI], [VERGIDAIRESI], [VERGINO], [GRUPID], [ULKE], [SEHIR], [ILCE], [ADRES], [TELEFON1], [TELEFON2], [FAX1], [FAX2], [WEBADRES], [MAILINFO], [YETKILI1], [YETKILIMAIL1], [YETKILI2], [YETKILIMAIL2], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (1, N'C000001', N'1', N'1', N'1', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', CAST(0x0000B0C50088F389 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[TBL_CARILER] ([ID], [CARIKODU], [CARIADI], [VERGIDAIRESI], [VERGINO], [GRUPID], [ULKE], [SEHIR], [ILCE], [ADRES], [TELEFON1], [TELEFON2], [FAX1], [FAX2], [WEBADRES], [MAILINFO], [YETKILI1], [YETKILIMAIL1], [YETKILI2], [YETKILIMAIL2], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (2, N'C000002', N'12222', N'222', N'2222', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', CAST(0x0000B0C50089301A AS DateTime), 1, NULL, NULL)
INSERT [dbo].[TBL_CARILER] ([ID], [CARIKODU], [CARIADI], [VERGIDAIRESI], [VERGINO], [GRUPID], [ULKE], [SEHIR], [ILCE], [ADRES], [TELEFON1], [TELEFON2], [FAX1], [FAX2], [WEBADRES], [MAILINFO], [YETKILI1], [YETKILIMAIL1], [YETKILI2], [YETKILIMAIL2], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (3, N'C000003', N'22', N'323214', N'4312432', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', CAST(0x0000B0C500898538 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[TBL_CARILER] ([ID], [CARIKODU], [CARIADI], [VERGIDAIRESI], [VERGINO], [GRUPID], [ULKE], [SEHIR], [ILCE], [ADRES], [TELEFON1], [TELEFON2], [FAX1], [FAX2], [WEBADRES], [MAILINFO], [YETKILI1], [YETKILIMAIL1], [YETKILI2], [YETKILIMAIL2], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (4, N'C000004', N'32', N'', N'', 1, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', CAST(0x0000B0C5008A6689 AS DateTime), 1, CAST(0x0000B0C500ACD813 AS DateTime), 1)
INSERT [dbo].[TBL_CARILER] ([ID], [CARIKODU], [CARIADI], [VERGIDAIRESI], [VERGINO], [GRUPID], [ULKE], [SEHIR], [ILCE], [ADRES], [TELEFON1], [TELEFON2], [FAX1], [FAX2], [WEBADRES], [MAILINFO], [YETKILI1], [YETKILIMAIL1], [YETKILI2], [YETKILIMAIL2], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (8, N'C000005', N'11', N'11', N'11111111111', 2, N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', N'', CAST(0x0000B0C500ACCEDC AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBL_CARILER] OFF
/****** Object:  Table [dbo].[TBL_CARIHAREKETLERI]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_CARIHAREKETLERI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CARIID] [int] NULL,
	[EVRAKTURU] [nvarchar](50) NULL,
	[EVRAKID] [int] NULL,
	[BORC] [decimal](18, 2) NULL,
	[ALACAK] [decimal](18, 2) NULL,
	[ACIKLAMA] [text] NULL,
	[TARIH] [datetime] NULL,
	[TIPI] [nvarchar](50) NULL,
	[SAVEDATE] [datetime] NULL,
	[SAVEUSER] [int] NULL,
	[EDITDATE] [datetime] NULL,
	[EDITUSER] [int] NULL,
 CONSTRAINT [PK_TBL_CARIHAREKETLERI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_CARIHAREKETLERI] ON
INSERT [dbo].[TBL_CARIHAREKETLERI] ([ID], [CARIID], [EVRAKTURU], [EVRAKID], [BORC], [ALACAK], [ACIKLAMA], [TARIH], [TIPI], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (1, 8, N'Kasa Tahsilat', 2, CAST(150.00 AS Decimal(18, 2)), NULL, N'H000002Belge NumarasıKasa Tahsilat İşlemi', CAST(0x0000B0C500AFF42F AS DateTime), N'KT', CAST(0x0000B0C500AFF430 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[TBL_CARIHAREKETLERI] ([ID], [CARIID], [EVRAKTURU], [EVRAKID], [BORC], [ALACAK], [ACIKLAMA], [TARIH], [TIPI], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (2, 1, N'Satış Faturası', 1, CAST(1.01 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'F000001No '' lu Satış Faturası', CAST(0x0000B0C500BA1931 AS DateTime), N'SF', CAST(0x0000B0C500BA1931 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[TBL_CARIHAREKETLERI] ([ID], [CARIID], [EVRAKTURU], [EVRAKID], [BORC], [ALACAK], [ACIKLAMA], [TARIH], [TIPI], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (3, 8, N'Satış Faturası', 2, CAST(2.04 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'F000002No '' lu Satış Faturası', CAST(0x0000B0C500C72FF5 AS DateTime), N'SF', CAST(0x0000B0C500C72FF5 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[TBL_CARIHAREKETLERI] ([ID], [CARIID], [EVRAKTURU], [EVRAKID], [BORC], [ALACAK], [ACIKLAMA], [TARIH], [TIPI], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (4, 8, N'Satış Faturası', 3, CAST(1.01 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'F000003No '' lu Satış Faturası', CAST(0x0000B0C500C79C61 AS DateTime), N'SF', CAST(0x0000B0C500C79C62 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[TBL_CARIHAREKETLERI] ([ID], [CARIID], [EVRAKTURU], [EVRAKID], [BORC], [ALACAK], [ACIKLAMA], [TARIH], [TIPI], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (5, 8, N'Satış Faturası', 4, CAST(1.01 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), N'F000004No '' lu Satış Faturası', CAST(0x0000B0C500C89E05 AS DateTime), N'SF', CAST(0x0000B0C500C89E05 AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBL_CARIHAREKETLERI] OFF
/****** Object:  Table [dbo].[TBL_CARIGRUPLARI]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_CARIGRUPLARI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[GRUPADI] [nvarchar](50) NULL,
	[GRUPKODU] [nvarchar](50) NULL,
	[SAVEDATE] [datetime] NULL,
	[SAVEUSER] [int] NULL,
	[EDITDATE] [datetime] NULL,
	[EDITUSER] [int] NULL,
 CONSTRAINT [PK_TBL_CARIGRUPLARI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_CARIGRUPLARI] ON
INSERT [dbo].[TBL_CARIGRUPLARI] ([ID], [GRUPADI], [GRUPKODU], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (1, N'1', N'1', CAST(0x0000B0C50088EB31 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[TBL_CARIGRUPLARI] ([ID], [GRUPADI], [GRUPKODU], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (2, N'2222', N'G000001', CAST(0x0000B0C500935D90 AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBL_CARIGRUPLARI] OFF
/****** Object:  Table [dbo].[TBL_BORDROLAR]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_BORDROLAR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NUMARA] [nvarchar](50) NULL,
	[CARIID] [int] NULL,
	[TARIH] [datetime] NULL,
	[ACIKLAMA] [text] NULL,
	[SAVEUSER] [int] NULL,
	[SAVEDATE] [datetime] NULL,
	[EDITUSER] [int] NULL,
	[EDITDATE] [datetime] NULL,
 CONSTRAINT [PK_TBL_BORDROLAR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_BANKALAR]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_BANKALAR](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HESAPNO] [nvarchar](50) NULL,
	[IBAN] [nvarchar](50) NULL,
	[BANKAADI] [nvarchar](50) NULL,
	[HESAPADI] [nvarchar](50) NULL,
	[SUBE] [nvarchar](50) NULL,
	[TEL] [nvarchar](50) NULL,
	[ADRES] [text] NULL,
	[TEMSILCI] [nvarchar](50) NULL,
	[TEMSILCIEMAIL] [nvarchar](150) NULL,
	[SAVEDATE] [datetime] NULL,
	[SAVEUSER] [int] NULL,
	[EDITDATE] [datetime] NULL,
	[EDITUSER] [int] NULL,
 CONSTRAINT [PK_TBL_BANKALAR] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_BANKALAR] ON
INSERT [dbo].[TBL_BANKALAR] ([ID], [HESAPNO], [IBAN], [BANKAADI], [HESAPADI], [SUBE], [TEL], [ADRES], [TEMSILCI], [TEMSILCIEMAIL], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (1, N'123456', N'TR123456', N'VAKIFBANK', N'VADESİZ', N'RİZEŞB', N'04642132002', N'Merkez', N'ADEM', N'adem@gmai.com', CAST(0x0000B0C5009BA46C AS DateTime), 1, NULL, NULL)
INSERT [dbo].[TBL_BANKALAR] ([ID], [HESAPNO], [IBAN], [BANKAADI], [HESAPADI], [SUBE], [TEL], [ADRES], [TEMSILCI], [TEMSILCIEMAIL], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (2, N'111', N'111', N'111', N'111', N'11', N'11', N'11', N'111', N'111', CAST(0x0000B0C500B43993 AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBL_BANKALAR] OFF
/****** Object:  Table [dbo].[TBL_BANKAHAREKETLERI]    Script Date: 11/28/2023 15:14:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_BANKAHAREKETLERI](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BANKAID] [int] NULL,
	[CARIID] [int] NULL,
	[BELGENO] [nvarchar](50) NULL,
	[TARIH] [datetime] NULL,
	[EVRAKTURU] [nvarchar](50) NULL,
	[EVRAKID] [int] NULL,
	[GCKODU] [nvarchar](50) NULL,
	[TUTAR] [decimal](18, 2) NULL,
	[ACIKLAMA] [text] NULL,
	[SAVEDATE] [datetime] NULL,
	[SAVEUSER] [int] NULL,
	[EDITDATE] [datetime] NULL,
	[EDITUSER] [int] NULL,
 CONSTRAINT [PK_TBL_BANKAHAREKETLERI] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_BANKAHAREKETLERI] ON
INSERT [dbo].[TBL_BANKAHAREKETLERI] ([ID], [BANKAID], [CARIID], [BELGENO], [TARIH], [EVRAKTURU], [EVRAKID], [GCKODU], [TUTAR], [ACIKLAMA], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (1, 1, NULL, N'B000001', CAST(0x0000B0C500000000 AS DateTime), N'Banka İslem', NULL, N'G', CAST(250.00 AS Decimal(18, 2)), N'de', CAST(0x0000B0C5009BB0B4 AS DateTime), 1, NULL, NULL)
INSERT [dbo].[TBL_BANKAHAREKETLERI] ([ID], [BANKAID], [CARIID], [BELGENO], [TARIH], [EVRAKTURU], [EVRAKID], [GCKODU], [TUTAR], [ACIKLAMA], [SAVEDATE], [SAVEUSER], [EDITDATE], [EDITUSER]) VALUES (2, 2, NULL, N'C000001', CAST(0x0000B0C5011C6F5B AS DateTime), N'Kendi Çekimiz', 1, N'C', CAST(1.00 AS Decimal(18, 2)), N'1Numaralı ve 25.11.2023Vadeli Kendi Çekimiz', CAST(0x0000B0C5011C6F5B AS DateTime), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TBL_BANKAHAREKETLERI] OFF
/****** Object:  View [dbo].[VW_KASAHAREKETLERI]    Script Date: 11/28/2023 15:14:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_KASAHAREKETLERI]
AS
SELECT     dbo.TBL_KASAHAREKETLERI.ID, dbo.TBL_KASAHAREKETLERI.KASAID, dbo.TBL_KASAHAREKETLERI.CARIID, dbo.TBL_KASALAR.KASAKODU, dbo.TBL_KASALAR.KASAADI, 
                      dbo.TBL_CARILER.CARIKODU, dbo.TBL_CARILER.CARIADI, dbo.TBL_KASAHAREKETLERI.BELGENO, dbo.TBL_KASAHAREKETLERI.EVRAKTURU, dbo.TBL_KASAHAREKETLERI.EVRAKID, 
                      dbo.TBL_KASAHAREKETLERI.TARIH, (CASE WHEN dbo.TBL_KASAHAREKETLERI.GCKODU = 'G' THEN dbo.TBL_KASAHAREKETLERI.TUTAR ELSE 0 END) AS GIRIS, 
                      (CASE WHEN dbo.TBL_KASAHAREKETLERI.GCKODU = 'C' THEN dbo.TBL_KASAHAREKETLERI.TUTAR ELSE 0 END) AS CIKIS, dbo.TBL_KASAHAREKETLERI.ACIKLAMA
FROM         dbo.TBL_KASAHAREKETLERI LEFT OUTER JOIN
                      dbo.TBL_KASALAR ON dbo.TBL_KASAHAREKETLERI.KASAID = dbo.TBL_KASALAR.ID LEFT OUTER JOIN
                      dbo.TBL_CARILER ON dbo.TBL_KASAHAREKETLERI.CARIID = dbo.TBL_CARILER.ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_KASAHAREKETLERI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 188
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TBL_KASALAR"
            Begin Extent = 
               Top = 0
               Left = 430
               Bottom = 120
               Right = 590
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TBL_CARILER"
            Begin Extent = 
               Top = 53
               Left = 670
               Bottom = 173
               Right = 830
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 15
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_KASAHAREKETLERI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_KASAHAREKETLERI'
GO
/****** Object:  View [dbo].[VW_KASADURUM]    Script Date: 11/28/2023 15:14:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_KASADURUM]
AS
SELECT     KASAID, SUM(CASE WHEN GCKODU = 'G' THEN TUTAR ELSE 0 END) AS GIRIS, SUM(CASE WHEN GCKODU = 'C' THEN TUTAR ELSE 0 END) AS CIKIS, 
                      SUM(CASE WHEN GCKODU = 'G' THEN TUTAR ELSE 0 END) - SUM(CASE WHEN GCKODU = 'C' THEN TUTAR ELSE 0 END) AS BAKIYE
FROM         dbo.TBL_KASAHAREKETLERI
GROUP BY KASAID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[21] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_KASAHAREKETLERI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 212
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_KASADURUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_KASADURUM'
GO
/****** Object:  View [dbo].[VW_KALEMLER]    Script Date: 11/28/2023 15:14:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_KALEMLER]
AS
SELECT     dbo.TBL_STOKHAREKETLERI.ID, dbo.TBL_STOKLAR.ID AS STOKID, dbo.TBL_STOKHAREKETLERI.FATURAID, dbo.TBL_STOKHAREKETLERI.IRSALIYEID, dbo.TBL_STOKLAR.STOKKODU, 
                      dbo.TBL_STOKLAR.STOKADI, dbo.TBL_STOKLAR.STOKBARKOD, dbo.TBL_STOKLAR.STOKBIRIM, dbo.TBL_STOKHAREKETLERI.BIRIMFIYAT, dbo.TBL_STOKHAREKETLERI.KDV, 
                      dbo.TBL_STOKHAREKETLERI.MIKTAR, dbo.TBL_STOKHAREKETLERI.MIKTAR * dbo.TBL_STOKHAREKETLERI.BIRIMFIYAT AS TOPLAM
FROM         dbo.TBL_STOKHAREKETLERI LEFT OUTER JOIN
                      dbo.TBL_STOKLAR ON dbo.TBL_STOKHAREKETLERI.STOKKODU = dbo.TBL_STOKLAR.STOKKODU
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[40] 2[1] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_STOKHAREKETLERI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 171
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TBL_STOKLAR"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 125
               Right = 409
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 13
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_KALEMLER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_KALEMLER'
GO
/****** Object:  View [dbo].[VW_DENEME]    Script Date: 11/28/2023 15:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_DENEME]
AS
SELECT     dbo.TBL_STOKLAR.STOKBARKOD, dbo.TBL_STOKLAR.STOKKODU, dbo.TBL_STOKLAR.STOKADI, dbo.TBL_STOKLAR.STOKBIRIM, dbo.TBL_STOKLAR.STOKALISFIYAT, 
                      dbo.TBL_STOKLAR.STOKSATISFIYAT, dbo.TBL_STOKLAR.STOKALISKDV, dbo.TBL_STOKLAR.STOKSATISKDV, dbo.TBL_STOKLAR.STOKGRUPID, dbo.TBL_STOKLAR.STOKRESIM, 
                      dbo.TBL_STOKLAR.STOKSAVEUSER, dbo.TBL_STOKLAR.STOKSAVEDATE, dbo.TBL_STOKLAR.STOKEDITUSER, dbo.TBL_STOKLAR.STOKEDITTIME, dbo.TBL_STOKLAR.ID, 
                      ISNULL(dbo.TBL_STOKHAREKETLERI.ID, N'') AS HAREKETID
FROM         dbo.TBL_STOKLAR LEFT OUTER JOIN
                      dbo.TBL_STOKHAREKETLERI ON dbo.TBL_STOKLAR.STOKKODU = dbo.TBL_STOKHAREKETLERI.STOKKODU
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_STOKLAR"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 197
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TBL_STOKHAREKETLERI"
            Begin Extent = 
               Top = 7
               Left = 414
               Bottom = 193
               Right = 574
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 17
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_DENEME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_DENEME'
GO
/****** Object:  View [dbo].[VW_CARILER]    Script Date: 11/28/2023 15:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_CARILER]
AS
SELECT     dbo.TBL_CARILER.*
FROM         dbo.TBL_CARILER
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_CARILER"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 25
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_CARILER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_CARILER'
GO
/****** Object:  View [dbo].[VW_CARIHAREKET]    Script Date: 11/28/2023 15:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_CARIHAREKET]
AS
SELECT     ISNULL(SUM(BORC), 0) AS BORC, ISNULL(SUM(ALACAK), 0) AS ALACAK, ISNULL(SUM(BORC), 0) - ISNULL(SUM(ALACAK), 0) AS BAKIYE, CARIID
FROM         dbo.TBL_CARIHAREKETLERI
GROUP BY CARIID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_CARIHAREKETLERI"
            Begin Extent = 
               Top = 61
               Left = 27
               Bottom = 181
               Right = 187
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 12
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_CARIHAREKET'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_CARIHAREKET'
GO
/****** Object:  View [dbo].[VW_STOKHAREKETLERI]    Script Date: 11/28/2023 15:14:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_STOKHAREKETLERI]
AS
SELECT     (CASE WHEN dbo.TBL_STOKHAREKETLERI.GCKODU = 'G' THEN dbo.TBL_STOKHAREKETLERI.MIKTAR ELSE 0 END) AS GIRIS, 
                      (CASE WHEN dbo.TBL_STOKHAREKETLERI.GCKODU = 'C' THEN dbo.TBL_STOKHAREKETLERI.MIKTAR ELSE 0 END) AS CIKIS, dbo.TBL_STOKHAREKETLERI.STOKKODU, 
                      dbo.TBL_STOKHAREKETLERI.FATURAID, dbo.TBL_STOKHAREKETLERI.TIPI, dbo.TBL_STOKLAR.STOKADI, dbo.TBL_STOKLAR.ID, dbo.TBL_FATURALAR.FATURANO, 
                      dbo.TBL_IRSALIYELER.IRSALIYENO, dbo.TBL_STOKHAREKETLERI.IRSALIYEID
FROM         dbo.TBL_STOKHAREKETLERI INNER JOIN
                      dbo.TBL_STOKLAR ON dbo.TBL_STOKHAREKETLERI.STOKKODU = dbo.TBL_STOKLAR.STOKKODU INNER JOIN
                      dbo.TBL_IRSALIYELER ON dbo.TBL_STOKHAREKETLERI.IRSALIYEID = dbo.TBL_IRSALIYELER.ID LEFT OUTER JOIN
                      dbo.TBL_FATURALAR ON dbo.TBL_STOKHAREKETLERI.FATURAID = dbo.TBL_FATURALAR.ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_STOKHAREKETLERI"
            Begin Extent = 
               Top = 5
               Left = 175
               Bottom = 207
               Right = 335
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TBL_STOKLAR"
            Begin Extent = 
               Top = 143
               Left = 356
               Bottom = 346
               Right = 529
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TBL_IRSALIYELER"
            Begin Extent = 
               Top = 126
               Left = 615
               Bottom = 246
               Right = 775
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "TBL_FATURALAR"
            Begin Extent = 
               Top = 6
               Left = 721
               Bottom = 126
               Right = 881
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 11
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_STOKHAREKETLERI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_STOKHAREKETLERI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_STOKHAREKETLERI'
GO
/****** Object:  View [dbo].[VW_STOKDURUM]    Script Date: 11/28/2023 15:14:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_STOKDURUM]
AS
SELECT     SUM(CASE WHEN GCKODU = 'G' THEN MIKTAR ELSE 0 END) AS GIRIS, SUM(CASE WHEN GCKODU = 'C' THEN MIKTAR ELSE 0 END) AS CIKIS, 
                      SUM(CASE WHEN GCKODU = 'G' THEN MIKTAR ELSE 0 END) - SUM(CASE WHEN GCKODU = 'C' THEN MIKTAR ELSE 0 END) AS BAKIYE, dbo.TBL_STOKLAR.ID, dbo.TBL_STOKLAR.STOKKODU, 
                      dbo.TBL_STOKLAR.STOKADI, dbo.TBL_STOKLAR.STOKBARKOD
FROM         dbo.TBL_STOKHAREKETLERI FULL OUTER JOIN
                      dbo.TBL_STOKLAR ON dbo.TBL_STOKHAREKETLERI.STOKKODU = dbo.TBL_STOKLAR.STOKKODU
GROUP BY dbo.TBL_STOKLAR.ID, dbo.TBL_STOKLAR.STOKKODU, dbo.TBL_STOKLAR.STOKADI, dbo.TBL_STOKLAR.STOKBARKOD
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_STOKHAREKETLERI"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 213
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TBL_STOKLAR"
            Begin Extent = 
               Top = 94
               Left = 505
               Bottom = 273
               Right = 694
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 11
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_STOKDURUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_STOKDURUM'
GO
/****** Object:  View [dbo].[VW_SORGUCARIGRUP]    Script Date: 11/28/2023 15:14:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_SORGUCARIGRUP]
AS
SELECT     dbo.TBL_CARIGRUPLARI.GRUPADI, dbo.TBL_CARIGRUPLARI.GRUPKODU, dbo.TBL_CARIGRUPLARI.ID, ISNULL(dbo.TBL_CARILER.GRUPID, '0') AS GRUPID
FROM         dbo.TBL_CARILER RIGHT OUTER JOIN
                      dbo.TBL_CARIGRUPLARI ON dbo.TBL_CARILER.GRUPID = dbo.TBL_CARIGRUPLARI.ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_CARILER"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "TBL_CARIGRUPLARI"
            Begin Extent = 
               Top = 48
               Left = 501
               Bottom = 168
               Right = 661
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_SORGUCARIGRUP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_SORGUCARIGRUP'
GO
/****** Object:  View [dbo].[VW_SORGU]    Script Date: 11/28/2023 15:14:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_SORGU]
AS
SELECT     ISNULL(dbo.TBL_STOKLAR.STOKGRUPID, '0') AS STOKGRUPID, dbo.TBL_STOKGRUPLARI.GRUPADI, dbo.TBL_STOKGRUPLARI.GRUPKODU, dbo.TBL_STOKGRUPLARI.ID
FROM         dbo.TBL_STOKLAR RIGHT OUTER JOIN
                      dbo.TBL_STOKGRUPLARI ON dbo.TBL_STOKLAR.STOKGRUPID = dbo.TBL_STOKGRUPLARI.ID
GROUP BY dbo.TBL_STOKLAR.STOKGRUPID, dbo.TBL_STOKGRUPLARI.GRUPADI, dbo.TBL_STOKGRUPLARI.GRUPKODU, dbo.TBL_STOKGRUPLARI.ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_STOKLAR"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "TBL_STOKGRUPLARI"
            Begin Extent = 
               Top = 18
               Left = 384
               Bottom = 138
               Right = 551
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_SORGU'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_SORGU'
GO
/****** Object:  View [dbo].[VW_BANKAHAREKETLERI]    Script Date: 11/28/2023 15:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_BANKAHAREKETLERI]
AS
SELECT     dbo.TBL_BANKAHAREKETLERI.ID, dbo.TBL_BANKAHAREKETLERI.BANKAID, dbo.TBL_BANKAHAREKETLERI.CARIID, dbo.TBL_BANKAHAREKETLERI.BELGENO, 
                      dbo.TBL_BANKAHAREKETLERI.TARIH, dbo.TBL_BANKAHAREKETLERI.EVRAKTURU, dbo.TBL_BANKAHAREKETLERI.ACIKLAMA, dbo.TBL_BANKAHAREKETLERI.EVRAKID, 
                      (CASE WHEN dbo.TBL_BANKAHAREKETLERI.GCKODU = 'G' THEN dbo.TBL_BANKAHAREKETLERI.TUTAR ELSE 0 END) AS GIRIS, 
                      (CASE WHEN dbo.TBL_BANKAHAREKETLERI.GCKODU = 'C' THEN dbo.TBL_BANKAHAREKETLERI.TUTAR ELSE 0 END) AS CIKIS, dbo.TBL_BANKALAR.HESAPADI, 
                      dbo.TBL_BANKALAR.BANKAADI
FROM         dbo.TBL_BANKALAR RIGHT OUTER JOIN
                      dbo.TBL_BANKAHAREKETLERI ON dbo.TBL_BANKALAR.ID = dbo.TBL_BANKAHAREKETLERI.BANKAID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_BANKALAR"
            Begin Extent = 
               Top = 20
               Left = 464
               Bottom = 208
               Right = 629
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TBL_BANKAHAREKETLERI"
            Begin Extent = 
               Top = 3
               Left = 71
               Bottom = 190
               Right = 231
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 14
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_BANKAHAREKETLERI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_BANKAHAREKETLERI'
GO
/****** Object:  View [dbo].[VW_BANKADURUM]    Script Date: 11/28/2023 15:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_BANKADURUM]
AS
SELECT     dbo.TBL_BANKALAR.ID, SUM(CASE WHEN dbo.TBL_BANKAHAREKETLERI.GCKODU = 'G' THEN dbo.TBL_BANKAHAREKETLERI.TUTAR ELSE 0 END) AS GIRIS, 
                      SUM(CASE WHEN dbo.TBL_BANKAHAREKETLERI.GCKODU = 'C' THEN dbo.TBL_BANKAHAREKETLERI.TUTAR ELSE 0 END) AS CIKIS, 
                      SUM(CASE WHEN dbo.TBL_BANKAHAREKETLERI.GCKODU = 'G' THEN dbo.TBL_BANKAHAREKETLERI.TUTAR ELSE 0 END) 
                      - SUM(CASE WHEN dbo.TBL_BANKAHAREKETLERI.GCKODU = 'C' THEN dbo.TBL_BANKAHAREKETLERI.TUTAR ELSE 0 END) AS BAKIYE
FROM         dbo.TBL_BANKALAR LEFT OUTER JOIN
                      dbo.TBL_BANKAHAREKETLERI ON dbo.TBL_BANKALAR.ID = dbo.TBL_BANKAHAREKETLERI.BANKAID
GROUP BY dbo.TBL_BANKALAR.ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_BANKALAR"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 203
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TBL_BANKAHAREKETLERI"
            Begin Extent = 
               Top = 16
               Left = 546
               Bottom = 136
               Right = 706
            End
            DisplayFlags = 280
            TopColumn = 6
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_BANKADURUM'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_BANKADURUM'
GO
/****** Object:  View [dbo].[VW_STOKLISTESI]    Script Date: 11/28/2023 15:14:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_STOKLISTESI]
AS
SELECT     dbo.TBL_STOKLAR.ID, dbo.TBL_STOKLAR.STOKKODU, dbo.TBL_STOKLAR.STOKADI, (CASE WHEN dbo.VW_STOKDURUM.GIRIS IS NULL THEN 0 ELSE dbo.VW_STOKDURUM.GIRIS END) AS GIRIS, 
                      (CASE WHEN dbo.VW_STOKDURUM.CIKIS IS NULL THEN 0 ELSE dbo.VW_STOKDURUM.CIKIS END) AS CIKIS, (CASE WHEN dbo.VW_STOKDURUM.BAKIYE IS NULL 
                      THEN 0 ELSE dbo.VW_STOKDURUM.BAKIYE END) AS BAKIYE, dbo.TBL_STOKLAR.STOKBARKOD, dbo.TBL_STOKGRUPLARI.GRUPADI
FROM         dbo.TBL_STOKLAR INNER JOIN
                      dbo.VW_STOKDURUM ON dbo.TBL_STOKLAR.ID = dbo.VW_STOKDURUM.ID INNER JOIN
                      dbo.TBL_STOKGRUPLARI ON dbo.TBL_STOKLAR.STOKGRUPID = dbo.TBL_STOKGRUPLARI.ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_STOKLAR"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "VW_STOKDURUM"
            Begin Extent = 
               Top = 44
               Left = 501
               Bottom = 164
               Right = 661
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TBL_STOKGRUPLARI"
            Begin Extent = 
               Top = 85
               Left = 356
               Bottom = 205
               Right = 523
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_STOKLISTESI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_STOKLISTESI'
GO
/****** Object:  View [dbo].[VW_KASALISTESI]    Script Date: 11/28/2023 15:14:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_KASALISTESI]
AS
SELECT     dbo.TBL_KASALAR.KASAKODU, dbo.TBL_KASALAR.ID, dbo.TBL_KASALAR.KASAADI, dbo.TBL_KASALAR.ACIKLAMA, (CASE WHEN dbo.VW_KASADURUM.GIRIS IS NULL 
                      THEN 0 ELSE dbo.VW_KASADURUM.GIRIS END) AS GIRIS, (CASE WHEN dbo.VW_KASADURUM.CIKIS IS NULL THEN 0 ELSE dbo.VW_KASADURUM.CIKIS END) AS CIKIS, 
                      (CASE WHEN dbo.VW_KASADURUM.BAKIYE IS NULL THEN 0 ELSE dbo.VW_KASADURUM.BAKIYE END) AS BAKIYE
FROM         dbo.TBL_KASALAR FULL OUTER JOIN
                      dbo.VW_KASADURUM ON dbo.TBL_KASALAR.ID = dbo.VW_KASADURUM.KASAID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_KASALAR"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VW_KASADURUM"
            Begin Extent = 
               Top = 43
               Left = 423
               Bottom = 163
               Right = 583
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_KASALISTESI'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_KASALISTESI'
GO
/****** Object:  View [dbo].[VW_BANKALISTE]    Script Date: 11/28/2023 15:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_BANKALISTE]
AS
SELECT     dbo.VW_BANKADURUM.GIRIS, dbo.VW_BANKADURUM.CIKIS, dbo.VW_BANKADURUM.BAKIYE, dbo.TBL_BANKALAR.ID, dbo.TBL_BANKALAR.HESAPNO, dbo.TBL_BANKALAR.IBAN, 
                      dbo.TBL_BANKALAR.BANKAADI, dbo.TBL_BANKALAR.HESAPADI, dbo.TBL_BANKALAR.SUBE, dbo.TBL_BANKALAR.TEL, dbo.TBL_BANKALAR.ADRES, dbo.TBL_BANKALAR.TEMSILCI, 
                      dbo.TBL_BANKALAR.TEMSILCIEMAIL
FROM         dbo.TBL_BANKALAR INNER JOIN
                      dbo.VW_BANKADURUM ON dbo.TBL_BANKALAR.ID = dbo.VW_BANKADURUM.ID
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = -96
      End
      Begin Tables = 
         Begin Table = "TBL_BANKALAR"
            Begin Extent = 
               Top = 50
               Left = 182
               Bottom = 170
               Right = 347
            End
            DisplayFlags = 280
            TopColumn = 8
         End
         Begin Table = "VW_BANKADURUM"
            Begin Extent = 
               Top = 43
               Left = 525
               Bottom = 163
               Right = 685
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 23
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_BANKALISTE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_BANKALISTE'
GO
/****** Object:  View [dbo].[VW_IRSALIYELER]    Script Date: 11/28/2023 15:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_IRSALIYELER]
AS
SELECT     dbo.TBL_CARILER.CARIADI, dbo.TBL_CARILER.VERGIDAIRESI, dbo.TBL_CARILER.VERGINO, dbo.TBL_CARILER.SEHIR, dbo.TBL_CARILER.ILCE, dbo.TBL_CARILER.ADRES, 
                      dbo.TBL_IRSALIYELER.IRSALIYENO, dbo.TBL_IRSALIYELER.CARIKODU, dbo.TBL_IRSALIYELER.TARIHI, dbo.TBL_IRSALIYELER.ACIKLAMA, dbo.VW_KALEMLER.STOKKODU, 
                      dbo.VW_KALEMLER.STOKADI, dbo.VW_KALEMLER.STOKBARKOD, dbo.VW_KALEMLER.STOKBIRIM, dbo.VW_KALEMLER.BIRIMFIYAT, dbo.VW_KALEMLER.KDV, dbo.VW_KALEMLER.MIKTAR, 
                      dbo.VW_KALEMLER.TOPLAM
FROM         dbo.TBL_IRSALIYELER INNER JOIN
                      dbo.VW_KALEMLER ON dbo.TBL_IRSALIYELER.ID = dbo.VW_KALEMLER.IRSALIYEID LEFT OUTER JOIN
                      dbo.TBL_CARILER ON dbo.TBL_IRSALIYELER.CARIKODU = dbo.TBL_CARILER.CARIKODU
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_CARILER"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 6
         End
         Begin Table = "TBL_IRSALIYELER"
            Begin Extent = 
               Top = 35
               Left = 273
               Bottom = 155
               Right = 433
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "VW_KALEMLER"
            Begin Extent = 
               Top = 11
               Left = 640
               Bottom = 198
               Right = 800
            End
            DisplayFlags = 280
            TopColumn = 4
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_IRSALIYELER'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_IRSALIYELER'
GO
/****** Object:  View [dbo].[VW_FATURALAR]    Script Date: 11/28/2023 15:14:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[VW_FATURALAR]
AS
SELECT        dbo.TBL_FATURALAR.CARIKODU, dbo.TBL_CARILER.CARIADI, dbo.TBL_CARILER.VERGIDAIRESI, dbo.TBL_CARILER.VERGINO, dbo.TBL_CARILER.SEHIR, dbo.TBL_CARILER.ILCE, dbo.TBL_CARILER.ADRES, 
                         dbo.TBL_FATURALAR.FATURANO, dbo.TBL_FATURALAR.TARIHI, dbo.TBL_FATURALAR.ACIKLAMA, dbo.TBL_FATURALAR.GENELTOPLAM, dbo.VW_KALEMLER.STOKKODU, dbo.VW_KALEMLER.STOKADI, 
                         dbo.VW_KALEMLER.STOKBIRIM, dbo.VW_KALEMLER.BIRIMFIYAT, dbo.VW_KALEMLER.KDV, dbo.VW_KALEMLER.STOKBARKOD, dbo.VW_KALEMLER.MIKTAR, dbo.VW_KALEMLER.TOPLAM
FROM            dbo.VW_KALEMLER INNER JOIN
                         dbo.TBL_FATURALAR ON dbo.VW_KALEMLER.FATURAID = dbo.TBL_FATURALAR.ID LEFT OUTER JOIN
                         dbo.TBL_CARILER ON dbo.TBL_FATURALAR.CARIKODU = dbo.TBL_CARILER.CARIKODU
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[14] 2[18] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1[50] 4[25] 3) )"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1[38] 3) )"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3) )"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TBL_CARILER"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 248
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 14
         End
         Begin Table = "TBL_FATURALAR"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 244
               Right = 418
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "VW_KALEMLER"
            Begin Extent = 
               Top = 21
               Left = 521
               Bottom = 238
               Right = 691
            End
            DisplayFlags = 280
            TopColumn = 3
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 20
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      En' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_FATURALAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'd
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_FATURALAR'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VW_FATURALAR'
GO
/****** Object:  Default [DF_TBL_STOKHAREKETLERI_SAVEUSER]    Script Date: 11/28/2023 15:14:32 ******/
ALTER TABLE [dbo].[TBL_STOKHAREKETLERI] ADD  CONSTRAINT [DF_TBL_STOKHAREKETLERI_SAVEUSER]  DEFAULT ((-1)) FOR [SAVEUSER]
GO
/****** Object:  Default [DF_TBL_STOKHAREKETLERI_SAVEDATE]    Script Date: 11/28/2023 15:14:32 ******/
ALTER TABLE [dbo].[TBL_STOKHAREKETLERI] ADD  CONSTRAINT [DF_TBL_STOKHAREKETLERI_SAVEDATE]  DEFAULT (getdate()) FOR [SAVEDATE]
GO
/****** Object:  Default [DF_TBL_STOKHAREKETLERI_EDITUSER]    Script Date: 11/28/2023 15:14:32 ******/
ALTER TABLE [dbo].[TBL_STOKHAREKETLERI] ADD  CONSTRAINT [DF_TBL_STOKHAREKETLERI_EDITUSER]  DEFAULT ((-1)) FOR [EDITUSER]
GO
/****** Object:  Default [DF_TBL_STOKHAREKETLERI_EDITDATE]    Script Date: 11/28/2023 15:14:32 ******/
ALTER TABLE [dbo].[TBL_STOKHAREKETLERI] ADD  CONSTRAINT [DF_TBL_STOKHAREKETLERI_EDITDATE]  DEFAULT (getdate()) FOR [EDITDATE]
GO
