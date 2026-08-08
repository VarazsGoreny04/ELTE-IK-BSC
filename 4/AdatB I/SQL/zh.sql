SELECT * FROM osztaly;
SELECT * FROM dolgozo;

-- 1.
SELECT oazon, telephely
FROM osztaly o
MINUS
SELECT o.oazon, telephely
FROM osztaly o JOIN dolgozo d ON  o.oazon = d.oazon;
/*
40	BOSTON
*/

-- 2.
SELECT f.dnev, d.dnev, d.fizetes
FROM dolgozo f, dolgozo d
WHERE f.foglalkozas = 'PRESIDENT' AND f.dkod = d.fonoke AND (d.oazon = 10 OR d.oazon = 20);
/*
KING	JONES	2975
KING	CLARK	2450
*/

-- 3.
SELECT d.dnev, d.belepes
FROM dolgozo f, dolgozo d
WHERE f.dkod = d.fonoke AND d.belepes + 300 <= f.belepes;
/*
SMITH	80-DEC.-17
*/

-- 4.
SELECT o.oazon, AVG(fizetes) fizu
FROM osztaly o JOIN dolgozo d ON  o.oazon = d.oazon
GROUP BY
 o.oazon
fetch first 1 row only;
/*
30	1800
*/

SELECT * FROM szeret;

-- 5.
SELECT gyumolcs, n.num - COUNT(*) nem
FROM szeret, (SELECT COUNT(*) num FROM (SELECT DISTINCT nev FROM szeret)) n
GROUP BY gyumolcs, n.num;
/*
k�rte	1
dinnye	3
alma	0
*/

-- 6.
SELECT a.nev, b.nev
FROM szeret a JOIN szeret b ON a.gyumolcs = b.gyumolcs,
(SELECT nev, COUNT(*) sz FROM szeret GROUP BY nev) c, 
(SELECT nev, COUNT(*) sz FROM szeret GROUP BY nev) d 
WHERE a.nev != b.nev AND a.nev = c.nev AND b.nev = d.nev
GROUP BY a.nev, b.nev, c.sz, d.sz
HAVING c.sz = COUNT(*) AND d.sz = COUNT(*);
/*
Micimack�	Tigris
Tigris	Micimack�
*/