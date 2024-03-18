/****** Object:  Table [dbo].[Beneficiari]    Script Date: 15/03/2024 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiari](
	[B_GUID] [uniqueidentifier] NOT NULL,
	[B_NOME] [nvarchar](max) NOT NULL,
	[B_COGNOME] [nvarchar](max) NOT NULL,
	[B_CELL] [nvarchar](max) NULL,
	[B_EMAIL] [nvarchar](max) NULL,
 CONSTRAINT [PK_Beneficiari] PRIMARY KEY CLUSTERED 
(
	[B_GUID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Causali]    Script Date: 15/03/2024 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Causali](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPTION] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Causali] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pratiche]    Script Date: 15/03/2024 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pratiche](
	[P_GUID] [uniqueidentifier] NOT NULL,
	[P_PTC] [nvarchar](16) NOT NULL,
	[P_DATAINS] [datetime2](7) NOT NULL,
	[P_TYPE] [int] NOT NULL,
	[BEN_GUID] [uniqueidentifier] NOT NULL,
	[P_PAG_TYPE] [int] NULL,
	[P_CAU] [int] NULL,
 CONSTRAINT [PK_Pratiche] PRIMARY KEY CLUSTERED 
(
	[P_GUID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPagamento]    Script Date: 15/03/2024 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPagamento](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPTION] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TipoPagamento] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPratica]    Script Date: 15/03/2024 17:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPratica](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DESCRIPTION] [nvarchar](max) NULL,
 CONSTRAINT [PK_TipoPratica] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Beneficiari] ADD  CONSTRAINT [DF_Beneficiari_Id]  DEFAULT (newid()) FOR [B_GUID]
GO
ALTER TABLE [dbo].[Pratiche] ADD  CONSTRAINT [DF_Pratiche_P_GUID]  DEFAULT (newid()) FOR [P_GUID]
GO
ALTER TABLE [dbo].[Pratiche] ADD  CONSTRAINT [DF_Pratiche_P_DATAINS]  DEFAULT (getdate()) FOR [P_DATAINS]
GO
ALTER TABLE [dbo].[Pratiche]  WITH CHECK ADD  CONSTRAINT [FK_Pratiche_Beneficiari] FOREIGN KEY([BEN_GUID])
REFERENCES [dbo].[Beneficiari] ([B_GUID])
GO
ALTER TABLE [dbo].[Pratiche] CHECK CONSTRAINT [FK_Pratiche_Beneficiari]
GO
ALTER TABLE [dbo].[Pratiche]  WITH CHECK ADD  CONSTRAINT [FK_Pratiche_Causali] FOREIGN KEY([P_CAU])
REFERENCES [dbo].[Causali] ([ID])
GO
ALTER TABLE [dbo].[Pratiche] CHECK CONSTRAINT [FK_Pratiche_Causali]
GO
ALTER TABLE [dbo].[Pratiche]  WITH CHECK ADD  CONSTRAINT [FK_Pratiche_TipoPagamento] FOREIGN KEY([P_PAG_TYPE])
REFERENCES [dbo].[TipoPagamento] ([ID])
GO
ALTER TABLE [dbo].[Pratiche] CHECK CONSTRAINT [FK_Pratiche_TipoPagamento]
GO
ALTER TABLE [dbo].[Pratiche]  WITH CHECK ADD  CONSTRAINT [FK_Pratiche_TipoPratica] FOREIGN KEY([P_TYPE])
REFERENCES [dbo].[TipoPratica] ([ID])
GO
ALTER TABLE [dbo].[Pratiche] CHECK CONSTRAINT [FK_Pratiche_TipoPratica]
GO