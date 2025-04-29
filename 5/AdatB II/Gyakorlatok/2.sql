DROP SEQUENCE seq1;
CREATE SEQUENCE seq1
MINVALUE 1 MAXVALUE 100 INCREMENT BY 5
START WITH 20 CYCLE;

CREATE TABLE seq_test(
    num_seq number
);

SELECT * FROM seq_test;
INSERT INTO seq_test VALUES (seq1.nextval);

-- Kinek a tulajdonaban talalhato az sz1 es mi pontosan?
SELECT * FROM sz1;

SELECT owner
FROM dba_objects
WHERE object_name = 'SZ1';

SELECT * 
FROM dba_synonyms
WHERE synonym_name = 'SZ1';

-- Linkelés
CREATE DATABASE LINK ullman 
CONNECT TO dvzcbt IDENTIFIED BY <jelszo> 
USING 'ullman.inf.elte.hu:1521/ullman';

SELECT * FROM kotroczo.dolgozo d, kotroczo.osztaly@ullman o WHERE d.oazon = o.oazon;

-- Kik azok a felhasznalok, akiknek tobb, mint 40 tablajuk, de maximum 37 indexuk van?
SELECT owner
FROM dba_objects
WHERE object_type = 'TABLE'
GROUP BY owner
HAVING COUNT(*) > 40
MINUS
SELECT owner
FROM dba_objects
WHERE object_type = 'INDEX'
GROUP BY owner
HAVING COUNT(*) > 37;

-- Adjuk meg azoknak a tablaknak a nevet, amelyeknek legalabb 8 darab datum tipusu oszlopa van!
SELECT table_name, COUNT(data_type)
FROM dba_tab_columns
WHERE data_type = 'DATE'
GROUP BY owner, table_name
HAVING COUNT(*) > 7;

-- Irjunk PLSQL procedurat amely a parameterkent kapott karakterlanc alapjan kiirja azoknak a
-- tablaknak a nevet es tulajdonosat, amelyek az adott karakterlanccal kezdodnek! 
-- (Ha a parameter kisbetus, akkor is mukodjon a procedura!)
CREATE OR REPLACE PROCEDURE table_print (charChain IN VARCHAR2) AS
    CURSOR cursor1 IS 
        SELECT owner, table_name 
        FROM dba_tables 
        WHERE UPPER(table_name) LIKE UPPER(charChain) || '%';
    rec cursor1%rowtype;
BEGIN
    FOR rec IN cursor1 LOOP
        dbms_output.put_line(rec.owner || ' - ' || rec.table_name);
    END LOOP;
END;
/

CALL table_print('al');

-- Melyek azok az objektumok amelyek tenyleges tarolast igenyelnek, vagyis tartoznak hozzajuk
-- adatblokkok?
SELECT DISTINCT object_type
FROM dba_objects
WHERE data_object_id IS NOT NULL;


SELECT DISTINCT object_type
FROM dba_objects
WHERE data_object_id IS NOT NULL
INTERSECT
SELECT DISTINCT object_type
FROM dba_objects
WHERE data_object_id IS NULL;

-- Adjuk meg azoknak a tablaknak a nevet, amelyeknek az elso es negyedik sora is VARCHAR2 tipusu!
SELECT owner, table_name
FROM dba_tab_columns
WHERE data_type = 'VARCHAR2' AND column_id = 1
INTERSECT
SELECT owner, table_name
FROM dba_tab_columns
WHERE data_type = 'VARCHAR2' AND column_id = 4;