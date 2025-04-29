SELECT *
FROM dba_objects;

SELECT owner, object_name
FROM dba_objects
WHERE object_name = 'DBA_TABLES' AND object_type = 'VIEW';

SELECT owner, object_name
FROM dba_objects
WHERE object_name='DBA_TABLES' AND object_type='SYNONYM';

SELECT DISTINCT object_type
FROM dba_objects
WHERE owner = 'ORAUSER';

SELECT COUNT(DISTINCT object_type) type_count
FROM dba_objects;

SELECT DISTINCT object_type
FROM dba_objects;

SELECT owner, COUNT(DISTINCT object_type) diff_obj_typ
FROM dba_objects
GROUP BY owner
HAVING COUNT(DISTINCT object_type) > 10
ORDER BY owner;

SELECT DISTINCT owner
FROM dba_objects
WHERE object_type = 'VIEW'
MINUS
SELECT DISTINCT owner
FROM dba_objects
WHERE object_type = 'TRIGGER';

SELECT owner
FROM dba_objects
WHERE object_type = 'TABLE'
GROUP BY owner
HAVING COUNT(object_type) > 40
INTERSECT
SELECT owner
FROM dba_objects
WHERE object_type = 'INDEX'
GROUP BY owner
HAVING COUNT(object_type) <= 37;

SELECT DISTINCT object_type
FROM dba_objects
WHERE data_object_id IS NULL;

SELECT DISTINCT object_type
FROM dba_objects
WHERE data_object_id IS NULL
INTERSECT
SELECT DISTINCT object_type
FROM dba_objects
WHERE data_object_id IS NOT NULL;

------------------------------------------------------------------------------------

SELECT *
FROM dba_tab_columns;

SELECT owner, table_name, COUNT(table_name) col_count
FROM dba_tab_columns
WHERE owner = 'NIKOVITS' AND table_name = 'EMP'
GROUP BY owner, table_name;

SELECT DISTINCT owner, table_name, column_name
FROM dba_tab_columns
WHERE column_name LIKE '%Z';

SELECT owner, table_name
FROM dba_tab_columns
WHERE data_type = 'DATE'
GROUP BY owner, table_name
HAVING COUNT(data_type) >= 8;

SELECT owner, table_name
FROM dba_tab_columns
WHERE data_type = 'VARCHAR2' AND column_id = 1
INTERSECT
SELECT owner, table_name
FROM dba_tab_columns
WHERE data_type = 'VARCHAR2' AND column_id = 4;

CREATE OR REPLACE PROCEDURE selecting(beg VARCHAR2) IS
    CURSOR c1 IS (SELECT owner, table_name
                  FROM dba_tables
                  WHERE table_name LIKE UPPER(beg) || '%');
    rec c1%ROWTYPE;
BEGIN
    FOR rec IN c1 LOOP
        dbms_output.put_line(rec.owner || ' - ' || rec.table_name);
    END LOOP;
END;
/

SET SERVEROUTPUT ON
EXECUTE selecting('a');

------------------------------------------------------------------------------------

SELECT *
FROM dba_tables;

SELECT *
FROM dba_segments;

SELECT *
FROM dba_extents;

SELECT *
FROM dba_clusters;

SELECT *
FROM dba_data_files;

SELECT *
FROM dba_data_objects;

SELECT *
FROM dba_indexes;

SELECT owner, table_name
FROM dba_tab_columns
GROUP BY owner, table_name
HAVING COUNT(DISTINCT data_type) = 26;

SELECT COUNT(DISTINCT owner)
FROM (SELECT owner, segment_name
      FROM dba_extents
      WHERE segment_type = 'TABLE'
      GROUP BY owner, segment_name
      HAVING COUNT(DISTINCT file_id) > 1);
      
SELECT COUNT(*)
FROM dba_extents e, dba_data_files f
WHERE e.file_id = f.file_id AND e.owner = 'VDANI' AND f.file_name LIKE '%users02.dbf';

SELECT COUNT(*)
FROM dba_extents
WHERE owner = 'VDANI'
AND file_id = (
    SELECT file_id 
    FROM dba_data_files 
    WHERE file_name LIKE '%users02.dbf%'
);

SELECT owner, cluster_name
FROM (SELECT * FROM dba_tables WHERE cluster_name IS NOT NULL)
GROUP BY owner, cluster_name
HAVING COUNT(table_name) > 10;

SELECT owner, cluster_name
FROM dba_tables
GROUP BY owner, cluster_name
HAVING COUNT(table_name) > 10
and cluster_name is not null;

SELECT *
FROM dba_objects
WHERE owner = 'NIKOVITS' AND object_name = 'HALLGATOK' AND object_type = 'TABLE';


select dbms_rowid.rowid_relative_fno(ROWID) fid,
                        dbms_rowid.rowid_block_number(ROWID) bid
                        from nikovits.hallgatok
                        group by dbms_rowid.rowid_relative_fno(ROWID),
                                dbms_rowid.rowid_block_number(ROWID);

create or replace procedure konzi is
    cursor exs is select file_id, block_id, blocks
                from dba_extents
                where owner='NIKOVITS'
                and segment_name='HALLGATOK';
                
    cursor foglalt is select dbms_rowid.rowid_relative_fno(ROWID) fid,
                        dbms_rowid.rowid_block_number(ROWID) bid
                        from nikovits.hallgatok
                        group by dbms_rowid.rowid_relative_fno(ROWID),
                                dbms_rowid.rowid_block_number(ROWID);
    vanbenne boolean;
begin
    for ext in exs loop
        for bc in ext.block_id..ext.block_id+7 loop
        
            vanbenne := false;
            for fog in foglalt loop
                if fog.bid = bc and fog.fid = ext.file_id then
                    vanbenne := true;
                end if;
            end loop;
            
            if not vanbenne then
                dbms_output.put_line(ext.file_id || ', ' || bc);
            end if;
            
        end loop;
    end loop;
end;
/

execute konzi;