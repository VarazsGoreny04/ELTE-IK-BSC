CREATE TABLE fiz_kategoria AS SELECT * FROM NIKOVITS.fiz_kategoria;

SELECT * FROM dvzcbt.dolgozo;
SELECT * FROM dvzcbt.osztaly;
SELECT * FROM dvzcbt.szeret;
SELECT * FROM dvzcbt.fiz_kategoria;

-- 1. feladat: Kik azok a dolgozók, akik 1982.01.01. után léptek be a céghez?
SELECT dnev Név
FROM dvzcbt.dolgozo
WHERE belepes > TO_DATE('1982.01.01', 'YYYY.MM.DD');

-- 2. feladat: Adjuk meg azon dolgozók nevét, akik nevének a második bet?je 'A'!
SELECT dnev Név
FROM dvzcbt.dolgozo
WHERE SUBSTR(dnev, 2, 1) = 'A';

SELECT dnev Név
FROM dvzcbt.dolgozo
WHERE dnev LIKE '_A%';

-- 3. feladat: Adjuk meg azon dolgozók nevét, akik nevében van legalább két 'L' bet?!
SELECT dnev Név
FROM dvzcbt.dolgozo
WHERE dnev LIKE '%L%L%';

SELECT dnev Név
FROM dvzcbt.dolgozo
WHERE INSTR(dnev, 'L', 1, 2) > 0;

SELECT dnev Név
FROM dvzcbt.dolgozo
WHERE LENGTH(REPLACE(dnev, 'L', '')) <= LENGTH(dnev) - 2;

-- 4. feladat: Listázzuk ki a dolgozók nevét és fizetését, valamint jelenítsük meg a fizetésüket grafikusan is úgy,
-- hogy a fizetés 1000$-ra kerekítve, minden 1000$-t egy '%' jel jelöl!
SELECT dnev Név, fizetes Fizetés, LPAD(' ', TRUNC(fizetes / 1000) + 1, '%') AS Fizu
FROM dvzcbt.dolgozo
ORDER BY Fizu DESC;

-- 5. feladat: Adjuk meg, hogy milyen napra esett KING belépési dátuma hónapjának napján!
SELECT dnev Név, belepes Belépés, TO_CHAR(LAST_DAY(belepes), 'Day') Nap
FROM dvzcbt.dolgozo
WHERE UPPER(dnev) = 'KING';

-- 6. feladat: Adjuk meg azokat a név, f?nök párokat, akiknek a neve olyan hosszú, mint a f?nöküké!
SELECT '(' || d1.dnev || ', ' || d2.dnev || ')' F?nök
FROM dvzcbt.dolgozo d1, dvzcbt.dolgozo d2
WHERE d1.fonoke = d2.dkod AND Length(d1.dnev) = Length(d2.dnev);

-- 7. feladat: Adjuk meg azon osztályok nevét és telephelyét, amelynek van 1.es fizetési kategóriájú dolgozója!
SELECT DISTINCT onev Osztály, telephely Telephely 
FROM dvzcbt.dolgozo NATURAL JOIN dvzcbt.osztaly, dvzcbt.fiz_kategoria
WHERE fizetes BETWEEN also AND felso AND kategoria = 1