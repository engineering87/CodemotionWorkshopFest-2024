/****** Object:  Table [dbo].[Causale]    Script Date: 15/03/2024 17:43:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Causale](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descrizione] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Causale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PraticheStraordinarie]    Script Date: 15/03/2024 17:43:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PraticheStraordinarie](
	[Id] [uniqueidentifier] NOT NULL,
	[Protocollo] [nvarchar](max) NOT NULL,
	[DataInserimento] [datetime2](7) NOT NULL,
	[IdCausale] [int] NOT NULL,
	[IdBeneficiario] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PraticheStraordinarie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[PraticheStraordinarie] ADD  CONSTRAINT [DF_PraticheStraordinarie_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[PraticheStraordinarie] ADD  CONSTRAINT [DF_PraticheStraordinarie_DataInserimento]  DEFAULT (getdate()) FOR [DataInserimento]
GO
ALTER TABLE [dbo].[PraticheStraordinarie]  WITH CHECK ADD  CONSTRAINT [FK_PraticheStraordinarie_Causale] FOREIGN KEY([IdCausale])
REFERENCES [dbo].[Causale] ([Id])
GO
ALTER TABLE [dbo].[PraticheStraordinarie] CHECK CONSTRAINT [FK_PraticheStraordinarie_Causale]
GO
