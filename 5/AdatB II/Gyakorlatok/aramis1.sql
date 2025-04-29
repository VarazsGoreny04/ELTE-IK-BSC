SELECT * 
FROM dba_indexes;

SELECT index_owner, index_name, COUNT(column_name) 
FROM dba_ind_columns
GROUP BY index_owner, index_name
HAVING COUNT(column_name) >= 9;

SELECT index_name
FROM dba_indexes
WHERE owner = 'VDANI' AND index_type LIKE '%BITMAP%';

SELECT index_owner, index_name
FROM dba_ind_columns
GROUP BY index_owner, index_name
HAVING COUNT(*) = 2
INTERSECT
SELECT owner, index_name
FROM dba_indexes
WHERE index_type LIKE '%FUNCTION-BASED%';

SELECT *
FROM dba_data_files;

SELECT COUNT(*) spaceNum, SUM(bytes) spaceSize
FROM dba_free_space
WHERE file_id = (SELECT file_id FROM dba_data_files WHERE file_name LIKE '%users01%');

SELECT *
FROM dba_data_files d, dba_free_space f
WHERE d.file_id = f.file_id AND d.file_name LIKE '%users01.dbf';