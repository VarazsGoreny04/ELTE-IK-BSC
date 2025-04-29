SELECT plan_table_output FROM TABLE(dbms_xplan.display());

SELECT * FROM dvzcbt.dolgozo;
SELECT * FROM dvzcbt.osztaly;
SELECT * FROM dvzcbt.fiz_kategoria;

-- 1. feladat:
/*
Írjunk olyan lekérdezéseket, amelyek végrehajtási tervében el?fordulnak a következ? m?veletek:

SORT GROUP BY, SORT ORDER BY, SORT UNIQUE, SORT AGGREGATE,
HASH JOIN, MERGE JOIN, NESTED LOOPS, UNION-ALL, MINUS,
INDEX RANGE SCAN, INDEX UNIQUE SCAN, TABLE ACCESS FULL, BITMAP INDEX
HASH UNIQUE, HASH GROUP BY
*/

-- SORT GROUP BY, TABLE ACCESS FULL
EXPLAIN PLAN FOR
SELECT DISTINCT dkod, dnev
FROM dvzcbt.dolgozo
GROUP BY dnev, dkod
HAVING dkod > 7900
ORDER BY dkod DESC, dnev ASC;

-- SORT ORDER BY
EXPLAIN PLAN FOR
SELECT DISTINCT dkod, dnev
FROM dvzcbt.dolgozo
ORDER BY dkod DESC, dnev ASC;

-- SORT UNIQUE, NESTED LOOPS, INDEX RANGE SCAN
EXPLAIN PLAN FOR
SELECT *
FROM dvzcbt.osztaly
WHERE oazon IN (SELECT oazon FROM dvzcbt.dolgozo WHERE dkod > 7900);

-- SORT AGGREGATE
EXPLAIN PLAN FOR
SELECT SUM(fizetes)
FROM dvzcbt.dolgozo;

-- HASH UNIQUE, HASH JOIN
CREATE INDEX ii3 ON fiz_kategoria(kategoria);

EXPLAIN PLAN FOR
SELECT DISTINCT o.onev
FROM (dvzcbt.dolgozo d NATURAL JOIN dvzcbt.osztaly o) CROSS JOIN dvzcbt.fiz_kategoria f
WHERE d.fizetes BETWEEN f.also AND f.felso AND f.kategoria = 1;

-- SORT UNIQUE, UNION-ALL
EXPLAIN PLAN FOR
SELECT *
FROM dvzcbt.osztaly
UNION
SELECT *
FROM dvzcbt.osztaly;

-- SORT UNIQUE, MINUS
EXPLAIN PLAN FOR
SELECT *
FROM dvzcbt.osztaly
MINUS
SELECT *
FROM dvzcbt.osztaly;

-- INDEX UNIQUE SCAN
EXPLAIN PLAN FOR
SELECT SUM(fizetes)
FROM dvzcbt.dolgozo
WHERE dkod = 7900;

-- MERGE JOIN
EXPLAIN PLAN FOR
SELECT *
FROM dvzcbt.dolgozo NATURAL JOIN dvzcbt.osztaly;

EXPLAIN PLAN FOR
SELECT *
FROM dvzcbt.dolgozo CROSS JOIN dvzcbt.osztaly;

EXPLAIN PLAN FOR
SELECT *
FROM dvzcbt.dolgozo, dvzcbt.osztaly;

-- HASH GROUP BY
EXPLAIN PLAN FOR
SELECT COUNT(dkod), dnev
FROM dvzcbt.dolgozo
GROUP BY dnev;


-- 2. feladat:
/*
Hozzunk létre indexet valamelyik táblához, majd adjuk meg a rendszer által
létrehozott új végrehajtási tervet. Olyan indexet hozzunk létre, amit
a lekérdezésben használni tud a rendszer és ez legyen is látható az új tervbõl.
*/
CREATE INDEX ii3 ON fiz_kategoria(kategoria);

-- Adjuk meg azoknak az osztalyoknak a neveit, amelyeknek van olyan dolgozoja aki az 1-es fizetesi kategoriaba esik!
EXPLAIN PLAN FOR
SELECT DISTINCT o.onev
FROM (dolgozo d NATURAL JOIN osztaly o) CROSS JOIN fiz_kategoria f
WHERE d.fizetes BETWEEN f.also AND f.felso AND f.kategoria = 1;

