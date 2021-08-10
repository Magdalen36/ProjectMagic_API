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

--INSERT INTO Color VALUES ('Blanc');
--INSERT INTO Color VALUES ('Vert');
--INSERT INTO Color VALUES ('Bleu');
--INSERT INTO Color VALUES ('Rouge');
--INSERT INTO Color VALUES ('Noir');
--INSERT INTO Color VALUES ('Incolore');
--INSERT INTO Color VALUES ('Multicolore');


--INSERT INTO [Role] VALUES ('Administrateur');
--INSERT INTO [Role] VALUES ('Visiteur');
--INSERT INTO [Role] VALUES ('Modérateur');


--INSERT INTO TypeCard VALUES (1, 'Terrain');
--INSERT INTO TypeCard VALUES (2, 'Créature');
--INSERT INTO TypeCard VALUES (3, 'Enchantement');
--INSERT INTO TypeCard VALUES (4, 'Ephémère');
--INSERT INTO TypeCard VALUES (5, 'Rituel');
--INSERT INTO TypeCard VALUES (6, 'Artefact');
--INSERT INTO TypeCard VALUES (7, 'Planeswalker');
