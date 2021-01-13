<Query Kind="SQL">
  <Connection>
    <ID>a5dfe7d5-ed30-4316-b3df-fa640f07da8b</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>DESKTOP-L8I0UQ6\SQLEXPRESS</Server>
    <Database>model</Database>
  </Connection>
</Query>

CREATE TABLE Glumac(
IDGlumca char(6),
Ime VARCHAR(30),
Prezime Varchar(30),
CONSTRAINT pk_IDGlumca PRIMARY KEY(IDGlumca)
)

CREATE TABLE IzdavackaKuca(
IDKuce CHAR(6), 
NazivKuce VARCHAR(30),
Drzava VARCHAR(30),
CONSTRAINT pk_IDKuce PRIMARY KEY(IDKuce)
)

CREATE TABLE Filmovi(
IDFilma CHAR(6), 
Naslov VARCHAR(30),
DatumIzdavanja DATETIME,
Trajanje INT ,
IDKuce CHAR(6),
CONSTRAINT pk_IDFilma PRIMARY KEY(IDFilma)
)

CREATE TABLE GlumiU(
IDGlumca CHAR(6),
IDFilma CHAR(6),
CONSTRAINT pk_GlumiU PRIMARY KEY (IDGlumca, IDFilma),
CONSTRAINT fk_IDGlumca FOREIGN KEY(IDGlumca) REFERENCES Glumac(IDGlumca),
CONSTRAINT fk_IDFilma FOREIGN KEY(IDFilma) REFERENCES Filmovi(IDFilma)
)

--1. ZADATAK
--a)
ALTER TABLE Glumac 
ADD Spol CHAR(1)

--b)
ALTER TABLE Glumac ADD CONSTRAINT chk_Spol CHECK (Spol IN ('M','F'))


--c)
ALTER TABLE Filmovi 
ALTER COLUMN Naslov VARCHAR(100)

--d)
ALTER TABLE IzdavackaKuca 
DROP COLUMN Drzava


--2.ZADATAK
--a)
INSERT INTO Glumac VALUES ('123a', 'Mihaela', 'Orić', 'F');

--b)
INSERT INTO Filmovi ( IDFilma, Naslov, Trajanje) VALUES ('456b', 'Ponos i predrasude', '2'); 

SELECT* FROM Glumac

--c)
UPDATE IzdavackaKuca SET NazivKuce=' 20th Century Fox u Twentieth Century Fox' WHERE NazivKuce='20th Century Fox'

--d)
DELETE FROM Filmovi WHERE DatumIzdavanja BETWEEN '1/7/2007/' AND '31/12/2007/'


--3. ZADATAK
--a) 
SELECT COUNT (IDGlumac) FROM Glumac WHERE Ime LIKE 'P%' AND Prezime LIKE 'C%'

--b)
SELECT Naslov, DatumIzdavanja, Trajanje FROM Filmovi WHERE Trajanje=(SELECT MIN(Trajanje) FROM Filmovi)

--c) 
SELECT YEAR(DatumIzdavanja), Trajanje FROM Filmovi ORDER BY DatumIzdavanja DESC

--d)
CREATE VIEW Pogled AS SELECT Naslov, Trajanje, NazivKuce FROM Filmovi, IzdavackaKuca WHERE Filmovi.IDKuce=IzdavackaKuca.IDKuce GROUP BY Naslov, Trajanje, NazivKuce


--ZADATAK 4.
CREATE FUNCTION Funkcija (@broj int) RETURNS INT
BEGIN 
	DECLARE @rez INT
	DECLARE @parni INT;
	SET @rez=0;
	SET @parni =0;
	IF @broj>0
		WHILE @parni<@broj-1
		BEGIN
			SET @parni =@parni+2;
			SET @rez=@rez+@parni;
		END;
ELSE SET @rez=ABS(@broj);
RETURN @rez;
END

DROP FUNCTION Funkcija 

SELECT dbo.Funkcija(5)
