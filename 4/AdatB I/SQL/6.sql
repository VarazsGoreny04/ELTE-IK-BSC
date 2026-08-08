CREATE TABLE dolgozo2 AS SELECT * FROM nikovits.dolgozo;
CREATE TABLE osztaly2 AS SELECT * FROM nikovits.osztaly;

SELECT * FROM dolgozo2;
SELECT * FROM osztaly2;
SELECT * FROM fiz_kategoria;

-- 1. feladat: Töröljük azokat a dolgozókat, akiknek a jutaléka NULL!
DELETE
FROM dolgozo2
WHERE jutalek IS NULL;
ROLLBACK;

-- 2. feladat: Töröljük azokat a dolgozókat, akiknek a belépési dátuma 1982 el?tti!
DELETE
FROM dolgozo2
WHERE belepes < TO_DATE('1982.01.01', 'YYYY.MM.DD');
ROLLBACK;

-- 1. feladat: Töröljük azokat a dolgozókat, akiknek a telephelye Dallas!
DELETE
FROM dolgozo2
WHERE oazon = (SELECT oazon FROM osztaly WHERE telephely = 'DALLAS');
ROLLBACK;

-- 1. feladat: Töröljük azokat a dolgozókat, akiknek a fizetése kisebb mint az átlagfizetés!
DELETE
FROM dolgozo2
WHERE fizetes < (SELECT AVG(fizetes) FROM dolgozo2);
ROLLBACK;

-- 5. feladat: Töröljük azokat az osztályokat amelynek 2 darab 2-es fizetési kategóriába es? dolgozója van!
DELETE
FROM osztaly2 o
WHERE (SELECT COUNT(*) 
       FROM dolgozo2 d, fiz_kategoria f 
       WHERE d.fizetes BETWEEN f.also AND f.felso AND kategoria = 2 AND o.oazon = d.oazon) = 2;
ROLLBACK;

-- 6. feladat: Vegyük fel a Kovács nev? dolgozót a 10-es osztályra a következ? értékkel:
-- dkod = 1
-- dnev = 'Kovacs'
-- oazon = '10'
-- belepes = aktuális dátum
-- fizetes = 10-es osztály átlagfizetése
-- Többi oszlop NULL
INSERT INTO dolgozo2 (dkod, dnev, foglalkozas, fonoke, belepes, fizetes, jutalek, oazon)
VALUES (1, 'Kovacs', NULL, NULL, SYSDATE, (SELECT AVG(fizetes) FROM dolgozo2 WHERE oazon = 10), NULL, 10);

SELECT * FROM dolgozo2;
ROLLBACK;

-- 7. feladat: Növeljük meg a 20 ostályon dolgozók fizetését 20%-al!
UPDATE dolgozo2
SET fizetes = fizetes * 1.2
WHERE oazon = 20;

SELECT * FROM dolgozo2;
COMMIT;

-- 8. feladat: Növeljük meg azok fizetését 500-al, akiknek a jutaléka NULL vagy a fizetes kisebb az átlagnál!
UPDATE dolgozo2
SET fizetes = fizetes + 500
WHERE jutalek IS NULL OR fizetes < (SELECT AVG(fizetes) FROM dolgozo2);

COMMIT;