USE [ServerDB]
GO

/****** Object:  Table [dbo].[StockTransaction]    Script Date: 30-05-2012 20:57:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StockTransaction](
	[NumTransaction] [int] IDENTITY(1,1) NOT NULL,
	[IDTransaction] [nvarchar](50) NOT NULL,
	[IDClient] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[ShareType] [nvarchar](50) NOT NULL,
	[ActionType] [bit] NOT NULL,
	[TransactionTime] [datetime] NOT NULL,
	[Rate] [float] NOT NULL,
	[Executed] [bit] NOT NULL,
	[Currency] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED 
(
	[NumTransaction] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[StockTransaction] ADD  CONSTRAINT [DF_StockTransaction_Executed]  DEFAULT ((0)) FOR [Executed]
GO

ALTER TABLE [dbo].[StockTransaction] ADD  CONSTRAINT [DF_StockTransaction_currency]  DEFAULT (N'EUR') FOR [Currency]
GO