-- 4. feladat:
/*
Adjuk meg a következõ lekérdezéseket és a hozzájuk tartozó végrehajtási
tervek fa struktúráját. Minden esetben lehet hinteket használni.
CIKK(ckod, cnev, szin, suly)
SZALLITO(szkod, sznev, statusz, telephely)
PROJEKT(pkod, pnev, helyszin)
SZALLIT(szkod, ckod, pkod, mennyiseg, datum)
-- 4.1
Adjuk meg a piros cikkekre vonatkozó szállitások összmennyiségét.
(vagyis a szallit táblabeli mennyiségek összegét adjuk meg)
*/
EXPLAIN PLAN FOR
SELECT /*+ NO_INDEX(sz) NO_INDEX(c)*/ SUM(sz.mennyiseg) ossz_szallit
FROM nikovits.szallit sz NATURAL JOIN nikovits.cikk c
WHERE c.szin = 'PIROS';

SELECT plan_table_output FROM TABLE(dbms_xplan.display());



















SELECT * FROM vdani.emp;

SELECT STATEMENT
  TABLE ACCESS FULL EMP;

EXPLAIN PLAN FOR
SELECT *
FROM vdani.emp;

SELECT plan_table_output FROM TABLE(dbms_xplan.display());

--------------------------------
SELECT STATEMENT
  HASH UNIQUE
    TABLE ACCESS FULL EMP;
    
EXPLAIN PLAN FOR
SELECT /*+ FULL(e)*/ DISTINCT deptno
FROM vdani.emp e;

SELECT plan_table_output FROM TABLE(dbms_xplan.display());

--------------------------------
SELECT STATEMENT 
  SORT  UNIQUE   
    TABLE ACCESS  FULL  EMP;
    
EXPLAIN PLAN FOR
SELECT /*+ FULL(e)*/ DISTINCT deptno
FROM vdani.emp e
ORDER BY deptno;

SELECT plan_table_output FROM TABLE(dbms_xplan.display());

--------------------------------------
SELECT STATEMENT
  SORT ORDER BY
    TABLE ACCESS FULL EMP;

EXPLAIN PLAN FOR
SELECT *
FROM vdani.emp
ORDER BY deptno;

SELECT plan_table_output FROM TABLE(dbms_xplan.display());

-------------------------------------------------
SELECT STATEMENT
  HASH  GROUP BY
    TABLE ACCESS  FULL  EMP;
    
EXPLAIN PLAN FOR
SELECT /*+ FULL(e)*/ deptno
FROM vdani.emp e
GROUP BY deptno;

SELECT plan_table_output FROM TABLE(dbms_xplan.display());

--------------------------------
SELECT STATEMENT
  SORT GROUP BY
    TABLE ACCESS FULL EMP;

EXPLAIN PLAN FOR
SELECT /*+ FULL(e)*/ deptno
FROM vdani.emp e
GROUP BY deptno
ORDER BY deptno;

SELECT plan_table_output FROM TABLE(dbms_xplan.display());

-------------------------------------------------
SELECT STATEMENT
  FILTER
    HASH GROUP BY
      TABLE ACCESS FULL EMP;
      
EXPLAIN PLAN FOR
SELECT /*+ FULL(e)*/ deptno
FROM vdani.emp e
GROUP BY deptno
HAVING deptno > 20;

SELECT plan_table_output FROM TABLE(dbms_xplan.display());

---------------------------------
SELECT STATEMENT
  FILTER      
    SORT  GROUP BY    
      TABLE ACCESS  FULL  EMP;

EXPLAIN PLAN FOR
SELECT /*+ FULL(e)*/ deptno
FROM vdani.emp e
GROUP BY deptno
HAVING deptno > 20
ORDER BY deptno;

SELECT plan_table_output FROM TABLE(dbms_xplan.display());

----------------------------------
SELECT STATEMENT      
  HASH JOIN      
    TABLE ACCESS  FULL  DEPT
    TABLE ACCESS  FULL  EMP;

