/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Movie (Title, Synopsis, ReleaseYear, Realisator) 
VALUES ('Star Wars', 'Han solo et Chewbacca parcours la galaxie en se tappant Leia', 1977, 'Georges Lucas')


INSERT INTO Movie (Title, Synopsis, ReleaseYear, Realisator) 
VALUES ('Indiana Jones', 'C'' est un mec qui cherche des vieux trucs', 1980, 'Steve Spielberg')
GO
