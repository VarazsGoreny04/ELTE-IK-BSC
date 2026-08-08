CREATE TABLE szeret AS SELECT * FROM  NIKOVITS.szeret;

SELECT *
FROM dvzcbt.szeret;

-- 1. feladat: Adjuk meg azokat a gyümölcsöket amelyeket Micimackó szeret!
SELECT gyumolcs AS "Gyümölcs"
FROM dvzcbt.szeret
WHERE nev = 'Micimackó';

-- 2. feladat: Adjuk meg azokat a gyümölcsöket amelyeket Micimackó nem szeret!
SELECT gyumolcs AS "Gyümölcs"
FROM dvzcbt.szeret
MINUS
SELECT gyumolcs
FROM dvzcbt.szeret
WHERE nev = 'Micimackó';

-- 3. feladat: Adjuk meg azoknak a nevét akik nem szeretik a körtét!
SELECT nev AS "Név"
FROM dvzcbt.szeret
MINUS
SELECT nev
FROM dvzcbt.szeret
WHERE gyumolcs = 'körte';

-- 4. feladat: Adjuk meg azoknak a nevét akik szeretik az almát, de nem szeretik a körtét!
SELECT nev AS "Név"
FROM dvzcbt.szeret
WHERE gyumolcs = 'alma'
MINUS
SELECT nev
FROM dvzcbt.szeret
WHERE gyumolcs = 'körte';