EXPLAIN PLAN FOR
SELECT *
FROM vdani.dept NATURAL JOIN vdani.emp;

EXPLAIN PLAN FOR
SELECT *
FROM vdani.dept d, vdani.emp e
WHERE d.deptno = e.deptno;

SELECT plan_table_output FROM TABLE(dbms_xplan.display());

-- Masodik terv
SELECT STATEMENT
  MERGE JOIN
    SORT JOIN
      TABLE ACCESS FULL DEPT
    SORT JOIN
      TABLE ACCESS FULL EMP;
      
      
EXPLAIN PLAN FOR
SELECT /*+ USE_MERGE(e d)*/ *
FROM vdani.emp e JOIN vdani.dept d ON e.deptno = d.deptno;

-- Harmadik terv
SELECT STATEMENT            
  NESTED LOOPS              
    TABLE ACCESS FULL DEPT
    TABLE ACCESS FULL EMP; 

EXPLAIN PLAN FOR
SELECT /*+ USE_NL(e d)*/ *
FROM vdani.emp e JOIN vdani.dept d ON e.deptno = d.deptno;

-------------------------------------------------------
SELECT STATEMENT
   SORT UNIQUE
     UNION-ALL
       TABLE ACCESS FULL EMP
       TABLE ACCESS FULL DEPT;

EXPLAIN PLAN FOR
SELECT /*+ FULL(d)*/ deptno
FROM vdani.dept d
UNION
SELECT /*+ FULL(e)*/ deptno
FROM vdani.emp e;

SELECT plan_table_output FROM TABLE(dbms_xplan.display());

-----------------------------------------------------------
SELECT STATEMENT
  UNION-ALL
    TABLE ACCESS FULL EMP
    TABLE ACCESS FULL DEPT;

EXPLAIN PLAN FOR
SELECT /*+ FULL(d)*/ deptno
FROM vdani.dept d
UNION ALL
SELECT /*+ FULL(e)*/ deptno
FROM vdani.emp e;

SELECT plan_table_output FROM TABLE(dbms_xplan.display());

-------------------------------------------------------
SELECT STATEMENT
  MINUS
    SORT UNIQUE
      TABLE ACCESS FULL DEPT
    SORT UNIQUE
      TABLE ACCESS FULL EMP;

EXPLAIN PLAN FOR
SELECT /*+ FULL(d)*/ deptno
FROM vdani.dept d
MINUS
SELECT /*+ FULL(e)*/ deptno
FROM vdani.emp e;

SELECT plan_table_output FROM TABLE(dbms_xplan.display());

------------------------------------------------
SELECT STATEMENT   
  HASH JOIN  SEMI  
    TABLE ACCESS  FULL  EMP 
    TABLE ACCESS  FULL  DEPT;
    
EXPLAIN PLAN FOR
SELECT ename
FROM vdani.emp
WHERE deptno IN (SELECT deptno FROM vdani.dept d);

SELECT plan_table_output FROM TABLE(dbms_xplan.display());

----------------------------------------
SELECT STATEMENT
  FILTER
    TABLE ACCESS FULL EMP
    TABLE ACCESS FULL DEPT;
    
EXPLAIN PLAN FOR
SELECT ename
FROM vdani.emp
WHERE deptno IN (SELECT /*+ NO_UNNEST*/ deptno FROM vdani.dept);

SELECT plan_table_output FROM TABLE(dbms_xplan.display());

------------------------------------------------
SELECT STATEMENT
  FILTER
    TABLE ACCESS FULL EMP
    TABLE ACCESS FULL DEPT

-- Másik terv
SELECT STATEMENT +  + 
  HASH JOIN + ANTI NA + 
    TABLE ACCESS + FULL + EMP
    TABLE ACCESS + FULL + DEPT
    
-----------------------------------------
SELECT STATEMENT      
  HASH JOIN  ANTI    
    TABLE ACCESS  FULL  EMP 
    TABLE ACCESS  FULL  DEPT
    
---------------------------------------
  SELECT STATEMENT
    TABLE ACCESS BY INDEX ROWID EMP
      INDEX RANGE SCAN ENAME