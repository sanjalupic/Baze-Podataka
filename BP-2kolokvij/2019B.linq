<Query Kind="SQL">
  <Connection>
    <ID>a5dfe7d5-ed30-4316-b3df-fa640f07da8b</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>DESKTOP-L8I0UQ6\SQLEXPRESS</Server>
    <Database>model</Database>
  </Connection>
</Query>

CREATE TABLE Putovanje (
IDPutovanje CHAR(6),
Destinacija VARCHAR (30),
DatumPolaska DATETIME,
RegOznaka CHAR(7),
CONSTRAINT IDPutovanje PRIMARY KEY (IDPutovanje),
)

CREATE TABLE Vozilo(
RegOznaka CHAR(7),
MarkaVozila VARCHAR(30),
ModelVozila VARCHAR(30),
BrMjesta INT,
DatProizvodnje DATETIME,
CONSTRAINT RegOznaka PRIMARY KEY (RegOznaka)
)

CREATE TABLE PutujeNa(
OIB CHAR(11),
IDPutovanje CHAR(6),
CONSTRAINT pk_PutujeNa PRIMARY KEY (OIB, IDPutovanje),
CONSTRAINT fk_OIB FOREIGN KEY (OIB) REFERENCES Putnik (OIB),
CONSTRAINT fk_IDPutovanje FOREIGN KEY (IDPutovanje) REFERENCES Putovanje(IDPutovanje)
)

--1.ZADATAK

--a)
ALTER TABLE VOZILO ALTER COLUMN ModelVozila VARCHAR (45) 

--b)
ALTER TABLE VOZILO DROP COLUMN BrMjesta
ALTER TABLE Vozilo ADD BrMjesta INT

--c)
ALTER TABLE Putovanje ADD Inozemstvo VARCHAR (30)

--d)
ALTER TABLE Putovanje ADD CONSTRAINT chk_Inozemstvo CHECK(Inozemstvo IN('DA', 'NE'))

--2.ZADATAK

--a)
UPDATE Vozilo SET MarkaVozila='Volkswagen'WHERE MarkaVozila='VW'

--b)
DELETE FROM Putovanje WHERE Destinacija='Barcelona' AND Year(DatumPolaska);

--c)
INSERT INTO Putnik VALUES ('63254156874', 'Sanja', 'Lupić')

--d)
INSERT INTO Putovanje (IDPutovanje, Destinacija, DatumPolaska, DatumPovratka) VALUES ('2143','Zagreb', '17/02/2021', '31/3/2021');


--3.ZADATAK

--a)
SELECT Destinacija, DatumPolaska, DatumPovratka FROM Putovanje WHERE DatumPolaska=(SELECT MAX(DatumPolaska) FROM Putovanje)

--b)
SELECT YEAR(DatProizvodnje), AVG(BrMjesta) FROM Vozilo ASC

--c) 
SELECT COUNT(IDPutovanje) FROM Putovanje WHERE Destinacije LIKE '%a';

--d)
CREATE VIEW PogledB AS SELECT Putovanje.Destinacija, Putovanje.YEAR(DatuPolaska), Vozilo.ModelVozila, Vozilo.MarkaVozila FROM Putovanje, Vozilo WHERE Putovanje.RegOznaka=Vozilo.RegOznaka GROUP BY Destinacija, YEAR(DatuPolaska), ModelVozila, MarkaVozila


--4.ZADATAK
CREATE PROCEDURE Procedura (@datum DATETIME) RETURN DATETIME
AS
