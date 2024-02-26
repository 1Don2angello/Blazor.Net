USE [MVCCRUD]
GO

CREATE TABLE [dbo].[formulario-ip](
    [id] [int] IDENTITY(1,1) NOT NULL,
    [ip] [varchar](50) NOT NULL,
    [funcion] [varchar](50) NOT NULL,
    [respuesta] [varchar](50) NOT NULL,
    [datos] [varchar](max) NULL,
 CONSTRAINT [PK_formulario-ip] PRIMARY KEY CLUSTERED 
(
    [id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO