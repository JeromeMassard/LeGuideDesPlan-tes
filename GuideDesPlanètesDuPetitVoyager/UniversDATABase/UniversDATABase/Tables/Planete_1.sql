CREATE TABLE [UniversDATABase].[Planete](
	[PlaneteNom] NVARCHAR(50) IDENTITY(1,1) NOT NULL,
	[PlaneteVolume] NVARCHAR(20) NOT NULL,
	[PlaneteMasse] NVARCHAR(20) NOT NULL,
	[PlaneteAnneaux] NVARCHAR(20) NOT NULL,
	[PlaneteDecouverte] NVARCHAR(15) NOT NULL,
	[PlaneteNBSat] NVARCHAR(3) NOT NULL,
	[PlanetePeriodeRevo] NVARCHAR(10) NOT NULL,
	[PlanetePathIm] NVARCHAR(300) NOT NULL	
);
GO
ALTER TABLE [UniversDATABase].[Planete]
	ADD CONSTRAINT [Def_Planete_Volume] DEFAULT 0 FOR [PlaneteVolume];
GO
ALTER TABLE [UniversDATABase].[Planete]
	ADD CONSTRAINT [Def_Planete_Masse] DEFAULT 0 FOR [PlaneteMasse];
GO
ALTER TABLE [UniversDATABase].[Planete]
	ADD CONSTRAINT [Def_Planete_Anneaux] DEFAULT 'Non' FOR [PlaneteAnneaux];
GO
ALTER TABLE [UniversDATABase].[Planete]
	ADD CONSTRAINT [Def_Planete_Decouverte] DEFAULT GetDate() FOR [PlaneteDecouverte];
GO
ALTER TABLE [UniversDATABase].[Planete]
	ADD CONSTRAINT [Def_Planete_NBSat] DEFAULT 0 FOR [PlaneteNBSat];
GO
ALTER TABLE [UniversDATABase].[Planete]
	ADD CONSTRAINT [Def_Planete_PeriodeRevo] DEFAULT 0 FOR [PlanetePeriodeRevo];