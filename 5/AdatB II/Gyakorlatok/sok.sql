-- L1(A) - T1 tranzakcio zarolja A adatbazis elemet
-- U1(A) - T1 tranzakcio feloldja A adatbazis elemet

-- L1(A); L2(B); L3(C); L1(D); L2(A); L3(D); L4(B); U1(A); L2(C);

SET AUTOCOMMIT OFF;

DROP TABLE tranz;
CREATE TABLE tranz(a INTEGER);

SELECT * FROM tranz;

COMMIT;

INSERT INTO tranz VALUES (1);
UPDATE tranz SET a = a + 1;

SAVEPOINT ketto;
ROLLBACK ketto;

CREATE TABLE tr(kulcs VARCHAR2(10), ertek INTEGER);
INSERT INTO tr VALUES ('A', 2);
INSERT INTO tr VALUES ('B', 3);
INSERT INTO tr VALUES ('C', 1);

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
SELECT * FROM tr;

UPDATE tr SET ertek = ertek + 1 WHERE kulcs = 'A';

COMMIT;