USE [DemoExam_09_02_07_02_2025_PU]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 28.09.2025 16:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[TypeId] [int] NOT NULL,
	[CostPerUnit] [decimal](18, 2) NOT NULL,
	[QuantityInStock] [decimal](18, 2) NOT NULL,
	[MinimalQuantity] [decimal](18, 2) NOT NULL,
	[QuantityInPack] [decimal](18, 2) NOT NULL,
	[UnitId] [int] NOT NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialsTypes]    Script Date: 28.09.2025 16:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialsTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LostCoef] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_MaterialsTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 28.09.2025 16:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
	[Article] [nvarchar](50) NOT NULL,
	[MinimalCost] [decimal](18, 2) NOT NULL,
	[TypeId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductsMaterials]    Script Date: 28.09.2025 16:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsMaterials](
	[MaterialId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Coef] [decimal](18, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductsTypes]    Script Date: 28.09.2025 16:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductsTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Coef] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_ProductsTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Units]    Script Date: 28.09.2025 16:07:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Units](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ShortName] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Materials] ADD  CONSTRAINT [DF_Materials_CostPerUnit]  DEFAULT ((0.00)) FOR [CostPerUnit]
GO
ALTER TABLE [dbo].[Materials] ADD  CONSTRAINT [DF_Materials_QuantityInStock]  DEFAULT ((0.00)) FOR [QuantityInStock]
GO
ALTER TABLE [dbo].[Materials] ADD  CONSTRAINT [DF_Materials_MinimalQuantity]  DEFAULT ((0.00)) FOR [MinimalQuantity]
GO
ALTER TABLE [dbo].[Materials] ADD  CONSTRAINT [DF_Materials_QuantityInPack]  DEFAULT ((0.00)) FOR [QuantityInPack]
GO
ALTER TABLE [dbo].[MaterialsTypes] ADD  CONSTRAINT [DF_MaterialsTypes_LostCoef]  DEFAULT ((0.00)) FOR [LostCoef]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_MinimalCost]  DEFAULT ((0.00)) FOR [MinimalCost]
GO
ALTER TABLE [dbo].[ProductsMaterials] ADD  CONSTRAINT [DF_ProductsMaterials_Coef]  DEFAULT ((0.00)) FOR [Coef]
GO
ALTER TABLE [dbo].[ProductsTypes] ADD  CONSTRAINT [DF_ProductsTypes_Coef]  DEFAULT ((0.00)) FOR [Coef]
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_MaterialsTypes] FOREIGN KEY([TypeId])
REFERENCES [dbo].[MaterialsTypes] ([Id])
GO
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_Materials_MaterialsTypes]
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_Units] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Units] ([Id])
GO
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_Materials_Units]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductsTypes] FOREIGN KEY([TypeId])
REFERENCES [dbo].[ProductsTypes] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductsTypes]
GO
ALTER TABLE [dbo].[ProductsMaterials]  WITH CHECK ADD  CONSTRAINT [FK_ProductsMaterials_Materials] FOREIGN KEY([MaterialId])
REFERENCES [dbo].[Materials] ([Id])
GO
ALTER TABLE [dbo].[ProductsMaterials] CHECK CONSTRAINT [FK_ProductsMaterials_Materials]
GO
ALTER TABLE [dbo].[ProductsMaterials]  WITH CHECK ADD  CONSTRAINT [FK_ProductsMaterials_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductsMaterials] CHECK CONSTRAINT [FK_ProductsMaterials_Products]
GO
USE [master]
GO
ALTER DATABASE [DemoExam_09_02_07_02_2025_PU] SET  READ_WRITE 
GO
