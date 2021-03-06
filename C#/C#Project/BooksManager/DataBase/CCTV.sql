USE [CCTV]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2019/12/25 23:41:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Book](
	[bookId] [char](5) NOT NULL,
	[bookName] [varchar](50) NULL,
	[bookPrice] [int] NULL,
	[publisDate] [datetime] NULL,
	[kogo] [varchar](500) NULL,
	[catalogId] [char](4) NOT NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[bookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NewCataLog]    Script Date: 2019/12/25 23:41:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NewCataLog](
	[catalogId] [char](4) NOT NULL,
	[catalogName] [varchar](50) NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_NewCataLog] PRIMARY KEY CLUSTERED 
(
	[catalogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_NewCataLog] FOREIGN KEY([catalogId])
REFERENCES [dbo].[NewCataLog] ([catalogId])
GO
ALTER TABLE [dbo].[Book] CHECK CONSTRAINT [FK_Book_NewCataLog]
GO
