-- Vegyuk 2012. februarjanak elso hetfojet es adjuk meg hogy osszesen hany darab telefonhivast kezdemenyeztek a megelozo napon a Szentendrei primer kozpontbol! 
SELECT SUM(darab)
FROM nikovits.hivas h, nikovits.kozpont k, nikovits.primer p
WHERE h.kozp_azon_hivo = k.kozp_azon 
      AND k.primer = p.korzet
      AND h.datum = next_day(TO_DATE('2012.01.31', 'yyyy.mm.dd'), 'hétf?') - 1;
 
SELECT rowid, dnev,
       dbms_rowid.rowid_object(rowid) adatobj,
       dbms_rowid.rowid_relative_fno(rowid) fajl,
       dbms_rowid.rowid_block_number(rowid) blokk,
       dbms_rowid.rowid_row_number(rowid) sor
FROM nikovits.dolgozo
WHERE dnev = 'KING';
 
SELECT * FROM dba_objects WHERE object_id = 73727;
SELECT * FROM dba_data_files WHERE file_id = 7;
 
SELECT *
FROM dba_indexes
WHERE owner = 'NIKOVITS' AND index_name = 'EMP2';

SELECT *
FROM dba_ind_columns
WHERE index_owner = 'NIKOVITS' AND index_name = 'EMP2';
 
SELECT *
FROM dba_ind_expressions
WHERE index_owner = 'NIKOVITS' AND index_name = 'EMP2';
 
-- Adjuk meg azokat a tablakat amelyeknek van csokkeno sorrendben indexelt oszlopa!
SELECT table_owner, table_name, column_name
FROM dba_ind_columns
WHERE descend = 'DESC'
GROUP BY table_owner, table_name, column_name;
 
-- Adjuk meg azoknak a tablaknak a nevet, amelyek legalabb 9 oszloposak. (Vagyis a tablanak legalabb 9 oszlopat vagy kifejezeset indexelik.)
SELECT index_owner, index_name, COUNT(column_name) cc
FROM dba_ind_columns
GROUP BY index_owner, index_name
HAVING COUNT(table_name) >= 9;
 
-- Hozzunk letre egy indexet a DOLGOZO tabla oazon oszlopara.
 
CREATE TABLE dolgozo AS SELECT * FROM nikovits.dolgozo;
 
CREATE INDEX dolgozo_oazon ON dolgozo(oazon);
SELECT * FROM dba_indexes WHERE owner = 'DVZCBT';