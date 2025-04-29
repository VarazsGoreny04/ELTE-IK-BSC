-- L1(A) - T1 tranzakció zárolja A adatbázis elemet
-- U1(A) - T1 tranzakció feloldja A adatbázis elemet

-- L1(A); L2(B); L3(C); L1(D); L2(A); L3(D); L4(B); U1(A); L2(C);
SET AUTOCOMMIT OFF;

DROP TABLE tranz;
CREATE TABLE tranz(
    a INTEGER
);

SELECT * FROM tranz;

COMMIT;

INSERT INTO tranz VALUES (1);

UPDATE tranz SET a = a + 1;

SAVEPOINT ketto;

ROLLBACK TO ketto;

DROP TABLE tr;
CREATE TABLE tr(
    kulcs VARCHAR(10),
    ertek INTEGER
);

INSERT INTO tr VALUES ('A', 2);
INSERT INTO tr VALUES ('B', 3);
INSERT INTO tr VALUES ('C', 1);

SELECT * FROM tr;

COMMIT;

-- 1. Tranzakció

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
SELECT * FROM tr;

UPDATE tr
SET ertek=ertek+1
WHERE kulcs='A';

UPDATE tranz SET a = a + 1;

COMMIT;

-- 2. Tranzakció
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
SELECT * FROM tr;

UPDATE tranz SET a = a + 1;

UPDATE tr
SET ertek=ertek+1
WHERE kulcs='A';

COMMIT;

----------------------

SELECT se.sid, se.username, lo.type, lo.lmode, lo.ctime
FROM v$lock lo, v$session se
WHERE se.sid = lo.sid AND username = 'KOTROCZO';

SELECT se.sid, se.username, lo.type, lo.lmode,
lo.request, lo.ctime, block
FROM v$lock lo, v$session se
WHERE se.sid = lo.sid AND username = 'KOTROCZO';

SELECT lo.oracle_username, lo.session_id,
lo.locked_mode, db.object_name, db.object_type
FROM v$locked_object lo, dba_objects db
WHERE lo.object_id = db.object_id and oracle_username = 'KOTROCZO';













