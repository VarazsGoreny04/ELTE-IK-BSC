SELECT * FROM dvzcbt.dolgozo;
SELECT * FROM dvzcbt.osztaly;
SELECT * FROM dvzcbt.szeret;
SELECT * FROM dvzcbt.fiz_kategoria;

-- 1. feladat: Adjuk meg aazokat az osztályokat és átlagfizetéseket, ahol az nagyobb, mint 2000!
SELECT oazon Osztály, ROUND(AVG(fizetes), 2) Fizu
FROM dvzcbt.dolgozo
GROUP BY oazon
HAVING AVG(fizetes) > 2000;

-- 2. feladat: Adjuk meg az átlagfizetést azokon az osztályokon, ahol legalább 4-en dolgoznak!
SELECT oazon Osztály, ROUND(AVG(fizetes), 2) Fizu
FROM dvzcbt.dolgozo
GROUP BY oazon
HAVING COUNT(*) >= 4;

-- 3. feladat: Adjuk meg az fizetéseket és a telephelyeket, azokon az osztályokon, ahol legalább 4-en dolgoznak!
SELECT oazon, ROUND(AVG(fizetes), 2) Fizu, telephely
FROM dvzcbt.dolgozo NATURAL JOIN dvzcbt.osztaly
GROUP BY oazon, telephely
HAVING COUNT(*) >= 4;

-- 4. feladat: Adjuk meg azon osztályok nevét és telephelyét, ahol az átlagfizetés nagyobb mint 2000!
SELECT onev, telephely
FROM dvzcbt.dolgozo NATURAL JOIN dvzcbt.osztaly
GROUP BY onev, telephely
HAVING Avg(fizetes) > 2000
ORDER BY onev;

-- 5. feladat: Adjuk meg azokat a fizetési kategóriákat, amikbe pontosan 3 dolgozó fizetése esik!
SELECT kategoria Kategória
FROM dvzcbt.dolgozo d, dvzcbt.fiz_kategoria f
WHERE d.fizetes BETWEEN f.also AND f.felso
GROUP BY kategoria
HAVING Count(kategoria) = 3
ORDER BY kategoria;

-- 6. feladat: Adjuk meg azon osztályok nevét és telephelyét, ahol van 1-es fizetési kategóriájú dolgozó!
SELECT onev, telephely, kategoria
FROM dvzcbt.dolgozo NATURAL JOIN dvzcbt.osztaly, dvzcbt.fiz_kategoria
WHERE fizetes BETWEEN also AND felso AND kategoria = 1
GROUP BY onev, telephely, kategoria;

SELECT onev, telephely, kategoria
FROM dvzcbt.dolgozo NATURAL JOIN dvzcbt.osztaly, dvzcbt.fiz_kategoria
WHERE fizetes BETWEEN also AND felso
GROUP BY onev, telephely, kategoria
HAVING kategoria = 1;


-- 7. feladat: Kik szeretnek minden gyümölcsöt?
SELECT nev
FROM dvzcbt.szeret
GROUP BY nev
HAVING Count(gyumolcs) = (SELECT Count(DISTINCT gyumolcs) FROM dvzcbt.szeret);