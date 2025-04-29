SELECT *
FROM dba_segments s
ORDER BY segment_name;

DESCRIBE dba_segments;

SELECT *
FROM dba_extents;

SELECT *
FROM dba_data_files;

SELECT *
FROM dba_tables;

-- Hol vannak Nikovits felhasználó Szallit táblájának az adatai tárolva?
SELECT *
FROM dba_tables t
WHERE owner = 'NIKOVITS' AND t.table_name = 'SZALLIT';

SELECT *
FROM dba_segments s
WHERE owner = 'NIKOVITS' AND s.segment_name = 'SZALLIT';

SELECT *
FROM dba_extents e
WHERE owner = 'NIKOVITS' AND e.segment_name = 'SZALLIT';

SELECT *
FROM dba_data_files
WHERE file_id IN (
    SELECT DISTINCT file_id
    FROM dba_extents e
    WHERE owner = 'NIKOVITS' AND e.segment_name = 'SZALLIT'
);

-- Adjuk meg adatfájlonként, hogy az egyes adatfájlokban mennyi a foglalt hely összesen!
SELECT d.file_name, d.bytes, e.ex_size
FROM dba_data_files d NATURAL JOIN (
    SELECT file_id, SUM(bytes) AS ex_size
    FROM dba_extents
    GROUP BY file_id) e;
    
-- Melyik két felhasználó adatai foglalják a legtöbb helyet az adatbázisban?
SELECT owner, SUM(bytes) AS seg_size
FROM dba_segments
GROUP BY owner
ORDER BY seg_size DESC
FETCH FIRST 2 ROW ONLY;

SELECT owner, SUM(bytes) AS ex_size
FROM dba_extents
GROUP BY owner
ORDER BY ex_size DESC
FETCH FIRST 2 ROW ONLY;

-- Van-e Nikovits felhasználónak olyan táblája, ami több adatfájlban is foglal helyet?
SELECT segment_name, COUNT(DISTINCT file_id) files
FROM dba_extents
WHERE owner = 'NIKOVITS' AND  segment_type = 'TABLE'
GROUP BY segment_name
HAVING COUNT(DISTINCT file_id) > 1;

-- Mekkora összefügg? szabad terület van a 'user01.dbf' nev? adatfájlban?
-- Mekkora ezek összmérete?
SELECT COUNT(*), SUM(f.bytes)
FROM dba_free_space f, dba_data_files d
WHERE d.file_name LIKE '%user01.dbf%' AND d.file_id = f.file_id;

-- Hány százalékban foglaltak az adatfájlok?
SELECT d.file_name, SUM(e.bytes) / d.bytes * 100
FROM dba_data_files d, dba_extents e
WHERE d.file_id = e.file_id
GROUP BY d.file_id, d.bytes;

-- Melyik táblatérben van az ORAUSER falhasznalo DOLGOZO táblája?
SELECT tablespace_name
FROM dba_tables t
WHERE t.owner = 'ORAUSER' AND t.table_name = 'DOLGOZO';


