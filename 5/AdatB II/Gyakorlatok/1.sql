ALTER USER dvzcbt IDENTIFIED BY < jelsz� >;

SELECT table_name, tablespace_name FROM user_tables;
SELECT * FROM user_tables;

SELECT *
FROM all_sequences
WHERE sequence_owner IN ('MDSYS', 'XDB');

SELECT sequence_name, min_value, max_value, increment_by
FROM all_sequences
WHERE sequence_owner IN ('MDSYS', 'XDB');

SELECT *
FROM dba_users
WHERE account_status = 'OPEN';

SELECT *
FROM dba_indexes;

DESCRIBE dba_indexes;

-- gyak1

DROP TABLE gyak1;

CREATE TABLE gyak1 (id number);

SELECT *
FROM gyak1;

SELECT * FROM dba_tables WHERE table_name = 'gyak1';

ANALYZE TABLE gyak1 COMPUTE STATISTICS;

--

-- EMP

SELECT *
FROM dba_tab_columns
WHERE owner = 'KOTROCZO' AND table_name = 'EMP';

CREATE OR REPLACE VIEW v1 AS
SELECT deptno, AVG(sal) vqSa1
FROM kotroczo.emp
GROUP BY deptno;

SELECT * FROM kotroczo.emp;
SELECT * FROM v1;

--

SELECT view_name, text FROM dba_views WHERE owner = 'DVZCBT' AND view_name = 'V1';

SELECT * FROM dba_objects;

-- Milyen t�pus� objektumai vannak az ORAUSER felhaszn�l�nak az adatb�zisban?

SELECT object_type
FROM dba_objects
WHERE 

-- H�ny k�l�nb�z? t�pus� objektum van nyilv�ntartva az adatb�zisban?

SELECT COUNT(DISTINCT object_type) FROM dba_objects;

-- Kik azok a felhaszn�l�k akiknek van n�zezete, de nincs trigger-je?

SELECT DISTINCT owner FROM dba_objects WHERE object_type = 'VIEW'
MINUS
SELECT DISTINCT owner FROM dba_objects WHERE object_type = 'TRIGGER';