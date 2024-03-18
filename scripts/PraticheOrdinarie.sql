/****** Object:  Table [dbo].[PraticheOrdinarie]    Script Date: 15/03/2024 17:42:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PraticheOrdinarie](
	[Id] [uniqueidentifier] NOT NULL,
	[Protocollo] [nvarchar](16) NOT NULL,
	[DataInserimento] [datetime2](7) NOT NULL,
	[TipoPagamento] [int] NOT NULL,
	[IdBeneficiario] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_PraticheOrdinarie] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoPagamento]    Script Date: 15/03/2024 17:42:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoPagamento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descrizione] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TipoPagamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[PraticheOrdinarie] ADD  CONSTRAINT [DF_PraticheOrdinarie_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[PraticheOrdinarie] ADD  CONSTRAINT [DF_PraticheOrdinarie_DataInserimento]  DEFAULT (getdate()) FOR [DataInserimento]
GO
ALTER TABLE [dbo].[PraticheOrdinarie]  WITH CHECK ADD  CONSTRAINT [FK_PraticheOrdinarie_TipoPagamento] FOREIGN KEY([TipoPagamento])
REFERENCES [dbo].[TipoPagamento] ([Id])
GO
ALTER TABLE [dbo].[PraticheOrdinarie] CHECK CONSTRAINT [FK_PraticheOrdinarie_TipoPagamento]
GO
