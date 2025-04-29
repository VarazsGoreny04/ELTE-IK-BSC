SELECT *
FROM dba_clusters;

SELECT *
FROM dba_clu_columns
WHERE owner = 'NIKOVITS';

SELECT *
FROM dba_cluster_hash_expressions
WHERE owner = 'NIKOVITS';

-- 1. feladat: Adjuk meg azokat a cluster-eket az adatbazisban amelyeken nincs egy tabla sem!
SELECT owner || '_' || cluster_name fullname FROM (
    SELECT owner, cluster_name
    FROM dba_clusters
    MINUS
    SELECT owner, cluster_name
    FROM dba_clu_columns);
    
-- 2. feladat: Adjuk meg azokat a cluster-eket amelyeken legalabb 2 tabla van!
SELECT owner, cluster_name, COUNT(*)
FROM dba_tables
WHERE cluster_name IS NOT NULL
GROUP BY owner, cluster_name
HAVING COUNT(*) >= 2;

DESCRIBE dba_tables;

-- 3. feladat: Adjuk meg azokat a cluster-eket, amelyeknek a cluster-kulcsa 3 oszlopbol all!
--SELECT owner, cluster_name, tbale_name, COUNT()clu_