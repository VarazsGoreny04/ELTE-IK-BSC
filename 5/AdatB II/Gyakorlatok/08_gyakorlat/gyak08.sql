DROP TABLE plan_table;
create table PLAN_TABLE (
        statement_id       varchar2(30),
        plan_id            number,
        timestamp          date,
        remarks            varchar2(4000),
        operation          varchar2(30),
        options            varchar2(255),
        object_node        varchar2(128),
        object_owner       varchar2(30),
        object_name        varchar2(30),
        object_alias       varchar2(65),
        object_instance    numeric,
        object_type        varchar2(30),
        optimizer          varchar2(255),
        search_columns     number,
        id                 numeric,
        parent_id          numeric,
        depth              numeric,
        position           numeric,
        cost               numeric,
        cardinality        numeric,
        bytes              numeric,
        other_tag          varchar2(255),
        partition_start    varchar2(255),
        partition_stop     varchar2(255),
        partition_id       numeric,
        other              long,
        distribution       varchar2(30),
        cpu_cost           numeric,
        io_cost            numeric,
        temp_space         numeric,
        access_predicates  varchar2(4000),
        filter_predicates  varchar2(4000),
        projection         varchar2(4000),
        time               numeric,
        qblock_name        varchar2(30),
        other_xml          clob
);

EXPLAIN PLAN FOR
SELECT *
FROM dolgozo
WHERE dnev = 'KING';

SELECT  plan_table_output FROM table(dbms_xplan.display());

EXPLAIN PLAN FOR
SELECT SUM(fizetes)
FROM dolgozo
WHERE oazon = 10;

SELECT * FROM dolgozo;
SELECT * FROM fiz_kategoria;
SELECT * FROM osztaly;
CREATE INDEX ii3 ON fiz_kategoria(kategoria);

-- Adjuk meg azoknak az osztályoknak a neveit, amelyeknek van olyan dolgozója
-- aki az 1-es fizetési kategóriába esik.
EXPLAIN PLAN FOR
SELECT DISTINCT onev
FROM (dolgozo d NATURAL JOIN osztaly o) CROSS JOIN fiz_kategoria f
WHERE fizetes BETWEEN f.also AND f.felso AND f.kategoria = 1;

SELECT  plan_table_output FROM table(dbms_xplan.display());

EXPLAIN PLAN FOR
SELECT sum(darab) FROM VDANI.hivas, VDANI.kozpont, VDANI.primer
WHERE hivas.kozp_azon_hivo=kozpont.kozp_azon AND kozpont.primer=primer.korzet
AND primer.varos = 'Szentendre' 
AND datum + 1 = next_day(to_date('2012.01.31', 'yyyy.mm.dd'),'hétfõ');

SELECT sum(darab) FROM VDANI.hivas, VDANI.kozpont, VDANI.primer
WHERE hivas.kozp_azon_hivo=kozpont.kozp_azon AND kozpont.primer=primer.korzet
AND primer.varos = 'Szentendre' 
AND datum = next_day(to_date('2012.01.31', 'yyyy.mm.dd'),'hétfõ') - 1;

EXPLAIN PLAN FOR
SELECT /*+ full(f) full(d) full(o) ordered use_nl(o) use_nl(f)*/ DISTINCT onev
FROM (dolgozo d NATURAL JOIN osztaly o) CROSS JOIN fiz_kategoria f
WHERE fizetes BETWEEN f.also AND f.felso AND f.kategoria = 1;

SELECT  plan_table_output FROM table(dbms_xplan.display());

/*
SELECT STATEMENT +  + 
  SORT + AGGREGATE + 
    TABLE ACCESS + FULL + NIKOVITS.CIKK
*/
EXPLAIN PLAN FOR
SELECT SUM(suly)
FROM nikovits.cikk;

/*
SELECT STATEMENT +  + 
  SORT + AGGREGATE + 
    TABLE ACCESS + BY INDEX ROWID + NIKOVITS.CIKK
      INDEX + UNIQUE SCAN + NIKOVITS.C_CKOD
*/
EXPLAIN PLAN FOR
SELECT SUM(suly)
FROM nikovits.cikk
WHERE ckod = 10;

SELECT * FROM dba_indexes WHERE owner = 'NIKOVITS' AND table_name = 'CIKK';

SELECT  plan_table_output FROM table(dbms_xplan.display());