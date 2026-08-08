CREATE TABLE dolgozo AS SELECT * FROM NIKOVITS.dolgozo;
CREATE TABLE osztaly AS SELECT * FROM NIKOVITS.osztaly;
CREATE TABLE szeret AS SELECT * FROM NIKOVITS.szeret;

DROP TABLE dvzcbt.dolgozo;

SELECT * FROM dvzcbt.dolgozo;
SELECT * FROM dvzcbt.osztaly;
SELECT * FROM dvzcbt.szeret;

SELECT *
FROM dvzcbt.dolgozo d, dvzcbt.osztaly o
WHERE d.oazon = o.oazon;

SELECT * 
FROM dvzcbt.dolgozo NATURAL JOIN dvzcbt.osztaly;

-- 1. feladat: Kik azok akik a 10-es vagy 20-as osztályon dolgoznak?
SELECT *
FROM dvzcbt.dolgozo
WHERE oazon = 10 OR oazon = 20;

-- 2. feladat: Kik azok a dolgozók akiknek a jutaléka nem nagyobb, mint 600?
SELECT *
FROM dvzcbt.dolgozo
WHERE jutalek IS NULL OR jutalek <= 600;

SELECT *
FROM dvzcbt.dolgozo
MINUS
SELECT *
FROM dvzcbt.dolgozo
WHERE jutalek > 600;

-- 3. fealdat: Adjuk meg azoknak a nevét és fizetésük kétszeresét, akik a 10-es osztályon dolgoznak
SELECT DNEV AS Név, FIZETES * 2 AS "Ketszer fizetes"
FROM dvzcbt.dolgozo
WHERE oazon = 10;

-- 4. feladat: Kik azok akik legalább két féle gyömölcsöt szeretnek
SELECT DISTINCT sz1.nev Név
FROM dvzcbt.szeret sz1, dvzcbt.szeret sz2
WHERE sz1.nev = sz2.nev AND sz1.gyumolcs <> sz2.gyumolcs;

-- 5. feladat: Kik azok akik legalább három féle gyömölcsöt szeretnek
SELECT DISTINCT sz1.nev Név
FROM dvzcbt.szeret sz1, dvzcbt.szeret sz2, dvzcbt.szeret sz3
WHERE sz1.nev = sz2.nev AND sz2.nev = sz3.nev AND
      sz1.gyumolcs != sz2.gyumolcs AND sz1.gyumolcs != sz3.gyumolcs AND sz2.gyumolcs != sz3.gyumolcs;

-- 6. feladat: Kik szeretnek legfeljebb kétféle gyümölcsöt
SELECT nev Név
FROM dvzcbt.szeret
MINUS
SELECT DISTINCT sz1.nev
FROM dvzcbt.szeret sz1, dvzcbt.szeret sz2, dvzcbt.szeret sz3
WHERE sz1.nev = sz2.nev AND sz2.nev = sz3.nev AND
      sz1.gyumolcs != sz2.gyumolcs AND sz1.gyumolcs != sz3.gyumolcs AND sz2.gyumolcs != sz3.gyumolcs;

-- 7. feladat: Kik azok a dolgozók akiknek a f?nöke KING?
SELECT d1.dnev
FROM dvzcbt.dolgozo d1, dvzcbt.dolgozo d2
WHERE d1.fonoke = d2.dkod AND d2.dnev = 'KING';

SELECT dnev Név
FROM dvzcbt.dolgozo
WHERE fonoke IN (
    SELECT dkod
    FROM dvzcbt.dolgozo 
    WHERE dnev LIKE 'KING');
    
-- 8. feladat: Kik azok a dolgozók, akik többet keresnek a f?nöküknél?
SELECT d1.dnev
FROM dvzcbt.dolgozo d1, dvzcbt.dolgozo d2
WHERE d1.fonoke = d2.dkod AND d1.fizetes > d2.fizetes;

-- 9. feladat: Kik azok a dolgozók akiknek a f?nökének a f?nöke a KING?
SELECT dnev Név
FROM dvzcbt.dolgozo
WHERE fonoke IN (
    SELECT dkod
    FROM dvzcbt.dolgozo
    WHERE fonoke IN (
        SELECT dkod
        FROM dvzcbt.dolgozo 
        WHERE dnev LIKE 'KING'));
        
-- 10. feladat: Kik azok a dolgozók, akiknek a telephelye DALLAS vagy CHICAGO?
SELECT dnev
FROM dvzcbt.dolgozo NATURAL JOIN dvzcbt.osztaly
WHERE telephely LIKE 'DALLAS' OR telephely LIKE 'CHICAGO'
ORDER BY dnev;

-- 11. feladat: Adjuk meg azokat a dolgozókat, akiknek van 2000-nél nagyobb fizetés? beosztottja
SELECT DISTINCT d1.dnev
FROM dvzcbt.dolgozo d1, dvzcbt.dolgozo d2
WHERE d1.dkod = d2.fonoke AND d2.fizetes > 2000;