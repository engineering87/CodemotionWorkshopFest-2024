/****** Object:  Table [dbo].[Beneficiari]    Script Date: 15/03/2024 17:41:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiari](
	[Id] [uniqueidentifier] NOT NULL,
	[Nome] [nvarchar](max) NOT NULL,
	[Cognome] [nvarchar](max) NOT NULL,
	[Cellulare] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
 CONSTRAINT [PK_Beneficiari] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Beneficiari] ADD  CONSTRAINT [DF_Beneficiari_Id]  DEFAULT (newid()) FOR [Id]
GO
