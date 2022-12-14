USE [PLANPROSOFT]
GO
/****** Object:  Table [dbo].[EmpresasA]    Script Date: 7/19/2022 11:02:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[EmpresasA](
	[id_Empresa] [int] IDENTITY(1,1) NOT NULL,
	[nombreEmpresa] [varchar](150) NULL,
	[logo] [image] NULL,
	[nombreLogo] [varchar](max) NULL,
	[rnc] [varchar](50) NULL,
	[rpe] [varchar](50) NULL,
	[direccion] [varchar](150) NULL,
	[telefono] [varchar](50) NULL,
	[nombreFiador] [varchar](150) NULL,
	[cedulaFiador] [varchar](50) NULL,
	[nombreRepresentanteLegal] [varchar](150) NULL,
	[correoEmpresa] [varchar](100) NULL,
	[enmiendas] [varchar](150) NULL,
	[nombreDirectorProyecto] [varchar](150) NULL,
	[cedulaDirector] [varchar](50) NULL,
	[nombreIngResidente1] [varchar](150) NULL,
	[cedulaIngResidente1] [varchar](50) NULL,
	[nombreIngResidente2] [varchar](150) NULL,
	[cedulaIngResidente2] [varchar](50) NULL,
	[nombreIngResidente3] [varchar](150) NULL,
	[cedulaIngResidente3] [varchar](50) NULL,
	[nombreSeguridad] [varchar](150) NULL,
	[cedulaSeguridad] [varchar](50) NULL,
	[nombreEncargadoOficinaT] [varchar](150) NULL,
	[cedulaEncargadoOficinaT] [varchar](50) NULL,
	[nombreEncargadoTopoG] [varchar](150) NULL,
	[nombreArqResidente1] [varchar](150) NULL,
	[cedulaArqResidente1] [varchar](50) NULL,
	[nombreArqResidente2] [varchar](150) NULL,
	[cedulaArqResidente2] [varchar](50) NULL,
	[nombreArqResidente3] [varchar](150) NULL,
	[cedulaArqResidente3] [varchar](50) NULL,
	[nombreAgeDesignado1] [varchar](150) NULL,
	[nombreAgeDesignado2] [varchar](150) NULL,
	[nombreAgeDesignado3] [varchar](150) NULL,
	[estado] [nchar](25) NULL,
 CONSTRAINT [PK_id_Empresa] PRIMARY KEY CLUSTERED 
(
	[id_Empresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MinisterioA]    Script Date: 7/19/2022 11:02:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MinisterioA](
	[id_Ministerio] [int] IDENTITY(1,1) NOT NULL,
	[nombreMinisterio] [varchar](150) NULL,
	[email] [varchar](50) NULL,
	[logo] [image] NULL,
	[nombreLogo] [varchar](max) NULL,
	[direccion] [varchar](150) NULL,
	[telefono] [varchar](50) NULL,
	[estado] [varchar](50) NULL,
 CONSTRAINT [PK_Ministerio_1] PRIMARY KEY CLUSTERED 
(
	[id_Ministerio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProyectosA]    Script Date: 7/19/2022 11:02:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[ProyectosA](
	[Id_proyecto] [int] IDENTITY(1,1) NOT NULL,
	[nombreProyecto] [varchar](150) NULL,
	[montoApropiacion] [float] NULL,
	[montoGanador] [float] NULL,
	[id_Ministerio] [int] NOT NULL,
	[proceso] [varchar](150) NULL,
	[garantiaSeriedadOferta] [varchar](50) NULL,
	[garantiaFielCumplimiento] [varchar](50) NULL,
	[porcientoAnticipo] [varchar](50) NULL,
	[numCopiasSobreA] [varchar](50) NULL,
	[numCopiasSobreB] [varchar](50) NULL,
	[tiempoMantenimientoOferta] [varchar](50) NULL,
	[vigenciaPoliza] [varchar](50) NULL,
	[aperturaSobreA] [varchar](50) NULL,
	[aperturaSobreB] [varchar](50) NULL,
	[tiempoEjecucionObra] [varchar](50) NULL,
	[diaVisitaObra] [varchar](50) NULL,
	[direccionVisitaObra] [varchar](150) NULL,
	[fechaEntregaSobreA] [varchar](50) NULL,
	[fechaEntregaSobreB] [varchar](50) NULL,
	[Fecha] [datetime] NULL,
	[Motivo] [varchar](200) NULL,
	[id_Empresa] [int] NULL,
	[estado] [nvarchar](50) NULL,
 CONSTRAINT [PK_PROYECTO] PRIMARY KEY CLUSTERED 
(
	[Id_proyecto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[test]    Script Date: 7/19/2022 11:02:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[test](
	[Oid] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
	[Codigo] [nvarchar](100) NULL,
	[nombre] [nvarchar](100) NULL,
	[OptimisticLockField] [int] NULL,
	[GCRecord] [int] NULL,
 CONSTRAINT [PK_test] PRIMARY KEY CLUSTERED 
(
	[Oid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/19/2022 11:02:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](100) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[firstName] [nvarchar](100) NOT NULL,
	[lastName] [nvarchar](100) NOT NULL,
	[position] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
	[profilePicture] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[userName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[USUARIO2]    Script Date: 7/19/2022 11:02:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[USUARIO2](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombres_y_Apellidos] [varchar](50) NULL,
	[Login] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Icono] [image] NULL,
	[Nombre_de_icono] [varchar](max) NULL,
	[Correo] [varchar](max) NULL,
	[Rol] [varchar](max) NULL,
	[Estado] [varchar](50) NULL,
 CONSTRAINT [PK_USUARIO2] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ProyectosA]  WITH CHECK ADD FOREIGN KEY([id_Empresa])
REFERENCES [dbo].[EmpresasA] ([id_Empresa])
GO
ALTER TABLE [dbo].[ProyectosA]  WITH CHECK ADD  CONSTRAINT [FK_MINISTERIO] FOREIGN KEY([id_Ministerio])
REFERENCES [dbo].[MinisterioA] ([id_Ministerio])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProyectosA] CHECK CONSTRAINT [FK_MINISTERIO]
GO
