﻿CREATE TABLE [dbo].[Movie]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Title VARCHAR(100) NOT NULL,
	Synopsis VARCHAR(250) not NULL,
	ReleaseYear INT NOT NULL,
	Realisator VARCHAR(50) NOT NULL
)