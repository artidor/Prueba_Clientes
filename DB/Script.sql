USE [ClienteDB]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 26/03/2023 16:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[Telefono] [varchar](20) NOT NULL,
	[Ocupacion] [varchar](25) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarjeta]    Script Date: 26/03/2023 16:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarjeta](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Tipo_Tarjeta] [int] NOT NULL,
	[Banco] [varchar](20) NOT NULL,
	[Numero] [varchar](20) NOT NULL,
	[Mes] [int] NOT NULL,
	[Ano] [int] NOT NULL,
	[codCliente] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tipo_Tarjeta]    Script Date: 26/03/2023 16:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Tarjeta](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Descripccion] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[clientes] ON 

INSERT [dbo].[clientes] ([Codigo], [Nombre], [Apellido], [Telefono], [Ocupacion]) VALUES (3, N'michael ant', N'sosa lopez', N'809-234-4374', N'informatico')
INSERT [dbo].[clientes] ([Codigo], [Nombre], [Apellido], [Telefono], [Ocupacion]) VALUES (4, N'julio', N'soto', N'809-435-6543', N'enfermero')
INSERT [dbo].[clientes] ([Codigo], [Nombre], [Apellido], [Telefono], [Ocupacion]) VALUES (5, N'cesar', N'montero', N'809-234-4376', N'informatico')
INSERT [dbo].[clientes] ([Codigo], [Nombre], [Apellido], [Telefono], [Ocupacion]) VALUES (6, N'maria', N'mateo', N'809-235-4374', N'informatico')
INSERT [dbo].[clientes] ([Codigo], [Nombre], [Apellido], [Telefono], [Ocupacion]) VALUES (7, N'paola antonia', N'sosa', N'829-234-4374', N'informatico')
SET IDENTITY_INSERT [dbo].[clientes] OFF
SET IDENTITY_INSERT [dbo].[Tarjeta] ON 

INSERT [dbo].[Tarjeta] ([ID], [Tipo_Tarjeta], [Banco], [Numero], [Mes], [Ano], [codCliente]) VALUES (15, 2, N'popular', N'500', 5, 5, 3)
INSERT [dbo].[Tarjeta] ([ID], [Tipo_Tarjeta], [Banco], [Numero], [Mes], [Ano], [codCliente]) VALUES (16, 1, N'reservas', N'5', 5, 5, 3)
INSERT [dbo].[Tarjeta] ([ID], [Tipo_Tarjeta], [Banco], [Numero], [Mes], [Ano], [codCliente]) VALUES (17, 1, N'5', N'111', 56, 56, 3)
INSERT [dbo].[Tarjeta] ([ID], [Tipo_Tarjeta], [Banco], [Numero], [Mes], [Ano], [codCliente]) VALUES (18, 1, N'199', N'199', 1, 1, 7)
SET IDENTITY_INSERT [dbo].[Tarjeta] OFF
SET IDENTITY_INSERT [dbo].[Tipo_Tarjeta] ON 

INSERT [dbo].[Tipo_Tarjeta] ([ID], [Descripccion]) VALUES (1, N'Credito')
INSERT [dbo].[Tipo_Tarjeta] ([ID], [Descripccion]) VALUES (2, N'Debito')
SET IDENTITY_INSERT [dbo].[Tipo_Tarjeta] OFF
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_clientes] FOREIGN KEY([codCliente])
REFERENCES [dbo].[clientes] ([Codigo])
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_clientes]
GO
ALTER TABLE [dbo].[Tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_Tarjeta_Tipo_Tarjeta] FOREIGN KEY([Tipo_Tarjeta])
REFERENCES [dbo].[Tipo_Tarjeta] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[Tarjeta] CHECK CONSTRAINT [FK_Tarjeta_Tipo_Tarjeta]
GO
