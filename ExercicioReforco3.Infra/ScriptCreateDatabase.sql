CREATE DATABASE ExercicioReforco3

USE [ExercicioReforco3]
GO
/****** Object:  Table [dbo].[Funcionario]    Script Date: 03/06/2018 22:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Funcionario](
	[id_funcionario] [bigint] IDENTITY(1,1) NOT NULL,
	[nome_funcionario] [varchar](150) NOT NULL,
	[cargo] [varchar](150) NOT NULL,
	[setor] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED 
(
	[id_funcionario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reuniao]    Script Date: 03/06/2018 22:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reuniao](
	[id_reuniao] [bigint] IDENTITY(1,1) NOT NULL,
	[funcionario_id] [bigint] NOT NULL,
	[sala_id] [bigint] NOT NULL,
	[data] [date] NOT NULL,
	[hora_inicio] [smalldatetime] NOT NULL,
	[hora_final] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_Reuniao] PRIMARY KEY CLUSTERED 
(
	[id_reuniao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sala]    Script Date: 03/06/2018 22:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sala](
	[id_sala] [bigint] IDENTITY(1,1) NOT NULL,
	[nome_sala] [varchar](100) NOT NULL,
	[qtde_lugares] [int] NOT NULL,
 CONSTRAINT [PK_Sala] PRIMARY KEY CLUSTERED 
(
	[id_sala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Reuniao]  WITH CHECK ADD FOREIGN KEY([funcionario_id])
REFERENCES [dbo].[Funcionario] ([id_funcionario])
GO
ALTER TABLE [dbo].[Reuniao]  WITH CHECK ADD FOREIGN KEY([sala_id])
REFERENCES [dbo].[Sala] ([id_sala])
GO
