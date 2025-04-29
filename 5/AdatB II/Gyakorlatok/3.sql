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

-- Hol vannak Nikovits felhaszn�l� Szallit t�bl�j�nak az adatai t�rolva?
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

-- Adjuk meg adatf�jlonk�nt, hogy az egyes adatf�jlokban mennyi a foglalt hely �sszesen!
SELECT d.file_name, d.bytes, e.ex_size
FROM dba_data_files d NATURAL JOIN (
    SELECT file_id, SUM(bytes) AS ex_size
    FROM dba_extents
    GROUP BY file_id) e;
    
-- Melyik k�t felhaszn�l� adatai foglalj�k a legt�bb helyet az adatb�zisban?
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

-- Van-e Nikovits felhaszn�l�nak olyan t�bl�ja, ami t�bb adatf�jlban is foglal helyet?
SELECT segment_name, COUNT(DISTINCT file_id) files
FROM dba_extents
WHERE owner = 'NIKOVITS' AND  segment_type = 'TABLE'
GROUP BY segment_name
HAVING COUNT(DISTINCT file_id) > 1;

-- Mekkora �sszef�gg? szabad ter�let van a 'user01.dbf' nev? adatf�jlban?
-- Mekkora ezek �sszm�rete?
SELECT COUNT(*), SUM(f.bytes)
FROM dba_free_space f, dba_data_files d
WHERE d.file_name LIKE '%user01.dbf%' AND d.file_id = f.file_id;

-- H�ny sz�zal�kban foglaltak az adatf�jlok?
SELECT d.file_name, SUM(e.bytes) / d.bytes * 100
FROM dba_data_files d, dba_extents e
WHERE d.file_id = e.file_id
GROUP BY d.file_id, d.bytes;

-- Melyik t�blat�rben van az ORAUSER falhasznalo DOLGOZO t�bl�ja?
SELECT tablespace_name
FROM dba_tables t
WHERE t.owner = 'ORAUSER' AND t.table_name = 'DOLGOZO';


